using Demo.DAL.Implementations;
using Demo.DAL.Interfaces;
using DemoEF.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DemoEF.DAL.Extensions
{
    public static class DependencyRegistration
    {
        public static void AddDAL(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(connectionString));
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IStudentReadRepository, StudentRepository>();
            services.AddScoped<IStudentWriteRepository, StudentRepository>();
        }
    }
}
