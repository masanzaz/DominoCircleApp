using DominoCircleApp.Domain.Models;

namespace DominoCircleApp.Tests
{
    public static class DominoTestData
    {
        public static IEnumerable<object[]> ValidDominoChains =>
            new List<object[]>
            {
                new object[] { new List<Domino> { new(1, 2), new(2, 3), new(3, 1) } },
                new object[] { new List<Domino> { new(2, 1), new(1, 3), new(3, 2) } },
                new object[] { new List<Domino> { new(5, 6), new(6, 7), new(7, 5) } }
            };

        public static IEnumerable<object[]> InvalidDominoChains =>
            new List<object[]>
            {
                new object[] { new List<Domino> { new(1, 2), new(4, 1), new(2, 3) } },
                new object[] { new List<Domino> { new(1, 2), new(2, 3), new(3, 4) } },
                new object[] { new List<Domino> { new(5, 6), new(7, 8), new(1, 3) } }
            };
    }
}
