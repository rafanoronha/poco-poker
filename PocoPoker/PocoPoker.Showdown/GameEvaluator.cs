using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class GameEvaluator
    {
        GameEvaluationChain chain;

        public GameEvaluator()
        {
            chain = new GameEvaluationChain(
                new IGameEvaluation[] {
                    new RoyalFlush(),
                    new StraightFlush(),
                    new FourOfAKind(),
                    new FullHouse(),
                    new Flush(),
                    new Straight()
                    //new ThreeOfAKind(),
                    //new TwoPair(),
                    //new OnePair(),
                    //new HighCard()
            });
        }

        public void Evaluate(Game game)
        {
            chain.Evaluate(game);
            if (game.Category == null)
            {
                throw new ApplicationException("game evaluation failed: no game category found for such game");
            }
        }
    }
}
