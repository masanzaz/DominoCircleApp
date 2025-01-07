namespace DominoCircleApp.Domain.Models
{
    public class Domino(int first, int second)
    {
        public int First { get; } = first;
        public int Second { get; } = second;

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
