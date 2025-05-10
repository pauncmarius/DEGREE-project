//PlayersModel
using FCUnirea.Domain.Entities;
using System;

namespace FCUnirea.Business.Models
{
    public class PlayersModel
    {
        public string PlayerName { get; set; }

        public Position Position { get; set; }

        public DateTime BirthDate { get; set; }

        //--------------Relations--------------------//
        // Foreign Key
        public int? Player_TeamsId { get; set; }
    }
}
