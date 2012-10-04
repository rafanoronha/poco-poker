using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class RoyalFlush : IGameEvaluation
    {
        public bool FitsMyCategory(Game game)
        {
            var firstCardSuit = game.Cards.First().Suit;
            
            var sameSuit = game.Cards.All(c =>
                firstCardSuit.Equals(c.Suit));

            var hasAce = game.Cards.Any(c =>
                Rank.ACE.Equals(c.Rank));

            var hasKing = game.Cards.Any(c =>
                Rank.KING.Equals(c.Rank));

            var hasQueen = game.Cards.Any(c =>
                Rank.QUEEN.Equals(c.Rank));

            var hasJack = game.Cards.Any(c =>
                Rank.JACK.Equals(c.Rank));

            var hasTen = game.Cards.Any(c =>
                Rank.TEN.Equals(c.Rank));

            return sameSuit && hasAce && hasKing && hasQueen && hasJack && hasTen;
        }

        public GameCategory Category
        {
            get { return GameCategory.ROYAL_FLUSH; }
        }
    }
}
