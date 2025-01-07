using DominoCircleApp.Application.Services;
using DominoCircleApp.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DominoCircleApp
{
    public static class DependencyInjectionConfig
    {
        public static ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IDominoChainService, DominoChainService>()
                .AddSingleton<DominoAppService>()
                .AddSingleton<ConsoleUIService>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}