using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class StraightFlush : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            return Fun.IsStraight(game.Cards) && game.SameSuit();
        }

        public GameCategory Category
        {
            get { return GameCategory.STRAIGHT_FLUSH; }
        }
    }
}
