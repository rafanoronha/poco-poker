using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Betting
{
    public class BettingRound
    {
        public BettingRound(Pot pot, Positions positions)
        {
            Pot = pot;

            Positions = positions;

            PotContest();

            CurrentTurn = new Turn(Positions.UnderTheGun);
        }

        public void PlaceAction(Action action)
        {
            if (Pot.HasWinner())
            {
                throw new EndOfRoundException();
            }
            if (CurrentTurn.Position != action.PlayerPosition)
            {
                throw new OutOfTurnException();
            }
            if (action.IsFold())
            {
                Pot.Leave(action.PlayerPosition.Player);
            }

            CurrentTurn = new Turn(CurrentTurn.Position.NextPosition);
        }

        public Turn CurrentTurn { get; private set; }
        public Positions Positions { get; private set; }
        public Pot Pot { get; private set; }

        void PotContest()
        {
            foreach (var p in Positions.Filled())
            {
                Pot.Contend(p.Player);
            }
        }
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

            Dealer.NextPosition = SmallBlind;
            SmallBlind.NextPosition = BigBlind;
            BigBlind.NextPosition = UnderTheGun;
            UnderTheGun.NextPosition = Dealer;
        }

        public Position Dealer { get; private set; }
        public Position SmallBlind { get; private set; }
        public Position BigBlind { get; private set; }
        public Position UnderTheGun { get; private set; }
        public Position Cutoff { get; private set; }
        public IEnumerable<Position> MiddlePositions { get; private set; }

        public IEnumerable<Position> Filled()
        {
            var filled = new List<Position>();
            if (Dealer != null)
            {
                filled.Add(Dealer);
            }
            if (SmallBlind != null)
            {
                filled.Add(SmallBlind);
            }
            if (BigBlind != null)
            {
                filled.Add(BigBlind);
            }
            if (UnderTheGun != null)
            {
                filled.Add(UnderTheGun);
            }
            if (Cutoff != null)
            {
                filled.Add(Cutoff);
            }
            if (MiddlePositions != null && 0 < MiddlePositions.Count())
            {
                foreach (var p in MiddlePositions)
                {
                    filled.Add(p);
                }
            }
            return filled;
        }
    }

    public class Position
    {
        public Position(Player player)
        {
            Player = player;
        }

        public Player Player { get; private set; }
        public Position NextPosition { get; internal set; }
    }

}
