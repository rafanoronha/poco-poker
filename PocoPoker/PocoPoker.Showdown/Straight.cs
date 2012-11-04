using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class Straight : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(IGame game)
        {
            IGameEvaluationResult result;

            if (Fun.IsStraight(game.Cards))
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
            get { return GameCategory.STRAIGHT; }
        }
    }
}
