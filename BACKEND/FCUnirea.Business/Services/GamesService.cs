
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

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
        public int AddGame(GamesModel game) => _gamesRepository.Add(_mapper.Map<Games>(game)).Id;
        public void UpdateGame(Games game) => _gamesRepository.Update(game);
        public void DeleteGame(int id)
        {
            var game = _gamesRepository.GetById(id);
            if (game != null) _gamesRepository.Delete(game);
        }
    }
}
