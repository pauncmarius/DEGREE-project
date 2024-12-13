using FCUnirea.Domain.Entities;
using FCUnirea.Persistance.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FCUnirea.Persistance.Data
{
    public class FCUnireaDbContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Feedbacks> Feedback { get; set; }
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

        public FCUnireaDbContext(DbContextOptions<FCUnireaDbContext> options) : base(options) { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=FCUnirea;Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CommentsMapping.Map(modelBuilder);
            CompetitionsMapping.Map(modelBuilder);
            FeedbacksMapping.Map(modelBuilder);
            GamesMapping.Map(modelBuilder);
            NewsMapping.Map(modelBuilder);
            PlayersMapping.Map(modelBuilder);
            PlayerStatisticsPerCompetitonMapping.Map(modelBuilder);
            PlayerStatisticsPerGameMapping.Map(modelBuilder);
            SeatsMapping.Map(modelBuilder);
            StadiumsMapping.Map(modelBuilder);
            TeamsMapping.Map(modelBuilder);
            TeamStatisticsMapping.Map(modelBuilder);
            TicketsMapping.Map(modelBuilder);
            UsersMapping.Map(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private static void SeedDatabase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasData(new List<Users>()
            {
                new Users()
                {
                    Id = 1
                },
                new Users()
                {
                    Id = 2
                }
            });

        }
    }
}
