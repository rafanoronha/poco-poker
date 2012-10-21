using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker
{
    public class CardBuilder
    {
        private Rank rank;

        public CardBuilder(Rank rank)
        {
            this.rank = rank;
        }

        public Card Hearths()
        {
            return new Card(this.rank, Suit.HEARTHS);
        }

        public Card Clubs()
        {
            return new Card(this.rank, Suit.CLUBS);
        }

        public Card Diamonds()
        {
            return new Card(this.rank, Suit.DIAMONDS);
        }

        public Card Spades()
        {
            return new Card(this.rank, Suit.SPADES);
        }

        public static CardBuilder Ace()
        {
            return new CardBuilder(Rank.ACE);
        }

        public static CardBuilder King()
        {
            return new CardBuilder(Rank.KING);
        }

        public static CardBuilder Queen()
        {
            return new CardBuilder(Rank.QUEEN);
        }

        public static CardBuilder Jack()
        {
            return new CardBuilder(Rank.JACK);
        }

        public static CardBuilder Ten()
        {
            return new CardBuilder(Rank.TEN);
        }

        public static CardBuilder Nine()
        {
            return new CardBuilder(Rank.NINE);
        }

        public static CardBuilder Four()
        {
            return new CardBuilder(Rank.FOUR);
        }

        public static CardBuilder Three()
        {
            return new CardBuilder(Rank.THREE);
        }

        public static CardBuilder Two()
        {
            return new CardBuilder(Rank.TWO);
        }

        public static Card RankUp(Card card)
        {
            int rank = (int)card.Rank;
            var up = (Rank)(rank + 1);
            return new Card(up, card.Suit);
        }

    }
}
