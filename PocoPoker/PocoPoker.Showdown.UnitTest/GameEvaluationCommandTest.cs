using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PocoPoker.Showdown.UnitTest
{
    [TestClass]
    public class GameEvaluationCommandTest
    {
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

        class GameMock : IGame
        {
            public IGameEvaluationResult ReceivedEvaluationResult { get; private set; }

            public void EvaluationResult(IGameEvaluationResult result)
            {
                ReceivedEvaluationResult = result;
            }

            public IEnumerable<Card> Cards
            {
                get { throw new NotImplementedException(); }
            }

            public IEnumerable<Card> UsedCards
            {
                get { throw new NotImplementedException(); }
            }

            public GameCategory? Category
            {
                get { throw new NotImplementedException(); }
            }

            public bool SameSuit()
            {
                throw new NotImplementedException();
            }
        }

        [TestMethod]
        public void ShouldReturnFalseWhenEvaluationFails()
        {
            //ARRANGE
            var game = new Game(
                CardBuilder.Ace().Hearths(),
                CardBuilder.King().Hearths(),
                CardBuilder.Queen().Hearths(),
                CardBuilder.Jack().Hearths(),
                CardBuilder.Ten().Hearths());
                        
            var evaluation = new EvaluationMock();
            evaluation.EvaluateReturns(new FailedGameEvaluationResult());

            var subject = new GameEvaluationCommand(evaluation);

            //ACT
            var actual = subject.Evaluate(game);

            //ASSERT
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenEvaluationSucceeds()
        {
            //ARRANGE
            var game = new Game(
                CardBuilder.Ace().Hearths(),
                CardBuilder.King().Hearths(),
                CardBuilder.Queen().Hearths(),
                CardBuilder.Jack().Hearths(),
                CardBuilder.Ten().Hearths());

            var evaluation = new EvaluationMock();
            evaluation.EvaluateReturns(new SuccessGameEvaluationResult(GameCategory.ROYAL_FLUSH, game.Cards));

            var subject = new GameEvaluationCommand(evaluation);

            //ACT
            var actual = subject.Evaluate(game);

            //ASSERT
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldCallGameEvaluationResultWhenEvaluationSucceeds()
        {
            //ARRANGE
            var gameMock = new GameMock();

            var result = new SuccessGameEvaluationResult(GameCategory.ROYAL_FLUSH, null);

            var evaluation = new EvaluationMock();
            evaluation.EvaluateReturns(result);

            var subject = new GameEvaluationCommand(evaluation);

            //ACT
            var actual = subject.Evaluate(gameMock);

            //ASSERT
            Assert.AreSame(result, gameMock.ReceivedEvaluationResult);
        }
    }
}
