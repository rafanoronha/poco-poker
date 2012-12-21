using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public abstract class Action
    {
        public bool IsFold()
        {
            return GetType().IsAssignableFrom(typeof(Fold));
        }

        public Position PlayerPosition { get; private set; }

        public static Action Call(Position playerPosition)
        {
            return NewAction<Call>(playerPosition);
        }

        public static Action Fold(Position playerPosition)
        {
            return NewAction<Fold>(playerPosition);
        }

        static Action NewAction<A>(Position playerPosition) where A : Action
        {
            var action = Activator.CreateInstance<A>();
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
