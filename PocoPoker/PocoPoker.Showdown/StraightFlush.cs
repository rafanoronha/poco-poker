using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class StraightFlush : Straight
    {
        public override bool FitsMyCategory(Game game)
        {
            var straight = base.FitsMyCategory(game);
            return straight && game.SameSuit();
        }

        public override GameCategory Category
        {
            get { return GameCategory.STRAIGHT_FLUSH; }
        }
    }
}
