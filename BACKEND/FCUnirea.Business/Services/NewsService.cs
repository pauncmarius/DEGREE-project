
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FCUnirea.Business.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, ICommentsRepository commentsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _commentsRepository = commentsRepository;
            _mapper = mapper;
        }


        public IEnumerable<News> GetNews() => _newsRepository.ListAll();
        public News GetNewsItem(int id)
        {
            return _newsRepository.GetByIdWithAuthor(id);
        }
        public int AddNews(NewsModel news) => _newsRepository.Add(_mapper.Map<News>(news)).Id;
        public void UpdateNews(News news) => _newsRepository.Update(news);
        public void DeleteNews(int id)
        {
            var news = _newsRepository.GetById(id);
            if (news != null) _newsRepository.Delete(news);
        }

        public NewsWithCommentsModel GetNewsWithComments(int id)
        {
            var news = _newsRepository.GetByIdWithAuthor(id);
            if (news == null) return null;

            var comments = _commentsRepository.GetByNewsIdWithUser(id);

            return new NewsWithCommentsModel
            {
                Id = news.Id,
                Title = news.Title,
                Text = news.Text,
                CreatedAt = news.CreatedAt,
                Username = news.News_Users != null ? news.News_Users.Username : "Autor necunoscut",
                Comments = comments.Select(c => new CommentDto
                {
                    Text = c.Text,
                    CreatedAt = c.CreatedAt,
                    Username = c.Comment_User?.Username
                }).ToList()
            };
        }


    }
}
