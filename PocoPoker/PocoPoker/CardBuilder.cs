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

        public static Card RankUp(Card card)
        {
            int rank = (int)card.Rank;
            var up = (Rank)(rank + 1);
            return new Card(up, card.Suit);
        }

    }
}
