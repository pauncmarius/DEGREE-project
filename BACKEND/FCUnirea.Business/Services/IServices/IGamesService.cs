using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface IGamesService
    {
        public IEnumerable<Games> GetGames();
        public Games GetGame(int id);
        public int AddGame(GamesModel game);
        public void UpdateGame(Games game);
        public void DeleteGame(int id);
    }
}
