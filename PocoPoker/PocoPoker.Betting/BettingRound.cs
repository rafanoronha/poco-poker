using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public class BettingRound
    {
        public BettingRound(Positions positions)
        {
            Positions = positions;
        }

        public void PlaceAction(Action action)
        {
        }

        public Turn CurrentTurn { get; private set; }
        public Positions Positions { get; private set; }
        public Pot Pot { get; private set; }
    }

    public class Positions
    {
        public Positions(
            Position dealer,
            Position sb,
            Position bb,
            Position utg)
        {
            Dealer = dealer;
            SmallBlind = sb;
            BigBlind = bb;
            UnderTheGun = utg;
        }

        public Position Dealer { get; private set; }
        public Position SmallBlind { get; private set; }
        public Position BigBlind { get; private set; }
        public Position UnderTheGun { get; private set; }
        public Position Cutoff { get; private set; }
        public IEnumerable<Position> MiddlePositions { get; private set; }
    }

    public class Position
    {
        public Position(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        public Position NextPosition { get; private set; }
    }

}
