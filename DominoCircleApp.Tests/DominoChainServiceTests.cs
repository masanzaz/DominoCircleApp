using DominoCircleApp.Application.Services;
using DominoCircleApp.Domain.Models;
using FluentAssertions;
using Xunit;

namespace DominoCircleApp.Tests
{
    public class DominoChainServiceTests
    {
        private readonly DominoChainService _service = new();

        [Theory]
        [MemberData(nameof(DominoTestData.ValidDominoChains), MemberType = typeof(DominoTestData))]
        public void CanFormCircle_ShouldReturnTrue_WhenValidChain(List<Domino> dominoes)
        {
            var result = _service.CanFormCircle(dominoes);

            result.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(DominoTestData.InvalidDominoChains), MemberType = typeof(DominoTestData))]
        public void CanFormCircle_ShouldReturnFalse_WhenInValidChain(List<Domino> dominoes)
        {
            var result = _service.CanFormCircle(dominoes);

            result.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(DominoTestData.ValidDominoChains), MemberType = typeof(DominoTestData))]
        public void GetCircularChain_ShouldReturnValidChain(List<Domino> dominoes)
        {
            var result = _service.GetCircularChain(dominoes);

            result.Should().NotBeNull();
            result.Should().HaveCount(dominoes.Count);

            var firstDomino = result!.First();
            var lastDomino = result.Last();
            firstDomino.First.Should().Be(lastDomino.Second);
        }

        [Theory]
        [MemberData(nameof(DominoTestData.InvalidDominoChains), MemberType = typeof(DominoTestData))]
        public void GetCircularChain_WithInvalidDominoChain_ReturnsNull(List<Domino> dominoes)
        {
            var result = _service.GetCircularChain(dominoes);

            result.Should().BeNull();
        }
    }
}