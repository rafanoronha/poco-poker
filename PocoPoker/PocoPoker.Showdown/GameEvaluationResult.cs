using System;
using System.Collections.Generic;
using System.Linq;

namespace PocoPoker.Showdown
{
    public interface IGameEvaluationResult
    {
        GameCategory Category { get; }
        IEnumerable<Card> UsedCards { get; }
        bool Success();
    }

    public abstract class GameEvaluationResultBase : IGameEvaluationResult
    {
        public GameEvaluationResultBase() { }

        public GameEvaluationResultBase(GameCategory category, IEnumerable<Card> usedCards)
        {
            Category = category;
            UsedCards = usedCards;
        }

        public virtual GameCategory Category { get; private set; }
        public virtual IEnumerable<Card> UsedCards { get; private set; }

        public bool Success()
        {
            return this.GetType().IsAssignableFrom(typeof(SuccessGameEvaluationResult));
        }
    }

    public class SuccessGameEvaluationResult : GameEvaluationResultBase
    {
        public SuccessGameEvaluationResult(GameCategory category, IEnumerable<Card> usedCards)
            : base(category, usedCards) { }
    }

    public class FailedGameEvaluationResult : GameEvaluationResultBase
    {
        public override GameCategory Category
        {
            get { throw new NotImplementedException(); }
        }

        public override IEnumerable<Card> UsedCards
        {
            get { throw new NotImplementedException(); }
        }
    }
}
