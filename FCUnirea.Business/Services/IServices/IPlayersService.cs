using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface IPlayersService
    {
        IEnumerable<Players> GetPlayers();
        Players GetPlayer(int id);
        int AddPlayer(PlayersModel player);
        void UpdatePlayer(Players player);
        void DeletePlayer(int id);
    }
}
