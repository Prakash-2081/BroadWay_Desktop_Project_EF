using Demo.DAL.Constants;
using DemoEF.BAL.Extensions;
using DemoEF.DAL.Extensions;
using DemoEF.Desktop.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            ServiceProvider = host.Services;


            ApplicationConfiguration.Initialize();
            Application.Run(ServiceProvider.GetService<LoginForm>());
        }
        public static IServiceProvider ServiceProvider { get; set; }
        public static IHostBuilder CreateHostBuilder(string[] args) =>

            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    string connectionString = hostContext.Configuration.GetConnectionString(ApplicationConstant.DefaultConnection);

                    services.AddDAL(connectionString);
                    services.ADDBAL();
                    services.ADDPresentationLayer();
                });
    }
}