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
        public int AddComment(Comments comment) => _commentsRepository.Add(comment).Id;
        public void UpdateComment(Comments comment) => _commentsRepository.Update(comment);
        public void DeleteComment(int id)
        {
            var comment = _commentsRepository.GetById(id);
            if (comment != null) _commentsRepository.Delete(comment);
        }
    }
}
