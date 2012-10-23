﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PocoPoker.Showdown;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class StraightTest
    {
        [TestClass]
        public class DoesFit
        {
            [TestMethod]
            public void FiveToNine()
            {
                // ARRANGE
                var cards = StraightFlushGameBuilder.Diamonds()
                    .From(Rank.FIVE).To(Rank.NINE).Cards.ToArray();

                var game = new Game(
                    cards[0],
                    cards[1],
                    cards[2],
                    cards[3],
                    new Card(cards[4].Rank, Suit.CLUBS));

                // ACT
                var actual = new Straight().FitsMyCategory(game);

                // ASSERT
                Assert.IsTrue(actual);
            }

            [TestMethod]
            public void TwoToSix()
            {
                // ARRANGE
                var cards = StraightFlushGameBuilder.Spades()
                    .From(Rank.TWO).To(Rank.SIX).Cards.ToArray();

                var game = new Game(
                    cards[0],
                    cards[1],
                    cards[2],
                    cards[3],
                    new Card(cards[4].Rank, Suit.CLUBS));

                // ACT
                var actual = new Straight().FitsMyCategory(game);

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
                    CardBuilder.Two().Spades(),
                    CardBuilder.Three().Diamonds(),
                    CardBuilder.Four().Clubs());

                // ACT
                var actual = new Straight().FitsMyCategory(game);

                // ASSERT
                Assert.IsFalse(actual);
            }
        }

    }
}