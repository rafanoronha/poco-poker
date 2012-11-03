using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class GameEvaluationChain
    {
        IEnumerator<IGameEvaluation> evaluations;

        public GameEvaluationChain(IEnumerable<IGameEvaluation> evaluations)
        {
            if (evaluations == null)
            {
                throw new ArgumentNullException("evaluations");
            }

            this.evaluations = evaluations.GetEnumerator();
        }

        public void Evaluate(Game game)
        {
            while (!evaluations.Current.FitsMyCategory(game))
            {
                evaluations.MoveNext();
            }
        }
    }

    public class GameEvaluationCommand
    {
        public bool Evaluate(Game game, IGameEvaluation gameEvaluation)
        {
            var fits = gameEvaluation.FitsMyCategory(game);
            if (fits)
            {
                game.EvaluationResult(gameEvaluation.Category);
            }

            return fits;
        }
    }
}
