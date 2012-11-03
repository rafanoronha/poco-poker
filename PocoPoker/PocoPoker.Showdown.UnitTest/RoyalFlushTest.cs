using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class RoyalFlushTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void Hearths()
            {
                // ARRANGE
                var game = Helper.HearthsRoyalFlush();

                // ACT
                var result = new RoyalFlush().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                Assert.AreSame(game.Cards, result.UsedCards);
            }

            [TestMethod]
            public void Spades()
            {
                // ARRANGE
                var hearthsRoyalFlushCards = Helper.HearthsRoyalFlush().Cards;
                var cards = hearthsRoyalFlushCards.Select(
                    c =>
                        new Card(c.Rank, Suit.SPADES)).ToArray();

                var game = new Game(cards[0], cards[1], cards[2], cards[3], cards[4]);

                // ACT
                var result = new RoyalFlush().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                Assert.AreSame(game.Cards, result.UsedCards);
            }

            [TestMethod]
            public void Clubs()
            {
                // ARRANGE
                var hearthsRoyalFlushCards = Helper.HearthsRoyalFlush().Cards;
                var cards = hearthsRoyalFlushCards.Select(
                    c =>
                        new Card(c.Rank, Suit.CLUBS)).ToArray();

                var game = new Game(cards[0], cards[1], cards[2], cards[3], cards[4]);

                // ACT
                var result = new RoyalFlush().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                Assert.AreSame(game.Cards, result.UsedCards);
            }

            [TestMethod]
            public void Diamonds()
            {
                // ARRANGE
                var hearthsRoyalFlushCards = Helper.HearthsRoyalFlush().Cards;
                var cards = hearthsRoyalFlushCards.Select(
                    c =>
                        new Card(c.Rank, Suit.DIAMONDS)).ToArray();

                var game = new Game(cards[0], cards[1], cards[2], cards[3], cards[4]);

                // ACT
                var result = new RoyalFlush().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                Assert.AreSame(game.Cards, result.UsedCards);
            }

        }

        [TestClass]
        public class DoesNotFit
        {
            [TestMethod]
            public void NineInsteadOfTen()
            {
                var royalFlush = Helper.HearthsRoyalFlush();
                
                var game = GameBuilder.Game(royalFlush).SwapLastCardWith(
                    CardBuilder.Nine().Hearths());

                // ACT
                var result = new RoyalFlush().Evaluate(game);

                // ASSERT
                Assert.IsFalse(result.Success());
            }
        }

        class Helper
        {
            public static Game HearthsRoyalFlush()
            {
                return new Game(
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.King().Hearths(),
                    CardBuilder.Queen().Hearths(),
                    CardBuilder.Jack().Hearths(),
                    CardBuilder.Ten().Hearths());
            }
        }

    }
}