using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPoker.Showdown
{
    public class Flush : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            return game.SameSuit();
        }

        public GameCategory Category
        {
            get { return GameCategory.FLUSH; }
        }
    }
}
