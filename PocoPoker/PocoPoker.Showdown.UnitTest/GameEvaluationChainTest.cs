using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class GameEvaluationChainTest
    {
        class WrongEvaluation : GameEvaluationBase
        {
            public override IGameEvaluationResult Evaluate(IGame game)
            {
                return Failed();
            }
        }
        class RightEvaluation : GameEvaluationBase
        {
            public override IGameEvaluationResult Evaluate(IGame game)
            {
                return Success(GameCategory.ROYAL_FLUSH, game.Cards);
            }
        }
        class EvaluationMock : GameEvaluationBase
        {
            IGameEvaluationResult evaluateReturns;

            public override IGameEvaluationResult Evaluate(IGame game)
            {
                EvaluateWasCalled = true;
                return evaluateReturns;
            }

            public void EvaluateReturns(IGameEvaluationResult evaluateReturns)
            {
                this.evaluateReturns = evaluateReturns;
            }

            public bool EvaluateWasCalled { get; private set; }
        }

        [TestMethod]
        public void ShouldStopWhenEvaluationSucceeds()
        {
            // ARRANGE
            var game = new Game(
                CardBuilder.Ace().Hearths(),
                CardBuilder.King().Hearths(),
                CardBuilder.Queen().Hearths(),
                CardBuilder.Jack().Hearths(),
                CardBuilder.Ten().Hearths());

            var evaluationMock = new EvaluationMock();
            evaluationMock.EvaluateReturns(new SuccessGameEvaluationResult(GameCategory.ROYAL_FLUSH, game.Cards));

            var subject = new GameEvaluationChain(new IGameEvaluation[] {
                new WrongEvaluation(),
                new RightEvaluation(),
                evaluationMock
            });

            // ACT
            subject.Evaluate(game);

            // ASSERT
            Assert.IsFalse(evaluationMock.EvaluateWasCalled);
        }

        [TestMethod]
        public void ShouldGiveChanceToAllEvaluations()
        {
            // ARRANGE
            var game = new Game(
                CardBuilder.Ace().Hearths(),
                CardBuilder.King().Hearths(),
                CardBuilder.Queen().Hearths(),
                CardBuilder.Jack().Hearths(),
                CardBuilder.Ten().Hearths());

            var evaluationMock = new EvaluationMock();
            evaluationMock.EvaluateReturns(new SuccessGameEvaluationResult(GameCategory.ROYAL_FLUSH, game.Cards));

            var subject = new GameEvaluationChain(new IGameEvaluation[] {
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                new WrongEvaluation(),
                evaluationMock
            });

            // ACT
            subject.Evaluate(game);

            // ASSERT
            Assert.IsTrue(evaluationMock.EvaluateWasCalled);
        }
    }
}
