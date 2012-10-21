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

        public Game SwapSuitWith(Suit suit)
        {
            var cards = this.hand.Cards.Select(c =>
                Fun.SwapSuit(c, suit)).ToArray();
            
            return new Game(cards[0], cards[1], cards[2], cards[3], cards[4]);
        }

        public static GameBuilder Game(Game hand)
        {
            return new GameBuilder(hand);
        }

    }

    public class StraightFlushGameBuilder
    {
        private Suit suit;
        private Card from;
        private Card to;

        public StraightFlushGameBuilder(Suit suit)
        {
            this.suit = suit;
        }

        public StraightFlushGameBuilder From(Rank rank)
        {
            this.from = new Card(rank, this.suit);
            return this;
        }

        public Game To(Rank rank)
        {
            this.to = new Card(rank, this.suit);

            var a = this.from;
            var b = CardBuilder.RankUp(a);
            var c = CardBuilder.RankUp(b);
            var d = CardBuilder.RankUp(c);
            var e = this.to;

            return new Game(a, b, c, d, e);
        }

        public static StraightFlushGameBuilder Diamonds()
        {
            return new StraightFlushGameBuilder(Suit.DIAMONDS);
        }

        public static StraightFlushGameBuilder Spades()
        {
            return new StraightFlushGameBuilder(Suit.SPADES);
        }

    }

    public class RoyalFlushGameBuilder
    {
        public static Game ClubsRoyalFlush()
        {
            return RoyalFlush(Suit.CLUBS);
        }

        public static Game SpadesRoyalFlush()
        {
            return RoyalFlush(Suit.SPADES);
        }

        public  static Game DiamondsRoyalFlush()
        {
            return RoyalFlush(Suit.DIAMONDS);
        }

        public static Game HearthsRoyalFlush()
        {
            return new Game(
                CardBuilder.Ace().Hearths(),
                CardBuilder.King().Hearths(),
                CardBuilder.Queen().Hearths(),
                CardBuilder.Jack().Hearths(),
                CardBuilder.Ten().Hearths());
        }

        private static Game RoyalFlush(Suit suit)
        {
            return GameBuilder.Game(HearthsRoyalFlush())
                .SwapSuitWith(suit);
        }

    }

}
