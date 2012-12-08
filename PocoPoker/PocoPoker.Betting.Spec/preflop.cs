using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoPoker.Betting;

namespace PocoPoker.Betting.Spec
{
    class preflop : nspec
    {
        void given_a_4_players_preflop_betting_round()
        {
            var playerStub = new Player();
            var dealer = new Position(playerStub);
            var sb = new Position(playerStub);
            var bb = new Position(playerStub);
            var utg = new Position(playerStub);

            var positions = new Positions(dealer, sb, bb, utg);
            var round = new BettingRound(positions);

            context["given under the gun is in turn"] = () =>
            {
                it["under the gun must call"] = () =>
                    round.PlaceAction(Action.Call(utg));

                it["dealer must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(dealer)));

                it["small blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(sb)));

                it["big blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(bb)));
            };

        }
    }
}
