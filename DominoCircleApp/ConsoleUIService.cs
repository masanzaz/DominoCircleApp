
using DominoCircleApp.Domain.Models;

namespace DominoCircleApp
{
    public class ConsoleUIService
    {
        public bool AskYesOrNo(string message)
        {
            string? input;

            PrintLine();
            while (true)
            {
                PrintLine();
                Console.Write($"**\t{message} [Y/N]: ");
                input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "Y")
                {
                    return true;
                }
                else if (input == "N")
                {
                    return false;
                }

                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop - 1);
            }
        }

        public void PrintHeader(string title)
        {
            Console.WriteLine($"***************\t\t {title} \t\t******************");
            PrintLine();
        }

        public void PrintLine()
        {
            Console.WriteLine("**\t\t\t\t\t\t\t\t\t\t\t**");
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine($"**\t{message}");
            PrintLine();
        }

        public void DisplayDominoSet(List<Domino> dominoes)
        {
            if (dominoes.Count > 0)
            {
                Console.Write("**\tCurrent set of dominoes:");
                Console.WriteLine($"{FormatDominoes(dominoes)}");
            }
            PrintLine();
        }

        private string FormatDominoes(List<Domino> dominoes)
        {
            return string.Join(", ", dominoes.Select(d => $"[{d.First}|{d.Second}]"));
        }
    }
}