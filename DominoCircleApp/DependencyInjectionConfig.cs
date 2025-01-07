using DominoCircleApp.Application.Services;
using DominoCircleApp.Domain.Interfaces;
using DominoCircleApp.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DominoCircleApp
{
    public static class DependencyInjectionConfig
    {
        public static ServiceProvider ConfigureServices()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var dominoConfig = config.GetSection("DominoConfig").Get<DominoConfig>() ?? new DominoConfig();
            dominoConfig.Validate();

            Domino.Configure(dominoConfig.MaxValue);

            var serviceProvider = new ServiceCollection()
                .AddSingleton(dominoConfig)
                .AddSingleton<IDominoChainService, DominoChainService>()
                .AddSingleton<DominoAppService>()
                .AddSingleton<ConsoleUIService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}