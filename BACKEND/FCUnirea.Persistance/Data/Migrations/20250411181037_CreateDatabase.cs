using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCUnirea.Persistance.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompetitionType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StadiumName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StadiumLocation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TeamType = table.Column<int>(type: "int", nullable: false),
                    IsInternal = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CoachName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatType = table.Column<int>(type: "int", nullable: false),
                    SeatName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SeatPrice = table.Column<int>(type: "int", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeTeamScore = table.Column<int>(type: "int", nullable: false),
                    AwayTeamScore = table.Column<int>(type: "int", nullable: false),
                    TicketsSold = table.Column<int>(type: "int", nullable: false),
                    RefereeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    StadiumId = table.Column<int>(type: "int", nullable: false),
                    AwayTeamId = table.Column<int>(type: "int", nullable: false),
                    HomeTeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Stadiums_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GamesPlayed = table.Column<int>(type: "int", nullable: false),
                    TotalWins = table.Column<int>(type: "int", nullable: false),
                    TotalLosses = table.Column<int>(type: "int", nullable: false),
                    TotalDraws = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false),
                    GoalsConceded = table.Column<int>(type: "int", nullable: false),
                    TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStatistics_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamStatistics_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerCompetiton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerCompetiton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetiton_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetiton_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerGame_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Competitions",
                columns: new[] { "Id", "CompetitionName", "CompetitionType" },
                values: new object[,]
                {
                    { 1, "Liga 1", 0 },
                    { 2, "Cupa Romaniei", 1 },
                    { 3, "Champions League", 2 },
                    { 4, "Liga 1 U21", 0 },
                    { 5, "Cupa Romaniei U21", 1 },
                    { 6, "Champions League U21", 2 },
                    { 7, "Liga 1 Tineret", 0 },
                    { 8, "Cupa Romaniei Tineret", 1 },
                    { 9, "Champions League Tineret", 2 }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Capacity", "IsInternal", "StadiumLocation", "StadiumName" },
                values: new object[,]
                {
                    { 1, 10, true, "Odobesti", "Unirea Stadium" },
                    { 2, 18, false, "București", "Stadionul București" },
                    { 3, 13, false, "Cluj", "Stadionul Cluj" },
                    { 4, 8, false, "Iași", "Stadionul Iași" },
                    { 5, 25, false, "Timișoara", "Stadionul Timișoara" },
                    { 6, 8, false, "Ploiești", "Stadionul Ploiești" },
                    { 7, 14, false, "Oradea", "Stadionul Oradea" },
                    { 8, 30, false, "Brașov", "Stadionul Brașov" },
                    { 9, 29, false, "Constanța", "Stadionul Constanța" },
                    { 10, 27, false, "Sibiu", "Stadionul Sibiu" },
                    { 11, 10, true, "Odobesti", "Unirea U21 Stadium" },
                    { 12, 12, false, "Bacău", "Stadionul Bacău" },
                    { 13, 21, false, "Galați", "Stadionul Galați" },
                    { 14, 28, false, "Craiova", "Stadionul Craiova" },
                    { 15, 21, false, "Baia Mare", "Stadionul Baia Mare" },
                    { 16, 24, false, "Vaslui", "Stadionul Vaslui" },
                    { 17, 22, false, "Târgu Mureș", "Stadionul Târgu Mureș" },
                    { 18, 25, false, "Slatina", "Stadionul Slatina" },
                    { 19, 18, false, "Botoșani", "Stadionul Botoșani" },
                    { 20, 29, false, "Târgoviște", "Stadionul Târgoviște" },
                    { 21, 10, true, "Odobesti", "Unirea Youth Stadium" },
                    { 22, 12, false, "Alba Iulia", "Stadionul Alba Iulia" },
                    { 23, 16, false, "Pitești", "Stadionul Pitești" },
                    { 24, 11, false, "București", "Stadionul București" },
                    { 25, 20, false, "Cluj", "Stadionul Cluj" },
                    { 26, 20, false, "Iași", "Stadionul Iași" },
                    { 27, 19, false, "Timișoara", "Stadionul Timișoara" },
                    { 28, 18, false, "Ploiești", "Stadionul Ploiești" },
                    { 29, 18, false, "Oradea", "Stadionul Oradea" },
                    { 30, 21, false, "Brașov", "Stadionul Brașov" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "Description", "IsInternal", "TeamName", "TeamType" },
                values: new object[,]
                {
                    { 1, "Petrica Florea", " ", true, "FC Unirea", 0 },
                    { 2, "Radu Voicu", "Echipă externă din București", false, "Steaua Sud", 0 },
                    { 3, "Adrian Luca", "Club extern din liga a II-a", false, "Dinamo Est", 0 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "Description", "IsInternal", "TeamName", "TeamType" },
                values: new object[,]
                {
                    { 4, "Cezar Năstase", "Echipă tradițională externă", false, "Rapid Nord", 0 },
                    { 5, "Marius Costache", "Echipă externă din Ploiești", false, "Petrolul Vest", 0 },
                    { 6, "Paul Dobre", "Echipă din centru", false, "Universitatea Brașov", 0 },
                    { 7, "Ovidiu Stan", "Echipă externă din Cluj", false, "CSM Cluj", 0 },
                    { 8, "Toma Marinescu", "Echipă din Buzău", false, "Gloria Buzău", 0 },
                    { 9, "Cristian Filip", "Club tânăr și ambițios", false, "Viitorul Constanța", 0 },
                    { 10, "Ilie Andrei", "Echipă argeșeană", false, "CS Mioveni", 0 },
                    { 11, "Mihai Olaru", " ", true, "FC Unirea U21", 1 },
                    { 12, "Eugen Varga", "Echipă externă U21", false, "U21 Voluntari", 1 },
                    { 13, "Victor Drăghici", "Farul Constanța U21", false, "U21 Farul", 1 },
                    { 14, "Ervin Balogh", "Sepsi OSK U21", false, "U21 Sepsi", 1 },
                    { 15, "George Călinescu", "Tineret Poli", false, "U21 Poli Iași", 1 },
                    { 16, "Remus Cernat", "Arad U21", false, "U21 UTA", 1 },
                    { 17, "Mihai Răducan", "Pitești U21", false, "U21 Argeș", 1 },
                    { 18, "Dan Tănase", "Sibiu U21", false, "U21 Hermannstadt", 1 },
                    { 19, "Florin Istrate", "Nord U21", false, "U21 Botoșani", 1 },
                    { 20, "Marius Ilie", "Oltenia U21", false, "U21 Slatina", 1 },
                    { 21, "Nica Cercel", " ", true, "FC Unirea Youth", 2 },
                    { 22, "Lavinia Andrei", "Grupa mică externă", false, "Youth Galați", 2 },
                    { 23, "Răzvan Cioran", "Copii sub 13 ani", false, "Youth Hunedoara", 2 },
                    { 24, "Silviu Coman", "Târgoviște Kids", false, "Youth Târgoviște", 2 },
                    { 25, "Mihai Leahu", "Zona Moldova", false, "Youth Vaslui", 2 },
                    { 26, "Adrian Cârciumaru", "Nord-Vest", false, "Youth Baia Mare", 2 },
                    { 27, "Viorel Neagu", "Oltenia Kids", false, "Youth Craiova", 2 },
                    { 28, "Andrei Moga", "Muntenia copii", false, "Youth Ploiești", 2 },
                    { 29, "Emil Crețu", "Echipă externă pentru juniori", false, "Youth Oradea", 2 },
                    { 30, "Flavius Pop", "Vest Kids", false, "Youth Arad", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@fcunirea.ro", "Admin", "Unirea", "aJJ6n23eBDAvvkgbNkbqVw==:Rkl+y/HGK2F3orm8uko70zncakYXDXmWAcTEheRZJCg=", "0712345678", 0, "admin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@fcunirea.ro", "Ion", "Popescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000001", 1, "user1" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2@fcunirea.ro", "Ana", "Ionescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000002", 1, "user2" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3@fcunirea.ro", "George", "Marin", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000003", 1, "user3" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4@fcunirea.ro", "Elena", "Dumitru", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000004", 1, "user4" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5@fcunirea.ro", "Mihai", "Stan", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000005", 1, "user5" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6@fcunirea.ro", "Bianca", "Toma", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000006", 1, "user6" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7@fcunirea.ro", "Alex", "Vasilescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000007", 1, "user7" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8@fcunirea.ro", "Diana", "Radu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000008", 1, "user8" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9@fcunirea.ro", "Tudor", "Matei", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000009", 1, "user9" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10@fcunirea.ro", "Andreea", "Ilie", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000010", 1, "user10" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 1, 1, 2, "Arbitru 1", 5 },
                    { 2, 0, new DateTime(2025, 4, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 2, 2, 0, "Arbitru 2", 9 },
                    { 3, 1, new DateTime(2025, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 3, 3, 2, "Arbitru 3", 6 },
                    { 4, 1, new DateTime(2025, 4, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 4, 4, 0, "Arbitru 4", 4 },
                    { 5, 2, new DateTime(2025, 4, 14, 2, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 5, 5, 1, "Arbitru 5", 12 },
                    { 6, 0, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 11, 11, 0, "Arbitru 6", 5 },
                    { 7, 3, new DateTime(2025, 4, 16, 1, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 12, 12, 2, "Arbitru 7", 6 },
                    { 8, 3, new DateTime(2025, 4, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 13, 13, 3, "Arbitru 8", 7 },
                    { 9, 1, new DateTime(2025, 4, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 14, 14, 2, "Arbitru 9", 8 },
                    { 10, 3, new DateTime(2025, 4, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 15, 15, 2, "Arbitru 10", 9 },
                    { 11, 1, new DateTime(2025, 4, 20, 3, 0, 0, 0, DateTimeKind.Unspecified), 26, 7, 21, 21, 2, "Arbitru 11", 5 },
                    { 12, 1, new DateTime(2025, 4, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), 27, 7, 22, 22, 2, "Arbitru 12", 4 },
                    { 13, 0, new DateTime(2025, 4, 22, 5, 0, 0, 0, DateTimeKind.Unspecified), 28, 7, 23, 23, 2, "Arbitru 13", 3 },
                    { 14, 1, new DateTime(2025, 4, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), 29, 7, 24, 24, 2, "Arbitru 14", 4 },
                    { 15, 2, new DateTime(2025, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified), 30, 7, 25, 25, 1, "Arbitru 15", 5 }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "UsersId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(506), 1, "Vezi cum a decurs meciul cu ID 1.", "Rezultatul meciului #1" },
                    { 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(507), 1, "Vezi cum a decurs meciul cu ID 2.", "Rezultatul meciului #2" },
                    { 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(508), 1, "Vezi cum a decurs meciul cu ID 3.", "Rezultatul meciului #3" },
                    { 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(508), 1, "Vezi cum a decurs meciul cu ID 4.", "Rezultatul meciului #4" },
                    { 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(509), 1, "Vezi cum a decurs meciul cu ID 5.", "Rezultatul meciului #5" },
                    { 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(510), 1, "Vezi cum a decurs meciul cu ID 6.", "Rezultatul meciului #6" },
                    { 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(538), 1, "Vezi cum a decurs meciul cu ID 7.", "Rezultatul meciului #7" },
                    { 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(539), 1, "Vezi cum a decurs meciul cu ID 8.", "Rezultatul meciului #8" },
                    { 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(540), 1, "Vezi cum a decurs meciul cu ID 9.", "Rezultatul meciului #9" },
                    { 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(541), 1, "Vezi cum a decurs meciul cu ID 10.", "Rezultatul meciului #10" },
                    { 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(541), 1, "Vezi cum a decurs meciul cu ID 11.", "Rezultatul meciului #11" },
                    { 12, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(542), 1, "Vezi cum a decurs meciul cu ID 12.", "Rezultatul meciului #12" },
                    { 13, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(543), 1, "Vezi cum a decurs meciul cu ID 13.", "Rezultatul meciului #13" },
                    { 14, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(543), 1, "Vezi cum a decurs meciul cu ID 14.", "Rezultatul meciului #14" },
                    { 15, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(544), 1, "Vezi cum a decurs meciul cu ID 15.", "Rezultatul meciului #15" }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 1, new DateTime(1996, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Popescu", 1, 2 },
                    { 2, new DateTime(2003, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Stan", 1, 0 },
                    { 3, new DateTime(2000, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Toma", 1, 1 },
                    { 4, new DateTime(1999, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ilie", 1, 2 },
                    { 5, new DateTime(1994, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Matei", 1, 1 },
                    { 6, new DateTime(1994, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Vasilescu", 1, 0 },
                    { 7, new DateTime(1992, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Radulescu", 1, 3 },
                    { 8, new DateTime(1995, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Lazar", 1, 2 },
                    { 9, new DateTime(1990, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Chiriac", 1, 1 },
                    { 10, new DateTime(1998, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Enache", 1, 2 },
                    { 11, new DateTime(1997, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Chiriac", 1, 3 },
                    { 12, new DateTime(1999, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Neagu", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 13, new DateTime(2006, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Neagu", 1, 3 },
                    { 14, new DateTime(1991, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Ilie", 1, 0 },
                    { 15, new DateTime(2004, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ilie", 1, 1 },
                    { 16, new DateTime(2005, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 1, 1 },
                    { 17, new DateTime(2004, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Neagu", 1, 2 },
                    { 18, new DateTime(2004, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Radulescu", 1, 3 },
                    { 19, new DateTime(1996, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Vasilescu", 1, 2 },
                    { 20, new DateTime(1990, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Enache", 1, 2 },
                    { 21, new DateTime(1992, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 2, 1 },
                    { 22, new DateTime(1991, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 2, 1 },
                    { 23, new DateTime(1990, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Cojocaru", 2, 1 },
                    { 24, new DateTime(1990, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Radulescu", 2, 2 },
                    { 25, new DateTime(2000, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Chiriac", 2, 0 },
                    { 26, new DateTime(1999, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Vasilescu", 2, 3 },
                    { 27, new DateTime(2006, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Georgescu", 2, 2 },
                    { 28, new DateTime(1992, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Diaconu", 2, 2 },
                    { 29, new DateTime(2004, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Ionescu", 2, 3 },
                    { 30, new DateTime(1990, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 2, 3 },
                    { 31, new DateTime(2005, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Georgescu", 2, 3 },
                    { 32, new DateTime(2005, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 2, 1 },
                    { 33, new DateTime(1993, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Cojocaru", 2, 2 },
                    { 34, new DateTime(2002, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Enache", 2, 3 },
                    { 35, new DateTime(1990, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Popescu", 2, 1 },
                    { 36, new DateTime(2004, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Neagu", 2, 1 },
                    { 37, new DateTime(2005, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 2, 1 },
                    { 38, new DateTime(1999, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Marin", 2, 2 },
                    { 39, new DateTime(2002, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Marin", 2, 2 },
                    { 40, new DateTime(2004, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Stan", 2, 2 },
                    { 41, new DateTime(1999, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Ilie", 3, 3 },
                    { 42, new DateTime(2006, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ionescu", 3, 1 },
                    { 43, new DateTime(1991, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Neagu", 3, 1 },
                    { 44, new DateTime(1999, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Chiriac", 3, 0 },
                    { 45, new DateTime(2002, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Marin", 3, 3 },
                    { 46, new DateTime(1996, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Vasilescu", 3, 2 },
                    { 47, new DateTime(1996, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Dumitrescu", 3, 0 },
                    { 48, new DateTime(1995, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Marin", 3, 0 },
                    { 49, new DateTime(1990, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Chiriac", 3, 2 },
                    { 50, new DateTime(1996, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Barbu", 3, 1 },
                    { 51, new DateTime(1994, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Marin", 3, 1 },
                    { 52, new DateTime(2004, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Dumitrescu", 3, 0 },
                    { 53, new DateTime(1991, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Toma", 3, 2 },
                    { 54, new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Radulescu", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 55, new DateTime(2005, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Chiriac", 3, 2 },
                    { 56, new DateTime(1991, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Toma", 3, 0 },
                    { 57, new DateTime(2003, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Popescu", 3, 3 },
                    { 58, new DateTime(1990, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Neagu", 3, 2 },
                    { 59, new DateTime(2000, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 3, 2 },
                    { 60, new DateTime(1994, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Stan", 3, 2 },
                    { 61, new DateTime(1990, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Georgescu", 4, 1 },
                    { 62, new DateTime(1997, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 4, 3 },
                    { 63, new DateTime(2003, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Petrescu", 4, 1 },
                    { 64, new DateTime(2004, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Marin", 4, 2 },
                    { 65, new DateTime(1995, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ilie", 4, 2 },
                    { 66, new DateTime(2000, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Georgescu", 4, 3 },
                    { 67, new DateTime(2001, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Vasilescu", 4, 1 },
                    { 68, new DateTime(1995, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Matei", 4, 1 },
                    { 69, new DateTime(1999, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Toma", 4, 3 },
                    { 70, new DateTime(1993, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Neagu", 4, 1 },
                    { 71, new DateTime(1993, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 4, 2 },
                    { 72, new DateTime(2000, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Barbu", 4, 1 },
                    { 73, new DateTime(1996, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cojocaru", 4, 0 },
                    { 74, new DateTime(1996, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 4, 0 },
                    { 75, new DateTime(2004, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 4, 0 },
                    { 76, new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Vasilescu", 4, 0 },
                    { 77, new DateTime(1991, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Enache", 4, 3 },
                    { 78, new DateTime(2002, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Matei", 4, 2 },
                    { 79, new DateTime(1999, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 4, 3 },
                    { 80, new DateTime(2005, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Barbu", 4, 0 },
                    { 81, new DateTime(1992, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Lazar", 5, 3 },
                    { 82, new DateTime(2002, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ionescu", 5, 2 },
                    { 83, new DateTime(2004, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 5, 1 },
                    { 84, new DateTime(1999, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Toma", 5, 3 },
                    { 85, new DateTime(1993, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Popescu", 5, 3 },
                    { 86, new DateTime(1994, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Petrescu", 5, 3 },
                    { 87, new DateTime(2003, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Chiriac", 5, 0 },
                    { 88, new DateTime(1992, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Popescu", 5, 0 },
                    { 89, new DateTime(1991, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Toma", 5, 1 },
                    { 90, new DateTime(1991, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Petrescu", 5, 1 },
                    { 91, new DateTime(1994, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Voicu", 5, 1 },
                    { 92, new DateTime(1996, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Georgescu", 5, 0 },
                    { 93, new DateTime(1994, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Petrescu", 5, 3 },
                    { 94, new DateTime(1992, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 5, 3 },
                    { 95, new DateTime(1996, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Stan", 5, 1 },
                    { 96, new DateTime(1991, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Popescu", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 97, new DateTime(1992, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Voicu", 5, 1 },
                    { 98, new DateTime(2003, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Dumitrescu", 5, 1 },
                    { 99, new DateTime(2001, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Georgescu", 5, 3 },
                    { 100, new DateTime(2003, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Petrescu", 5, 2 },
                    { 101, new DateTime(1992, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Marin", 6, 2 },
                    { 102, new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Voicu", 6, 0 },
                    { 103, new DateTime(1993, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Dumitrescu", 6, 0 },
                    { 104, new DateTime(1992, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Voicu", 6, 0 },
                    { 105, new DateTime(1994, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ilie", 6, 1 },
                    { 106, new DateTime(1997, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 6, 3 },
                    { 107, new DateTime(1995, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Radulescu", 6, 2 },
                    { 108, new DateTime(1992, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Diaconu", 6, 0 },
                    { 109, new DateTime(1999, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Enache", 6, 1 },
                    { 110, new DateTime(2000, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Cojocaru", 6, 1 },
                    { 111, new DateTime(2006, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Matei", 6, 2 },
                    { 112, new DateTime(2004, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Georgescu", 6, 2 },
                    { 113, new DateTime(2004, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Ionescu", 6, 0 },
                    { 114, new DateTime(1991, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Diaconu", 6, 0 },
                    { 115, new DateTime(1994, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Chiriac", 6, 2 },
                    { 116, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Lazar", 6, 3 },
                    { 117, new DateTime(2000, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 6, 3 },
                    { 118, new DateTime(1998, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Marin", 6, 3 },
                    { 119, new DateTime(2003, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Enache", 6, 1 },
                    { 120, new DateTime(2006, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Neagu", 6, 2 },
                    { 121, new DateTime(1998, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Enache", 7, 3 },
                    { 122, new DateTime(2001, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Ionescu", 7, 1 },
                    { 123, new DateTime(2004, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Chiriac", 7, 3 },
                    { 124, new DateTime(1999, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Lazar", 7, 1 },
                    { 125, new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Cojocaru", 7, 3 },
                    { 126, new DateTime(1990, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Stan", 7, 3 },
                    { 127, new DateTime(1995, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 7, 3 },
                    { 128, new DateTime(1998, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Radulescu", 7, 1 },
                    { 129, new DateTime(2003, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Voicu", 7, 3 },
                    { 130, new DateTime(2001, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Radulescu", 7, 1 },
                    { 131, new DateTime(2000, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Neagu", 7, 3 },
                    { 132, new DateTime(2005, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Toma", 7, 2 },
                    { 133, new DateTime(1998, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Vasilescu", 7, 2 },
                    { 134, new DateTime(1994, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Radulescu", 7, 0 },
                    { 135, new DateTime(2001, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Vasilescu", 7, 0 },
                    { 136, new DateTime(1990, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Neagu", 7, 2 },
                    { 137, new DateTime(1999, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Dumitrescu", 7, 1 },
                    { 138, new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Matei", 7, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 139, new DateTime(2000, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cojocaru", 7, 2 },
                    { 140, new DateTime(1997, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Neagu", 7, 1 },
                    { 141, new DateTime(2003, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Lazar", 8, 2 },
                    { 142, new DateTime(1999, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Vasilescu", 8, 0 },
                    { 143, new DateTime(1996, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Cojocaru", 8, 0 },
                    { 144, new DateTime(1993, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 8, 3 },
                    { 145, new DateTime(2003, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Georgescu", 8, 1 },
                    { 146, new DateTime(1998, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Ionescu", 8, 0 },
                    { 147, new DateTime(1998, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Neagu", 8, 0 },
                    { 148, new DateTime(1992, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Marin", 8, 3 },
                    { 149, new DateTime(2001, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Barbu", 8, 1 },
                    { 150, new DateTime(2004, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Marin", 8, 2 },
                    { 151, new DateTime(1993, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Ilie", 8, 3 },
                    { 152, new DateTime(1991, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Voicu", 8, 0 },
                    { 153, new DateTime(2002, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Ionescu", 8, 0 },
                    { 154, new DateTime(1991, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Voicu", 8, 1 },
                    { 155, new DateTime(2001, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Cojocaru", 8, 3 },
                    { 156, new DateTime(1990, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Diaconu", 8, 3 },
                    { 157, new DateTime(2004, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Marin", 8, 1 },
                    { 158, new DateTime(1999, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Marin", 8, 1 },
                    { 159, new DateTime(1998, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Toma", 8, 3 },
                    { 160, new DateTime(2006, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Stan", 8, 3 },
                    { 161, new DateTime(2005, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 9, 1 },
                    { 162, new DateTime(1992, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Petrescu", 9, 0 },
                    { 163, new DateTime(1996, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Vasilescu", 9, 2 },
                    { 164, new DateTime(1992, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Stan", 9, 3 },
                    { 165, new DateTime(1990, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Marin", 9, 0 },
                    { 166, new DateTime(1997, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Ilie", 9, 3 },
                    { 167, new DateTime(2001, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Enache", 9, 3 },
                    { 168, new DateTime(1992, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Toma", 9, 2 },
                    { 169, new DateTime(1998, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Enache", 9, 0 },
                    { 170, new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 9, 3 },
                    { 171, new DateTime(1991, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Petrescu", 9, 1 },
                    { 172, new DateTime(1997, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Lazar", 9, 0 },
                    { 173, new DateTime(2002, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Matei", 9, 3 },
                    { 174, new DateTime(2003, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ilie", 9, 1 },
                    { 175, new DateTime(1994, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Voicu", 9, 0 },
                    { 176, new DateTime(2000, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Enache", 9, 1 },
                    { 177, new DateTime(1999, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Barbu", 9, 3 },
                    { 178, new DateTime(1997, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 9, 3 },
                    { 179, new DateTime(1992, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Matei", 9, 1 },
                    { 180, new DateTime(1997, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Popescu", 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 181, new DateTime(1995, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Radulescu", 10, 2 },
                    { 182, new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 10, 2 },
                    { 183, new DateTime(2004, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Voicu", 10, 1 },
                    { 184, new DateTime(2003, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Voicu", 10, 0 },
                    { 185, new DateTime(1991, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Ilie", 10, 1 },
                    { 186, new DateTime(2002, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Lazar", 10, 0 },
                    { 187, new DateTime(2006, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 10, 0 },
                    { 188, new DateTime(1996, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Diaconu", 10, 1 },
                    { 189, new DateTime(1996, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Ilie", 10, 3 },
                    { 190, new DateTime(1992, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Petrescu", 10, 2 },
                    { 191, new DateTime(2000, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Chiriac", 10, 2 },
                    { 192, new DateTime(1992, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Cojocaru", 10, 1 },
                    { 193, new DateTime(2001, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Ionescu", 10, 3 },
                    { 194, new DateTime(2006, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ionescu", 10, 2 },
                    { 195, new DateTime(1995, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Toma", 10, 3 },
                    { 196, new DateTime(1993, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 10, 1 },
                    { 197, new DateTime(1993, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Diaconu", 10, 2 },
                    { 198, new DateTime(2000, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Radulescu", 10, 3 },
                    { 199, new DateTime(2003, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Diaconu", 10, 1 },
                    { 200, new DateTime(2001, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Marin", 10, 1 },
                    { 201, new DateTime(2005, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Ilie", 11, 0 },
                    { 202, new DateTime(2004, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Ionescu", 11, 0 },
                    { 203, new DateTime(2004, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Lazar", 11, 3 },
                    { 204, new DateTime(2008, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Ilie", 11, 1 },
                    { 205, new DateTime(2006, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Georgescu", 11, 3 },
                    { 206, new DateTime(2005, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Matei", 11, 1 },
                    { 207, new DateTime(2006, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Diaconu", 11, 2 },
                    { 208, new DateTime(2008, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Dumitrescu", 11, 3 },
                    { 209, new DateTime(2007, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Toma", 11, 2 },
                    { 210, new DateTime(2004, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Diaconu", 11, 2 },
                    { 211, new DateTime(2005, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Diaconu", 11, 3 },
                    { 212, new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Voicu", 11, 2 },
                    { 213, new DateTime(2008, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Cojocaru", 11, 1 },
                    { 214, new DateTime(2007, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Radulescu", 11, 0 },
                    { 215, new DateTime(2005, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Radulescu", 11, 2 },
                    { 216, new DateTime(2005, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Matei", 11, 0 },
                    { 217, new DateTime(2004, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Neagu", 11, 0 },
                    { 218, new DateTime(2007, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Dumitrescu", 11, 3 },
                    { 219, new DateTime(2007, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cojocaru", 11, 1 },
                    { 220, new DateTime(2004, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 11, 0 },
                    { 221, new DateTime(2007, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Diaconu", 12, 0 },
                    { 222, new DateTime(2008, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Neagu", 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 223, new DateTime(2007, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Stan", 12, 1 },
                    { 224, new DateTime(2006, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 12, 0 },
                    { 225, new DateTime(2006, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Marin", 12, 2 },
                    { 226, new DateTime(2006, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Popescu", 12, 1 },
                    { 227, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Voicu", 12, 0 },
                    { 228, new DateTime(2004, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 12, 0 },
                    { 229, new DateTime(2007, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 12, 1 },
                    { 230, new DateTime(2007, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Marin", 12, 2 },
                    { 231, new DateTime(2007, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 12, 0 },
                    { 232, new DateTime(2005, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Marin", 12, 2 },
                    { 233, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Radulescu", 12, 1 },
                    { 234, new DateTime(2008, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 12, 3 },
                    { 235, new DateTime(2006, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 12, 1 },
                    { 236, new DateTime(2004, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Diaconu", 12, 3 },
                    { 237, new DateTime(2005, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ionescu", 12, 1 },
                    { 238, new DateTime(2006, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Petrescu", 12, 0 },
                    { 239, new DateTime(2005, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Lazar", 12, 3 },
                    { 240, new DateTime(2007, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Popescu", 12, 1 },
                    { 241, new DateTime(2004, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Matei", 13, 0 },
                    { 242, new DateTime(2008, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Voicu", 13, 0 },
                    { 243, new DateTime(2008, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Matei", 13, 2 },
                    { 244, new DateTime(2007, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Petrescu", 13, 2 },
                    { 245, new DateTime(2007, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ionescu", 13, 3 },
                    { 246, new DateTime(2005, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 13, 3 },
                    { 247, new DateTime(2005, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Diaconu", 13, 3 },
                    { 248, new DateTime(2006, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 13, 3 },
                    { 249, new DateTime(2007, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Enache", 13, 2 },
                    { 250, new DateTime(2004, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Marin", 13, 0 },
                    { 251, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Radulescu", 13, 0 },
                    { 252, new DateTime(2005, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Barbu", 13, 3 },
                    { 253, new DateTime(2004, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Neagu", 13, 3 },
                    { 254, new DateTime(2005, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Diaconu", 13, 0 },
                    { 255, new DateTime(2007, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cojocaru", 13, 1 },
                    { 256, new DateTime(2004, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Petrescu", 13, 1 },
                    { 257, new DateTime(2004, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Barbu", 13, 1 },
                    { 258, new DateTime(2008, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Radulescu", 13, 3 },
                    { 259, new DateTime(2006, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Toma", 13, 0 },
                    { 260, new DateTime(2004, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Stan", 13, 1 },
                    { 261, new DateTime(2007, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Barbu", 14, 2 },
                    { 262, new DateTime(2007, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Voicu", 14, 1 },
                    { 263, new DateTime(2006, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Barbu", 14, 3 },
                    { 264, new DateTime(2004, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Lazar", 14, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 265, new DateTime(2004, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 14, 2 },
                    { 266, new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Lazar", 14, 2 },
                    { 267, new DateTime(2005, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 14, 2 },
                    { 268, new DateTime(2004, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Toma", 14, 1 },
                    { 269, new DateTime(2007, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Cojocaru", 14, 0 },
                    { 270, new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 14, 3 },
                    { 271, new DateTime(2008, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Voicu", 14, 3 },
                    { 272, new DateTime(2008, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ionescu", 14, 1 },
                    { 273, new DateTime(2004, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ilie", 14, 1 },
                    { 274, new DateTime(2007, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Marin", 14, 3 },
                    { 275, new DateTime(2005, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 14, 3 },
                    { 276, new DateTime(2004, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Barbu", 14, 2 },
                    { 277, new DateTime(2004, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Ilie", 14, 0 },
                    { 278, new DateTime(2004, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Petrescu", 14, 2 },
                    { 279, new DateTime(2007, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Radulescu", 14, 0 },
                    { 280, new DateTime(2008, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Georgescu", 14, 1 },
                    { 281, new DateTime(2006, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 15, 1 },
                    { 282, new DateTime(2007, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 15, 3 },
                    { 283, new DateTime(2008, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Cojocaru", 15, 0 },
                    { 284, new DateTime(2007, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Georgescu", 15, 3 },
                    { 285, new DateTime(2005, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Lazar", 15, 3 },
                    { 286, new DateTime(2007, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Neagu", 15, 0 },
                    { 287, new DateTime(2008, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Ionescu", 15, 0 },
                    { 288, new DateTime(2006, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 15, 2 },
                    { 289, new DateTime(2004, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Voicu", 15, 0 },
                    { 290, new DateTime(2005, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Voicu", 15, 1 },
                    { 291, new DateTime(2008, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Barbu", 15, 1 },
                    { 292, new DateTime(2005, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Diaconu", 15, 1 },
                    { 293, new DateTime(2007, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Matei", 15, 2 },
                    { 294, new DateTime(2008, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Voicu", 15, 3 },
                    { 295, new DateTime(2006, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Diaconu", 15, 0 },
                    { 296, new DateTime(2007, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ilie", 15, 2 },
                    { 297, new DateTime(2005, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Marin", 15, 2 },
                    { 298, new DateTime(2008, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Marin", 15, 2 },
                    { 299, new DateTime(2006, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Cojocaru", 15, 2 },
                    { 300, new DateTime(2005, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Ilie", 15, 0 },
                    { 301, new DateTime(2006, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Dumitrescu", 16, 1 },
                    { 302, new DateTime(2004, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Lazar", 16, 3 },
                    { 303, new DateTime(2008, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Diaconu", 16, 3 },
                    { 304, new DateTime(2007, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Neagu", 16, 3 },
                    { 305, new DateTime(2005, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Radulescu", 16, 1 },
                    { 306, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Voicu", 16, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 307, new DateTime(2008, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Marin", 16, 0 },
                    { 308, new DateTime(2007, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Radulescu", 16, 0 },
                    { 309, new DateTime(2007, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Diaconu", 16, 0 },
                    { 310, new DateTime(2004, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Ionescu", 16, 1 },
                    { 311, new DateTime(2007, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 16, 0 },
                    { 312, new DateTime(2004, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Popescu", 16, 0 },
                    { 313, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Toma", 16, 0 },
                    { 314, new DateTime(2006, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 16, 0 },
                    { 315, new DateTime(2006, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Petrescu", 16, 3 },
                    { 316, new DateTime(2004, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Popescu", 16, 3 },
                    { 317, new DateTime(2006, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Petrescu", 16, 3 },
                    { 318, new DateTime(2006, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Radulescu", 16, 2 },
                    { 319, new DateTime(2005, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Stan", 16, 1 },
                    { 320, new DateTime(2008, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Enache", 16, 2 },
                    { 321, new DateTime(2004, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Vasilescu", 17, 1 },
                    { 322, new DateTime(2004, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Dumitrescu", 17, 2 },
                    { 323, new DateTime(2008, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Barbu", 17, 3 },
                    { 324, new DateTime(2008, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Vasilescu", 17, 3 },
                    { 325, new DateTime(2007, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Ilie", 17, 1 },
                    { 326, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Neagu", 17, 1 },
                    { 327, new DateTime(2007, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Georgescu", 17, 0 },
                    { 328, new DateTime(2004, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Voicu", 17, 3 },
                    { 329, new DateTime(2004, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Cojocaru", 17, 1 },
                    { 330, new DateTime(2008, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Vasilescu", 17, 2 },
                    { 331, new DateTime(2007, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Matei", 17, 2 },
                    { 332, new DateTime(2004, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Popescu", 17, 2 },
                    { 333, new DateTime(2007, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Voicu", 17, 2 },
                    { 334, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Diaconu", 17, 2 },
                    { 335, new DateTime(2007, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Georgescu", 17, 0 },
                    { 336, new DateTime(2008, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Barbu", 17, 1 },
                    { 337, new DateTime(2007, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Enache", 17, 1 },
                    { 338, new DateTime(2008, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Marin", 17, 1 },
                    { 339, new DateTime(2005, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cojocaru", 17, 1 },
                    { 340, new DateTime(2007, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Lazar", 17, 1 },
                    { 341, new DateTime(2006, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Marin", 18, 0 },
                    { 342, new DateTime(2004, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Ionescu", 18, 0 },
                    { 343, new DateTime(2008, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Voicu", 18, 3 },
                    { 344, new DateTime(2004, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Chiriac", 18, 2 },
                    { 345, new DateTime(2006, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Toma", 18, 0 },
                    { 346, new DateTime(2008, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Matei", 18, 1 },
                    { 347, new DateTime(2006, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Marin", 18, 1 },
                    { 348, new DateTime(2006, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Enache", 18, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 349, new DateTime(2004, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 18, 2 },
                    { 350, new DateTime(2004, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Diaconu", 18, 2 },
                    { 351, new DateTime(2005, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 18, 1 },
                    { 352, new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Radulescu", 18, 3 },
                    { 353, new DateTime(2006, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Matei", 18, 0 },
                    { 354, new DateTime(2005, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Petrescu", 18, 1 },
                    { 355, new DateTime(2005, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Neagu", 18, 2 },
                    { 356, new DateTime(2006, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Matei", 18, 0 },
                    { 357, new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Matei", 18, 3 },
                    { 358, new DateTime(2008, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Vasilescu", 18, 1 },
                    { 359, new DateTime(2007, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Radulescu", 18, 1 },
                    { 360, new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Popescu", 18, 1 },
                    { 361, new DateTime(2007, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 19, 2 },
                    { 362, new DateTime(2007, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Marin", 19, 2 },
                    { 363, new DateTime(2007, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Vasilescu", 19, 2 },
                    { 364, new DateTime(2005, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Ionescu", 19, 3 },
                    { 365, new DateTime(2004, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Cojocaru", 19, 2 },
                    { 366, new DateTime(2006, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Dumitrescu", 19, 1 },
                    { 367, new DateTime(2008, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Dumitrescu", 19, 2 },
                    { 368, new DateTime(2007, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Ilie", 19, 1 },
                    { 369, new DateTime(2004, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Lazar", 19, 0 },
                    { 370, new DateTime(2005, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Petrescu", 19, 0 },
                    { 371, new DateTime(2004, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Vasilescu", 19, 2 },
                    { 372, new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Ionescu", 19, 0 },
                    { 373, new DateTime(2005, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ilie", 19, 1 },
                    { 374, new DateTime(2006, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Toma", 19, 1 },
                    { 375, new DateTime(2008, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Stan", 19, 0 },
                    { 376, new DateTime(2007, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Ilie", 19, 2 },
                    { 377, new DateTime(2007, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Marin", 19, 1 },
                    { 378, new DateTime(2007, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Radulescu", 19, 3 },
                    { 379, new DateTime(2007, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Vasilescu", 19, 2 },
                    { 380, new DateTime(2007, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ionescu", 19, 1 },
                    { 381, new DateTime(2005, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Dumitrescu", 20, 3 },
                    { 382, new DateTime(2008, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Chiriac", 20, 0 },
                    { 383, new DateTime(2005, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Voicu", 20, 0 },
                    { 384, new DateTime(2004, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Popescu", 20, 3 },
                    { 385, new DateTime(2004, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Radulescu", 20, 0 },
                    { 386, new DateTime(2006, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Voicu", 20, 0 },
                    { 387, new DateTime(2008, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Georgescu", 20, 1 },
                    { 388, new DateTime(2007, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Toma", 20, 1 },
                    { 389, new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Diaconu", 20, 2 },
                    { 390, new DateTime(2006, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Dumitrescu", 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 391, new DateTime(2007, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 20, 1 },
                    { 392, new DateTime(2007, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Barbu", 20, 1 },
                    { 393, new DateTime(2006, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Georgescu", 20, 1 },
                    { 394, new DateTime(2004, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 20, 2 },
                    { 395, new DateTime(2008, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Lazar", 20, 3 },
                    { 396, new DateTime(2006, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Cojocaru", 20, 0 },
                    { 397, new DateTime(2005, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Georgescu", 20, 1 },
                    { 398, new DateTime(2004, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Cojocaru", 20, 2 },
                    { 399, new DateTime(2007, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 20, 3 },
                    { 400, new DateTime(2008, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ionescu", 20, 0 },
                    { 401, new DateTime(2011, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Radulescu", 21, 0 },
                    { 402, new DateTime(2011, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 21, 3 },
                    { 403, new DateTime(2012, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ilie", 21, 3 },
                    { 404, new DateTime(2012, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Vasilescu", 21, 1 },
                    { 405, new DateTime(2009, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Ionescu", 21, 1 },
                    { 406, new DateTime(2009, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 21, 3 },
                    { 407, new DateTime(2011, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 21, 1 },
                    { 408, new DateTime(2011, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Ionescu", 21, 2 },
                    { 409, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Cojocaru", 21, 3 },
                    { 410, new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Enache", 21, 1 },
                    { 411, new DateTime(2011, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Vasilescu", 21, 3 },
                    { 412, new DateTime(2010, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Vasilescu", 21, 1 },
                    { 413, new DateTime(2009, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Ionescu", 21, 0 },
                    { 414, new DateTime(2009, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Toma", 21, 1 },
                    { 415, new DateTime(2010, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Neagu", 21, 3 },
                    { 416, new DateTime(2011, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Neagu", 21, 1 },
                    { 417, new DateTime(2010, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Neagu", 21, 0 },
                    { 418, new DateTime(2010, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Chiriac", 21, 3 },
                    { 419, new DateTime(2010, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ilie", 21, 1 },
                    { 420, new DateTime(2009, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Diaconu", 21, 0 },
                    { 421, new DateTime(2009, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Marin", 22, 0 },
                    { 422, new DateTime(2012, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Dumitrescu", 22, 3 },
                    { 423, new DateTime(2012, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Marin", 22, 0 },
                    { 424, new DateTime(2011, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Radulescu", 22, 3 },
                    { 425, new DateTime(2010, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Toma", 22, 3 },
                    { 426, new DateTime(2012, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Ilie", 22, 0 },
                    { 427, new DateTime(2010, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Neagu", 22, 2 },
                    { 428, new DateTime(2012, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Voicu", 22, 2 },
                    { 429, new DateTime(2009, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Toma", 22, 2 },
                    { 430, new DateTime(2012, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Vasilescu", 22, 2 },
                    { 431, new DateTime(2011, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Barbu", 22, 0 },
                    { 432, new DateTime(2010, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Chiriac", 22, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 433, new DateTime(2011, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Lazar", 22, 1 },
                    { 434, new DateTime(2011, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Marin", 22, 3 },
                    { 435, new DateTime(2011, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Neagu", 22, 2 },
                    { 436, new DateTime(2009, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 22, 1 },
                    { 437, new DateTime(2009, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Vasilescu", 22, 2 },
                    { 438, new DateTime(2010, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Lazar", 22, 1 },
                    { 439, new DateTime(2012, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Dumitrescu", 22, 1 },
                    { 440, new DateTime(2012, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Petrescu", 22, 2 },
                    { 441, new DateTime(2010, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Neagu", 23, 0 },
                    { 442, new DateTime(2010, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Barbu", 23, 2 },
                    { 443, new DateTime(2012, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Barbu", 23, 1 },
                    { 444, new DateTime(2009, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Voicu", 23, 3 },
                    { 445, new DateTime(2011, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Popescu", 23, 3 },
                    { 446, new DateTime(2011, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Lazar", 23, 2 },
                    { 447, new DateTime(2011, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Marin", 23, 0 },
                    { 448, new DateTime(2010, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Matei", 23, 1 },
                    { 449, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Neagu", 23, 0 },
                    { 450, new DateTime(2011, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Dumitrescu", 23, 1 },
                    { 451, new DateTime(2009, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Popescu", 23, 0 },
                    { 452, new DateTime(2009, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Popescu", 23, 0 },
                    { 453, new DateTime(2009, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 23, 3 },
                    { 454, new DateTime(2010, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 23, 2 },
                    { 455, new DateTime(2011, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Voicu", 23, 0 },
                    { 456, new DateTime(2009, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Dumitrescu", 23, 1 },
                    { 457, new DateTime(2012, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Lazar", 23, 2 },
                    { 458, new DateTime(2012, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Neagu", 23, 3 },
                    { 459, new DateTime(2009, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Marin", 23, 0 },
                    { 460, new DateTime(2012, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Voicu", 23, 2 },
                    { 461, new DateTime(2012, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Georgescu", 24, 2 },
                    { 462, new DateTime(2011, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Cojocaru", 24, 0 },
                    { 463, new DateTime(2009, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Voicu", 24, 2 },
                    { 464, new DateTime(2011, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Neagu", 24, 1 },
                    { 465, new DateTime(2009, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Voicu", 24, 3 },
                    { 466, new DateTime(2011, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Ionescu", 24, 0 },
                    { 467, new DateTime(2010, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Radulescu", 24, 3 },
                    { 468, new DateTime(2009, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Ilie", 24, 0 },
                    { 469, new DateTime(2011, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Georgescu", 24, 3 },
                    { 470, new DateTime(2011, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Georgescu", 24, 0 },
                    { 471, new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Lazar", 24, 0 },
                    { 472, new DateTime(2010, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 24, 2 },
                    { 473, new DateTime(2010, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Radulescu", 24, 3 },
                    { 474, new DateTime(2012, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Petrescu", 24, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 475, new DateTime(2011, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Neagu", 24, 0 },
                    { 476, new DateTime(2010, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Popescu", 24, 1 },
                    { 477, new DateTime(2009, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Ilie", 24, 0 },
                    { 478, new DateTime(2009, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Diaconu", 24, 1 },
                    { 479, new DateTime(2010, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Marin", 24, 1 },
                    { 480, new DateTime(2012, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 24, 1 },
                    { 481, new DateTime(2010, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Radulescu", 25, 0 },
                    { 482, new DateTime(2009, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Neagu", 25, 1 },
                    { 483, new DateTime(2011, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Barbu", 25, 2 },
                    { 484, new DateTime(2009, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Diaconu", 25, 2 },
                    { 485, new DateTime(2009, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 25, 0 },
                    { 486, new DateTime(2009, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ilie", 25, 3 },
                    { 487, new DateTime(2010, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Enache", 25, 2 },
                    { 488, new DateTime(2011, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Ionescu", 25, 0 },
                    { 489, new DateTime(2012, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Georgescu", 25, 3 },
                    { 490, new DateTime(2009, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 25, 1 },
                    { 491, new DateTime(2011, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Ionescu", 25, 0 },
                    { 492, new DateTime(2012, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cojocaru", 25, 3 },
                    { 493, new DateTime(2009, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Barbu", 25, 2 },
                    { 494, new DateTime(2009, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Enache", 25, 1 },
                    { 495, new DateTime(2011, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Stan", 25, 2 },
                    { 496, new DateTime(2009, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Lazar", 25, 1 },
                    { 497, new DateTime(2011, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ionescu", 25, 1 },
                    { 498, new DateTime(2010, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Marin", 25, 0 },
                    { 499, new DateTime(2009, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Lazar", 25, 2 },
                    { 500, new DateTime(2011, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Voicu", 25, 1 },
                    { 501, new DateTime(2010, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Ionescu", 26, 2 },
                    { 502, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Cojocaru", 26, 3 },
                    { 503, new DateTime(2010, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Toma", 26, 3 },
                    { 504, new DateTime(2009, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Enache", 26, 1 },
                    { 505, new DateTime(2012, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 26, 0 },
                    { 506, new DateTime(2011, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Voicu", 26, 1 },
                    { 507, new DateTime(2011, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Enache", 26, 2 },
                    { 508, new DateTime(2011, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Enache", 26, 2 },
                    { 509, new DateTime(2009, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Popescu", 26, 1 },
                    { 510, new DateTime(2012, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Petrescu", 26, 2 },
                    { 511, new DateTime(2012, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 26, 0 },
                    { 512, new DateTime(2009, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Neagu", 26, 2 },
                    { 513, new DateTime(2012, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Stan", 26, 1 },
                    { 514, new DateTime(2011, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ionescu", 26, 1 },
                    { 515, new DateTime(2011, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Toma", 26, 1 },
                    { 516, new DateTime(2009, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 26, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 517, new DateTime(2012, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cojocaru", 26, 1 },
                    { 518, new DateTime(2012, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 26, 0 },
                    { 519, new DateTime(2009, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Petrescu", 26, 1 },
                    { 520, new DateTime(2009, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Popescu", 26, 3 },
                    { 521, new DateTime(2010, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 27, 0 },
                    { 522, new DateTime(2009, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Vasilescu", 27, 3 },
                    { 523, new DateTime(2011, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Dumitrescu", 27, 3 },
                    { 524, new DateTime(2011, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 27, 0 },
                    { 525, new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Georgescu", 27, 1 },
                    { 526, new DateTime(2012, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ilie", 27, 2 },
                    { 527, new DateTime(2011, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Dumitrescu", 27, 3 },
                    { 528, new DateTime(2009, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Neagu", 27, 1 },
                    { 529, new DateTime(2009, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Diaconu", 27, 2 },
                    { 530, new DateTime(2011, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Diaconu", 27, 3 },
                    { 531, new DateTime(2009, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Lazar", 27, 0 },
                    { 532, new DateTime(2009, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Neagu", 27, 3 },
                    { 533, new DateTime(2012, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Lazar", 27, 2 },
                    { 534, new DateTime(2011, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Petrescu", 27, 0 },
                    { 535, new DateTime(2011, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Stan", 27, 3 },
                    { 536, new DateTime(2009, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Cojocaru", 27, 2 },
                    { 537, new DateTime(2011, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 27, 3 },
                    { 538, new DateTime(2009, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Ionescu", 27, 1 },
                    { 539, new DateTime(2009, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Enache", 27, 0 },
                    { 540, new DateTime(2011, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Barbu", 27, 1 },
                    { 541, new DateTime(2009, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Matei", 28, 3 },
                    { 542, new DateTime(2009, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 28, 3 },
                    { 543, new DateTime(2009, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Chiriac", 28, 3 },
                    { 544, new DateTime(2009, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Enache", 28, 2 },
                    { 545, new DateTime(2012, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Ilie", 28, 3 },
                    { 546, new DateTime(2009, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Vasilescu", 28, 2 },
                    { 547, new DateTime(2010, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Vasilescu", 28, 0 },
                    { 548, new DateTime(2009, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Popescu", 28, 3 },
                    { 549, new DateTime(2010, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Matei", 28, 2 },
                    { 550, new DateTime(2012, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Petrescu", 28, 3 },
                    { 551, new DateTime(2011, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Enache", 28, 2 },
                    { 552, new DateTime(2010, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Toma", 28, 3 },
                    { 553, new DateTime(2010, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Toma", 28, 3 },
                    { 554, new DateTime(2010, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Radulescu", 28, 2 },
                    { 555, new DateTime(2011, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Lazar", 28, 0 },
                    { 556, new DateTime(2009, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Popescu", 28, 0 },
                    { 557, new DateTime(2011, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 28, 3 },
                    { 558, new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Barbu", 28, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 559, new DateTime(2011, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Radulescu", 28, 1 },
                    { 560, new DateTime(2010, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Ionescu", 28, 0 },
                    { 561, new DateTime(2009, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Petrescu", 29, 2 },
                    { 562, new DateTime(2011, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ionescu", 29, 2 },
                    { 563, new DateTime(2010, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 29, 3 },
                    { 564, new DateTime(2012, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Diaconu", 29, 2 },
                    { 565, new DateTime(2011, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Toma", 29, 0 },
                    { 566, new DateTime(2011, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Lazar", 29, 2 },
                    { 567, new DateTime(2012, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Diaconu", 29, 1 },
                    { 568, new DateTime(2009, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Ilie", 29, 3 },
                    { 569, new DateTime(2010, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Voicu", 29, 2 },
                    { 570, new DateTime(2009, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Petrescu", 29, 2 },
                    { 571, new DateTime(2010, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Diaconu", 29, 1 },
                    { 572, new DateTime(2009, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Marin", 29, 2 },
                    { 573, new DateTime(2009, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Vasilescu", 29, 0 },
                    { 574, new DateTime(2011, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Dumitrescu", 29, 1 },
                    { 575, new DateTime(2010, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Toma", 29, 0 },
                    { 576, new DateTime(2011, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Neagu", 29, 2 },
                    { 577, new DateTime(2012, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Toma", 29, 2 },
                    { 578, new DateTime(2012, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Matei", 29, 0 },
                    { 579, new DateTime(2012, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Neagu", 29, 3 },
                    { 580, new DateTime(2012, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Diaconu", 29, 1 },
                    { 581, new DateTime(2009, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Voicu", 30, 3 },
                    { 582, new DateTime(2009, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Stan", 30, 0 },
                    { 583, new DateTime(2010, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Toma", 30, 1 },
                    { 584, new DateTime(2010, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Diaconu", 30, 3 },
                    { 585, new DateTime(2011, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Marin", 30, 2 },
                    { 586, new DateTime(2009, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Georgescu", 30, 1 },
                    { 587, new DateTime(2009, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Dumitrescu", 30, 3 },
                    { 588, new DateTime(2011, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Vasilescu", 30, 1 },
                    { 589, new DateTime(2011, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Stan", 30, 3 },
                    { 590, new DateTime(2010, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Marin", 30, 0 },
                    { 591, new DateTime(2009, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Matei", 30, 2 },
                    { 592, new DateTime(2010, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Stan", 30, 3 },
                    { 593, new DateTime(2011, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Neagu", 30, 1 },
                    { 594, new DateTime(2009, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Neagu", 30, 3 },
                    { 595, new DateTime(2012, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Dumitrescu", 30, 0 },
                    { 596, new DateTime(2012, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Diaconu", 30, 1 },
                    { 597, new DateTime(2012, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Lazar", 30, 0 },
                    { 598, new DateTime(2010, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 30, 1 },
                    { 599, new DateTime(2010, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Chiriac", 30, 3 },
                    { 600, new DateTime(2010, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 30, 0 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "SeatName", "SeatPrice", "SeatType", "StadiumId" },
                values: new object[,]
                {
                    { 1, "A1", 150, 3, 1 },
                    { 2, "A2", 150, 3, 1 },
                    { 3, "B1", 50, 0, 1 },
                    { 4, "B2", 50, 0, 1 },
                    { 5, "C1", 50, 0, 1 },
                    { 6, "C2", 50, 0, 1 },
                    { 7, "D1", 50, 0, 1 },
                    { 8, "D2", 50, 0, 1 },
                    { 9, "E1", 50, 0, 1 },
                    { 10, "E2", 50, 0, 1 },
                    { 11, "A1", 150, 3, 11 },
                    { 12, "A2", 150, 3, 11 },
                    { 13, "B1", 50, 0, 11 },
                    { 14, "B2", 50, 0, 11 },
                    { 15, "C1", 50, 0, 11 },
                    { 16, "C2", 50, 0, 11 },
                    { 17, "D1", 50, 0, 11 },
                    { 18, "D2", 50, 0, 11 },
                    { 19, "E1", 50, 0, 11 },
                    { 20, "E2", 50, 0, 11 },
                    { 21, "A1", 150, 3, 21 },
                    { 22, "A2", 150, 3, 21 },
                    { 23, "B1", 50, 0, 21 },
                    { 24, "B2", 50, 0, 21 },
                    { 25, "C1", 50, 0, 21 },
                    { 26, "C2", 50, 0, 21 },
                    { 27, "D1", 50, 0, 21 },
                    { 28, "D2", 50, 0, 21 },
                    { 29, "E1", 50, 0, 21 },
                    { 30, "E2", 50, 0, 21 }
                });

            migrationBuilder.InsertData(
                table: "TeamStatistics",
                columns: new[] { "Id", "GamesPlayed", "GoalsConceded", "GoalsScored", "CompetitionId", "TeamId", "TotalDraws", "TotalLosses", "TotalPoints", "TotalWins" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 1, 1, 0, 0, 3, 1 },
                    { 2, 1, 2, 1, 1, 6, 0, 1, 0, 0 },
                    { 3, 1, 0, 0, 1, 2, 1, 0, 1, 0 },
                    { 4, 1, 0, 0, 1, 7, 1, 0, 1, 0 },
                    { 5, 1, 1, 2, 1, 3, 0, 0, 3, 1 },
                    { 6, 1, 2, 1, 1, 8, 0, 1, 0, 0 },
                    { 7, 1, 1, 0, 1, 4, 0, 1, 0, 0 },
                    { 8, 1, 0, 1, 1, 9, 0, 0, 3, 1 },
                    { 9, 1, 2, 1, 1, 5, 0, 1, 0, 0 },
                    { 10, 1, 1, 2, 1, 10, 0, 0, 3, 1 },
                    { 11, 1, 0, 0, 4, 11, 1, 0, 1, 0 },
                    { 12, 1, 0, 0, 4, 16, 1, 0, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "TeamStatistics",
                columns: new[] { "Id", "GamesPlayed", "GoalsConceded", "GoalsScored", "CompetitionId", "TeamId", "TotalDraws", "TotalLosses", "TotalPoints", "TotalWins" },
                values: new object[,]
                {
                    { 13, 1, 3, 2, 4, 12, 0, 1, 0, 0 },
                    { 14, 1, 2, 3, 4, 17, 0, 0, 3, 1 },
                    { 15, 1, 3, 3, 4, 13, 1, 0, 1, 0 },
                    { 16, 1, 3, 3, 4, 18, 1, 0, 1, 0 },
                    { 17, 1, 1, 2, 4, 14, 0, 0, 3, 1 },
                    { 18, 1, 2, 1, 4, 19, 0, 1, 0, 0 },
                    { 19, 1, 3, 2, 4, 15, 0, 1, 0, 0 },
                    { 20, 1, 2, 3, 4, 20, 0, 0, 3, 1 },
                    { 21, 1, 1, 2, 7, 21, 0, 0, 3, 1 },
                    { 22, 1, 2, 1, 7, 26, 0, 1, 0, 0 },
                    { 23, 1, 1, 2, 7, 22, 0, 0, 3, 1 },
                    { 24, 1, 2, 1, 7, 27, 0, 1, 0, 0 },
                    { 25, 1, 0, 2, 7, 23, 0, 0, 3, 1 },
                    { 26, 1, 2, 0, 7, 28, 0, 1, 0, 0 },
                    { 27, 1, 1, 2, 7, 24, 0, 0, 3, 1 },
                    { 28, 1, 2, 1, 7, 29, 0, 1, 0, 0 },
                    { 29, 1, 2, 1, 7, 25, 0, 1, 0, 0 },
                    { 30, 1, 1, 2, 7, 30, 0, 0, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 1, 1, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(554), "Comentariu de la user 9 pentru știrea 1." },
                    { 2, 1, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(556), "Comentariu de la user 1 pentru știrea 1." },
                    { 3, 1, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(557), "Comentariu de la user 4 pentru știrea 1." },
                    { 4, 1, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(557), "Comentariu de la user 8 pentru știrea 1." },
                    { 5, 1, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(558), "Comentariu de la user 2 pentru știrea 1." },
                    { 6, 2, 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(559), "Comentariu de la user 6 pentru știrea 2." },
                    { 7, 2, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(559), "Comentariu de la user 7 pentru știrea 2." },
                    { 8, 2, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(560), "Comentariu de la user 10 pentru știrea 2." },
                    { 9, 2, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(561), "Comentariu de la user 4 pentru știrea 2." },
                    { 10, 2, 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(562), "Comentariu de la user 5 pentru știrea 2." },
                    { 11, 3, 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(562), "Comentariu de la user 6 pentru știrea 3." },
                    { 12, 3, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(563), "Comentariu de la user 2 pentru știrea 3." },
                    { 13, 3, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(563), "Comentariu de la user 11 pentru știrea 3." },
                    { 14, 3, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(564), "Comentariu de la user 8 pentru știrea 3." },
                    { 15, 3, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(565), "Comentariu de la user 9 pentru știrea 3." },
                    { 16, 4, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(565), "Comentariu de la user 2 pentru știrea 4." },
                    { 17, 4, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(566), "Comentariu de la user 10 pentru știrea 4." },
                    { 18, 4, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(567), "Comentariu de la user 1 pentru știrea 4." },
                    { 19, 4, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(568), "Comentariu de la user 7 pentru știrea 4." },
                    { 20, 4, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(568), "Comentariu de la user 8 pentru știrea 4." },
                    { 21, 5, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(569), "Comentariu de la user 4 pentru știrea 5." },
                    { 22, 5, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(569), "Comentariu de la user 9 pentru știrea 5." },
                    { 23, 5, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(570), "Comentariu de la user 8 pentru știrea 5." },
                    { 24, 5, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(570), "Comentariu de la user 11 pentru știrea 5." },
                    { 25, 5, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(571), "Comentariu de la user 10 pentru știrea 5." },
                    { 26, 6, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(572), "Comentariu de la user 2 pentru știrea 6." },
                    { 27, 6, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(572), "Comentariu de la user 7 pentru știrea 6." },
                    { 28, 6, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(573), "Comentariu de la user 8 pentru știrea 6." },
                    { 29, 6, 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(573), "Comentariu de la user 5 pentru știrea 6." },
                    { 30, 6, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(574), "Comentariu de la user 11 pentru știrea 6." },
                    { 31, 7, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(575), "Comentariu de la user 4 pentru știrea 7." },
                    { 32, 7, 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(575), "Comentariu de la user 8 pentru știrea 7." },
                    { 33, 7, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(576), "Comentariu de la user 3 pentru știrea 7." },
                    { 34, 7, 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(577), "Comentariu de la user 6 pentru știrea 7." },
                    { 35, 7, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(578), "Comentariu de la user 11 pentru știrea 7." },
                    { 36, 8, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(578), "Comentariu de la user 4 pentru știrea 8." },
                    { 37, 8, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(579), "Comentariu de la user 2 pentru știrea 8." },
                    { 38, 8, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(579), "Comentariu de la user 9 pentru știrea 8." },
                    { 39, 8, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(580), "Comentariu de la user 11 pentru știrea 8." },
                    { 40, 8, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(581), "Comentariu de la user 7 pentru știrea 8." },
                    { 41, 9, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(581), "Comentariu de la user 1 pentru știrea 9." },
                    { 42, 9, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(582), "Comentariu de la user 2 pentru știrea 9." }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 43, 9, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(582), "Comentariu de la user 7 pentru știrea 9." },
                    { 44, 9, 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(583), "Comentariu de la user 5 pentru știrea 9." },
                    { 45, 9, 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(584), "Comentariu de la user 6 pentru știrea 9." },
                    { 46, 10, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(585), "Comentariu de la user 2 pentru știrea 10." },
                    { 47, 10, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(585), "Comentariu de la user 1 pentru știrea 10." },
                    { 48, 10, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(586), "Comentariu de la user 11 pentru știrea 10." },
                    { 49, 10, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(587), "Comentariu de la user 7 pentru știrea 10." },
                    { 50, 10, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(587), "Comentariu de la user 3 pentru știrea 10." },
                    { 51, 11, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(588), "Comentariu de la user 2 pentru știrea 11." },
                    { 52, 11, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(588), "Comentariu de la user 1 pentru știrea 11." },
                    { 53, 11, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(589), "Comentariu de la user 7 pentru știrea 11." },
                    { 54, 11, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(590), "Comentariu de la user 11 pentru știrea 11." },
                    { 55, 11, 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(590), "Comentariu de la user 5 pentru știrea 11." },
                    { 56, 12, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(591), "Comentariu de la user 9 pentru știrea 12." },
                    { 57, 12, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(591), "Comentariu de la user 3 pentru știrea 12." },
                    { 58, 12, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(592), "Comentariu de la user 11 pentru știrea 12." },
                    { 59, 12, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(593), "Comentariu de la user 2 pentru știrea 12." },
                    { 60, 12, 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(593), "Comentariu de la user 7 pentru știrea 12." },
                    { 61, 13, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(594), "Comentariu de la user 1 pentru știrea 13." },
                    { 62, 13, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(594), "Comentariu de la user 10 pentru știrea 13." },
                    { 63, 13, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(595), "Comentariu de la user 9 pentru știrea 13." },
                    { 64, 13, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(596), "Comentariu de la user 3 pentru știrea 13." },
                    { 65, 13, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(596), "Comentariu de la user 11 pentru știrea 13." },
                    { 66, 14, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(620), "Comentariu de la user 3 pentru știrea 14." },
                    { 67, 14, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(622), "Comentariu de la user 10 pentru știrea 14." },
                    { 68, 14, 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(623), "Comentariu de la user 1 pentru știrea 14." },
                    { 69, 14, 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(623), "Comentariu de la user 11 pentru știrea 14." },
                    { 70, 14, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(624), "Comentariu de la user 2 pentru știrea 14." },
                    { 71, 15, 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(625), "Comentariu de la user 10 pentru știrea 15." },
                    { 72, 15, 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(625), "Comentariu de la user 3 pentru știrea 15." },
                    { 73, 15, 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(626), "Comentariu de la user 4 pentru știrea 15." },
                    { 74, 15, 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(626), "Comentariu de la user 9 pentru știrea 15." },
                    { 75, 15, 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(627), "Comentariu de la user 2 pentru știrea 15." }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1, 1, 11 },
                    { 2, 1, 1, 1 },
                    { 3, 1, 1, 114 },
                    { 4, 1, 3, 47 },
                    { 5, 1, 3, 56 },
                    { 6, 1, 3, 158 },
                    { 7, 1, 4, 176 },
                    { 8, 1, 5, 98 },
                    { 9, 1, 5, 183 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 10, 1, 5, 191 },
                    { 11, 1, 7, 230 },
                    { 12, 1, 7, 221 },
                    { 13, 1, 7, 333 },
                    { 14, 1, 7, 329 },
                    { 15, 1, 7, 324 },
                    { 16, 1, 8, 250 },
                    { 17, 1, 8, 254 },
                    { 18, 1, 8, 258 },
                    { 19, 1, 8, 343 },
                    { 20, 1, 8, 357 },
                    { 21, 1, 8, 358 },
                    { 22, 1, 9, 262 },
                    { 23, 1, 9, 277 },
                    { 24, 1, 9, 376 },
                    { 25, 1, 10, 293 },
                    { 26, 1, 10, 299 },
                    { 27, 1, 10, 400 },
                    { 28, 1, 10, 393 },
                    { 29, 1, 10, 397 },
                    { 30, 1, 11, 420 },
                    { 31, 1, 11, 406 },
                    { 32, 1, 11, 511 },
                    { 33, 1, 12, 431 },
                    { 34, 1, 12, 437 },
                    { 35, 1, 12, 537 },
                    { 36, 1, 13, 451 },
                    { 37, 1, 13, 457 },
                    { 38, 1, 14, 473 },
                    { 39, 1, 14, 464 },
                    { 40, 1, 14, 561 },
                    { 41, 1, 15, 484 },
                    { 42, 1, 15, 586 },
                    { 43, 1, 15, 581 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(396), 1, 1, 1 },
                    { 2, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(399), 1, 2, 2 },
                    { 3, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(399), 1, 3, 3 },
                    { 4, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(400), 1, 4, 4 },
                    { 5, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(401), 1, 5, 5 },
                    { 6, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(402), 6, 11, 6 },
                    { 7, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(402), 6, 12, 7 },
                    { 8, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(403), 6, 13, 8 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 9, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(404), 6, 14, 9 },
                    { 10, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(405), 6, 15, 10 },
                    { 11, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(405), 11, 21, 1 },
                    { 12, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(406), 11, 22, 2 },
                    { 13, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(407), 11, 23, 3 },
                    { 14, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(407), 11, 24, 4 },
                    { 15, new DateTime(2025, 4, 11, 18, 10, 37, 133, DateTimeKind.Utc).AddTicks(408), 11, 25, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                column: "AwayTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompetitionId",
                table: "Games",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_StadiumId",
                table: "Games",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UsersId",
                table: "News",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamsId",
                table: "Players",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerCompetiton_CompetitionId",
                table: "PlayerStatisticsPerCompetiton",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerCompetiton_PlayerId",
                table: "PlayerStatisticsPerCompetiton",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerGame_GameId",
                table: "PlayerStatisticsPerGame",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerGame_PlayerId",
                table: "PlayerStatisticsPerGame",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_StadiumId",
                table: "Seats",
                column: "StadiumId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStatistics_CompetitionId",
                table: "TeamStatistics",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStatistics_TeamId",
                table: "TeamStatistics",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GameId",
                table: "Tickets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PlayerStatisticsPerCompetiton");

            migrationBuilder.DropTable(
                name: "PlayerStatisticsPerGame");

            migrationBuilder.DropTable(
                name: "TeamStatistics");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Stadiums");
        }
    }
}
