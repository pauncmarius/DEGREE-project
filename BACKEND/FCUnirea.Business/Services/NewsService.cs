
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using System.Collections.Generic;

namespace FCUnirea.Business.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsService(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
        }

        public IEnumerable<News> GetNews() => _newsRepository.ListAll();
        public News GetNewsItem(int id) => _newsRepository.GetById(id);
        public int AddNews(NewsModel news) => _newsRepository.Add(_mapper.Map<News>(news)).Id;
        public void UpdateNews(News news) => _newsRepository.Update(news);
        public void DeleteNews(int id)
        {
            var news = _newsRepository.GetById(id);
            if (news != null) _newsRepository.Delete(news);
        }
    }
}
