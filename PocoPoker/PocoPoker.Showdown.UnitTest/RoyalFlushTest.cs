using System;
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
                var game = RoyalFlushGameBuilder.HearthsRoyalFlush();

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void Spades()
            {
                // ARRANGE
                var game = RoyalFlushGameBuilder.SpadesRoyalFlush();

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void Clubs()
            {
                // ARRANGE
                var game = RoyalFlushGameBuilder.ClubsRoyalFlush();

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void Diamonds()
            {
                // ARRANGE
                var game = RoyalFlushGameBuilder.DiamondsRoyalFlush();

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

        }

        [TestClass]
        public class DoesNotFit
        {
            [TestMethod]
            public void NineInsteadOfTen()
            {
                var royalFlush = RoyalFlushGameBuilder.HearthsRoyalFlush();
                
                var game = GameBuilder.Game(royalFlush).SwapLastCardWith(
                    CardBuilder.Nine().Hearths());

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsFalse(actual);                
            }
        }

    }
}