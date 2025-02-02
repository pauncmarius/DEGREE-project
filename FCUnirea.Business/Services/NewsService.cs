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
        public int AddNews(News news) => _newsRepository.Add(news).Id;
        public void UpdateNews(News news) => _newsRepository.Update(news);
        public void DeleteNews(int id)
        {
            var news = _newsRepository.GetById(id);
            if (news != null) _newsRepository.Delete(news);
        }
    }
}
