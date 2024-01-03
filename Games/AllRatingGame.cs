using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3oop.DB.Services;
using Lab3oop;
using Lab3oop.DB.Entity;
using Lab3oop.Games;

namespace Lab3oop
{

    public class AllRatingGame : Game
    {

        public AllRatingGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        public override int getPlayRating(GameAccount player, int player1Number, int player2Number)
        {

            return playRating = player.CurrentRating;
        }

    }
}
