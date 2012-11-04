using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class RoyalFlush : GameEvaluationBase
    {
        public override IGameEvaluationResult Evaluate(IGame game)
        {
            IGameEvaluationResult result;

            var rankChecks = new Func<Card, bool>[] {
                Fun.IsAce,
                Fun.IsKing,
                Fun.IsQueen,
                Fun.IsJack,
                Fun.IsTen
            };

            if (game.SameSuit() && Fun.PassAny<Card>()(game.Cards, rankChecks))
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
            get { return GameCategory.ROYAL_FLUSH; }
        }
    }
}
