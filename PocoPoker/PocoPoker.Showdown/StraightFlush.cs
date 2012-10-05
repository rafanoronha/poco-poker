using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class StraightFlush : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            var fits = false;

            var firstCardSuit = game.Cards.First().Suit;

            var sameSuit = game.Cards.All(c =>
                firstCardSuit.Equals(c.Suit));

            if (sameSuit)
            {
                int maxRank = game.Cards.Max(c =>
                    (int)c.Rank);

                Func<Card, Rank, bool> rankCheck = (c, r) =>
                    r.Equals(c.Rank);

                var rankChecks = new Func<Card, bool>[] {
                    (c) => rankCheck(c, (Rank)maxRank),
                    (c) => rankCheck(c, (Rank)maxRank-1),
                    (c) => rankCheck(c, (Rank)maxRank-2),
                    (c) => rankCheck(c, (Rank)maxRank-3),
                    (c) => rankCheck(c, (Rank)maxRank-4),
                };

                fits = game.Cards.All(card =>
                    rankChecks.Any(check =>
                        check(card)));
            }

            return fits;
        }

        public GameCategory Category
        {
            get { return GameCategory.STRAIGHT_FLUSH; }
        }
    }
}
