using DominoCircleApp.Domain.Interfaces;
using DominoCircleApp.Domain.Models;

namespace DominoCircleApp
{
    public class DominoAppService
    {
        private readonly IDominoChainService _dominoChainService;
        private readonly ConsoleUIService _consoleUIService;

        public DominoAppService(IDominoChainService dominoChainService, ConsoleUIService consoleUIService)
        {
            _dominoChainService = dominoChainService;
            _consoleUIService = consoleUIService;
        }

        public void Run()
        {
            var dominoes = CollectDominoes();

            Console.Clear();

            _consoleUIService.PrintHeader("Welcome to the Domino Circle App!");

            _consoleUIService.PrintMessage("Processing dominoes.....");

            _consoleUIService.DisplayDominoSet(dominoes);

            if (!_dominoChainService.CanFormCircle(dominoes))
            {
                _consoleUIService.PrintMessage("The given set of dominoes cannot form a circular chain.");
                return;
            }

            var circularChain = _dominoChainService.GetCircularChain(dominoes);

            if (circularChain == null)
            {
                _consoleUIService.PrintMessage("Could not create a valid circular chain from the given dominoes.");
            }
            else
            {
                _consoleUIService.PrintMessage($"A valid circular chain was found: {string.Join(" -> ", circularChain)}");
            }

            _consoleUIService.PrintLine();
        }

        public List<Domino> CollectDominoes()
        {
            var dominoes = new List<Domino>();

            while (true)
            {
                Console.Clear();
                _consoleUIService.PrintHeader("Welcome to the Domino Circle App!");

                _consoleUIService.DisplayDominoSet(dominoes);

                Console.Write("**\tEnter a domino pair (format: a,b): ");
                var input = Console.ReadLine();

                var parsedDomino = ParseDominoInput(input);
                if (parsedDomino != null)
                {
                    dominoes.Add(parsedDomino);
                    _consoleUIService.PrintMessage($"Domino {parsedDomino.ToString()} added.");
                }
                else
                {
                    _consoleUIService.PrintMessage("Invalid input. Please enter a valid domino pair (e.g., 3,4).");
                    Thread.Sleep(3000);
                    continue;
                }

                if (!_consoleUIService.AskYesOrNo("Do you want to add another domino?"))
                {
                    break;
                }
            }

            return dominoes;
        }

        private Domino? ParseDominoInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            var parts = input.Split(',');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int first) ||
                !int.TryParse(parts[1], out int second))
            {
                return null;
            }

            try
            {
                return new Domino(first, second);
            }
            catch (ArgumentException ex)
            {
                _consoleUIService.PrintMessage($"{ex.Message}");
                return null;
            }
        }
    }
}