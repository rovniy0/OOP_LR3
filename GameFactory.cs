using System;
using Lab3oop;
using Lab3oop.DB.Services;
using Lab3oop.DB.Entity;
using Lab3oop.Games;

namespace Lab3oop
{
    public class GameFactory
    {
        public Game CreateGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new Game(player1, player2, service);
        }
        public Game CreateTrainingGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new TrainingGame(player1, player2, service);
        }

        public Game CreateAllinGame(GameAccount player1, GameAccount player2, GameService service)
        {
            return new AllRatingGame(player1, player2, service);
        }

    }
}
