using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class Straight : IGameEvaluation
    {
        public virtual bool FitsMyCategory(Game game)
        {
            return Fun.IsStraight(game.Cards);
        }

        public virtual GameCategory Category
        {
            get { return GameCategory.STRAIGHT; }
        }
    }
}
