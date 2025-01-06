using DominoCircleApp.Domain.Models;

namespace DominoCircleApp.Domain.Interfaces
{
    public interface IDominoChainService
    {
        bool CanFormCircle(List<Domino> dominoes);

        List<Domino>? GetCircularChain(List<Domino> dominoes);

    }
}