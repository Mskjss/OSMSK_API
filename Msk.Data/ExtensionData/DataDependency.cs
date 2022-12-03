using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Msk.Data.Context;
using Msk.Data.Contracts.Users;
using Msk.Data.Repositorys.Users;
using Msk.Service.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Data.ExtensionData
{
    public static class DataDependency
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            


            services.AddScoped<IUsersRepository,UsersRepository> ();
            services.AddScoped<ITokenService, TokenService>();
         
        }
    }
}
