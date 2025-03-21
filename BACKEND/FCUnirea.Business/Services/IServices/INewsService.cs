﻿
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;
using System.Collections.Generic;

namespace FCUnirea.Business.Services.IServices
{
    public interface INewsService
    {
        public IEnumerable<News> GetNews();
        public News GetNewsItem(int id);
        public int AddNews(NewsModel news);
        public void UpdateNews(News news);
        public void DeleteNews(int id);
    }
}
