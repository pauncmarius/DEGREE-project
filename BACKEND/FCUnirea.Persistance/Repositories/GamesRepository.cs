﻿
using FCUnirea.Domain.Entities;
using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;

namespace FCUnirea.Persistance.Repositories
{
    public class GamesRepository : BaseRepository<Games>, IGamesRepository
    {
        public GamesRepository(FCUnireaDbContext fcUnireaDbContext) : base(fcUnireaDbContext)
        {

        }
    }
}
