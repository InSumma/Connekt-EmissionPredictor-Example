using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using DemoApiCall.Interfaces;
using DemoApiCall.Services;
namespace DemoApiCall
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            var serviceProvider = new ServiceCollection()
           .AddScoped(typeof(IApiCallService), typeof(ApiCallService))
           .AddScoped(typeof(IRun<IReturnModel>), typeof(Run<IReturnModel>))
           .AddSingleton(typeof(IConfiguration), Configuration)
           .BuildServiceProvider();

           var run = serviceProvider.GetService<IRun<IReturnModel>>();
           run.Start();

        }

    }
}
