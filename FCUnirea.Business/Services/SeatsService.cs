﻿using AutoMapper;
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
    public class SeatsService : ISeatsService
    {
        private readonly ISeatsRepository _repository;
        private readonly IMapper _mapper;

        public SeatsService(ISeatsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<Seats> GetSeats() => _repository.ListAll();
        public Seats GetSeat(int id) => _repository.GetById(id);
        public int AddSeat(Seats seat) => _repository.Add(seat).Id;
        public void UpdateSeat(Seats seat) => _repository.Update(seat);
        public void DeleteSeat(int id)
        {
            var seat = _repository.GetById(id);
            if (seat != null) _repository.Delete(seat);
        }
    }
}
