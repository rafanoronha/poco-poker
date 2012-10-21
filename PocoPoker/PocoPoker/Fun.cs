using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker
{
    public class Fun
    {
        public static Func<IEnumerable<Card>, bool> SameSuit =
            (cards) =>
                cards.All(c =>
                    cards.First().Suit == c.Suit);

        public static Func<Card, Rank, bool> RankCheck =
            (c, r) =>
                r.Equals(c.Rank);

        public static Func<Card, bool> IsAce =
            (c) =>
                RankCheck(c, Rank.ACE);

        public static Func<Card, bool> IsKing =
            (c) =>
                RankCheck(c, Rank.KING);

        public static Func<Card, bool> IsQueen =
            (c) =>
                RankCheck(c, Rank.QUEEN);

        public static Func<Card, bool> IsJack =
            (c) =>
                RankCheck(c, Rank.JACK);

        public static Func<Card, bool> IsTen =
            (c) =>
                RankCheck(c, Rank.TEN);

        public static Func<IEnumerable<T>, IEnumerable<Func<T, bool>>, bool> PassAny<T>()
        {
            return (args, tests) =>
                args.All(arg =>
                    tests.Any(test =>
                        test(arg)));
        }

        public static Func<Card, Suit, Card> SwapSuit =
            (card, suit) =>
                new Card(card.Rank, suit);
                    
    }
}
