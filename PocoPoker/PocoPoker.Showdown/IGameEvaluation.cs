﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocoPoker.Showdown
{
    public interface IGameEvaluation
    {
        IGameEvaluationResult Evaluate(Game game);
    }

    public abstract class GameEvaluationBase : IGameEvaluation
    {
        public abstract IGameEvaluationResult Evaluate(Game game);

        public IGameEvaluationResult Failed()
        {
            return new FailedGameEvaluationResult();
        }

        public IGameEvaluationResult Success(GameCategory category, IEnumerable<Card> usedCards)
        {
            return new SuccessGameEvaluationResult(category, usedCards);
        }
    }
    
}
