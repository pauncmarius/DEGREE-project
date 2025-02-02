using AutoMapper;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public GamesService(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public IEnumerable<Games> GetGames() => _gamesRepository.ListAll();
        public Games GetGame(int id) => _gamesRepository.GetById(id);
        public int AddGame(Games game) => _gamesRepository.Add(game).Id;
        public void UpdateGame(Games game) => _gamesRepository.Update(game);
        public void DeleteGame(int id)
        {
            var game = _gamesRepository.GetById(id);
            if (game != null) _gamesRepository.Delete(game);
        }
    }
}
