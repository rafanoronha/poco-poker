using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class StraightFlush : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(Game game)
        {
            IGameEvaluationResult result;
            if (Fun.IsStraight(game.Cards) && game.SameSuit())
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
            get { return GameCategory.STRAIGHT_FLUSH; }
        }
    }
}
