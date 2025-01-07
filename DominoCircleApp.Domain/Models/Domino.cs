namespace DominoCircleApp.Domain.Models
{
    public class Domino
    {
        public static int MinValue { get; private set; } = 1;
        public static int MaxValue { get; private set; } = 2;

        public int First { get; }
        public int Second { get; }

        public Domino(int first, int second)
        {
            if (first < MinValue || second < MinValue || first > MaxValue || second > MaxValue)
            {
                throw new ArgumentException($"Domino values must be between {MinValue} and {MaxValue} (inclusive).");
            }

            First = first;
            Second = second;
        }

        public static void Configure(int maxValue)
        {
            if (maxValue < MinValue)
            {
                throw new ArgumentException("Invalid range.");
            }

            MaxValue = maxValue;
        }

        public Domino Flip()
        {
            return new Domino(Second, First);
        }

        public override string ToString()
        {
            return $"[{First}|{Second}]";
        }
    }
}
