using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoPoker.Betting;

namespace PocoPoker.Betting.Spec
{
    class describe_Turns : nspec
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
                round = new BettingRound(new Pot(), positions);
            };

            context["given betting round just started"] = () =>
            {
                it["under the gun may act"] = () =>
                    round.PlaceAction(Action.Call(utg));

                it["dealer must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(dealer)));

                it["small blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Call(sb)));

                it["big blind must not act"] = expect<OutOfTurnException>(() =>
                    round.PlaceAction(Action.Fold(bb)));

                context["given under the gun acted"] = () =>
                {
                    before = () => round.PlaceAction(Action.Call(utg));

                    it["dealer may act"] = () =>
                        round.PlaceAction(Action.Call(dealer));

                    it["under the gun must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Fold(utg)));

                    it["small blind must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Call(sb)));

                    it["big blind must not act"] = expect<OutOfTurnException>(() =>
                        round.PlaceAction(Action.Fold(bb)));

                    context["given dealer acted"] = () =>
                    {
                        before = () => round.PlaceAction(Action.Call(dealer));

                        it["small blind may act"] = () =>
                            round.PlaceAction(Action.Call(sb));

                        it["big blind must not act"] = expect<OutOfTurnException>(() =>
                            round.PlaceAction(Action.Fold(bb)));

                        it["under the gun must not act"] = expect<OutOfTurnException>(() =>
                            round.PlaceAction(Action.Call(utg)));

                        it["dealer must not act"] = expect<OutOfTurnException>(() =>
                            round.PlaceAction(Action.Fold(dealer)));

                        context["given small blind acted"] = () =>
                        {
                            before = () => round.PlaceAction(Action.Call(sb));

                            it["big blind may act"] = () =>
                                round.PlaceAction(Action.Call(bb));

                            it["under the gun must not act"] = expect<OutOfTurnException>(() =>
                                round.PlaceAction(Action.Fold(utg)));

                            it["dealer must not act"] = expect<OutOfTurnException>(() =>
                                round.PlaceAction(Action.Call(dealer)));

                            it["small blind must not act"] = expect<OutOfTurnException>(() =>
                                round.PlaceAction(Action.Fold(sb)));
                        };
                    };
                };
            };

        }
    }
}
