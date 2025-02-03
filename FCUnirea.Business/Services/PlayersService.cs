using AutoMapper;
using FCUnirea.Business.Models;
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
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _playerRepository;
        private readonly IMapper _mapper;

        public PlayersService(IPlayersRepository playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public IEnumerable<Players> GetPlayers() => _playerRepository.ListAll();
        public Players GetPlayer(int id) => _playerRepository.GetById(id);
        public int AddPlayer(PlayersModel player) => _playerRepository.Add(_mapper.Map<Players>(player)).Id;
        public void UpdatePlayer(Players player) => _playerRepository.Update(player);
        public void DeletePlayer(int id)
        {
            var player = _playerRepository.GetById(id);
            if (player != null) _playerRepository.Delete(player);
        }
    }
}
