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
                    Capacity = table.Column<int>(type: "int", nullable: false)
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
                    Record = table.Column<string>(type: "TEXT", nullable: false)
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
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    Reserved = table.Column<bool>(type: "bit", nullable: false),
                    StadiumsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Stadiums_StadiumsId",
                        column: x => x.StadiumsId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
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
                    HomeTeamId = table.Column<int>(type: "int", nullable: true),
                    AwayTeamId = table.Column<int>(type: "int", nullable: true),
                    CompetitionsId = table.Column<int>(type: "int", nullable: true),
                    StadiumsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Stadiums_StadiumsId",
                        column: x => x.StadiumsId,
                        principalTable: "Stadiums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Teams_AwayTeamId",
                        column: x => x.AwayTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Teams_HomeTeamId",
                        column: x => x.HomeTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
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
                    CompetitionsId = table.Column<int>(type: "int", nullable: true),
                    TeamsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStatistics_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeamStatistics_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromStaffId = table.Column<int>(type: "int", nullable: true),
                    ToPlayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_FromStaffId",
                        column: x => x.FromStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Users_ToPlayerId",
                        column: x => x.ToPlayerId,
                        principalTable: "Users",
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
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    UsersId = table.Column<int>(type: "int", nullable: true),
                    TeamsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Players_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatsId = table.Column<int>(type: "int", nullable: true),
                    GamesId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatsId",
                        column: x => x.SeatsId,
                        principalTable: "Seats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: true),
                    UsersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerCompetiton",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Saves = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    CompetitionsId = table.Column<int>(type: "int", nullable: true),
                    PlayersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerCompetiton", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetiton_Competitions_CompetitionsId",
                        column: x => x.CompetitionsId,
                        principalTable: "Competitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetiton_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    PassesCompleted = table.Column<int>(type: "int", nullable: false),
                    Saves = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    MinutesPlayed = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: true),
                    PlayersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerGame_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "NewsId", "Text", "UsersId" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8538), null, "Felicitări echipei!", null });

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
                table: "Feedback",
                columns: new[] { "Id", "CreatedAt", "FromStaffId", "Review", "ToPlayerId" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8557), null, "Un meci foarte bun!", null });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamId", "AwayTeamScore", "CompetitionsId", "GameDate", "HomeTeamId", "HomeTeamScore", "StadiumsId", "TicketsSold" },
                values: new object[] { 1, null, 1, null, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8420), null, 2, null, 5000 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "Text", "Title", "UsersId" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8516), "FC Unirea a câștigat cu 2-1!", "Victorie mare pentru FC Unirea!", null });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerCompetiton",
                columns: new[] { "Id", "Assists", "CompetitionsId", "Goals", "MinutesPlayed", "PlayersId", "RedCards", "Saves", "YellowCards" },
                values: new object[] { 1, 5, null, 10, 1200, null, 0, 0, 2 });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Assists", "GamesId", "Goals", "MinutesPlayed", "PassesCompleted", "PlayersId", "RedCards", "Saves", "YellowCards" },
                values: new object[] { 1, 1, null, 2, 90, 30, null, 0, 0, 0 });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "Position", "TeamsId", "UsersId" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Popescu", 0, null, null },
                    { 2, new DateTime(2000, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Ionescu", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Reserved", "SeatName", "SeatPrice", "SeatType", "StadiumsId" },
                values: new object[,]
                {
                    { 1, false, "A1", 150, 3, null },
                    { 2, false, "B2", 50, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Capacity", "StadiumLocation", "StadiumName" },
                values: new object[,]
                {
                    { 1, 20000, "Odobesti", "Unirea Stadium" },
                    { 2, 2000, "Odobesti", "Unirea U21 Stadium" },
                    { 3, 200, "Odobesti", "Unirea Youth Stadium" }
                });

            migrationBuilder.InsertData(
                table: "TeamStatistics",
                columns: new[] { "Id", "CompetitionsId", "GamesPlayed", "GoalsConceded", "GoalsScored", "TeamsId", "TotalDraws", "TotalLosses", "TotalPoints", "TotalWins" },
                values: new object[] { 1, null, 15, 15, 30, null, 3, 2, 33, 10 });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "IsInternal", "Record", "TeamName", "TeamType" },
                values: new object[,]
                {
                    { 1, true, " ", "FC Unirea", 0 },
                    { 2, true, " ", "FC Unirea U21", 1 },
                    { 3, true, " ", "FC Unirea Youth", 2 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GamesId", "SeatsId", "UsersId" },
                values: new object[] { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8441), null, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "HashedPassword", "LastName", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8315), "admin@fcunirea.com", "Admin", "hashedpassword", "User", "0734567890", 0, "admin" },
                    { 2, new DateTime(2025, 2, 6, 11, 29, 16, 866, DateTimeKind.Utc).AddTicks(8322), "mariuspaun@example.com", "Marius", "hashedpassword", "Paun", "0787654321", 1, "mariuspaun" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UsersId",
                table: "Comments",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_FromStaffId",
                table: "Feedback",
                column: "FromStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ToPlayerId",
                table: "Feedback",
                column: "ToPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AwayTeamId",
                table: "Games",
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompetitionsId",
                table: "Games",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_StadiumsId",
                table: "Games",
                column: "StadiumsId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UsersId",
                table: "News",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamsId",
                table: "Players",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UsersId",
                table: "Players",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerCompetiton_CompetitionsId",
                table: "PlayerStatisticsPerCompetiton",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerCompetiton_PlayersId",
                table: "PlayerStatisticsPerCompetiton",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerGame_GamesId",
                table: "PlayerStatisticsPerGame",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerGame_PlayersId",
                table: "PlayerStatisticsPerGame",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_StadiumsId",
                table: "Seats",
                column: "StadiumsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStatistics_CompetitionsId",
                table: "TeamStatistics",
                column: "CompetitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStatistics_TeamsId",
                table: "TeamStatistics",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_GamesId",
                table: "Tickets",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatsId",
                table: "Tickets",
                column: "SeatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UsersId",
                table: "Tickets",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Feedback");

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
