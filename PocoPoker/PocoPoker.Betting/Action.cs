using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public abstract class Action
    {
        public Position PlayerPosition { get; private set; }

        public static Action Call(Position playerPosition)
        {
            var action = new Call();
            action.PlayerPosition = playerPosition;
            return action;
        }
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
