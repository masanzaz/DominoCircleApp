using DominoCircleApp;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = DependencyInjectionConfig.ConfigureServices();
var appService = serviceProvider.GetRequiredService<DominoAppService>();
var consoleUIService = serviceProvider.GetRequiredService<ConsoleUIService>();

while (true)
{
    appService.Run();

    consoleUIService.PrintMessage("Game Over!");

    if (!consoleUIService.AskYesOrNo("Do you want to play again?"))
    {
        break;
    }
}

consoleUIService.PrintLine();

Console.WriteLine("***** Thank you for using the Domino Circle App!");