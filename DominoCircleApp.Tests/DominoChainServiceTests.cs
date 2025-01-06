using DominoCircleApp.Application.Services;
using DominoCircleApp.Domain.Models;
using FluentAssertions;
using Xunit;

namespace DominoCircleApp.Tests
{
    public class DominoChainServiceTests
    {
        [Fact]
        public void CanFormCircle_ShouldReturnTrue_WhenValidChain()
        {
            var service = new DominoChainService();
            var dominoes = new List<Domino>
            {
                new(1, 2),
                new(2, 3),
                new(3, 1)
            };

            var result = service.CanFormCircle(dominoes);

            result.Should().BeTrue();
        }

        [Fact]
        public void CanFormCircle_ShouldReturnFalse_WhenInValidChain()
        {
            var service = new DominoChainService();
            var dominoes = new List<Domino>
            {
                new(1, 2),
                new(4, 1),
                new(2, 3)
            };

            var result = service.CanFormCircle(dominoes);

            result.Should().BeFalse();
        }

        [Fact]
        public void GetCircularChain_ShouldReturnValidChain()
        {
            var service = new DominoChainService();
            var dominoes = new List<Domino>
            {
                new(2, 1),
                new(2, 3),
                new(1, 3)
            };

            var result = service.GetCircularChain(dominoes);

            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            var firstDomino = result!.First();
            var lastDomino = result.Last();
            firstDomino.First.Should().Be(lastDomino.Second);
        }

        [Fact]
        public void GetCircularChain_WithInvalidDominoChain_ReturnsNull()
        {
            var service = new DominoChainService();
            var dominoes = new List<Domino>
            {
                new(1, 2),
                new(4, 1),
                new(2, 3)
            };

            var result = service.GetCircularChain(dominoes);

            result.Should().BeNull();
        }
    }
}