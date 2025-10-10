using Demo.BAL.Implementations;
using Demo.BAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF.BAL.Extensions
{
    public static class DependencyRegistration
    {
        public static void ADDBAL(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStudentReadServices, StudentServices>();
            services.AddScoped<IStudentWriteServices, StudentServices>();
        }
    }
}
