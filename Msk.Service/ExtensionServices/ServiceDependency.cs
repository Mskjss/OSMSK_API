using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Msk.Service.Users.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msk.Service.ExtensionServices
{
    public static class ServiceDependency
    {
        public static void AddApplication(this IServiceCollection services)
        {
           
            services.AddMediatR(typeof(CreateUserHandler));
            services.AddMediatR(typeof(CreateUserValueHandler));





        }
    }
}
