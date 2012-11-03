using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPoker.Showdown
{
    public class Flush : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(Game game)
        {
            IGameEvaluationResult result;
            if (game.SameSuit())
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
            get { return GameCategory.FLUSH; }
        }

    }
}
