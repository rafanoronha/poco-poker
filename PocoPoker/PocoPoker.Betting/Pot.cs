using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public class Pot
    {
        List<Player> betters;

        public Pot()
        {
            betters = new List<Player>();
        }

        public void Contend(Player player)
        {
            betters.Add(player);
        }

        public void Leave(Player player)
        {
            betters.Remove(player);
            if (1 == betters.Count())
            {
                Winner = betters.Single();
            }
        }

        public bool HasWinner()
        {
            return Winner != null;
        }

        public IEnumerable<Player> Betters { get { return betters; } }
        public Player Winner { get; private set; }

    }
}
