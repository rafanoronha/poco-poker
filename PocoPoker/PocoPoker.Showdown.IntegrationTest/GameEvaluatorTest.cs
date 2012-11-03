using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PocoPoker.Showdown.IntegrationTest
{
    [TestClass]
    public class GameEvaluatorTest
    {
        [TestMethod]
        public void RoyalFlush()
        {
            // ARRANGE
            var game = new Game(
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.King().Hearths(),
                    CardBuilder.Queen().Hearths(),
                    CardBuilder.Jack().Hearths(),
                    CardBuilder.Ten().Hearths());

            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.ROYAL_FLUSH, game.Category);
        }

        [TestMethod]
        public void StraightFlush()
        {
            // ARRANGE
            var game = new Game(
                    CardBuilder.Eight().Hearths(),
                    CardBuilder.Seven().Hearths(),
                    CardBuilder.Nine().Hearths(),
                    CardBuilder.Ten().Hearths(),
                    CardBuilder.Jack().Hearths());

            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.STRAIGHT_FLUSH, game.Category);
        }

        [TestMethod]
        public void FourOfAKind()
        {
            // ARRANGE
            var game = new Game(
                    CardBuilder.Two().Hearths(),
                    CardBuilder.Two().Clubs(),
                    CardBuilder.Seven().Hearths(),
                    CardBuilder.Two().Diamonds(),
                    CardBuilder.Two().Spades());

            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.FOUR_OF_A_KIND, game.Category);
        }

        [TestMethod]
        public void FullHouse()
        {
            // ARRANGE
            var game = new Game(
                CardBuilder.Queen().Hearths(),
                CardBuilder.Queen().Diamonds(),
                CardBuilder.Four().Clubs(),
                CardBuilder.Queen().Spades(),
                CardBuilder.Four().Hearths());

            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.FULL_HOUSE, game.Category);
        }

        [TestMethod]
        public void Flush()
        {
            // ARRANGE
            var game = new Game(
                    CardBuilder.Five().Spades(),
                    CardBuilder.Six().Spades(),
                    CardBuilder.Ace().Spades(),
                    CardBuilder.Ten().Spades(),
                    CardBuilder.Queen().Spades());
            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.FLUSH, game.Category);
        }

        [TestMethod]
        public void Straight()
        {
            // ARRANGE
            var cards = StraightFlushGameBuilder.Diamonds()
               .From(Rank.TWO).To(Rank.SIX).Cards.ToArray();

            var game = new Game(
                cards[0],
                cards[1],
                cards[2],
                cards[3],
                new Card(cards[4].Rank, Suit.CLUBS));
            // ACT
            new GameEvaluator().Evaluate(game);

            // ASSERT
            Assert.AreEqual(GameCategory.STRAIGHT, game.Category);
        }
    }
}
