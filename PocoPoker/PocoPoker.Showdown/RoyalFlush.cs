using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class RoyalFlush : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            var fits = false;

            var firstCardSuit = game.Cards.First().Suit;

            var sameSuit = game.Cards.All(c => 
                firstCardSuit.Equals(c.Suit));

            if (sameSuit)
            {
                Func<Card, Rank, bool> rankCheck = (c, r) => r.Equals(c.Rank);

                var rankChecks = new Func<Card, bool>[] {
                    (c) => rankCheck(c, Rank.ACE),
                    (c) => rankCheck(c, Rank.KING),
                    (c) => rankCheck(c, Rank.QUEEN),
                    (c) => rankCheck(c, Rank.JACK),
                    (c) => rankCheck(c, Rank.TEN)
                };
 
                fits = game.Cards.All(card =>
                    rankChecks.Any(check =>
                        check(card)));
            }

            return fits;
        }

        public GameCategory Category
        {
            get { return GameCategory.ROYAL_FLUSH; }
        }
    }
}
