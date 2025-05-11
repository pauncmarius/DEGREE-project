//CommentsService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _usersRepository;


        public CommentsService(ICommentsRepository commentsRepository, IMapper mapper, IUsersRepository usersRepository)
        {
            _commentsRepository = commentsRepository;
            _mapper = mapper;
            _usersRepository = usersRepository;
        }

        public IEnumerable<Comments> GetComments() => _commentsRepository.ListAll();
        public Comments GetComment(int id) => _commentsRepository.GetById(id);
        public int AddComment(CommentsModel comment) => _commentsRepository.Add(_mapper.Map<Comments>(comment)).Id;
        public void UpdateComment(Comments comment) => _commentsRepository.Update(comment);
        public void DeleteComment(int id)
        {
            var comment = _commentsRepository.GetById(id);
            if (comment != null) 
                _commentsRepository.Delete(comment);
        }

        public IEnumerable<Comments> GetByNewsId(int newsId)
        {
            return _commentsRepository.GetByNewsIdWithUser(newsId);

        }

        public int? AddCommentWithUser(CommentsModel model, string username)
        {
            var user = _usersRepository.GetByUsername(username);
            if (user == null) return null;

            var comment = _mapper.Map<Comments>(model);
            comment.CreatedAt = DateTime.UtcNow;
            comment.Comment_UsersId = user.Id;

            return _commentsRepository.Add(comment).Id;
        }

    }
}
