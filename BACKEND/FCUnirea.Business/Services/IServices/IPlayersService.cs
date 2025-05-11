//IPlayersService
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;


namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayersService
    {
        public IEnumerable<Players> GetPlayers();
        public Players GetPlayer(int id);
        public int AddPlayer(PlayersModel player);
        public void UpdatePlayer(Players player);
        public void DeletePlayer(int id);

        IEnumerable<Players> GetPlayersByTeam(int teamId); // 👈 nou

    }
}
