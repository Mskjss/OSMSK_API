using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Msk.Data.Context;
using Msk.Data.ExtensionData;
using Msk.Service.ExtensionServices;
using Msk.Service.Token;
using System.Reflection;
using System.Text;

namespace Msk.Api
{
    public class Startup: IStartup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<PostgreContext>(opt => opt.UseNpgsql("name=ConnectionStrings:DataBase"));
            services.AddScoped<PostgreContext>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lancheteria", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description =
                       "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                       "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                       "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddTransient<ITokenService, TokenService>();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();


            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            

        }

    }
    public interface IStartup 
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment environment);
    }
    public static class StartupExtensions 
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webAppBuilder) where TStartup : IStartup
        {
            var startup=Activator.CreateInstance(typeof(TStartup),webAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startups.cs Inválida");
            startup.ConfigureServices(webAppBuilder.Services);
            var app = webAppBuilder.Build();
            startup.Configure(app, app.Environment);
            app.Run();
            return webAppBuilder;
        }
    }
}
