﻿// <auto-generated />
using System;
using FCUnirea.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FCUnirea.Persistance.Data.Migrations
{
    [DbContext(typeof(FCUnireaDbContext))]
    partial class FCUnireaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FCUnirea.Domain.Entities.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("TEXT")
                        .HasColumnName("Text");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8538),
                            Text = "Felicitări echipei!"
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Competitions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompetitionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CompetitionName");

                    b.Property<int>("CompetitionType")
                        .HasColumnType("int")
                        .HasColumnName("CompetitionType");

                    b.HasKey("Id");

                    b.ToTable("Competitions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompetitionName = "Liga 1",
                            CompetitionType = 0
                        },
                        new
                        {
                            Id = 2,
                            CompetitionName = "Cupa Romaniei",
                            CompetitionType = 1
                        },
                        new
                        {
                            Id = 3,
                            CompetitionName = "Champions League",
                            CompetitionType = 2
                        },
                        new
                        {
                            Id = 4,
                            CompetitionName = "Liga 1 U21",
                            CompetitionType = 0
                        },
                        new
                        {
                            Id = 5,
                            CompetitionName = "Cupa Romaniei U21",
                            CompetitionType = 1
                        },
                        new
                        {
                            Id = 6,
                            CompetitionName = "Champions League U21",
                            CompetitionType = 2
                        },
                        new
                        {
                            Id = 7,
                            CompetitionName = "Liga 1 Tineret",
                            CompetitionType = 0
                        },
                        new
                        {
                            Id = 8,
                            CompetitionName = "Cupa Romaniei Tineret",
                            CompetitionType = 1
                        },
                        new
                        {
                            Id = 9,
                            CompetitionName = "Champions League Tineret",
                            CompetitionType = 2
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Feedbacks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<int?>("FromStaffId")
                        .HasColumnType("int");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT")
                        .HasColumnName("Review");

                    b.Property<int?>("ToPlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromStaffId");

                    b.HasIndex("ToPlayerId");

                    b.ToTable("Feedback");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8557),
                            Review = "Un meci foarte bun!"
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AwayTeamId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamScore")
                        .HasColumnType("int")
                        .HasColumnName("AwayTeamScore");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("GameDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("GameDate");

                    b.Property<int?>("HomeTeamId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamScore")
                        .HasColumnType("int")
                        .HasColumnName("HomeTeamScore");

                    b.Property<int?>("StadiumsId")
                        .HasColumnType("int");

                    b.Property<int>("TicketsSold")
                        .HasColumnType("int")
                        .HasColumnName("TicketsSold");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeamId");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("HomeTeamId");

                    b.HasIndex("StadiumsId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AwayTeamScore = 1,
                            GameDate = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8420),
                            HomeTeamScore = 2,
                            TicketsSold = 5000
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Title");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsersId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8516),
                            Text = "FC Unirea a câștigat cu 2-1!",
                            Title = "Victorie mare pentru FC Unirea!"
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("BirthDate");

                    b.Property<string>("PlayerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PlayerName");

                    b.Property<int>("Position")
                        .HasColumnType("int")
                        .HasColumnName("Position");

                    b.Property<int?>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamsId");

                    b.HasIndex("UsersId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Alex Popescu",
                            Position = 0
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2000, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PlayerName = "Mihai Ionescu",
                            Position = 1
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.PlayerStatisticsPerCompetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Assists")
                        .HasColumnType("int")
                        .HasColumnName("Assists");

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int")
                        .HasColumnName("Goals");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int")
                        .HasColumnName("MinutesPlayed");

                    b.Property<int?>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int")
                        .HasColumnName("RedCards");

                    b.Property<int>("Saves")
                        .HasColumnType("int")
                        .HasColumnName("Saves");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int")
                        .HasColumnName("YellowCards");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerStatisticsPerCompetiton");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assists = 5,
                            Goals = 10,
                            MinutesPlayed = 1200,
                            RedCards = 0,
                            Saves = 0,
                            YellowCards = 2
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.PlayerStatisticsPerGame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Assists")
                        .HasColumnType("int")
                        .HasColumnName("Assists");

                    b.Property<int?>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int")
                        .HasColumnName("Goals");

                    b.Property<int>("MinutesPlayed")
                        .HasColumnType("int")
                        .HasColumnName("MinutesPlayed");

                    b.Property<int>("PassesCompleted")
                        .HasColumnType("int")
                        .HasColumnName("PassesCompleted");

                    b.Property<int?>("PlayersId")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int")
                        .HasColumnName("RedCards");

                    b.Property<int>("Saves")
                        .HasColumnType("int")
                        .HasColumnName("Saves");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int")
                        .HasColumnName("YellowCards");

                    b.HasKey("Id");

                    b.HasIndex("GamesId");

                    b.HasIndex("PlayersId");

                    b.ToTable("PlayerStatisticsPerGame");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Assists = 1,
                            Goals = 2,
                            MinutesPlayed = 90,
                            PassesCompleted = 30,
                            RedCards = 0,
                            Saves = 0,
                            YellowCards = 0
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Seats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Reserved")
                        .HasColumnType("bit")
                        .HasColumnName("Reserved");

                    b.Property<string>("SeatName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("SeatName");

                    b.Property<int>("SeatPrice")
                        .HasColumnType("int")
                        .HasColumnName("SeatPrice");

                    b.Property<int>("SeatType")
                        .HasColumnType("int")
                        .HasColumnName("SeatType");

                    b.Property<int?>("StadiumsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumsId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Reserved = false,
                            SeatName = "A1",
                            SeatPrice = 150,
                            SeatType = 3
                        },
                        new
                        {
                            Id = 2,
                            Reserved = false,
                            SeatName = "B2",
                            SeatPrice = 50,
                            SeatType = 0
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Stadiums", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<string>("StadiumLocation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("StadiumLocation");

                    b.Property<string>("StadiumName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("StadiumName");

                    b.HasKey("Id");

                    b.ToTable("Stadiums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 20000,
                            StadiumLocation = "Odobesti",
                            StadiumName = "Unirea Stadium"
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2000,
                            StadiumLocation = "Odobesti",
                            StadiumName = "Unirea U21 Stadium"
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 200,
                            StadiumLocation = "Odobesti",
                            StadiumName = "Unirea Youth Stadium"
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsInternal")
                        .HasColumnType("bit")
                        .HasColumnName("IsInternal");

                    b.Property<string>("Record")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Record");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TeamName");

                    b.Property<int>("TeamType")
                        .HasColumnType("int")
                        .HasColumnName("TeamType");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsInternal = true,
                            Record = " ",
                            TeamName = "FC Unirea",
                            TeamType = 0
                        },
                        new
                        {
                            Id = 2,
                            IsInternal = true,
                            Record = " ",
                            TeamName = "FC Unirea U21",
                            TeamType = 1
                        },
                        new
                        {
                            Id = 3,
                            IsInternal = true,
                            Record = " ",
                            TeamName = "FC Unirea Youth",
                            TeamType = 2
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.TeamStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CompetitionsId")
                        .HasColumnType("int");

                    b.Property<int>("GamesPlayed")
                        .HasColumnType("int")
                        .HasColumnName("GamesPlayed");

                    b.Property<int>("GoalsConceded")
                        .HasColumnType("int")
                        .HasColumnName("GoalsConceded");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int")
                        .HasColumnName("GoalsScored");

                    b.Property<int?>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int>("TotalDraws")
                        .HasColumnType("int")
                        .HasColumnName("TotalDraws");

                    b.Property<int>("TotalLosses")
                        .HasColumnType("int")
                        .HasColumnName("TotalLosses");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("int")
                        .HasColumnName("TotalPoints");

                    b.Property<int>("TotalWins")
                        .HasColumnType("int")
                        .HasColumnName("TotalWins");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("TeamStatistics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GamesPlayed = 15,
                            GoalsConceded = 15,
                            GoalsScored = 30,
                            TotalDraws = 3,
                            TotalLosses = 2,
                            TotalPoints = 33,
                            TotalWins = 10
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Tickets", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateReservation")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateReservation");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateReservation = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8441)
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("FirstName");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HashedPassword");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("PhoneNumber");

                    b.Property<int>("Role")
                        .HasColumnType("int")
                        .HasColumnName("Role");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8315),
                            Email = "admin@fcunirea.com",
                            FirstName = "Admin",
                            HashedPassword = "hashedpassword",
                            LastName = "User",
                            PhoneNumber = "0734567890",
                            Role = 0,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8322),
                            Email = "mariuspaun@example.com",
                            FirstName = "Marius",
                            HashedPassword = "hashedpassword",
                            LastName = "Paun",
                            PhoneNumber = "0787654321",
                            Role = 1,
                            Username = "mariuspaun"
                        });
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Comments", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.News", null)
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");

                    b.HasOne("FCUnirea.Domain.Entities.Users", null)
                        .WithMany("Comments")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Feedbacks", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Users", "FromStaff")
                        .WithMany("FeedbackFromStaff")
                        .HasForeignKey("FromStaffId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("FCUnirea.Domain.Entities.Users", "ToPlayer")
                        .WithMany("FeedbackToPlayers")
                        .HasForeignKey("ToPlayerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromStaff");

                    b.Navigation("ToPlayer");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Games", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Teams", "AwayTeam")
                        .WithMany()
                        .HasForeignKey("AwayTeamId");

                    b.HasOne("FCUnirea.Domain.Entities.Competitions", null)
                        .WithMany("Games")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Domain.Entities.Teams", "HomeTeam")
                        .WithMany()
                        .HasForeignKey("HomeTeamId");

                    b.HasOne("FCUnirea.Domain.Entities.Stadiums", null)
                        .WithMany("Games")
                        .HasForeignKey("StadiumsId");

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.News", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Users", null)
                        .WithMany("News")
                        .HasForeignKey("UsersId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Players", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Teams", null)
                        .WithMany("Players")
                        .HasForeignKey("TeamsId");

                    b.HasOne("FCUnirea.Domain.Entities.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.PlayerStatisticsPerCompetition", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Competitions", null)
                        .WithMany("PlayerStatisticsPerCompetiton")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Domain.Entities.Players", null)
                        .WithMany("PlayerStatisticsPerCompetitons")
                        .HasForeignKey("PlayersId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.PlayerStatisticsPerGame", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Games", null)
                        .WithMany("PlayerStatisticsPerGame")
                        .HasForeignKey("GamesId");

                    b.HasOne("FCUnirea.Domain.Entities.Players", null)
                        .WithMany("PlayerStatisticsPerGame")
                        .HasForeignKey("PlayersId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Seats", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Stadiums", null)
                        .WithMany("Seats")
                        .HasForeignKey("StadiumsId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.TeamStatistics", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Competitions", null)
                        .WithMany("TeamStatistics")
                        .HasForeignKey("CompetitionsId");

                    b.HasOne("FCUnirea.Domain.Entities.Teams", null)
                        .WithMany("TeamStatistics")
                        .HasForeignKey("TeamsId");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Tickets", b =>
                {
                    b.HasOne("FCUnirea.Domain.Entities.Games", null)
                        .WithMany("Tickets")
                        .HasForeignKey("GamesId");

                    b.HasOne("FCUnirea.Domain.Entities.Seats", "Seats")
                        .WithMany()
                        .HasForeignKey("SeatsId");

                    b.HasOne("FCUnirea.Domain.Entities.Users", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UsersId");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Competitions", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("PlayerStatisticsPerCompetiton");

                    b.Navigation("TeamStatistics");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Games", b =>
                {
                    b.Navigation("PlayerStatisticsPerGame");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.News", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Players", b =>
                {
                    b.Navigation("PlayerStatisticsPerCompetitons");

                    b.Navigation("PlayerStatisticsPerGame");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Stadiums", b =>
                {
                    b.Navigation("Games");

                    b.Navigation("Seats");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Teams", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("TeamStatistics");
                });

            modelBuilder.Entity("FCUnirea.Domain.Entities.Users", b =>
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
