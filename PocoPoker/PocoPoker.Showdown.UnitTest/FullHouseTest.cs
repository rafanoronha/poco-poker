using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocoPoker.Showdown;
using System.Collections;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class FullHouseTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void AcesFullOfKings()
            {
                // ARRANGE
                var game = AcesFullOfKingsGame();

                // ACT
                var actual = new FullHouse().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }
            
            [TestMethod]
            public void FivesFullOfQueens()
            {
                var acesFullOfKings = AcesFullOfKingsGame();

                // ARRANGE
                var aces = acesFullOfKings.Cards.Where(
                    c =>
                        Rank.ACE == c.Rank);

                var kings = acesFullOfKings.Cards.Where(
                    c =>
                        Rank.KING == c.Rank);

                var fives = aces.Select(
                    c =>
                        new Card(Rank.FIVE, c.Suit)).ToArray();

                var queens = kings.Select(
                    c =>
                        new Card(Rank.QUEEN, c.Suit)).ToArray();

                var game = new Game(
                    fives[0],
                    queens[0],
                    fives[1],
                    queens[1],
                    fives[2]);

                // ACT
                var actual = new FullHouse().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            private Game AcesFullOfKingsGame()
            {
                return new Game(
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.Ace().Diamonds(),
                    CardBuilder.King().Clubs(),
                    CardBuilder.Ace().Spades(),
                    CardBuilder.King().Hearths());
            }

        }

        [TestClass]
        public class DoesNotFit
        {
        }

    }
}