using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocoPoker.Showdown;
using System.Collections;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class FourOfAKindTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void FourAcesAndNine()
            {
                // ARRANGE
                var game = FourAcesAndANine();

                // ACT
                var result = new FourOfAKind().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                CollectionAssert.AreEquivalent(game.Cards.Where(c => Rank.ACE == c.Rank).ToList(), result.UsedCards.ToList());
            }
            
            [TestMethod]
            public void FourSevensAndTwo()
            {
                // ARRANGE
                var fourAces = FourAcesAndANine().Cards.Where(
                    c =>
                        Rank.ACE == c.Rank);

                var fourSevens = fourAces.Select(
                    c =>
                        new Card(Rank.SEVEN, c.Suit)).ToArray();

                var game = new Game(
                    fourSevens[0],
                    fourSevens[1],
                    fourSevens[2],
                    fourSevens[3],
                    CardBuilder.Two().Clubs());

                // ACT
                var result = new FourOfAKind().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                CollectionAssert.AreEquivalent(fourSevens.ToList(), result.UsedCards.ToList());
            }

            [TestMethod]
            public void FourEightsAndNine()
            {
                // ARRANGE
                var fourAces = FourAcesAndANine().Cards.Where(
                    c =>
                        Rank.ACE == c.Rank);

                var fourEights = fourAces.Select(
                    c =>
                        new Card(Rank.EIGHT, c.Suit)).ToArray();

                var game = new Game(
                    fourEights[0],
                    fourEights[1],
                    fourEights[2],
                    fourEights[3],
                    CardBuilder.Nine().Spades());

                // ACT
                var result = new FourOfAKind().Evaluate(game);

                // ASSERT
                Assert.IsTrue(result.Success());
                CollectionAssert.AreEquivalent(fourEights.ToList(), result.UsedCards.ToList());
            }

            private Game FourAcesAndANine()
            {
                return new Game(
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.Ace().Diamonds(),
                    CardBuilder.Ace().Clubs(),
                    CardBuilder.Ace().Spades(),
                    CardBuilder.Nine().Hearths());
            }

        }

        [TestClass]
        public class DoesNotFit
        {
        }

    }
}