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

            if (game.SameSuit())
            {
                var maxRank = game.Cards.Max(c =>
                    (int)c.Rank);

                var rankChecks = new Func<Card, bool>[] {
                    (c) => Fun.RankCheck(c, (Rank)maxRank),
                    (c) => Fun.RankCheck(c, (Rank)maxRank-1),
                    (c) => Fun.RankCheck(c, (Rank)maxRank-2),
                    (c) => Fun.RankCheck(c, (Rank)maxRank-3),
                    (c) => Fun.RankCheck(c, (Rank)maxRank-4),
                };

                fits = Fun.PassAny<Card>()(game.Cards, rankChecks);
            }

            return fits;
        }

        public GameCategory Category
        {
            get { return GameCategory.STRAIGHT_FLUSH; }
        }
    }
}
