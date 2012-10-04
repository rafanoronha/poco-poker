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
                var game = HearthsRoyalFlush();

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
                var royalFlush = HearthsRoyalFlush();
                
                var game = GameBuilder.Game(royalFlush).SwapLastCardWith(
                    CardBuilder.Nine().Hearths());

                // ACT
                var actual = new RoyalFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsFalse(actual);                
            }
        }

        private static Game HearthsRoyalFlush()
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