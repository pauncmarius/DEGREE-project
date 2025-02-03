using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCUnirea.Business.Services.IServices
{
    public interface INewsService
    {
        IEnumerable<News> GetNews();
        News GetNewsItem(int id);
        int AddNews(NewsModel news);
        void UpdateNews(News news);
        void DeleteNews(int id);
    }
}
