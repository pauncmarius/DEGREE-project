using FCUnirea.Data.Mappings;
using FCUnirea.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEGREE.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=FCUnirea;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UsersMapping.Map(modelBuilder);
        }

        public DbSet<Comments> Comments { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<PlayerStatisticsPerGame> PlayerStatisticsPerGame { get; set; }
        public DbSet<PlayerStatisticsPerCompetiton> PlayerStatisticsPerCompetiton { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Stadiums> Stadiums { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<TeamStatistics> TeamStatistics { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
