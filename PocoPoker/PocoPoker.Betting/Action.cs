using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public abstract class Action
    {
        public Player Player { get; private set; }
    }

    public class Check : Action
    {
    }

    public class Bet : Action
    {
    }

    public class Fold : Action
    {
    }

    public class Call : Action
    {
    }

    public class Raise : Action
    {
    }
}
