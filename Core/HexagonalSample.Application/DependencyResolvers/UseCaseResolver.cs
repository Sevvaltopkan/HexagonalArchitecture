using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Application.DependencyResolvers
{
    public static class UseCaseResolver
    {
        public static void AddUseCaseService(this IServiceCollection services)
        {
          
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        }
    }
}

