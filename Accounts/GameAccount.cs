using System.Text;
using Lab3oop.DB.Services;
using Lab3oop.Games;

namespace Lab3oop.DB.Entity
{
    public class GameAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public int CurrentRating { get; set; } = 100;
        public List<GameResult> GameHistory; 
        private GameAccountService service;

        public int GamesCount { get; set; } 
        public int WinStreak { get; set; } = 1;
        public GameAccountService _service { get; set; }

        public GameAccount(GameAccountService service, int ID, int gamesCount = 0)
        {
            _service = service;
            GamesCount = gamesCount;
            GameHistory= _service.GetHistory(this);
            Id = ID;
           
        }


        public void WinGame(string opponentName, Game game, int player1Number, int player2Number)
        {
            int ratingChange = CalculateRatingChange(game.getPlayRating(this, player1Number, player2Number), player1Number, player2Number);
            GamesCount++;
            CurrentRating += ratingChange;
            var result = new GameResult(opponentName, "Перемога", ratingChange);
            GameHistory.Add(result);
            WinStreak++;
            _service.Update(this);
        }

        public void LoseGame(string opponentName, Game game, int player1Number, int player2Number)
        {
            int ratingChange = CalculateRatingChange(game.getPlayRating(this, player1Number, player2Number), player1Number, player2Number);
            GamesCount++;
            CurrentRating -= ratingChange;
            var result = new GameResult(opponentName, "Поразка", ratingChange);
            GameHistory.Add(result);
            WinStreak = 0;
            _service.Update(this);
        }

        public void draw(string opponentName) 
        {

            GamesCount++;
            var result = new GameResult(opponentName, "Нічия");
            GameHistory.Add(result);
            _service.Update(this);
        }

        public void GetStats()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine($"Історія ігор:");
            if (GameHistory == null) 
            {
                Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
                return;
            }

            Console.WriteLine($"Ім'я:{UserName}, Id: {Id}");
            for (int i = 0; i < GameHistory.Count; i++)
            {
                var result = _service.GetHistory(this)[i];
                String matchResult;
                if (result.Won == null) 
                {
                    Console.WriteLine($"Партія №{i + 1}: \n" +
                  $"Результат: Нічия, опонент: {result.OpponentName}, зміна рейтингу: {result.RatingChange}\n");
                }
                Console.WriteLine($"Партія №{i + 1}: \n" +
                                  $"Опонент: {result.OpponentName}, {(result.Won)}, зміна рейтингу: {result.RatingChange}\n");
            }
            Console.WriteLine($"Рейтинг гравця {UserName}: {CurrentRating}\n" +
                              $"Кількість ігор: {GamesCount}\n");
        }

        public virtual int CalculateRatingChange(int ratingChange)
        {
            return ratingChange;
        }

        public virtual int CalculateRatingChange(int ratingChange, int player1Number, int player2Number) 
        {
            return ratingChange;
        }
    }
}
