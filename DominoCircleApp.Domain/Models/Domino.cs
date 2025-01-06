namespace DominoCircleApp.Domain.Models
{
    public class Domino
    {
        public int First { get; }
        public int Second { get; }

        public Domino(int first, int second)
        {
            First = first;
            Second = second;
        }

        public Domino Flip()
        {
            return new Domino(Second, First);
        }
    }
}
