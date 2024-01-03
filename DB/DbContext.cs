using Lab3oop.DB.Entity;
using Lab3oop.DB.Entity.Games;
using System;


namespace Lab3oop.DB
{
    public class DbContext
    {
        public List<GameEntity> Games { get; set; }
        public List<GameAccountEntity> Accounts { get; set; }

        public DbContext()
        {
            Games = new List<GameEntity>();
            Accounts = new List<GameAccountEntity>();
        }
    }
}