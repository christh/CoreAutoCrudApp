using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.EventLog;

namespace CoreAutoCrudApp.React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CoreAutoCrudApp.Data.Repositories.SeedData.Initialize();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                
                }
                )
            .ConfigureServices((hostContext, services) =>
            {
                services.AddLogging(configure =>
                configure.AddEventLog((options) =>
                {
                    options.LogName = "Core Auto Crud App";
                    options.SourceName = "React App";
                    options.Filter = (x, y) => y >= LogLevel.Information;
                })
                .AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information)
                .AddFilter<ConsoleLoggerProvider>(level => level >= LogLevel.Debug));
            });
    }
}
