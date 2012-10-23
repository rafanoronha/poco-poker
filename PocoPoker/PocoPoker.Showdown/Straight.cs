using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class Straight : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            return Fun.IsStraight(game.Cards);
        }

        public GameCategory Category
        {
            get { return GameCategory.FOUR_OF_A_KIND; }
        }
    }
}
