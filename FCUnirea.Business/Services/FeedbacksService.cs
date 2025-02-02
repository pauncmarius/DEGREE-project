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
    public class FeedbacksService : IFeedbacksService
    {
        private readonly IFeedbacksRepository _feedbacksRepository;
        private readonly IMapper _mapper;

        public FeedbacksService(IFeedbacksRepository feedbacksRepository, IMapper mapper)
        {
            _feedbacksRepository = feedbacksRepository;
            _mapper = mapper;
        }

        public IEnumerable<Feedbacks> GetFeedbacks() => _feedbacksRepository.ListAll();
        public Feedbacks GetFeedback(int id) => _feedbacksRepository.GetById(id);
        public int AddFeedback(Feedbacks feedback) => _feedbacksRepository.Add(feedback).Id;
        public void UpdateFeedback(Feedbacks feedback) => _feedbacksRepository.Update(feedback);
        public void DeleteFeedback(int id)
        {
            var feedback = _feedbacksRepository.GetById(id);
            if (feedback != null) _feedbacksRepository.Delete(feedback);
        }
    }
}
