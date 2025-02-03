using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IGamesService
    {
        IEnumerable<Games> GetGames();
        Games GetGame(int id);
        int AddGame(GamesModel game);
        void UpdateGame(Games game);
        void DeleteGame(int id);
    }
}
