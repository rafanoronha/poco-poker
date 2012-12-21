using NSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoPoker.Betting;

namespace PocoPoker.Betting.Spec
{
    class describe_FearfulBigBlind : nspec
    {
        void given_a_4_players_preflop_betting_round()
        {
            BettingRound round = null;
            Position dealer = null, sb = null, bb = null, utg = null;

            before = () =>
            {
                var playerStub = new Player();
                var fearfulPlayer = new Player();

                utg = new Position(playerStub);
                bb = new Position(fearfulPlayer);
                sb = new Position(playerStub);
                dealer = new Position(playerStub);

                var positions = new Positions(dealer, sb, bb, utg);
                round = new BettingRound(new Pot(), positions);
            };

            context["given big blind is so fearful"] = () =>
            {
                context["that everyone run away"] = () =>
                {
                    before = () =>
                        {
                            round.PlaceAction(Action.Fold(utg));
                            round.PlaceAction(Action.Fold(dealer));
                            round.PlaceAction(Action.Fold(sb));
                        };

                    it["big blind must not act"] = expect<EndOfRoundException>(() =>
                        round.PlaceAction(Action.Fold(bb)));

                    it["big blind wins the pot"] = () =>
                        round.Pot.Winner.should_be(bb.Player);
                };
            };
        }
    }
}
