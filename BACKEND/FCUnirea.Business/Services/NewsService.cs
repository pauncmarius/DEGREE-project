//NewsService
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
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


        public IEnumerable<News> GetNews() => _newsRepository.ListAll().OrderByDescending(n => n.CreatedAt);
        public News GetNewsItem(int id)
        {
            return _newsRepository.GetByIdWithAuthor(id);
        }
        public int AddNews(NewsModel news) => _newsRepository.Add(_mapper.Map<News>(news)).Id;
        public void UpdateNews(NewsModel model)
        {
            var existing = _newsRepository.GetById(model.Id);
            if (existing == null) return;

            // pastram datele care nu vin din frontend
            existing.Title = model.Title;
            existing.Text = model.Text;
            existing.CreatedAt = existing.CreatedAt;
            existing.News_UsersId = existing.News_UsersId;

            _newsRepository.Update(existing);
        }

        public void DeleteNews(int id)
        {
            var news = _newsRepository.GetById(id);
            if (news == null) return;

            var comments = _commentsRepository.GetByNewsIdWithUser(id).ToList();
            foreach (var comment in comments)
            {
                _commentsRepository.Delete(comment);
            }

            _newsRepository.Delete(news);
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
                    Id = c.Id,
                    Text = c.Text,
                    CreatedAt = c.CreatedAt,
                    Username = c.Comment_User?.Username
                }).ToList()
            };
        }


    }
}
