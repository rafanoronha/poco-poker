using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PocoPoker
{
    public struct Card
    {
        private Rank rank;
        private Suit suit;

        public Card(Rank rank, Suit suit)
        {
            this.rank = rank;
            this.suit = suit;
        }

        public Rank Rank
        {
            get
            {
                return this.rank;
            }
        }

        public Suit Suit
        {
            get
            {
                return this.suit;
            }
        }


    }

}
