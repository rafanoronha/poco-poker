using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class FourOfAKind : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            return (from c in game.Cards
             group c by c.Rank).Any(
                g =>
                    4 == g.Count());
        }

        public GameCategory Category
        {
            get { return GameCategory.FOUR_OF_A_KIND; }
        }
    }
}
