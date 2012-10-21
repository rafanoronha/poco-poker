using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocoPoker.Showdown;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class StraightFlushTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void DiamondsFiveToNine()
            {
                // ARRANGE
                var game = StraightFlushGameBuilder.Diamonds()
                    .From(Rank.FIVE).To(Rank.NINE);

                // ACT
                var actual = new StraightFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void SpadesTwoToSix()
            {
                // ARRANGE
                var game = StraightFlushGameBuilder.Spades()
                    .From(Rank.TWO).To(Rank.SIX);

                // ACT
                var actual = new StraightFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

        }

        [TestClass]
        public class DoesNotFit
        {
            [TestMethod]
            public void WrapAround()
            {
                // ARRANGE
                var game = new Game(
                    CardBuilder.King().Hearths(),
                    CardBuilder.Ace().Hearths(),
                    CardBuilder.Two().Hearths(),
                    CardBuilder.Three().Hearths(),
                    CardBuilder.Four().Hearths());

                // ACT
                var actual = new StraightFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsFalse(actual);
            }
        }

    }
}