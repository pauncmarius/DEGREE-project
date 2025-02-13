using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsService(ICommentsRepository commentsRepository, IMapper mapper)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }

        public IEnumerable<Comments> GetComments() => _commentsRepository.ListAll();
        public Comments GetComment(int id) => _commentsRepository.GetById(id);
        public int AddComment(CommentsModel comment) => _commentsRepository.Add(_mapper.Map<Comments>(comment)).Id;
        public void UpdateComment(Comments comment) => _commentsRepository.Update(comment);
        public void DeleteComment(int id)
        {
            var comment = _commentsRepository.GetById(id);
            if (comment != null) _commentsRepository.Delete(comment);
        }
    }
}
