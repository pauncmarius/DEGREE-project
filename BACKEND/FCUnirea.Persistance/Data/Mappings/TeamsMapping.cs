//TeamsMapping
using FCUnirea.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FCUnirea.Persistance.Data.Mappings
{
    internal abstract class TeamsMapping
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teams>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.TeamName)
                .HasColumnName("TeamName")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.TeamType)
                .HasColumnName("TeamType")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.IsInternal)
                .HasColumnName("IsInternal")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.Description)
                .HasColumnName("Description")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .Property(s => s.CoachName)
                .HasColumnName("CoachName")
                .IsRequired();

            modelBuilder.Entity<Teams>()
                .HasMany(n => n.Teams_TeamStatistics)
                .WithOne(c => c.TeamsStatistics_Teams)
                .HasForeignKey(c => c.TeamsStatistics_TeamsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teams>()
                .HasMany(n => n.Teams_Players)
                .WithOne(c => c.Player_Teams)
                .HasForeignKey(c => c.Player_TeamsId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teams>()
                .HasMany(n => n.Team_HomeTeam)
                .WithOne(c => c.Game_HomeTeam)
                .HasForeignKey(c => c.Game_HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Teams>()
                .HasMany(n => n.Team_AwayTeam)
                .WithOne(c => c.Game_AwayTeam)
                .HasForeignKey(c => c.Game_AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
