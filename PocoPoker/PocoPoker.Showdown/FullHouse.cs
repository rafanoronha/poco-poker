using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class FullHouse : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            var cardsByRank =
                from c in game.Cards
                group c by c.Rank;

            // 5 cards for which there are
            // 2 ranks and 3 cards for one of those ranks
            return 2 == cardsByRank.Count() &&
                cardsByRank.Any(g =>
                    3 == g.Count());

        }

        public GameCategory Category
        {
            get { return GameCategory.FULL_HOUSE; }
        }
    }
}
