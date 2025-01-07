namespace DominoCircleApp.Domain.Models
{
    public class DominoConfig
    {
        public int MinValue { get; set; } = 1;

        public int MaxValue { get; set; } = 6;

        public void Validate()
        {
            if (MinValue < 0 || MaxValue <= MinValue)
            {
                throw new ArgumentException($"Domino values must be between {MinValue} and {MaxValue} (inclusive).");
            }
        }
    }
}