using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class GameBuilder
    {
        private Game hand;

        public GameBuilder(Game hand)
        {
            this.hand = hand;
        }

        public Game SwapLastCardWith(Card card)
        {
            var currentCards = this.hand.Cards.ToList();
            return new Game(
                currentCards[0],
                currentCards[1],
                currentCards[2],
                currentCards[3],
                card);
        }

        public static GameBuilder Game(Game hand)
        {
            return new GameBuilder(hand);
        }
    }
}
