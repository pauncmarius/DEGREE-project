﻿//GamesMapping.cs
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class GamesMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.GameDate)
                .HasColumnName("GameDate")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.HomeTeamScore)
                .HasColumnName("HomeTeamScore")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.AwayTeamScore)
                .HasColumnName("AwayTeamScore")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(s => s.TicketsSold)
                .HasColumnName("TicketsSold")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.Game_HomeTeamId)
                .HasColumnName("HomeTeamId")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.Game_AwayTeamId)
                .HasColumnName("AwayTeamId")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.Game_CompetitionsId)
                .HasColumnName("CompetitionId")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.Game_StadiumsId)
                .HasColumnName("StadiumId")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.RefereeName)
                .HasColumnName("RefereeName")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .Property(c => c.IsPlayed)
                .HasColumnName("IsPlayed")
                .IsRequired();

            modelBuilder.Entity<Games>()
                .HasMany(n => n.Games_Tickets)
                .WithOne(c => c.Ticket_Games)
                .HasForeignKey(c => c.Ticket_GamesId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Games>()
                .HasMany(n => n.Games_PlayerStatisticsPerGame)
                .WithOne(c => c.PlayerStatisticsPerGame_Games)
                .HasForeignKey(c => c.PlayerStatisticsPerGame_GamesId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
