using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class FourOfAKind : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(Game game)
        {
            IGameEvaluationResult result;

            var fourOfAKind = (from c in game.Cards
                    group c by c.Rank).Where(
                g =>
                    4 == g.Count());

            if (1 == fourOfAKind.Count())
            {
                result = Success(Category, fourOfAKind.First().ToList());
            }
            else
            {
                result = Failed();
            }
            return result;
        }

        GameCategory Category
        {
            get { return GameCategory.FOUR_OF_A_KIND; }
        }
    }
}
