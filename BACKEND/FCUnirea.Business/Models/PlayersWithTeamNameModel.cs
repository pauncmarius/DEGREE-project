using FCUnirea.Domain.Entities;
using System;

namespace FCUnirea.Business.Models
{
    public class PlayersWithTeamNameModel
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public Position Position { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Player_TeamsId { get; set; }
        public string TeamName { get; set; }
    }
}
