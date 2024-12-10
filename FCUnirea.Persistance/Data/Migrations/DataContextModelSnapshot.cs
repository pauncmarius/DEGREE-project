﻿// <auto-generated />
using System;
using DEGREE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FCUnirea.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FCUnirea.Entities.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("FCUnirea.Entities.Competitions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompetitionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompetitionType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("FCUnirea.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Review")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.HasIndex("UsersId1");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("FCUnirea.Entities.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int");

                    b.Property<int?>("StadiumsId")
                        .HasColumnType("int");

                    b.Property<int>("TicketsSold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("StadiumsId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("FCUnirea.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("FCUnirea.Entities.PlayerStatisticsPerCompetiton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("Saves")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerStatisticsPerCompetiton");
                });

            modelBuilder.Entity("FCUnirea.Entities.PlayerStatisticsPerGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("PassesCompleted")
                        .HasColumnType("int");

                    b.Property<int?>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("Saves")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerStatisticsPerGame");
                });

            modelBuilder.Entity("FCUnirea.Entities.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PlayerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int?>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("FCUnirea.Entities.Seats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Reserved")
                        .HasColumnType("bit");

                    b.Property<string>("SeatName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeatPrice")
                        .HasColumnType("int");

                    b.Property<int>("SeatType")
                        .HasColumnType("int");

                    b.Property<int?>("StadiumsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumsId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("FCUnirea.Entities.Stadiums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("StadiumLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StadiumName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("FCUnirea.Entities.TeamStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int");

                    b.Property<int>("GoalsConceded")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int?>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int>("TotalDraws")
                        .HasColumnType("int");

                    b.Property<int>("TotalLosses")
                        .HasColumnType("int");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("TotalWins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("TeamStatistics");
                });

            modelBuilder.Entity("FCUnirea.Entities.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsInternal")
                        .HasColumnType("bit");

                    b.Property<string>("Record")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("FCUnirea.Entities.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<int?>("SeatsId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("SeatsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("FCUnirea.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FCUnirea.Entities.Comments", b =>
                {
                    b.HasOne("FCUnirea.Entities.News", null)
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");

                    b.HasOne("FCUnirea.Entities.Users", null)
                        .WithMany("Comments")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("FCUnirea.Entities.Feedback", b =>
                {
                    b.HasOne("FCUnirea.Entities.Users", null)
                        .WithMany("FeedbackFromStaff")
                        .HasForeignKey("UsersId");

                    b.HasOne("FCUnirea.Entities.Users", null)
                        .WithMany("FeedbackToPlayers")
                        .HasForeignKey("UsersId1");
                });

            modelBuilder.Entity("FCUnirea.Entities.Games", b =>
                {
                    b.HasOne("FCUnirea.Entities.Teams", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("FCUnirea.Entities.Competitions", null)
                        .WithMany("Games")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Entities.Teams", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("FCUnirea.Entities.Stadiums", null)
                        .WithMany("Games")
                        .HasForeignKey("StadiumsId");

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("FCUnirea.Entities.News", b =>
                {
                    b.HasOne("FCUnirea.Entities.Users", null)
                        .WithMany("News")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("FCUnirea.Entities.PlayerStatisticsPerCompetiton", b =>
                {
                    b.HasOne("FCUnirea.Entities.Competitions", null)
                        .WithMany("PlayerStatisticsPerCompetiton")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Entities.Players", null)
                        .WithMany("PlayerStatisticsPerCompetitons")
                        .HasForeignKey("PlayersId");
                });

            modelBuilder.Entity("FCUnirea.Entities.PlayerStatisticsPerGame", b =>
                {
                    b.HasOne("FCUnirea.Entities.Games", null)
                        .WithMany("PlayerStatisticsPerGame")
                        .HasForeignKey("GamesId");

                    b.HasOne("FCUnirea.Entities.Players", null)
                        .WithMany("PlayerStatisticsPerGame")
                        .HasForeignKey("PlayersId");
                });

            modelBuilder.Entity("FCUnirea.Entities.Players", b =>
                {
                    b.HasOne("FCUnirea.Entities.Teams", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamsId");

                    b.HasOne("FCUnirea.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FCUnirea.Entities.Seats", b =>
                {
                    b.HasOne("FCUnirea.Entities.Stadiums", null)
                        .WithMany("Seats")
                        .HasForeignKey("StadiumsId");
                });

            modelBuilder.Entity("FCUnirea.Entities.TeamStatistics", b =>
                {
                    b.HasOne("FCUnirea.Entities.Competitions", null)
                        .WithMany("TeamStatistics")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Entities.Teams", null)
                        .WithMany("TeamStatistics")
                        .HasForeignKey("TeamsId");
                });

            modelBuilder.Entity("FCUnirea.Entities.Tickets", b =>
                {
                    b.HasOne("FCUnirea.Entities.Games", null)
                        .WithMany("Tickets")
                        .HasForeignKey("GamesId");

                    b.HasOne("FCUnirea.Entities.Seats", "Seats")
                        .WithMany()
                        .HasForeignKey("SeatsId");

                    b.HasOne("FCUnirea.Entities.Users", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UsersId");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("FCUnirea.Entities.Competitions", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("PlayerStatisticsPerCompetiton");

                    b.Navigation("TeamStatistics");
                });

            modelBuilder.Entity("FCUnirea.Entities.Games", b =>
                {
                    b.Navigation("PlayerStatisticsPerGame");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FCUnirea.Entities.News", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FCUnirea.Entities.Players", b =>
                {
                    b.Navigation("PlayerStatisticsPerCompetitons");

                    b.Navigation("PlayerStatisticsPerGame");
                });

            modelBuilder.Entity("FCUnirea.Entities.Stadiums", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("FCUnirea.Entities.Teams", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("TeamStatistics");
                });

            modelBuilder.Entity("FCUnirea.Entities.Users", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("FeedbackFromStaff");

                    b.Navigation("FeedbackToPlayers");

                    b.Navigation("News");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}