using System;
using System.Text;
using System.Threading.Tasks;
using Lab3oop.DB.Services;
using Lab3oop.DB.Entity;

namespace Lab3oop.Games
{
    public class Game
    {
        public int Id { get; set; }   
        public GameAccount player1 { get; set; }
        public GameAccount player2 { get; set; }
        public GameAccount Winner { get; set; }
        public int playRating { get; set; } = 10;
        public GameService _service { get; set; }
        public Game(GameAccount player1, GameAccount player2, GameService service)
        {
            this.player1 = player1;
            this.player2 = player2;
            _service = service;
        }

        public virtual int getPlayRating(GameAccount player, int player1Number,int player2Number) { return playRating; }
       

        public virtual void GameStart()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            Console.Write("Введіть ім'я першого гравця: ");
            player1.UserName = Console.ReadLine().Trim();

            Console.Write("Введіть ім'я другого гравця: ");
            player2.UserName = Console.ReadLine().Trim();

            PlayGame();
        }

        public virtual void PlayGame()

        {
            Console.Write($"Рейтинг на який ви граєте: {playRating} ");
            Console.WriteLine();
            if (playRating > player1.CurrentRating - 1 || playRating > player2.CurrentRating - 1)
            {
                Console.WriteLine("Недостатньо рейтингу для продовження гри.");
                EndGame();
                return;
            }

            Random random = new Random();
            Console.WriteLine($"{player1.UserName}, введіть число від 1 до 20:");
            int player1Number = int.Parse(Console.ReadLine());
            int player2Number = random.Next(1, 21);

            Console.WriteLine($"{player2.UserName}, ввів число {player2Number}");
            if (player1Number > player2Number)
            {
                player1.WinGame(player2.UserName, this, player1Number, player2Number);
                player2.LoseGame(player1.UserName, this, player1Number, player2Number);
                Winner = player1;
                _service.Create(this);
                Console.WriteLine($"Переміг {player1.UserName}!");
            }
            if (player1Number < player2Number)
            {
                player2.WinGame(player1.UserName, this, player1Number, player2Number);
                player1.LoseGame(player2.UserName, this, player1Number, player2Number);
                Winner = player2;
                _service.Create(this);
                Console.WriteLine($"Переміг {player2.UserName}!");
            }
            if (player1Number == player2Number)
            {
                player1.draw(player2.UserName);
                player2.draw(player1.UserName);
                Console.WriteLine("Нічия");
            }
            Console.WriteLine($"Поточний рейтинг користувача {player1.UserName}: {player1.CurrentRating}");
            Console.WriteLine($"Поточний рейтинг користувача {player2.UserName}: {player2.CurrentRating}");
            EndGame();
           
        }
        public virtual void EndGame()
        {
            while (true)
            {
                Console.Write("\nПродовжити гру? (Y/N): ");
                string continuePlayingResponse = Console.ReadLine().Trim();

                if (!continuePlayingResponse.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                PlayGame();
            }
        }


    }

}

