
using FCUnirea.Domain.Entities;
using FCUnirea.Persistance.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//add-migration CreateDatabase -o Data/Migrations
namespace FCUnirea.Persistance.Data
{
    public class FCUnireaDbContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Competitions> Competitions { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Players> Players { get; set; }
        public DbSet<PlayerStatisticsPerGame> PlayerStatisticsPerGame { get; set; }
        public DbSet<PlayerStatisticsPerCompetition> PlayerStatisticsPerCompetiton { get; set; }
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
            GamesMapping.Map(modelBuilder);
            NewsMapping.Map(modelBuilder);
            PlayersMapping.Map(modelBuilder);
            PlayerStatisticsPerCompetitionMapping.Map(modelBuilder);
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
            modelBuilder.Entity<Competitions>().HasData(new List<Competitions>()
            {
                new Competitions() { Id = 1, CompetitionName = "Liga 1", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 2, CompetitionName = "Cupa Romaniei", CompetitionType = CompetitionType.NationalCup },
                new Competitions() { Id = 3, CompetitionName = "Champions League", CompetitionType = CompetitionType.ChampionsLeague },
                new Competitions() { Id = 4, CompetitionName = "Liga 1 U21", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 5, CompetitionName = "Cupa Romaniei U21", CompetitionType = CompetitionType.NationalCup },
                new Competitions() { Id = 6, CompetitionName = "Champions League U21", CompetitionType = CompetitionType.ChampionsLeague },
                new Competitions() { Id = 7, CompetitionName = "Liga 1 Tineret", CompetitionType = CompetitionType.NationalLeague },
                new Competitions() { Id = 8, CompetitionName = "Cupa Romaniei Tineret", CompetitionType = CompetitionType.NationalCup },
                new Competitions() { Id = 9, CompetitionName = "Champions League Tineret", CompetitionType = CompetitionType.ChampionsLeague }
            });

            modelBuilder.Entity<Users>().HasData(new List<Users>()
            {
                new Users() { Id = 1, Username = "admin", Email = "admin@fcunirea.com", FirstName = "Admin", LastName = "User", Password = "hashedpassword", PhoneNumber = "0734567890", Role = UserRole.Admin, CreatedAt = DateTime.UtcNow},
                new Users() { Id = 2, Username = "mariuspaun", Email = "mariuspaun@example.com", FirstName = "Marius", LastName = "Paun", Password = "hashedpassword", PhoneNumber = "0787654321", Role = UserRole.Customer, CreatedAt = DateTime.UtcNow }
            });

            modelBuilder.Entity<Teams>().HasData(new List<Teams>()
            {
                new Teams() { Id = 1, TeamName = "FC Unirea", TeamType = TeamType.Adult, IsInternal = true, Record = " " },
                new Teams() { Id = 2, TeamName = "FC Unirea U21", TeamType = TeamType.U21, IsInternal = true, Record = " " },
                new Teams() { Id = 3, TeamName = "FC Unirea Youth", TeamType = TeamType.Kids, IsInternal = true, Record = " " }
            });

            modelBuilder.Entity<Players>().HasData(new List<Players>()
            {
                new Players() { Id = 1, PlayerName = "Alex Popescu", Position = Position.Atacker, BirthDate = new DateTime(1998, 5, 20), Player_TeamsId = 1},
                new Players() { Id = 2, PlayerName = "Mihai Ionescu", Position = Position.Midfielder, BirthDate = new DateTime(2000, 8, 10), Player_TeamsId = 2 }
            });

            modelBuilder.Entity<Stadiums>().HasData(new List<Stadiums>()
            {
                new Stadiums() { Id = 1, StadiumName = "Unirea Stadium", StadiumLocation = "Odobesti", Capacity = 20000 },
                new Stadiums() { Id = 2, StadiumName = "Unirea U21 Stadium", StadiumLocation = "Odobesti", Capacity = 2000 },
                new Stadiums() { Id = 3, StadiumName = "Unirea Youth Stadium", StadiumLocation = "Odobesti", Capacity = 200 }
            });

            modelBuilder.Entity<Seats>().HasData(new List<Seats>()
            {
                new Seats() { Id = 1, SeatType = SeatType.Vip, SeatName = "A1", SeatPrice = 150, Reserved = false, Seat_StadiumsId = 1 },
                new Seats() { Id = 2, SeatType = SeatType.Standard, SeatName = "B2", SeatPrice = 50, Reserved = false, Seat_StadiumsId =1 }
            });

            modelBuilder.Entity<Games>().HasData(new List<Games>()
            {
                new Games() { Id = 1, GameDate = DateTime.UtcNow, HomeTeamScore = 2, AwayTeamScore = 1, TicketsSold = 5000, Game_HomeTeamId = 1, Game_AwayTeamId = 2, Game_CompetitionsId = 1, Game_StadiumsId = 1}
            });

            modelBuilder.Entity<Tickets>().HasData(new List<Tickets>()
            {
                new Tickets() { Id = 1, DateReservation = DateTime.UtcNow, Ticket_SeatsId = 1, Ticket_GamesId = 1, Ticket_UsersId = 1 }
            });

            modelBuilder.Entity<TeamStatistics>().HasData(new List<TeamStatistics>()
            {
                new TeamStatistics() { Id = 1, GamesPlayed = 15, TotalWins = 10, TotalLosses = 2, TotalDraws = 3, GoalsScored = 30, GoalsConceded = 15, TotalPoints = 33, TeamsStatistics_TeamsId = 1, TeamStatistics_CompetitionsId = 1 }
            });

            modelBuilder.Entity<PlayerStatisticsPerCompetition>().HasData(new List<PlayerStatisticsPerCompetition>()
            {
                new PlayerStatisticsPerCompetition() { Id = 1, Goals = 10, Assists = 5, Saves = 0, YellowCards = 2, RedCards = 0, MinutesPlayed = 1200, PlayerStatisticsPerCompetition_CompetitionsId = 1, PlayerStatisticsPerCompetition_PlayersId = 1 }
            });

            modelBuilder.Entity<PlayerStatisticsPerGame>().HasData(new List<PlayerStatisticsPerGame>()
            {
                new PlayerStatisticsPerGame() { Id = 1, Goals = 2, Assists = 1, PassesCompleted = 30, Saves = 0, YellowCards = 0, RedCards = 0, MinutesPlayed = 90, PlayerStatisticsPerGame_GamesId = 1, PlayerStatisticsPerGame_PlayersId = 1}
            });

            modelBuilder.Entity<News>().HasData(new List<News>()
            {
                new News() { Id = 1, Title = "Victorie mare pentru FC Unirea!", Text = "FC Unirea a câștigat cu 2-1!", CreatedAt = DateTime.UtcNow, News_UsersId = 1 }
            });

            modelBuilder.Entity<Comments>().HasData(new List<Comments>()
            {
                new Comments() { Id = 1, Text = "Felicitări echipei!", CreatedAt = DateTime.UtcNow, Comment_NewsId = 1, Comment_UsersId = 1 }
            });
       }
    }
}
