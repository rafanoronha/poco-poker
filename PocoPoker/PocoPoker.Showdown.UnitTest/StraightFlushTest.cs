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
            public void Scenario1()
            {
                // ARRANGE
                var game = StraightFlushGameBuilder.Diamonds()
                    .From(Rank.FIVE).To(Rank.NINE);

                // ACT
                var actual = new StraightFlush().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

        }

        [TestClass]
        public class DoesNotFit
        {
        }

    }
}