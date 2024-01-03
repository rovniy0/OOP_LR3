using System;
using Lab3oop;
using Lab3oop.DB.Entity;
using Lab3oop.DB.Services;
using Lab3oop.Games;

namespace Lab3oop
{
    public class TrainingGame : Game
    {
        public TrainingGame(GameAccount player1, GameAccount player2, GameService service) : base(player1, player2, service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }
        public override int getPlayRating(GameAccount player, int player1Number, int player2Number)
        {
            return 0;
        }
    }
}
