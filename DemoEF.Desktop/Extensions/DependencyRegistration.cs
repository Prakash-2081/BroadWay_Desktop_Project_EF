using Demo.Desktop;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEF.Desktop.Extensions
{
    public static class DependencyRegistration
    {
        public static void ADDPresentationLayer(this IServiceCollection services)
        {
            services.AddScoped<LoginForm>();
            services.AddScoped<StudentForm>();
        }
    }
}
