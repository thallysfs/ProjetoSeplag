using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoSeplag.Infra.Data.Context;
using ProjetoSeplag.Infra.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSeplag.WorkServices
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    services.AddDbContext<AplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
                    NativeInjectorBootStrapper.RegisterServices(services);
                    services.AddHostedService<Worker>();
                    
                });
    }
}
