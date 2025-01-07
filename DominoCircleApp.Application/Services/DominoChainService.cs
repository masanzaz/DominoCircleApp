using DominoCircleApp.Domain.Interfaces;
using DominoCircleApp.Domain.Models;

namespace DominoCircleApp.Application.Services
{
    public class DominoChainService : IDominoChainService
    {
        public bool CanFormCircle(List<Domino> dominoes)
        {
            if (dominoes == null || dominoes.Count < 2)
                return false;

            var endCount = new Dictionary<int, int>();

            foreach (var domino in dominoes)
            {
                if (!endCount.ContainsKey(domino.First))
                    endCount[domino.First] = 0;
                if (!endCount.ContainsKey(domino.Second))
                    endCount[domino.Second] = 0;

                endCount[domino.First]++;
                endCount[domino.Second]++;
            }

            return endCount.Values.All(count => count % 2 == 0);
        }

        public List<Domino>? GetCircularChain(List<Domino> dominoes)
        {
            if (dominoes == null || dominoes.Count < 2)
                return null;

            if (!CanFormCircle(dominoes))
                return null;

            var result = new List<Domino> { dominoes[0] };
            var remainingDominoes = new List<Domino>(dominoes);
            remainingDominoes.RemoveAt(0);

            while (remainingDominoes.Count > 0)
            {
                bool matchFound = false;

                for (int i = 0; i < remainingDominoes.Count; i++)
                {
                    var currentDomino = remainingDominoes[i];
                    var lastDomino = result[result.Count - 1];

                    if (lastDomino.Second == currentDomino.First)
                    {
                        result.Add(currentDomino);
                        remainingDominoes.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                    else if (lastDomino.Second == currentDomino.Second)
                    {
                        result.Add(currentDomino.Flip());
                        remainingDominoes.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                    return null;
            }

            if (result[result.Count - 1].Second == result[0].First)
                return result;

            return null;
        }

    }
}
