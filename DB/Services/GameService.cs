using Lab3oop.DB.Services;
using Lab3oop.DB.Entity.Games;
using Lab3oop.DB.Repositories;
using Lab3oop.DB.Repositories.Base;
using Lab3oop.DB.Services.Base;
using Lab3oop.Games;


namespace Lab3oop.DB.Services
{
    public class GameService : IGameService
    {
        GameRepository repository;
        GameAccountService _serviceAcc;
        public GameService(DbContext context)
        {
            repository = new GameRepository(context);
            _serviceAcc= new GameAccountService(context);
        }
        public void Create(Game entity)
        {
            repository.Create(Map(entity));
        }
        public void Delete(Game entity)
        {
            repository.Delete(Map(entity));
        }
        public List<Game> GetAll()
        {
            var list = repository.GetAll().Select(x => Map(x)).ToList();
            return list;
        }
        public Game GetById(int id)
        {
            return Map(repository.GetById(id));
        }
        public void Update(Game entity)
        {
            repository.Update(Map(entity));
        }
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,
                
            };
        }
        private Game Map(GameEntity game)
        {
            return new Game(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
        private AllRatingGameEntity Map(AllRatingGame game)
        {
            return new AllRatingGameEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,

            };
        }
        private AllRatingGame Map(AllRatingGameEntity game)
        {
            return new AllRatingGame(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
        private TrainingGameEntity Map(TrainingGame game)
        {
            return new TrainingGameEntity
            {
                Id = game.Id,
                Player1 = game.player1,
                Player2 = game.player2,
                PlayRating = game.playRating,

            };
        }
        private TrainingGame Map(TrainingGameEntity game)
        {
            return new TrainingGame(game.Player1, game.Player2, this)
            {
                Id = game.Id,
                player1 = game.Player1,
                player2 = game.Player2,
                playRating = game.PlayRating,
            };
        }
    }
}
