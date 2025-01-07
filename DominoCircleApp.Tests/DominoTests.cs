using DominoCircleApp.Domain.Models;
using FluentAssertions;
using Xunit;

namespace DominoCircleApp.Tests
{
    public class DominoTests
    {
        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        [InlineData(5, 6)]
        public void Constructor_ShouldCreateDomino_WhenValuesAreValid(int first, int second)
        {
            var domino = new Domino(first, second);

            domino.First.Should().Be(first);
            domino.Second.Should().Be(second);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(1, 7)]
        [InlineData(-1, -2)]
        public void Constructor_ShouldThrowException_WhenValuesAreOutOfRange(int first, int second)
        {
            Action act = () => new Domino(first, second);

            act.Should().Throw<ArgumentException>()
                .WithMessage($"*Domino values must be between {Domino.MinValue} and {Domino.MaxValue}*");
        }

        [Theory]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void Configure_ShouldUpdateMaxValue_WhenValidValueIsProvided(int maxValue)
        {
            Domino.Configure(maxValue);

            Domino.MaxValue.Should().Be(maxValue);
        }

        [Fact]
        public void Configure_ShouldThrowException_WhenMaxValueIsLessThanMinValue()
        {
            Action act = () => Domino.Configure(0);

            act.Should().Throw<ArgumentException>()
                .WithMessage("*Invalid range.*");
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(3, 4)]
        [InlineData(5, 6)]
        public void Flip_ShouldReturnDominoWithSwappedValues(int first, int second)
        {
            var domino = new Domino(first, second);

            var flipped = domino.Flip();

            flipped.First.Should().Be(second);
            flipped.Second.Should().Be(first);
        }
    }
}