using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public interface IGameEvaluation
    {
        bool FitsMyCategory(Game game);
        GameCategory Category { get; }
    }
}
