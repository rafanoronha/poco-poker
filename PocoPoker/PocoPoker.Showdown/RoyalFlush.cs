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

            if (game.SameSuit())
            {
                var rankChecks = new Func<Card, bool>[] {
                    Fun.IsAce,
                    Fun.IsKing,
                    Fun.IsQueen,
                    Fun.IsJack,
                    Fun.IsTen
                };

                fits = Fun.PassAny<Card>()(game.Cards, rankChecks);
            }

            return fits;
        }

        public GameCategory Category
        {
            get { return GameCategory.ROYAL_FLUSH; }
        }
    }
}
