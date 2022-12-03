using Msk.Api;

var builder = WebApplication.CreateBuilder(args)
    .UseStartup<Startup>();
//var configuration = builder.Configuration;

//// AUTHETICATION GOOGLE
//builder.Services.AddAuthentication().AddGoogle(googleOptions =>
//{
//    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
//    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
//});

//// AUTHETICATION FACEBOOOK
//builder.Services.AddAuthentication().AddFacebook(facebookOptions =>
//{
//    facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
//    facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
//});
