using Demo.Desktop;
using Microsoft.Extensions.DependencyInjection;

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
