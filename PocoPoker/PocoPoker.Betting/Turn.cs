using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public class Turn
    {
        public Turn(Position position)
        {
            Position = position;
        }

        public Position Position { get; private set; }
    }
}
