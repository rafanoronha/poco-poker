using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class FullHouse : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(Game game)
        {
            IGameEvaluationResult result;

            var cardsByRank =
                from c in game.Cards
                group c by c.Rank;

            // 5 cards for which there are
            // 2 ranks and 3 cards for one of those ranks
            var fullHouse = 2 == cardsByRank.Count() &&
                cardsByRank.Any(g =>
                    3 == g.Count());

            if (fullHouse)
            {
                result = Success(Category, game.Cards);
            }
            else
            {
                result = Failed();
            }
            return result;
        }

        GameCategory Category
        {
            get { return GameCategory.FULL_HOUSE; }
        }
    }
}
