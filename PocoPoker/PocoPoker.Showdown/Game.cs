using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker.Showdown
{
    public class Game
    {
        private List<Card> cards;

        public Game(Card a, Card b, Card c, Card d, Card e)
        {
            this.cards = new List<Card>(new Card[] { a, b, c, d, e });
        }

        public IEnumerable<Card> Cards
        {
            get
            {
                return this.cards.AsEnumerable();
            }
        }

    }
}
