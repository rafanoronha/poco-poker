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
            BettingRound round = null;
            Position dealer = null, sb = null, bb = null, utg = null;

            before = () =>
            {
                var playerStub = new Player();

                utg = new Position(playerStub);
                bb = new Position(playerStub);
                sb = new Position(playerStub);
                dealer = new Position(playerStub);

                var positions = new Positions(dealer, sb, bb, utg);
                round = new BettingRound(positions);
            };

            context["given under the gun is in turn"] = () =>
            {
                it["under the gun may call"] = () =>
                    round.PlaceAction(Action.Call(utg));

                it["dealer must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(dealer)));

                it["small blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(sb)));

                it["big blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(bb)));

                context["given utg acted and now dealer is in turn"] = () =>
                {
                    before = () => round.PlaceAction(Action.Call(utg));

                    it["dealer may call"] = () =>
                        round.PlaceAction(Action.Call(dealer));

                    it["under the gun must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Fold(utg)));

                    it["small blind must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Fold(sb)));

                    it["big blind must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Fold(bb)));
                };
            };

        }
    }
}
