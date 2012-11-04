using System;
using System.Collections.Generic;
namespace PocoPoker.Showdown
{
    public interface IGame
    {
        IEnumerable<PocoPoker.Card> Cards { get; }
        void EvaluationResult(IGameEvaluationResult result);
        IEnumerable<PocoPoker.Card> UsedCards { get; }
        GameCategory? Category { get; }
        bool SameSuit();
    }
}
