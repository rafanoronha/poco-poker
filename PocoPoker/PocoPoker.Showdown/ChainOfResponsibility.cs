using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public class GameEvaluationChain
    {
        IEnumerator<GameEvaluationCommand> evaluations;

        public GameEvaluationChain(IEnumerable<IGameEvaluation> evaluations)
        {
            if (evaluations == null)
            {
                throw new ArgumentNullException("evaluations");
            }

            this.evaluations = evaluations.Select((x) => new GameEvaluationCommand(x)).GetEnumerator();
        }

        public void Evaluate(IGame game)
        {
            bool hasNext;
            do
            {
                hasNext = evaluations.MoveNext();
            }
            while (hasNext && !evaluations.Current.Evaluate(game));
        }
    }

    public class GameEvaluationCommand
    {
        IGameEvaluation gameEvaluation;

        public GameEvaluationCommand(IGameEvaluation gameEvaluation)
        {
            this.gameEvaluation = gameEvaluation;
        }

        public bool Evaluate(IGame game)
        {
            var result = gameEvaluation.Evaluate(game);
            var success = result.Success();
            if (success)
            {
                game.EvaluationResult(result);
            }

            return success;
        }
    }
}
