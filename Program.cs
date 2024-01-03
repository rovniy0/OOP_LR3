using Lab3oop.DB.Services;
using Lab3oop.DB;
using Lab3oop.DB.Entity;
using Lab3oop.Games;
using System.Text;
using Lab3oop.GameAccounts;
using System;

namespace Lab3oop
{
    public class Program
    {
        static void Main(string[] args)
        {

            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            
            Console.OutputEncoding = Encoding.UTF8;

            Start(accountService, gameService);
        }
        public static void Start(GameAccountService accountService, GameService gameService)
        {

            GameAccount player1 = SelectedAccountType(accountService);
            var player2 = new GameAccount(accountService, accountService.GetAll().Count());
            accountService.Create(player2);

            Game game = GameType(player1, player2, gameService);

            game.GameStart();

            Show(accountService);

        }
        public static void Show(GameAccountService accountService)
        {
            var listAccounts = accountService.GetAll();
            foreach (var account in listAccounts)
            {
                if (account != null)
                {
                    account.GetStats();
                }

            }
        }
        private static GameAccount SelectedAccountType(GameAccountService service)
        {
            Console.WriteLine("Оберіть аккаунт: \n | 1. StandardGameAccount | 2. BonusGameAccount | 3-StreakGameAccount |:");
            int response = Convert.ToInt32(Console.ReadLine());
            var id = service.GetAll().Count();

            switch (response)
            {
                case 1:
                    var standardGameAccount = new GameAccount(service, id);
                    service.Create(standardGameAccount);
                    return standardGameAccount;
                case 2:
                    var bonusGameAccount = new PremiumGameAccount(service, id);
                    service.Create(bonusGameAccount);
                    return bonusGameAccount;

                case 3:
                    var streakGameAccount = new ProGameAccount(service, id);
                    service.Create(streakGameAccount);
                    return streakGameAccount;

                default:
                    Console.WriteLine("\nВведене значення є некоректним");
                    return SelectedAccountType(service);
            }
        }

        private static Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("Standard game | Training game | AllRating game");
            Console.WriteLine("Оберіть тип гри: \n | 1. Standard game | 2. Training game | 3. AllRating game:");
            int temp = Convert.ToInt32(Console.ReadLine());
            GameFactory gameFactory = new GameFactory();

            switch (temp)
            {
                case 1:
                    return gameFactory.CreateGame(player1, player2, service);

                case 2:
                    return gameFactory.CreateTrainingGame(player1, player2, service);

                case 3:
                    return gameFactory.CreateAllinGame(player1, player2, service);

                default:
                    Console.WriteLine("\nВведене значення є некоректним");
                    return GameType(player1, player2, service);
            }
        }


    }
}
