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
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
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
                    IsPlayed = table.Column<bool>(type: "bit", nullable: false),
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
                name: "PlayerStatisticsPerCompetition",
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
                    table.PrimaryKey("PK_PlayerStatisticsPerCompetition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetition_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerStatisticsPerCompetition_Players_PlayerId",
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
                    { 5, "Liga 1 Tineret", 0 },
                    { 6, "Champions League Knockout stage", 2 }
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
                    { 30, 21, false, "Brașov", "Stadionul Brașov" },
                    { 31, 22, false, "Galati", "Stadionul Galati" },
                    { 32, 15, false, "Braila", "Stadionul Braila" },
                    { 33, 17, false, "Giugiu", "Stadionul Giugiu" },
                    { 34, 16, false, "Ploieti", "Stadionul Ploieti" },
                    { 35, 14, false, "Focsani", "Stadionul Focsani" },
                    { 36, 19, false, "Cluj", "Stadionul Cluj" }
                });

            migrationBuilder.InsertData(
                table: "Stadiums",
                columns: new[] { "Id", "Capacity", "IsInternal", "StadiumLocation", "StadiumName" },
                values: new object[,]
                {
                    { 41, 20, false, "Belgrad", "Stadionul Belgrad" },
                    { 42, 12, false, "Zagreb", "Stadionul Zagreb" },
                    { 43, 16, false, "Pireu", "Stadionul Pireu" },
                    { 44, 11, false, "Istanbul", "Stadionul Istanbul" },
                    { 45, 20, false, "Barcelona", "Stadionul Barcelona" },
                    { 46, 20, false, "Munchen", "Stadionul Munchen" },
                    { 47, 19, false, "Paris", "Stadionul Paris" },
                    { 48, 18, false, "Manchester", "Stadionul Manchester" },
                    { 49, 18, false, "Torino", "Stadionul Torino" }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "Description", "IsInternal", "TeamName", "TeamType" },
                values: new object[,]
                {
                    { 1, "Petrica Florea", "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\r\n\r\nEchipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016. ", true, "FC Unirea", 0 },
                    { 2, "Radu Voicu", "Echipă externă din București", false, "Steaua Sud", 0 },
                    { 3, "Adrian Luca", "Club extern din Est", false, "Dinamo Est", 0 },
                    { 4, "Cezar Năstase", "Echipă tradițională externă", false, "Rapid Nord", 0 },
                    { 5, "Marius Costache", "Echipă externă din Ploiești", false, "Petrolul Vest", 0 },
                    { 6, "Paul Dobre", "Echipă din centru", false, "Universitatea Brașov", 0 },
                    { 7, "Ovidiu Stan", "Echipă externă din Cluj", false, "CSM Cluj", 0 },
                    { 8, "Toma Marinescu", "Echipă din Buzău", false, "Gloria Buzău", 0 },
                    { 9, "Cristian Filip", "Club tânăr și ambițios", false, "Viitorul Constanța", 0 },
                    { 10, "Ilie Andrei", "Echipă argeșeană", false, "CS Mioveni", 0 },
                    { 11, "Mihai Olaru", "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\r\n\r\nÎncă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\r\n\r\nPrin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice. ", true, "FC Unirea U21", 1 },
                    { 12, "Eugen Varga", "Echipă externă U21", false, "U21 Voluntari", 1 },
                    { 13, "Victor Drăghici", "Farul Constanța U21", false, "U21 Farul", 1 },
                    { 14, "Ervin Balogh", "Sepsi OSK U21", false, "U21 Sepsi", 1 },
                    { 15, "George Călinescu", "Tineret Poli", false, "U21 Poli Iași", 1 },
                    { 16, "Remus Cernat", "Arad U21", false, "U21 UTA", 1 },
                    { 17, "Mihai Răducan", "Pitești U21", false, "U21 Argeș", 1 },
                    { 18, "Dan Tănase", "Sibiu U21", false, "U21 Hermannstadt", 1 },
                    { 19, "Florin Istrate", "Nord U21", false, "U21 Botoșani", 1 },
                    { 20, "Marius Ilie", "Oltenia U21", false, "U21 Slatina", 1 },
                    { 21, "Nica Cercel", "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\r\n\r\nScopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\r\n\r\nPrin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune. ", true, "FC Unirea Youth", 2 },
                    { 22, "Lavinia Andrei", "Grupa mică externă", false, "Youth Galați", 2 },
                    { 23, "Răzvan Cioran", "Copii sub 13 ani", false, "Youth Hunedoara", 2 },
                    { 24, "Silviu Coman", "Târgoviște Kids", false, "Youth Târgoviște", 2 },
                    { 25, "Mihai Leahu", "Zona Moldova", false, "Youth Vaslui", 2 },
                    { 26, "Adrian Cârciumaru", "Nord-Vest", false, "Youth Baia Mare", 2 },
                    { 27, "Viorel Neagu", "Oltenia Kids", false, "Youth Craiova", 2 },
                    { 28, "Andrei Moga", "Muntenia copii", false, "Youth Ploiești", 2 },
                    { 29, "Emil Crețu", "Echipă externă pentru juniori", false, "Youth Oradea", 2 },
                    { 30, "Flavius Pop", "Vest Kids", false, "Youth Arad", 2 },
                    { 31, "Radu Cârciumaru", "Club extern din liga a III-a", false, "Steaua Galati", 0 },
                    { 32, "Radu Tănase", "Club extern din liga a II-a", false, "Steaua Braila", 0 },
                    { 33, "Adrian Cioran", "Club extern din liga a III-a", false, "Dinamo Giugiu", 0 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CoachName", "Description", "IsInternal", "TeamName", "TeamType" },
                values: new object[,]
                {
                    { 34, "Cezar Năstase", "Club extern din liga a II-a", false, "Rapid Ploieti", 0 },
                    { 35, "Istrate Costache", "Club extern din liga a III-a", false, "Petrolul Focsani", 0 },
                    { 36, "Paul Dobre", "Club extern din liga a II-a", false, "Universitatea Cluj", 0 },
                    { 37, "Ovidiu Istrate", "Club extern din liga a III-a", false, "CSM Arad", 0 },
                    { 38, "Florin Marinescu", "Club extern din liga a II-a", false, "Gloria Bistrita", 0 },
                    { 39, "Cristian Filip", "Club extern din liga a III-a", false, "Viitorul Olt", 0 },
                    { 40, "Ilie Florin", "Club extern din liga a II-a", false, "CS Otila", 0 },
                    { 41, "Radu Gok", "Club Sarb", false, "Steaua Belgrad", 0 },
                    { 42, "Adrian Petrovic", "Club Croat", false, "Dinamo Zagreb", 0 },
                    { 43, "Cezar Papadopoulos", "Club Grec", false, "Olympiakos", 0 },
                    { 44, "Marius Yilmaz", "Club Turc", false, "Fenerbahce", 0 },
                    { 45, "Pablo Garcia", "Club Spaniol", false, "Barcelona", 0 },
                    { 46, "Hans Müller", "Club German", false, "Bayern Munchen", 0 },
                    { 47, "Jean Dupont", "Club Francez", false, "Paris Saint-Germain", 0 },
                    { 48, "John Smith", "Club Englez", false, "Manchester City", 0 },
                    { 49, "Marco Rossi", "Club Italian", false, "Juventus", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@fcunirea.ro", "Admin", "Unirea", "aJJ6n23eBDAvvkgbNkbqVw==:Rkl+y/HGK2F3orm8uko70zncakYXDXmWAcTEheRZJCg=", "0712345678", 0, "admin" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ion.popescu@fcunirea.ro", "Ion", "Popescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000001", 1, "ion.popescu" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ana.ionescu@fcunirea.ro", "Ana", "Ionescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000002", 1, "ana.ionescu" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "george.marin@fcunirea.ro", "George", "Marin", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000003", 1, "george.marin" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "elena.dumitru@fcunirea.ro", "Elena", "Dumitru", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000004", 1, "elena.dumitru" },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mihai.stan@fcunirea.ro", "Mihai", "Stan", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000005", 1, "mihai.stan" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "bianca.toma@fcunirea.ro", "Bianca", "Toma", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000006", 1, "bianca.toma" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alex.vasilescu@fcunirea.ro", "Alex", "Vasilescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000007", 1, "alex.vasilescu" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "diana.radu@fcunirea.ro", "Diana", "Radu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000008", 1, "diana.radu" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "tudor.matei@fcunirea.ro", "Tudor", "Matei", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000009", 1, "tudor.matei" },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "andreea.ilie@fcunirea.ro", "Andreea", "Ilie", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000010", 1, "andreea.ilie" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "claudiu.dobre@fcunirea.ro", "Claudiu", "Dobre", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000011", 1, "claudiu.dobre" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "raluca.georgescu@fcunirea.ro", "Raluca", "Georgescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000012", 1, "raluca.georgescu" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ionut.moldovan@fcunirea.ro", "Ionut", "Moldovan", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000013", 1, "ionut.moldovan" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "carmen.pop@fcunirea.ro", "Carmen", "Pop", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000014", 1, "carmen.pop" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vlad.enache@fcunirea.ro", "Vlad", "Enache", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000015", 1, "vlad.enache" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "irina.voicu@fcunirea.ro", "Irina", "Voicu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000016", 1, "irina.voicu" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sebastian.cristea@fcunirea.ro", "Sebastian", "Cristea", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000017", 1, "sebastian.cristea" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "simona.marinescu@fcunirea.ro", "Simona", "Marinescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000018", 1, "simona.marinescu" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "rares.sava@fcunirea.ro", "Rares", "Sava", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000019", 1, "rares.sava" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "paula.mateescu@fcunirea.ro", "Paula", "Mateescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000020", 1, "paula.mateescu" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alin.badea@fcunirea.ro", "Alin", "Badea", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000021", 1, "alin.badea" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "adelina.dragan@fcunirea.ro", "Adelina", "Dragan", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000022", 1, "adelina.dragan" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucian.simeon@fcunirea.ro", "Lucian", "Simeon", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000023", 1, "lucian.simeon" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "gabriela.radulescu@fcunirea.ro", "Gabriela", "Radulescu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000024", 1, "gabriela.radulescu" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vasile.ciobanu@fcunirea.ro", "Vasile", "Ciobanu", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000025", 1, "vasile.ciobanu" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Role", "Username" },
                values: new object[,]
                {
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "oana.manole@fcunirea.ro", "Oana", "Manole", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000026", 1, "oana.manole" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cornel.ardelean@fcunirea.ro", "Cornel", "Ardelean", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000027", 1, "cornel.ardelean" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "camelia.pavel@fcunirea.ro", "Camelia", "Pavel", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000028", 1, "camelia.pavel" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "grigore.nastase@fcunirea.ro", "Grigore", "Nastase", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000029", 1, "grigore.nastase" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "veronica.filip@fcunirea.ro", "Veronica", "Filip", "WTM/73BdHfimme4uRkFNWA==:70kq150aS87havltE4F8HHTApxiz1TcfnQV2kHNvVxI=", "0700000030", 1, "veronica.filip" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 1, 1, 2, true, "Marius Popa", 5 },
                    { 2, 0, new DateTime(2025, 5, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 2, 2, 0, true, "Cătălin Gheorghe", 9 },
                    { 3, 1, new DateTime(2025, 5, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 3, 3, 2, true, "Daniel Petrescu", 6 },
                    { 4, 1, new DateTime(2025, 5, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 4, 4, 0, true, "Bogdan Neagu", 4 },
                    { 5, 2, new DateTime(2025, 5, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 5, 5, 1, true, "Mihai Rusu", 12 },
                    { 6, 0, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 11, 11, 0, true, "Paul Voicu", 5 },
                    { 7, 3, new DateTime(2025, 5, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 12, 12, 2, true, "Paul Voicu", 6 },
                    { 8, 3, new DateTime(2025, 5, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 13, 13, 3, true, "Cosmin Ionescu", 7 },
                    { 9, 1, new DateTime(2025, 5, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 14, 14, 2, true, "Radu Marin", 8 },
                    { 10, 3, new DateTime(2025, 5, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 15, 15, 2, true, "Silviu Barbu", 9 },
                    { 11, 1, new DateTime(2025, 5, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 21, 21, 2, true, "Florin Stan", 5 },
                    { 12, 1, new DateTime(2025, 5, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 22, 22, 2, true, "Andrei Dumitrescu", 4 },
                    { 13, 0, new DateTime(2025, 5, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 23, 23, 2, true, "Alexandru Vasilescu", 3 },
                    { 14, 1, new DateTime(2025, 5, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 24, 24, 2, true, "George Ilie", 4 },
                    { 15, 2, new DateTime(2025, 5, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 25, 25, 1, true, "Iulian Nistor", 5 },
                    { 16, 1, new DateTime(2025, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 10, 10, 2, true, "Cristian Ene", 22 },
                    { 17, 3, new DateTime(2025, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 7, 7, 1, true, "Paul Voicu", 12 },
                    { 18, 2, new DateTime(2025, 5, 8, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 8, 8, 2, true, "Iulian Nistor", 23 },
                    { 19, 1, new DateTime(2025, 5, 8, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 9, 9, 0, true, "Mihai Rusu", 17 },
                    { 20, 1, new DateTime(2025, 5, 8, 2, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 1, 1, 4, true, "Silviu Barbu", 8 },
                    { 21, 0, new DateTime(2025, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 20, 20, 2, true, "Cătălin Gheorghe", 20 },
                    { 22, 2, new DateTime(2025, 5, 8, 1, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 17, 17, 2, true, "Cătălin Gheorghe", 16 },
                    { 23, 3, new DateTime(2025, 5, 8, 18, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 18, 18, 0, true, "Daniel Petrescu", 14 },
                    { 24, 1, new DateTime(2025, 5, 8, 6, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 19, 19, 1, true, "Florin Stan", 9 },
                    { 25, 2, new DateTime(2025, 5, 8, 11, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 11, 11, 0, true, "Cristian Ene", 5 },
                    { 26, 0, new DateTime(2025, 5, 8, 3, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 30, 30, 3, true, "Alexandru Vasilescu", 19 },
                    { 27, 1, new DateTime(2025, 5, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 27, 27, 2, true, "Marius Popa", 16 },
                    { 28, 2, new DateTime(2025, 5, 8, 5, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 28, 28, 0, true, "Andrei Dumitrescu", 11 },
                    { 29, 3, new DateTime(2025, 5, 8, 6, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 29, 29, 1, true, "George Ilie", 14 },
                    { 30, 2, new DateTime(2025, 5, 8, 8, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 21, 21, 2, true, "Radu Marin", 9 },
                    { 31, 2, new DateTime(2025, 5, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 2, 2, 1, true, "Bogdan Neagu", 16 },
                    { 32, 1, new DateTime(2025, 5, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 3, 3, 0, true, "Cosmin Ionescu", 10 },
                    { 33, 2, new DateTime(2025, 5, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 4, 4, 2, true, "Andrei Dumitrescu", 7 },
                    { 34, 0, new DateTime(2025, 5, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 5, 5, 3, true, "Alexandru Vasilescu", 21 },
                    { 35, 1, new DateTime(2025, 5, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 6, 6, 1, true, "Marius Popa", 5 },
                    { 36, 1, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 12, 12, 1, true, "Paul Voicu", 8 },
                    { 37, 2, new DateTime(2025, 5, 15, 1, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 13, 13, 0, true, "Paul Voicu", 11 },
                    { 38, 3, new DateTime(2025, 5, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 14, 14, 4, true, "Daniel Petrescu", 25 },
                    { 39, 0, new DateTime(2025, 5, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 15, 15, 2, true, "Radu Marin", 15 },
                    { 40, 2, new DateTime(2025, 5, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 16, 16, 1, true, "Cosmin Ionescu", 12 },
                    { 41, 3, new DateTime(2025, 5, 15, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 22, 22, 0, true, "Silviu Barbu", 7 },
                    { 42, 2, new DateTime(2025, 5, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 23, 23, 2, true, "Bogdan Neagu", 17 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 43, 1, new DateTime(2025, 5, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 24, 24, 0, true, "Cătălin Gheorghe", 16 },
                    { 44, 0, new DateTime(2025, 5, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 25, 25, 1, true, "Cristian Ene", 10 },
                    { 45, 2, new DateTime(2025, 5, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 26, 26, 3, true, "Mihai Rusu", 14 },
                    { 46, 1, new DateTime(2025, 5, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 10, 10, 2, true, "Florin Stan", 16 },
                    { 47, 0, new DateTime(2025, 5, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 8, 8, 3, true, "Iulian Nistor", 19 },
                    { 48, 2, new DateTime(2025, 5, 22, 19, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 9, 9, 2, true, "George Ilie", 25 },
                    { 49, 2, new DateTime(2025, 5, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 1, 1, 1, true, "Alexandru Vasilescu", 7 },
                    { 50, 0, new DateTime(2025, 5, 22, 2, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2, 2, 2, true, "Radu Marin", 12 },
                    { 51, 1, new DateTime(2025, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 20, 20, 2, true, "Paul Voicu", 18 },
                    { 52, 1, new DateTime(2025, 5, 22, 1, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 18, 18, 0, true, "Paul Voicu", 11 },
                    { 53, 2, new DateTime(2025, 5, 22, 18, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 19, 19, 1, true, "Bogdan Neagu", 17 },
                    { 54, 0, new DateTime(2025, 5, 22, 6, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 11, 11, 0, true, "Cristian Ene", 4 },
                    { 55, 1, new DateTime(2025, 5, 22, 11, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 12, 12, 1, true, "Silviu Barbu", 10 },
                    { 56, 2, new DateTime(2025, 5, 22, 3, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 30, 30, 0, true, "Andrei Dumitrescu", 16 },
                    { 57, 0, new DateTime(2025, 5, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 28, 28, 2, true, "Daniel Petrescu", 13 },
                    { 58, 1, new DateTime(2025, 5, 22, 5, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 29, 29, 1, true, "Cosmin Ionescu", 7 },
                    { 59, 1, new DateTime(2025, 5, 22, 6, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 21, 21, 0, true, "Mihai Rusu", 7 },
                    { 60, 2, new DateTime(2025, 5, 22, 8, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 22, 22, 2, true, "Iulian Nistor", 13 },
                    { 61, 0, new DateTime(2025, 5, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 3, 3, 2, true, "Cătălin Gheorghe", 10 },
                    { 62, 3, new DateTime(2025, 5, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 4, 4, 1, true, "George Ilie", 6 },
                    { 63, 1, new DateTime(2025, 5, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 5, 5, 1, true, "Florin Stan", 19 },
                    { 64, 1, new DateTime(2025, 5, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 6, 6, 0, true, "Marius Popa", 7 },
                    { 65, 2, new DateTime(2025, 5, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 7, 7, 2, true, "Marius Popa", 8 },
                    { 66, 0, new DateTime(2025, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 13, 13, 1, true, "Paul Voicu", 14 },
                    { 67, 0, new DateTime(2025, 5, 29, 1, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 14, 14, 0, true, "Paul Voicu", 28 },
                    { 68, 1, new DateTime(2025, 5, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 15, 15, 2, true, "Radu Marin", 20 },
                    { 69, 3, new DateTime(2025, 5, 29, 6, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 16, 16, 0, true, "Cătălin Gheorghe", 24 },
                    { 70, 1, new DateTime(2025, 5, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 17, 17, 1, true, "Silviu Barbu", 19 },
                    { 71, 0, new DateTime(2025, 5, 29, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 23, 23, 2, true, "Cosmin Ionescu", 11 },
                    { 72, 2, new DateTime(2025, 5, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 24, 24, 2, true, "Iulian Nistor", 12 },
                    { 73, 1, new DateTime(2025, 5, 29, 5, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 25, 25, 3, true, "Alexandru Vasilescu", 9 },
                    { 74, 2, new DateTime(2025, 5, 29, 6, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 26, 26, 1, true, "Daniel Petrescu", 11 },
                    { 75, 1, new DateTime(2025, 5, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 27, 27, 2, true, "Bogdan Neagu", 8 },
                    { 76, 1, new DateTime(2025, 6, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 10, 10, 2, true, "Cristian Ene", 17 },
                    { 77, 3, new DateTime(2025, 6, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 9, 9, 0, true, "Mihai Rusu", 19 },
                    { 78, 1, new DateTime(2025, 6, 6, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 1, 1, 1, true, "George Ilie", 8 },
                    { 79, 2, new DateTime(2025, 6, 6, 21, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 2, 2, 0, true, "Florin Stan", 6 },
                    { 80, 2, new DateTime(2025, 6, 6, 2, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 3, 3, 2, true, "Andrei Dumitrescu", 11 },
                    { 81, 0, new DateTime(2025, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 20, 20, 1, true, "Radu Marin", 21 },
                    { 82, 1, new DateTime(2025, 6, 6, 1, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 19, 19, 2, true, "Radu Marin", 13 },
                    { 83, 2, new DateTime(2025, 6, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 11, 11, 0, true, "Paul Voicu", 8 },
                    { 84, 0, new DateTime(2025, 6, 6, 6, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 12, 12, 1, true, "Florin Stan", 10 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 85, 1, new DateTime(2025, 6, 6, 11, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 13, 13, 2, true, "Cosmin Ionescu", 18 },
                    { 86, 2, new DateTime(2025, 6, 6, 3, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 30, 30, 3, true, "Iulian Nistor", 15 },
                    { 87, 1, new DateTime(2025, 6, 6, 20, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 29, 29, 1, true, "George Ilie", 13 },
                    { 88, 1, new DateTime(2025, 6, 6, 5, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 21, 21, 0, true, "Marius Popa", 7 },
                    { 89, 2, new DateTime(2025, 6, 6, 6, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 22, 22, 2, true, "Bogdan Neagu", 11 },
                    { 90, 1, new DateTime(2025, 6, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 23, 23, 2, true, "Silviu Barbu", 7 },
                    { 91, 1, new DateTime(2025, 6, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 4, 4, 1, true, "Andrei Dumitrescu", 5 },
                    { 92, 2, new DateTime(2025, 6, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 5, 5, 0, true, "Daniel Petrescu", 23 },
                    { 93, 1, new DateTime(2025, 6, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 6, 6, 2, true, "Cătălin Gheorghe", 15 },
                    { 94, 0, new DateTime(2025, 6, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 7, 7, 3, true, "Alexandru Vasilescu", 12 },
                    { 95, 2, new DateTime(2025, 6, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 8, 8, 2, true, "Mihai Rusu", 19 },
                    { 96, 1, new DateTime(2025, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 14, 14, 0, true, "Cristian Ene", 25 },
                    { 97, 2, new DateTime(2025, 6, 13, 1, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 15, 15, 1, true, "Cristian Ene", 19 },
                    { 98, 0, new DateTime(2025, 6, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 16, 16, 2, true, "Paul Voicu", 22 },
                    { 99, 1, new DateTime(2025, 6, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 17, 17, 1, true, "Daniel Petrescu", 17 },
                    { 100, 0, new DateTime(2025, 5, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 18, 18, 0, true, "Mihai Rusu", 14 },
                    { 101, 2, new DateTime(2025, 6, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 24, 24, 2, true, "Alexandru Vasilescu", 19 },
                    { 102, 1, new DateTime(2025, 6, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 25, 25, 3, true, "George Ilie", 16 },
                    { 103, 0, new DateTime(2025, 6, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 26, 26, 1, true, "Bogdan Neagu", 16 },
                    { 104, 2, new DateTime(2025, 6, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 27, 27, 2, true, "Cristian Ene", 17 },
                    { 105, 2, new DateTime(2025, 6, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 28, 28, 1, true, "Iulian Nistor", 19 },
                    { 106, 3, new DateTime(2025, 6, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 10, 10, 1, true, "Silviu Barbu", 18 },
                    { 107, 0, new DateTime(2025, 6, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 1, 1, 0, true, "Cătălin Gheorghe", 8 },
                    { 108, 1, new DateTime(2025, 6, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 2, 2, 2, true, "Cosmin Ionescu", 13 },
                    { 109, 2, new DateTime(2025, 6, 20, 21, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 3, 3, 0, true, "Marius Popa", 12 },
                    { 110, 1, new DateTime(2025, 6, 20, 2, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4, 4, 1, true, "Radu Marin", 7 },
                    { 111, 1, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 20, 20, 1, true, "Andrei Dumitrescu", 16 },
                    { 112, 0, new DateTime(2025, 6, 20, 1, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 11, 11, 3, true, "Andrei Dumitrescu", 9 },
                    { 113, 3, new DateTime(2025, 6, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 12, 12, 2, true, "Florin Stan", 12 },
                    { 114, 0, new DateTime(2025, 6, 20, 6, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 13, 13, 1, true, "Cristian Ene", 12 },
                    { 115, 2, new DateTime(2025, 6, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 14, 14, 0, true, "Marius Popa", 14 },
                    { 116, 2, new DateTime(2025, 6, 20, 3, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 30, 30, 2, true, "Daniel Petrescu", 19 },
                    { 117, 3, new DateTime(2025, 6, 20, 20, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 21, 21, 1, true, "Florin Stan", 10 },
                    { 118, 2, new DateTime(2025, 6, 20, 5, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 22, 22, 0, true, "Cătălin Gheorghe", 15 },
                    { 119, 1, new DateTime(2025, 6, 20, 6, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 23, 23, 2, true, "Bogdan Neagu", 17 },
                    { 120, 1, new DateTime(2025, 6, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 24, 24, 0, true, "Andrei Dumitrescu", 18 },
                    { 121, 1, new DateTime(2025, 6, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 5, 5, 2, true, "George Ilie", 13 },
                    { 122, 2, new DateTime(2025, 6, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 6, 6, 0, true, "Alexandru Vasilescu", 15 },
                    { 123, 0, new DateTime(2025, 6, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 7, 7, 3, true, "Cosmin Ionescu", 9 },
                    { 124, 1, new DateTime(2025, 6, 27, 21, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 8, 8, 1, true, "Radu Marin", 17 },
                    { 125, 2, new DateTime(2025, 6, 27, 2, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 9, 9, 1, true, "Silviu Barbu", 11 },
                    { 126, 0, new DateTime(2025, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 15, 15, 0, true, "Iulian Nistor", 8 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 127, 1, new DateTime(2025, 6, 27, 1, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 16, 16, 2, true, "Iulian Nistor", 14 },
                    { 128, 2, new DateTime(2025, 6, 27, 18, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 17, 17, 0, true, "Mihai Rusu", 13 },
                    { 129, 0, new DateTime(2025, 6, 27, 6, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 18, 18, 1, true, "Paul Voicu", 7 },
                    { 130, 0, new DateTime(2025, 6, 27, 11, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 19, 19, 0, true, "Cătălin Gheorghe", 9 },
                    { 131, 3, new DateTime(2025, 6, 27, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 25, 25, 1, true, "Florin Stan", 16 },
                    { 132, 2, new DateTime(2025, 6, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 26, 26, 2, true, "Iulian Nistor", 18 },
                    { 133, 0, new DateTime(2025, 6, 27, 5, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 27, 27, 0, true, "Mihai Rusu", 10 },
                    { 134, 1, new DateTime(2025, 6, 27, 6, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 28, 28, 2, true, "Bogdan Neagu", 17 },
                    { 135, 2, new DateTime(2025, 6, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 29, 29, 0, true, "Cosmin Ionescu", 12 },
                    { 136, 0, new DateTime(2025, 7, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 10, 10, 2, true, "Cristian Ene", 16 },
                    { 137, 1, new DateTime(2025, 7, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 9, 9, 0, true, "Marius Popa", 13 },
                    { 138, 1, new DateTime(2025, 7, 4, 19, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 8, 8, 1, true, "Radu Marin", 11 },
                    { 139, 0, new DateTime(2025, 7, 4, 21, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 7, 7, 3, true, "George Ilie", 18 },
                    { 140, 1, new DateTime(2025, 7, 4, 2, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 6, 6, 1, true, "Silviu Barbu", 14 },
                    { 141, 2, new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 20, 20, 0, true, "Paul Voicu", 12 },
                    { 142, 0, new DateTime(2025, 7, 4, 1, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 19, 19, 1, true, "Paul Voicu", 9 },
                    { 143, 2, new DateTime(2025, 7, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 18, 18, 2, true, "Andrei Dumitrescu", 13 },
                    { 144, 0, new DateTime(2025, 7, 4, 6, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 17, 17, 0, true, "Alexandru Vasilescu", 7 },
                    { 145, 3, new DateTime(2025, 7, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 16, 16, 1, true, "Daniel Petrescu", 17 },
                    { 146, 1, new DateTime(2025, 7, 4, 3, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 30, 30, 0, true, "Iulian Nistor", 10 },
                    { 147, 0, new DateTime(2025, 7, 4, 20, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 29, 29, 1, true, "Marius Popa", 12 },
                    { 148, 2, new DateTime(2025, 7, 4, 5, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 28, 28, 2, true, "Daniel Petrescu", 11 },
                    { 149, 1, new DateTime(2025, 7, 4, 6, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 27, 27, 3, true, "Radu Marin", 14 },
                    { 150, 2, new DateTime(2025, 7, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 26, 26, 1, true, "Bogdan Neagu", 8 },
                    { 151, 0, new DateTime(2025, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 6, 6, 0, false, "Paul Voicu", 0 },
                    { 152, 0, new DateTime(2025, 7, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 5, 5, 0, false, "Silviu Barbu", 0 },
                    { 153, 0, new DateTime(2025, 7, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 4, 4, 0, false, "Andrei Dumitrescu", 0 },
                    { 154, 0, new DateTime(2025, 7, 11, 21, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 3, 3, 0, false, "Cosmin Ionescu", 0 },
                    { 155, 0, new DateTime(2025, 7, 11, 2, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2, 2, 0, false, "Mihai Rusu", 0 },
                    { 156, 0, new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 16, 16, 0, false, "Cristian Ene", 0 },
                    { 157, 0, new DateTime(2025, 7, 11, 1, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 15, 15, 0, false, "Cristian Ene", 0 },
                    { 158, 0, new DateTime(2025, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 14, 14, 0, false, "Florin Stan", 0 },
                    { 159, 0, new DateTime(2025, 7, 11, 6, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 13, 13, 0, false, "George Ilie", 0 },
                    { 160, 0, new DateTime(2025, 7, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 12, 12, 0, false, "Cătălin Gheorghe", 0 },
                    { 161, 0, new DateTime(2025, 7, 11, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 26, 26, 0, false, "Alexandru Vasilescu", 0 },
                    { 162, 0, new DateTime(2025, 7, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 25, 25, 0, false, "Daniel Petrescu", 0 },
                    { 163, 0, new DateTime(2025, 7, 11, 5, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 24, 24, 0, false, "Cosmin Ionescu", 0 },
                    { 164, 0, new DateTime(2025, 7, 11, 6, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 23, 23, 0, false, "George Ilie", 0 },
                    { 165, 0, new DateTime(2025, 7, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 22, 22, 0, false, "Mihai Rusu", 0 },
                    { 166, 0, new DateTime(2025, 7, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 10, 10, 0, false, "Silviu Barbu", 0 },
                    { 167, 0, new DateTime(2025, 7, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1, 1, 0, false, "Andrei Dumitrescu", 0 },
                    { 168, 0, new DateTime(2025, 7, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 9, 9, 0, false, "Cristian Ene", 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 169, 0, new DateTime(2025, 7, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 8, 8, 0, false, "Alexandru Vasilescu", 0 },
                    { 170, 0, new DateTime(2025, 7, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 7, 7, 0, false, "Cătălin Gheorghe", 0 },
                    { 171, 0, new DateTime(2025, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 20, 20, 0, false, "Paul Voicu", 0 },
                    { 172, 0, new DateTime(2025, 7, 18, 1, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 11, 11, 0, false, "Paul Voicu", 0 },
                    { 173, 0, new DateTime(2025, 7, 18, 18, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 19, 19, 0, false, "Bogdan Neagu", 0 },
                    { 174, 0, new DateTime(2025, 7, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 18, 18, 0, false, "Iulian Nistor", 0 },
                    { 175, 0, new DateTime(2025, 7, 18, 11, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 17, 17, 0, false, "Radu Marin", 0 },
                    { 176, 0, new DateTime(2025, 7, 18, 3, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 30, 30, 0, false, "Marius Popa", 0 },
                    { 177, 0, new DateTime(2025, 7, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 21, 21, 0, false, "Florin Stan", 0 },
                    { 178, 0, new DateTime(2025, 7, 18, 5, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 29, 29, 0, false, "Andrei Dumitrescu", 0 },
                    { 179, 0, new DateTime(2025, 7, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 28, 28, 0, false, "Cosmin Ionescu", 0 },
                    { 180, 0, new DateTime(2025, 7, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 27, 27, 0, false, "Cătălin Gheorghe", 0 },
                    { 181, 0, new DateTime(2025, 7, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 7, 7, 0, false, "Radu Marin", 0 },
                    { 182, 0, new DateTime(2025, 7, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 6, 6, 0, false, "Florin Stan", 0 },
                    { 183, 0, new DateTime(2025, 7, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 5, 5, 0, false, "Iulian Nistor", 0 },
                    { 184, 0, new DateTime(2025, 7, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 4, 4, 0, false, "Silviu Barbu", 0 },
                    { 185, 0, new DateTime(2025, 7, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 3, 3, 0, false, "Cristian Ene", 0 },
                    { 186, 0, new DateTime(2025, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 17, 17, 0, false, "Marius Popa", 0 },
                    { 187, 0, new DateTime(2025, 7, 25, 1, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 16, 16, 0, false, "Marius Popa", 0 },
                    { 188, 0, new DateTime(2025, 7, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 15, 15, 0, false, "Mihai Rusu", 0 },
                    { 189, 0, new DateTime(2025, 7, 25, 6, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 14, 14, 0, false, "Alexandru Vasilescu", 0 },
                    { 190, 0, new DateTime(2025, 7, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 13, 13, 0, false, "Daniel Petrescu", 0 },
                    { 191, 0, new DateTime(2025, 7, 25, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 27, 27, 0, false, "George Ilie", 0 },
                    { 192, 0, new DateTime(2025, 7, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 26, 26, 0, false, "Paul Voicu", 0 },
                    { 193, 0, new DateTime(2025, 7, 25, 5, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 25, 25, 0, false, "Bogdan Neagu", 0 },
                    { 194, 0, new DateTime(2025, 7, 25, 6, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 24, 24, 0, false, "Radu Marin", 0 },
                    { 195, 0, new DateTime(2025, 7, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 23, 23, 0, false, "Silviu Barbu", 0 },
                    { 196, 0, new DateTime(2025, 8, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 10, 10, 0, false, "Iulian Nistor", 0 },
                    { 197, 0, new DateTime(2025, 8, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 2, 2, 0, false, "Andrei Dumitrescu", 0 },
                    { 198, 0, new DateTime(2025, 8, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 1, 1, 0, false, "Alexandru Vasilescu", 0 },
                    { 199, 0, new DateTime(2025, 8, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 9, 9, 0, false, "Cătălin Gheorghe", 0 },
                    { 200, 0, new DateTime(2025, 8, 2, 2, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 8, 8, 0, false, "Cosmin Ionescu", 0 },
                    { 201, 0, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 20, 20, 0, false, "Paul Voicu", 0 },
                    { 202, 0, new DateTime(2025, 8, 2, 1, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 12, 12, 0, false, "Paul Voicu", 0 },
                    { 203, 0, new DateTime(2025, 8, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 11, 11, 0, false, "Daniel Petrescu", 0 },
                    { 204, 0, new DateTime(2025, 8, 2, 6, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 19, 19, 0, false, "Florin Stan", 0 },
                    { 205, 0, new DateTime(2025, 8, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 18, 18, 0, false, "Marius Popa", 0 },
                    { 206, 0, new DateTime(2025, 8, 2, 3, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 30, 30, 0, false, "Cristian Ene", 0 },
                    { 207, 0, new DateTime(2025, 8, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 22, 22, 0, false, "George Ilie", 0 },
                    { 208, 0, new DateTime(2025, 8, 2, 5, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 21, 21, 0, false, "Bogdan Neagu", 0 },
                    { 209, 0, new DateTime(2025, 8, 2, 6, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 29, 29, 0, false, "Mihai Rusu", 0 },
                    { 210, 0, new DateTime(2025, 8, 2, 8, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 28, 28, 0, false, "Paul Voicu", 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 211, 0, new DateTime(2025, 8, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 8, 8, 0, false, "Bogdan Neagu", 0 },
                    { 212, 0, new DateTime(2025, 8, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 7, 7, 0, false, "Marius Popa", 0 },
                    { 213, 0, new DateTime(2025, 8, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 6, 6, 0, false, "Daniel Petrescu", 0 },
                    { 214, 0, new DateTime(2025, 8, 9, 21, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 5, 5, 0, false, "Radu Marin", 0 },
                    { 215, 0, new DateTime(2025, 8, 9, 2, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 4, 4, 0, false, "Cătălin Gheorghe", 0 },
                    { 216, 0, new DateTime(2025, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 18, 18, 0, false, "Silviu Barbu", 0 },
                    { 217, 0, new DateTime(2025, 8, 9, 1, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 17, 17, 0, false, "Silviu Barbu", 0 },
                    { 218, 0, new DateTime(2025, 8, 9, 18, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 16, 16, 0, false, "Alexandru Vasilescu", 0 },
                    { 219, 0, new DateTime(2025, 8, 9, 6, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 15, 15, 0, false, "Iulian Nistor", 0 },
                    { 220, 0, new DateTime(2025, 8, 9, 11, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 14, 14, 0, false, "Mihai Rusu", 0 },
                    { 221, 0, new DateTime(2025, 8, 9, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 28, 28, 0, false, "Cosmin Ionescu", 0 },
                    { 222, 0, new DateTime(2025, 8, 9, 20, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 27, 27, 0, false, "George Ilie", 0 },
                    { 223, 0, new DateTime(2025, 8, 9, 5, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 26, 26, 0, false, "Andrei Dumitrescu", 0 },
                    { 224, 0, new DateTime(2025, 8, 9, 6, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 25, 25, 0, false, "Florin Stan", 0 },
                    { 225, 0, new DateTime(2025, 8, 9, 8, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 24, 24, 0, false, "Cristian Ene", 0 },
                    { 226, 0, new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 10, 10, 0, false, "George Ilie", 0 },
                    { 227, 0, new DateTime(2025, 8, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 3, 3, 0, false, "Alexandru Vasilescu", 0 },
                    { 228, 0, new DateTime(2025, 8, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 2, 2, 0, false, "Mihai Rusu", 0 },
                    { 229, 0, new DateTime(2025, 8, 16, 21, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 1, 1, 0, false, "Florin Stan", 0 },
                    { 230, 0, new DateTime(2025, 8, 16, 2, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 9, 9, 0, false, "Andrei Dumitrescu", 0 },
                    { 231, 0, new DateTime(2025, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 20, 20, 0, false, "Cristian Ene", 0 },
                    { 232, 0, new DateTime(2025, 8, 16, 1, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 13, 13, 0, false, "Cristian Ene", 0 },
                    { 233, 0, new DateTime(2025, 8, 16, 18, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 12, 12, 0, false, "Silviu Barbu", 0 },
                    { 234, 0, new DateTime(2025, 8, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 11, 11, 0, false, "Iulian Nistor", 0 },
                    { 235, 0, new DateTime(2025, 8, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 19, 19, 0, false, "Cosmin Ionescu", 0 },
                    { 236, 0, new DateTime(2025, 8, 16, 3, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 30, 30, 0, false, "Cătălin Gheorghe", 0 },
                    { 237, 0, new DateTime(2025, 8, 16, 20, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 23, 23, 0, false, "Daniel Petrescu", 0 },
                    { 238, 0, new DateTime(2025, 8, 16, 5, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 22, 22, 0, false, "Bogdan Neagu", 0 },
                    { 239, 0, new DateTime(2025, 8, 16, 6, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 21, 21, 0, false, "Marius Popa", 0 },
                    { 240, 0, new DateTime(2025, 8, 16, 8, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 29, 29, 0, false, "Paul Voicu", 0 },
                    { 241, 0, new DateTime(2025, 8, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 9, 9, 0, false, "Radu Marin", 0 },
                    { 242, 0, new DateTime(2025, 8, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 8, 8, 0, false, "Marius Popa", 0 },
                    { 243, 0, new DateTime(2025, 8, 23, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 7, 7, 0, false, "George Ilie", 0 },
                    { 244, 0, new DateTime(2025, 8, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 6, 6, 0, false, "Florin Stan", 0 },
                    { 245, 0, new DateTime(2025, 8, 23, 2, 0, 0, 0, DateTimeKind.Unspecified), 4, 1, 5, 5, 0, false, "Paul Voicu", 0 },
                    { 246, 0, new DateTime(2025, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 4, 19, 19, 0, false, "Cristian Ene", 0 },
                    { 247, 0, new DateTime(2025, 8, 23, 1, 0, 0, 0, DateTimeKind.Unspecified), 11, 4, 18, 18, 0, false, "Cristian Ene", 0 },
                    { 248, 0, new DateTime(2025, 8, 23, 18, 0, 0, 0, DateTimeKind.Unspecified), 12, 4, 17, 17, 0, false, "Iulian Nistor", 0 },
                    { 249, 0, new DateTime(2025, 8, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), 13, 4, 16, 16, 0, false, "Cosmin Ionescu", 0 },
                    { 250, 0, new DateTime(2025, 8, 23, 11, 0, 0, 0, DateTimeKind.Unspecified), 14, 4, 15, 15, 0, false, "Alexandru Vasilescu", 0 },
                    { 251, 0, new DateTime(2025, 8, 23, 3, 0, 0, 0, DateTimeKind.Unspecified), 30, 5, 29, 29, 0, false, "Silviu Barbu", 0 },
                    { 252, 0, new DateTime(2025, 8, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), 21, 5, 28, 28, 0, false, "Cătălin Gheorghe", 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 253, 0, new DateTime(2025, 8, 23, 5, 0, 0, 0, DateTimeKind.Unspecified), 22, 5, 27, 27, 0, false, "Daniel Petrescu", 0 },
                    { 254, 0, new DateTime(2025, 8, 23, 6, 0, 0, 0, DateTimeKind.Unspecified), 23, 5, 26, 26, 0, false, "Andrei Dumitrescu", 0 },
                    { 255, 0, new DateTime(2025, 8, 23, 8, 0, 0, 0, DateTimeKind.Unspecified), 24, 5, 25, 25, 0, false, "Mihai Rusu", 0 },
                    { 256, 0, new DateTime(2025, 8, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 10, 10, 0, false, "Bogdan Neagu", 0 },
                    { 257, 0, new DateTime(2025, 8, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 1, 4, 4, 0, false, "Radu Marin", 0 },
                    { 258, 0, new DateTime(2025, 8, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 3, 3, 0, false, "Cătălin Gheorghe", 0 },
                    { 259, 0, new DateTime(2025, 8, 30, 21, 0, 0, 0, DateTimeKind.Unspecified), 8, 1, 2, 2, 0, false, "Andrei Dumitrescu", 0 },
                    { 260, 0, new DateTime(2025, 8, 30, 2, 0, 0, 0, DateTimeKind.Unspecified), 9, 1, 1, 1, 0, false, "Bogdan Neagu", 0 },
                    { 261, 0, new DateTime(2025, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 4, 20, 20, 0, false, "Florin Stan", 0 },
                    { 262, 0, new DateTime(2025, 8, 30, 1, 0, 0, 0, DateTimeKind.Unspecified), 16, 4, 14, 14, 0, false, "Florin Stan", 0 },
                    { 263, 0, new DateTime(2025, 8, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), 17, 4, 13, 13, 0, false, "Iulian Nistor", 0 },
                    { 264, 0, new DateTime(2025, 8, 30, 6, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 12, 12, 0, false, "Radu Marin", 0 },
                    { 265, 0, new DateTime(2025, 8, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 19, 4, 11, 11, 0, false, "Mihai Rusu", 0 },
                    { 266, 0, new DateTime(2025, 8, 30, 3, 0, 0, 0, DateTimeKind.Unspecified), 25, 5, 30, 30, 0, false, "Marius Popa", 0 },
                    { 267, 0, new DateTime(2025, 8, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 26, 5, 24, 24, 0, false, "Daniel Petrescu", 0 },
                    { 268, 0, new DateTime(2025, 8, 30, 5, 0, 0, 0, DateTimeKind.Unspecified), 27, 5, 23, 23, 0, false, "Alexandru Vasilescu", 0 },
                    { 269, 0, new DateTime(2025, 8, 30, 6, 0, 0, 0, DateTimeKind.Unspecified), 28, 5, 22, 22, 0, false, "Silviu Barbu", 0 },
                    { 270, 0, new DateTime(2025, 8, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 29, 5, 21, 21, 0, false, "Paul Voicu", 0 },
                    { 271, 0, new DateTime(2025, 4, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, 1, 1, 1, true, "Radu Marin", 10 },
                    { 272, 2, new DateTime(2025, 4, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), 9, 2, 2, 2, 0, true, "Marius Popa", 10 },
                    { 273, 0, new DateTime(2025, 4, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), 31, 2, 3, 3, 1, true, "Florin Stan", 10 },
                    { 274, 1, new DateTime(2025, 4, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, 4, 4, 0, true, "Andrei Dumitrescu", 10 },
                    { 275, 1, new DateTime(2025, 4, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 5, 5, 2, true, "Iulian Nistor", 10 },
                    { 276, 0, new DateTime(2025, 4, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), 34, 2, 6, 6, 0, true, "Cosmin Ionescu", 10 },
                    { 277, 0, new DateTime(2025, 4, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), 35, 2, 7, 7, 0, true, "Alexandru Vasilescu", 10 },
                    { 278, 0, new DateTime(2025, 4, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), 36, 2, 8, 8, 1, true, "Silviu Barbu", 10 },
                    { 279, 2, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 10, 10, 0, true, "Radu Marin", 10 },
                    { 280, 3, new DateTime(2025, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 9, 9, 0, true, "Marius Popa", 10 },
                    { 281, 1, new DateTime(2025, 5, 7, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 31, 31, 1, true, "Florin Stan", 10 },
                    { 282, 0, new DateTime(2025, 5, 7, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, 2, 32, 32, 0, true, "Andrei Dumitrescu", 10 },
                    { 283, 0, new DateTime(2025, 5, 7, 18, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 33, 33, 2, true, "Iulian Nistor", 10 },
                    { 284, 0, new DateTime(2025, 5, 7, 20, 0, 0, 0, DateTimeKind.Unspecified), 6, 2, 34, 34, 1, true, "Cosmin Ionescu", 10 },
                    { 285, 3, new DateTime(2025, 5, 7, 22, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 35, 35, 0, true, "Alexandru Vasilescu", 10 },
                    { 286, 1, new DateTime(2025, 5, 7, 8, 0, 0, 0, DateTimeKind.Unspecified), 8, 2, 36, 36, 3, true, "Silviu Barbu", 10 },
                    { 287, 0, new DateTime(2025, 6, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 1, 1, 4, true, "Radu Marin", 10 },
                    { 288, 0, new DateTime(2025, 6, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 32, 2, 3, 3, 0, true, "Marius Popa", 10 },
                    { 289, 0, new DateTime(2025, 6, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 34, 34, 1, true, "Florin Stan", 10 },
                    { 290, 3, new DateTime(2025, 6, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), 36, 2, 7, 7, 3, true, "Andrei Dumitrescu", 10 },
                    { 291, 0, new DateTime(2025, 6, 8, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, 2, 0, true, "Radu Marin", 10 },
                    { 292, 1, new DateTime(2025, 6, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 32, 32, 0, true, "Marius Popa", 10 },
                    { 293, 0, new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 34, 2, 33, 33, 2, true, "Florin Stan", 10 },
                    { 294, 1, new DateTime(2025, 6, 8, 16, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 36, 36, 0, true, "Andrei Dumitrescu", 10 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 295, 0, new DateTime(2025, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1, 1, 3, true, "Radu Marin", 10 },
                    { 296, 0, new DateTime(2025, 7, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 7, 7, 0, true, "Marius Popa", 10 },
                    { 297, 3, new DateTime(2025, 7, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 3, 3, 2, true, "Andrei Dumitrescu", 10 },
                    { 298, 0, new DateTime(2025, 7, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 33, 33, 1, true, "Florin Stan", 10 },
                    { 299, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 33, 2, 1, 1, 0, false, "Radu Marin", 0 },
                    { 300, 0, new DateTime(2025, 8, 6, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 33, 33, 0, false, "Marius Popa", 0 },
                    { 301, 2, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 41, 3, 1, 1, 2, true, "Tomasz Nowak", 6 },
                    { 302, 0, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 42, 42, 1, true, "Marco Rossi", 8 },
                    { 303, 2, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 43, 43, 3, true, "Lars Andersen", 5 },
                    { 304, 2, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 47, 3, 44, 44, 0, true, "Francesco Bianchi", 7 },
                    { 305, 1, new DateTime(2025, 5, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), 46, 3, 45, 45, 1, true, "Kevin O'Connor", 9 },
                    { 306, 0, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 49, 49, 3, true, "Nikos Dimitriou", 7 },
                    { 307, 1, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, 41, 41, 0, true, "John Schmidt", 6 },
                    { 308, 3, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 46, 46, 2, true, "Carlos Pereira", 8 },
                    { 309, 1, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 47, 47, 1, true, "Diego Alvarez", 6 },
                    { 310, 0, new DateTime(2025, 5, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 48, 48, 1, true, "Omer Kaplan", 6 },
                    { 311, 1, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, 1, 1, 2, true, "Tomasz Nowak", 6 },
                    { 312, 3, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 41, 3, 43, 43, 1, true, "Marco Rossi", 5 },
                    { 313, 0, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 44, 44, 2, true, "Lars Andersen", 8 },
                    { 314, 1, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 45, 45, 0, true, "Francesco Bianchi", 6 },
                    { 315, 1, new DateTime(2025, 6, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), 47, 3, 46, 46, 1, true, "Kevin O'Connor", 8 },
                    { 316, 1, new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 41, 41, 3, true, "Nikos Dimitriou", 9 },
                    { 317, 0, new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 42, 42, 2, true, "John Schmidt", 8 },
                    { 318, 1, new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 49, 49, 1, true, "Carlos Pereira", 7 },
                    { 319, 0, new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 47, 47, 2, true, "Diego Alvarez", 6 },
                    { 320, 3, new DateTime(2025, 6, 18, 10, 0, 0, 0, DateTimeKind.Unspecified), 46, 3, 48, 48, 0, true, "Omer Kaplan", 8 },
                    { 321, 1, new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 1, 1, 1, true, "Tomasz Nowak", 7 },
                    { 322, 2, new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, 44, 44, 2, true, "Marco Rossi", 6 },
                    { 323, 3, new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 41, 3, 45, 45, 0, true, "Lars Andersen", 5 },
                    { 324, 0, new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 46, 46, 2, true, "Francesco Bianchi", 9 },
                    { 325, 2, new DateTime(2025, 7, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 47, 47, 2, true, "Kevin O'Connor", 8 },
                    { 326, 0, new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 42, 42, 0, false, "Nikos Dimitriou", 0 },
                    { 327, 0, new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 43, 43, 0, false, "John Schmidt", 0 },
                    { 328, 0, new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 47, 3, 49, 49, 0, false, "Carlos Pereira", 0 },
                    { 329, 0, new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 46, 3, 41, 41, 0, false, "Diego Alvarez", 0 },
                    { 330, 0, new DateTime(2025, 7, 16, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 48, 48, 0, false, "Omer Kaplan", 0 },
                    { 331, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 1, 1, 0, false, "Tomasz Nowak", 0 },
                    { 332, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 45, 45, 0, false, "Marco Rossi", 0 },
                    { 333, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, 46, 46, 0, false, "Lars Andersen", 0 },
                    { 334, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 41, 3, 47, 47, 0, false, "Francesco Bianchi", 0 },
                    { 335, 0, new DateTime(2025, 7, 30, 10, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 49, 49, 0, false, "Kevin O'Connor", 0 },
                    { 336, 0, new DateTime(2025, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 41, 41, 0, false, "Nikos Dimitriou", 0 }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeamScore", "GameDate", "AwayTeamId", "CompetitionId", "HomeTeamId", "StadiumId", "HomeTeamScore", "IsPlayed", "RefereeName", "TicketsSold" },
                values: new object[,]
                {
                    { 337, 0, new DateTime(2025, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 47, 3, 42, 42, 0, false, "John Schmidt", 0 },
                    { 338, 0, new DateTime(2025, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 49, 3, 43, 43, 0, false, "Carlos Pereira", 0 },
                    { 339, 0, new DateTime(2025, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 48, 3, 44, 44, 0, false, "Diego Alvarez", 0 },
                    { 340, 0, new DateTime(2025, 8, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 46, 46, 0, false, "Omer Kaplan", 0 },
                    { 341, 0, new DateTime(2025, 8, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 45, 3, 1, 1, 0, false, "Tomasz Nowak", 0 },
                    { 342, 0, new DateTime(2025, 8, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 46, 3, 47, 47, 0, false, "Marco Rossi", 0 },
                    { 343, 0, new DateTime(2025, 8, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 43, 3, 48, 48, 0, false, "Lars Andersen", 0 },
                    { 344, 0, new DateTime(2025, 8, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 44, 3, 49, 49, 0, false, "Francesco Bianchi", 0 },
                    { 345, 0, new DateTime(2025, 8, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), 42, 3, 41, 41, 0, false, "Kevin O'Connor", 0 }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "UsersId", "Text", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2864), 1, "FC Unirea este încântată să anunțe participarea în trei competiții importante în sezonul acesta: Liga 1, Cupa României și Champions League.\r\n        \r\n                    Participarea în **Liga 1** aduce un nou prilej pentru echipa noastră de a lupta pentru titlul național, alături de cele mai bune echipe din țară.\r\n\r\n                    În **Cupa României**, obiectivul nostru este să mergem cât mai departe în competiție și să aducem suporterilor momente de neuitat.\r\n\r\n                    Nu în ultimul rând, prezența în **Champions League** reprezintă un vis devenit realitate! Este o șansă uriașă pentru echipă de a se confrunta cu formații de top din Europa, de a acumula experiență și de a duce numele FC Unirea pe cele mai mari stadioane.\r\n\r\n                    Vă invităm să fiți alături de noi în acest sezon de excepție! Hai, Unirea!", "FC Unirea va participa în trei competiții sezonul acesta!" },
                    { 2, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2867), 1, "Echipa FC Unirea U21 va concura exclusiv în Liga 1 U21 în acest sezon, o competiție dedicată tinerilor talentați care fac parte din generația viitorului.\r\n\r\n                    Liga 1 U21 reprezintă o oportunitate excelentă pentru jucătorii noștri să-și demonstreze abilitățile și să facă pasul spre echipa mare. Antrenorii și staff-ul tehnic sunt încrezători că tinerii vor aduce rezultate bune și vor evolua de la meci la meci.\r\n\r\n                    Obiectivul principal este dezvoltarea jucătorilor, promovarea valorilor clubului și pregătirea lor pentru a face față provocărilor fotbalului de performanță.\r\n\r\n                    Susțineți FC Unirea U21 în această nouă aventură fotbalistică! Hai, Unirea!", "FC Unirea U21 va participa doar în Liga 1 U21 sezonul acesta!" },
                    { 3, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2868), 1, "Avem bucuria să anunțăm că echipa FC Unirea Youth va evolua în acest sezon în **Liga 1 de tineret**!\r\n\r\n                    Această competiție este dedicată tinerilor fotbaliști cu potențial, care se pregătesc pentru pasul următor în cariera lor sportivă. Obiectivul clubului este să descopere noi talente și să le ofere oportunitatea de a juca la nivel înalt încă de la o vârstă fragedă.\r\n\r\n                    Prin participarea în Liga 1 de tineret, FC Unirea Youth urmărește nu doar rezultate, ci și dezvoltarea continuă a jucătorilor, spiritul de echipă și promovarea fair-play-ului.\r\n\r\n                    Le dorim mult succes tinerilor noștri și suntem convinși că vor reprezenta cu mândrie culorile clubului! Susțineți FC Unirea Youth la fiecare meci!", "FC Unirea Youth va participa în Liga 1 de tineret!" },
                    { 4, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2869), 1, "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. \r\n                    De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\r\n\r\n                    Echipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. \r\n                    Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016.\r\n\r\n                    În prezent, echipa este pregătită de antrenorul Petrica Florea, sub îndrumarea căruia FC Unirea continuă să-și consolideze poziția în fotbalul românesc și să inspire o nouă generație de sportivi. \r\n                    Hai, Unirea!", "Despre FC Unirea – Istorie, valori și performanță" },
                    { 5, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2869), 1, "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. \r\n                    Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\r\n\r\n                    Încă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. \r\n                    Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\r\n\r\n                    Prin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. \r\n                    Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice.\r\n\r\n                    În prezent, echipa este pregătită de antrenorul Mihai Olaru, sub îndrumarea căruia tinerii își pot atinge potențialul și pot face pasul spre echipa de seniori.\r\n                    Hai, Unirea U21!", "FC Unirea U21 – Rampă de lansare pentru tinerii fotbaliști" },
                    { 6, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2871), 1, "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. \r\n                    Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\r\n\r\n                    Scopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. \r\n                    De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\r\n\r\n                    Prin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. \r\n                    Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune.\r\n\r\n                    În prezent, echipa este antrenată de Nica Cercel, un tehnician recunoscut pentru devotamentul său față de copii și pentru rezultatele obținute la nivel juvenil. \r\n                    Hai, Unirea Youth!", "FC Unirea Youth – Academia care formează viitorul clubului" },
                    { 7, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2872), 1, "Echipa FC Unirea pornește la drum în noul sezon cu un lot valoros, format din jucători experimentați și tineri de perspectivă. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Daniel Rădulescu (1992)  \r\n                    - Denis Chiriac (1997)  \r\n                    - Alin Neagu (2006)  \r\n                    - Ionuț Rădulescu (2004)  \r\n\r\n                    **Fundași:**  \r\n                    - Ștefan Popescu (1996)  \r\n                    - Radu Ilie (1999)  \r\n                    - Alex Lazăr (1995)  \r\n                    - Andrei Enache (1998)  \r\n                    - Andrei Neagu (2004)  \r\n                    - Robert Vasilescu (1996)  \r\n                    - Vlad Enache (1990)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Mihai Toma (2000)  \r\n                    - Daniel Matei (1994)  \r\n                    - Sergiu Chiriac (1990)  \r\n                    - Denis Neagu (1999)  \r\n                    - George Ilie (2004)  \r\n                    - Gabriel Vasilescu (2005)  \r\n\r\n                    **Atacanți:**  \r\n                    - Daniel Stan (2003)  \r\n                    - Alex Vasilescu (1994)  \r\n                    - Denis Ilie (1991)  \r\n\r\n                    Echipa este pregătită să facă performanță și să aducă noi bucurii suporterilor!\r\n\r\n                    Hai, Unirea!", "Lotul echipei FC Unirea pentru sezonul actual" },
                    { 8, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2872), 1, "FC Unirea U21 abordează noul sezon cu o echipă tânără, plină de entuziasm și determinare. Lotul reunește atât jucători cu experiență la nivel de juniori, cât și talente aflate la început de drum, dornice să confirme la cel mai înalt nivel al fotbalului de tineret. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Denis Lazar (2004)  \r\n                    - Eduard Georgescu (2006)  \r\n                    - Alin Dumitrescu (2008)  \r\n                    - Eduard Diaconu (2005)  \r\n                    - Robert Dumitrescu (2007)  \r\n\r\n                    **Fundași:**  \r\n                    - George Diaconu (2006)  \r\n                    - Adrian Toma (2007)  \r\n                    - Alin Diaconu (2004)  \r\n                    - Alin Voicu (2005)  \r\n                    - Sergiu Radulescu (2005)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Daniel Ilie (2008)  \r\n                    - Alex Matei (2005)  \r\n                    - Robert Cojocaru (2008)  \r\n                    - Denis Cojocaru (2007)  \r\n\r\n                    **Atacanți:**  \r\n                    - Cristian Ilie (2005)  \r\n                    - Robert Ionescu (2004)  \r\n                    - Robert Radulescu (2007)  \r\n                    - Florin Matei (2005)  \r\n                    - Sergiu Neagu (2004)  \r\n                    - Eduard Popescu (2004)  \r\n\r\n                    Prin această selecție, FC Unirea U21 își propune să crească jucători valoroși, capabili să facă pasul spre fotbalul de seniori.\r\n\r\n                    Mult succes în noul sezon, U21! Hai, Unirea!", "Lotul echipei FC Unirea U21 pentru sezonul actual" },
                    { 9, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2873), 1, "FC Unirea Youth aliniază în acest sezon un lot numeros, format din copii și adolescenți talentați, cu dorință de afirmare și mult entuziasm. Mulți dintre acești jucători reprezintă viitorul clubului și al fotbalului local. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Cristian Matei (2011)  \r\n                    - Vlad Ilie (2012)  \r\n                    - Ionuț Neagu (2009)  \r\n                    - Adrian Cojocaru (2012)  \r\n                    - Paul Vasilescu (2011)  \r\n                    - Alin Neagu (2010)  \r\n                    - Cristian Chiriac (2010)  \r\n\r\n                    **Fundași:**  \r\n                    - Gabriel Ionescu (2011)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Alin Vasilescu (2012)  \r\n                    - Andrei Ionescu (2009)  \r\n                    - Vlad Ionescu (2011)  \r\n                    - Sergiu Enache (2011)  \r\n                    - Alex Vasilescu (2010)  \r\n                    - Adrian Toma (2009)  \r\n                    - Vlad Neagu (2011)  \r\n                    - Ionuț Ilie (2010)  \r\n\r\n                    **Atacanți:**  \r\n                    - Paul Rădulescu (2011)  \r\n                    - Alin Ionescu (2009)  \r\n                    - George Neagu (2010)  \r\n                    - Ionuț Diaconu (2009)  \r\n\r\n                    Clubul investește permanent în dezvoltarea acestor copii, asigurându-le pregătire modernă și condiții optime pentru a-și atinge potențialul. Mult succes, Unirea Youth!\r\n\r\n                    Hai, Unirea!", "Lotul echipei FC Unirea Youth pentru sezonul actual" },
                    { 10, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2874), 1, "FC Unirea Youth intră în noul sezon cu o echipă tânără și echilibrată, construită pe valori solide și pe dorința de afirmare a fiecărui copil. Jucătorii acestei generații sunt dovada investiției clubului în viitor, iar energia și ambiția lor se văd la fiecare antrenament și meci. Iată lotul complet:\r\n\r\n                    **Portari:**  \r\n                    - Adrian Cojocaru (2012)  \r\n                    - Alin Neagu (2010)  \r\n                    - Cristian Chiriac (2010)  \r\n\r\n                    **Fundași:**  \r\n                    - Cristian Matei (2011)  \r\n                    - Vlad Ilie (2012)  \r\n                    - Ionuț Neagu (2009)  \r\n                    - Gabriel Ionescu (2011)  \r\n                    - Paul Vasilescu (2011)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Alin Vasilescu (2012)  \r\n                    - Andrei Ionescu (2009)  \r\n                    - Vlad Ionescu (2011)  \r\n                    - Sergiu Enache (2011)  \r\n                    - Alex Vasilescu (2010)  \r\n                    - Adrian Toma (2009)  \r\n                    - Vlad Neagu (2011)  \r\n                    - Ionuț Ilie (2010)  \r\n\r\n                    **Atacanți:**  \r\n                    - Paul Rădulescu (2011)  \r\n                    - Alin Ionescu (2009)  \r\n                    - George Neagu (2010)  \r\n                    - Ionuț Diaconu (2009)  \r\n\r\n                    Lotul este rezultatul muncii academiei și reflectă preocuparea permanentă pentru dezvoltarea tinerelor talente.  \r\n                    Succes, Unirea Youth! Hai, copii!", "Lotul echipei FC Unirea Youth pentru sezonul actual" },
                    { 11, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2875), 1, "FC Unirea își dispută meciurile de acasă pe **Unirea Stadium**, situat în orașul Odobești.\r\n\r\n                    Stadionul dispune de o capacitate de 10 locuri și este destinat exclusiv meciurilor echipelor clubului, oferind o atmosferă caldă și apropiată de comunitatea locală. De-a lungul timpului, Unirea Stadium a găzduit numeroase momente speciale pentru suporterii alb-albaștrilor, devenind un simbol al pasiunii pentru fotbal în zonă.\r\n\r\n                    Fiecare partidă jucată pe Unirea Stadium înseamnă emoție, determinare și susținere necondiționată din partea fanilor. Clubul mulțumește tuturor celor care vin să susțină echipa și promite să facă din fiecare meci o adevărată sărbătoare a fotbalului.\r\n\r\n                    Hai, Unirea!", "Acasă pentru FC Unirea: Unirea Stadium din Odobești" },
                    { 12, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2876), 1, "FC Unirea U21 joacă meciurile de acasă pe **Unirea U21 Stadium**, în orașul Odobești.\r\n\r\n                    Stadionul oferă o capacitate de 10 locuri și a devenit un loc familiar pentru generațiile de tineri fotbaliști ai clubului. Fiecare partidă disputată aici este o oportunitate pentru juniorii noștri să impresioneze și să-și construiască drumul spre performanță.\r\n\r\n                    Suporterii care vin pe Unirea U21 Stadium creează o atmosferă caldă și încurajatoare, ajutând echipa să se simtă mereu susținută, indiferent de rezultat. Stadionul reprezintă un punct de pornire spre cariere de succes pentru mulți jucători crescuți la FC Unirea.\r\n\r\n                    Mult succes în noul sezon, Unirea U21!\r\n                    Hai, Unirea!", "Unirea U21 Stadium – Casa tinerilor de la FC Unirea U21" },
                    { 13, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2877), 1, "FC Unirea Youth își dispută meciurile de acasă pe **Unirea Youth Stadium**, situat în Odobești.\r\n\r\n                    Acest stadion, cu o capacitate de 10 locuri, este locul unde copiii și adolescenții clubului fac primii pași în fotbalul organizat. Pentru mulți dintre ei, Unirea Youth Stadium reprezintă locul unde pasiunea pentru fotbal se transformă în visuri, prietenii și primele reușite sportive.\r\n\r\n                    Fiecare meci disputat aici este o oportunitate de a învăța, de a se bucura de fotbal și de a construi viitorul clubului. Atmosfera este mereu caldă, iar suporterii prezenți îi încurajează pe tinerii jucători la fiecare pas.\r\n\r\n                    Hai, Unirea Youth!", "Unirea Youth Stadium – Terenul de joacă al viitorilor campioni" },
                    { 14, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2877), 1, "La fiecare meci disputat pe **Unirea Stadium** din Odobești, suporterii au la dispoziție o gamă variată de locuri, atât pentru cei care preferă confortul maxim, cât și pentru cei care vor să simtă pulsul tribunei alături de ceilalți fani.\r\n\r\n                    **Locuri disponibile:**  \r\n                    - VIP: A1, A2 (preț: 150 lei/bilet)  \r\n                    - Standard: B1, B2, C1, C2, D1, D2, E1, E2 (preț: 50 lei/bilet)  \r\n\r\n                    Indiferent de tipul biletului ales, fiecare suporter contribuie la atmosfera specială de pe stadion și la susținerea echipei. Vă așteptăm la fiecare meci să vă bucurați de fotbal și să susțineți FC Unirea din tribunele noastre!\r\n\r\n                    Hai, Unirea!", "Locurile disponibile la meciurile de acasă pe Unirea Stadium" }
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
                    { 12, new DateTime(1999, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Neagu", 1, 1 },
                    { 13, new DateTime(2006, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Neagu", 1, 3 },
                    { 14, new DateTime(1991, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Ilie", 1, 0 },
                    { 15, new DateTime(2004, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ilie", 1, 1 },
                    { 16, new DateTime(2005, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 1, 1 },
                    { 17, new DateTime(2004, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Neagu", 1, 2 },
                    { 18, new DateTime(2004, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Radulescu", 1, 3 },
                    { 19, new DateTime(1996, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Vasilescu", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 54, new DateTime(1996, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Radulescu", 3, 3 },
                    { 55, new DateTime(2005, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Chiriac", 3, 2 },
                    { 56, new DateTime(1991, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Toma", 3, 0 },
                    { 57, new DateTime(2003, 8, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Popescu", 3, 3 },
                    { 58, new DateTime(1990, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Neagu", 3, 2 },
                    { 59, new DateTime(2000, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 3, 2 },
                    { 60, new DateTime(1994, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Stan", 3, 2 },
                    { 61, new DateTime(1990, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Georgescu", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 96, new DateTime(1991, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Popescu", 5, 1 },
                    { 97, new DateTime(1992, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Voicu", 5, 1 },
                    { 98, new DateTime(2003, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Dumitrescu", 5, 1 },
                    { 99, new DateTime(2001, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Georgescu", 5, 3 },
                    { 100, new DateTime(2003, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Petrescu", 5, 2 },
                    { 101, new DateTime(1992, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Marin", 6, 2 },
                    { 102, new DateTime(1991, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Voicu", 6, 0 },
                    { 103, new DateTime(1993, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Dumitrescu", 6, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 138, new DateTime(1992, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Matei", 7, 3 },
                    { 139, new DateTime(2000, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cojocaru", 7, 2 },
                    { 140, new DateTime(1997, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Neagu", 7, 1 },
                    { 141, new DateTime(2003, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Lazar", 8, 2 },
                    { 142, new DateTime(1999, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Vasilescu", 8, 0 },
                    { 143, new DateTime(1996, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Cojocaru", 8, 0 },
                    { 144, new DateTime(1993, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eduard Popescu", 8, 3 },
                    { 145, new DateTime(2003, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Georgescu", 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 180, new DateTime(1997, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Popescu", 9, 1 },
                    { 181, new DateTime(1995, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Radulescu", 10, 2 },
                    { 182, new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 10, 2 },
                    { 183, new DateTime(2004, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Voicu", 10, 1 },
                    { 184, new DateTime(2003, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Voicu", 10, 0 },
                    { 185, new DateTime(1991, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Ilie", 10, 1 },
                    { 186, new DateTime(2002, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Lazar", 10, 0 },
                    { 187, new DateTime(2006, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 10, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 222, new DateTime(2008, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Neagu", 12, 1 },
                    { 223, new DateTime(2007, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Stan", 12, 1 },
                    { 224, new DateTime(2006, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 12, 0 },
                    { 225, new DateTime(2006, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Marin", 12, 2 },
                    { 226, new DateTime(2006, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Popescu", 12, 1 },
                    { 227, new DateTime(2004, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Voicu", 12, 0 },
                    { 228, new DateTime(2004, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Enache", 12, 0 },
                    { 229, new DateTime(2007, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Vasilescu", 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 264, new DateTime(2004, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Lazar", 14, 3 },
                    { 265, new DateTime(2004, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 14, 2 },
                    { 266, new DateTime(2005, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Lazar", 14, 2 },
                    { 267, new DateTime(2005, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 14, 2 },
                    { 268, new DateTime(2004, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Toma", 14, 1 },
                    { 269, new DateTime(2007, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Cojocaru", 14, 0 },
                    { 270, new DateTime(2008, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 14, 3 },
                    { 271, new DateTime(2008, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Voicu", 14, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 306, new DateTime(2005, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Voicu", 16, 1 },
                    { 307, new DateTime(2008, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Marin", 16, 0 },
                    { 308, new DateTime(2007, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Radulescu", 16, 0 },
                    { 309, new DateTime(2007, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Diaconu", 16, 0 },
                    { 310, new DateTime(2004, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Ionescu", 16, 1 },
                    { 311, new DateTime(2007, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 16, 0 },
                    { 312, new DateTime(2004, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Popescu", 16, 0 },
                    { 313, new DateTime(2005, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Toma", 16, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 348, new DateTime(2006, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Enache", 18, 3 },
                    { 349, new DateTime(2004, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Barbu", 18, 2 },
                    { 350, new DateTime(2004, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Diaconu", 18, 2 },
                    { 351, new DateTime(2005, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 18, 1 },
                    { 352, new DateTime(2004, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Radulescu", 18, 3 },
                    { 353, new DateTime(2006, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Matei", 18, 0 },
                    { 354, new DateTime(2005, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Petrescu", 18, 1 },
                    { 355, new DateTime(2005, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Neagu", 18, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 390, new DateTime(2006, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Dumitrescu", 20, 1 },
                    { 391, new DateTime(2007, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 20, 1 },
                    { 392, new DateTime(2007, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Barbu", 20, 1 },
                    { 393, new DateTime(2006, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Georgescu", 20, 1 },
                    { 394, new DateTime(2004, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Popescu", 20, 2 },
                    { 395, new DateTime(2008, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Lazar", 20, 3 },
                    { 396, new DateTime(2006, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Cojocaru", 20, 0 },
                    { 397, new DateTime(2005, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Georgescu", 20, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 398, new DateTime(2004, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Cojocaru", 20, 2 },
                    { 399, new DateTime(2007, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 20, 3 },
                    { 400, new DateTime(2008, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Ionescu", 20, 0 },
                    { 401, new DateTime(2011, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Radulescu", 21, 0 },
                    { 402, new DateTime(2011, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Matei", 21, 2 },
                    { 403, new DateTime(2012, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ilie", 21, 2 },
                    { 404, new DateTime(2012, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Vasilescu", 21, 1 },
                    { 405, new DateTime(2009, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Ionescu", 21, 1 },
                    { 406, new DateTime(2009, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 21, 2 },
                    { 407, new DateTime(2011, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 21, 1 },
                    { 408, new DateTime(2011, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Ionescu", 21, 2 },
                    { 409, new DateTime(2012, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Cojocaru", 21, 3 },
                    { 410, new DateTime(2011, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Enache", 21, 1 },
                    { 411, new DateTime(2011, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Vasilescu", 21, 2 },
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
                    { 432, new DateTime(2010, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Chiriac", 22, 0 },
                    { 433, new DateTime(2011, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Lazar", 22, 1 },
                    { 434, new DateTime(2011, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Marin", 22, 3 },
                    { 435, new DateTime(2011, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Neagu", 22, 2 },
                    { 436, new DateTime(2009, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 22, 1 },
                    { 437, new DateTime(2009, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Vasilescu", 22, 2 },
                    { 438, new DateTime(2010, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Lazar", 22, 1 },
                    { 439, new DateTime(2012, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Dumitrescu", 22, 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 474, new DateTime(2012, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Petrescu", 24, 0 },
                    { 475, new DateTime(2011, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Neagu", 24, 0 },
                    { 476, new DateTime(2010, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex Popescu", 24, 1 },
                    { 477, new DateTime(2009, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Ilie", 24, 0 },
                    { 478, new DateTime(2009, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Diaconu", 24, 1 },
                    { 479, new DateTime(2010, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Marin", 24, 1 },
                    { 480, new DateTime(2012, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 24, 1 },
                    { 481, new DateTime(2010, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Radulescu", 25, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 516, new DateTime(2009, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 26, 1 },
                    { 517, new DateTime(2012, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cojocaru", 26, 1 },
                    { 518, new DateTime(2012, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Lazar", 26, 0 },
                    { 519, new DateTime(2009, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Petrescu", 26, 1 },
                    { 520, new DateTime(2009, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Popescu", 26, 3 },
                    { 521, new DateTime(2010, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Ionescu", 27, 0 },
                    { 522, new DateTime(2009, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alin Vasilescu", 27, 3 },
                    { 523, new DateTime(2011, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Dumitrescu", 27, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 558, new DateTime(2012, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Barbu", 28, 1 },
                    { 559, new DateTime(2011, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Radulescu", 28, 1 },
                    { 560, new DateTime(2010, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Ionescu", 28, 0 },
                    { 561, new DateTime(2009, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tudor Petrescu", 29, 2 },
                    { 562, new DateTime(2011, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ionescu", 29, 2 },
                    { 563, new DateTime(2010, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergiu Toma", 29, 3 },
                    { 564, new DateTime(2012, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Diaconu", 29, 2 },
                    { 565, new DateTime(2011, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Toma", 29, 0 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
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
                    { 600, new DateTime(2010, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 30, 0 },
                    { 601, new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Ionescu", 31, 2 },
                    { 602, new DateTime(1992, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Ionescu", 31, 1 },
                    { 603, new DateTime(2004, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Voicu", 31, 3 },
                    { 604, new DateTime(2003, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Voicu", 31, 0 },
                    { 605, new DateTime(2003, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Zamfir", 31, 2 },
                    { 606, new DateTime(1988, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Nistor", 31, 1 },
                    { 607, new DateTime(2004, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Petrescu", 31, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 608, new DateTime(1986, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Cojocaru", 31, 0 },
                    { 609, new DateTime(2002, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Popa", 31, 2 },
                    { 610, new DateTime(2000, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Ionescu", 31, 1 },
                    { 611, new DateTime(2004, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Voicu", 31, 3 },
                    { 612, new DateTime(1998, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Popa", 31, 0 },
                    { 613, new DateTime(1989, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Georgescu", 31, 2 },
                    { 614, new DateTime(2007, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Cojoc", 31, 1 },
                    { 615, new DateTime(1989, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Cristea", 31, 3 },
                    { 616, new DateTime(1999, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Tudor", 31, 0 },
                    { 617, new DateTime(1990, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Neagu", 31, 2 },
                    { 618, new DateTime(1997, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Cojoc", 31, 1 },
                    { 619, new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Ionescu", 31, 3 },
                    { 620, new DateTime(1986, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Vasilescu", 31, 0 },
                    { 621, new DateTime(2005, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Cojoc", 32, 2 },
                    { 622, new DateTime(1986, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 32, 1 },
                    { 623, new DateTime(1986, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Tudor", 32, 3 },
                    { 624, new DateTime(1992, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Tudor", 32, 0 },
                    { 625, new DateTime(2007, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Zamfir", 32, 2 },
                    { 626, new DateTime(1985, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Nistor", 32, 1 },
                    { 627, new DateTime(1990, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Cojocaru", 32, 3 },
                    { 628, new DateTime(2000, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Georgescu", 32, 0 },
                    { 629, new DateTime(1985, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Enache", 32, 2 },
                    { 630, new DateTime(1994, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Zamfir", 32, 1 },
                    { 631, new DateTime(1985, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 32, 3 },
                    { 632, new DateTime(1990, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Petrescu", 32, 0 },
                    { 633, new DateTime(1987, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Popescu", 32, 2 },
                    { 634, new DateTime(2003, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Stan", 32, 1 },
                    { 635, new DateTime(2003, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Stan", 32, 3 },
                    { 636, new DateTime(2000, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Georgescu", 32, 0 },
                    { 637, new DateTime(1987, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Voicu", 32, 2 },
                    { 638, new DateTime(2004, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 32, 1 },
                    { 639, new DateTime(2006, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Voicu", 32, 3 },
                    { 640, new DateTime(2000, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Popescu", 32, 0 },
                    { 641, new DateTime(1985, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Dumitrescu", 33, 2 },
                    { 642, new DateTime(1989, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Albu", 33, 1 },
                    { 643, new DateTime(1991, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Enache", 33, 3 },
                    { 644, new DateTime(1997, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Popescu", 33, 0 },
                    { 645, new DateTime(1996, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Ionescu", 33, 2 },
                    { 646, new DateTime(1987, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Cojocaru", 33, 1 },
                    { 647, new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cristea", 33, 3 },
                    { 648, new DateTime(1992, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Neagu", 33, 0 },
                    { 649, new DateTime(1986, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Neagu", 33, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 650, new DateTime(1988, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Enache", 33, 1 },
                    { 651, new DateTime(2006, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Zamfir", 33, 3 },
                    { 652, new DateTime(1987, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Popescu", 33, 0 },
                    { 653, new DateTime(1995, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Avram", 33, 2 },
                    { 654, new DateTime(1994, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Petrescu", 33, 1 },
                    { 655, new DateTime(1985, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Ionescu", 33, 3 },
                    { 656, new DateTime(2007, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Dinu", 33, 0 },
                    { 657, new DateTime(1995, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Avram", 33, 2 },
                    { 658, new DateTime(1998, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Cojoc", 33, 1 },
                    { 659, new DateTime(1997, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Popescu", 33, 3 },
                    { 660, new DateTime(2003, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Dinu", 33, 0 },
                    { 661, new DateTime(1988, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ionut Neagu", 34, 2 },
                    { 662, new DateTime(2002, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Dumitrescu", 34, 1 },
                    { 663, new DateTime(1988, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Enache", 34, 3 },
                    { 664, new DateTime(1985, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Ionescu", 34, 0 },
                    { 665, new DateTime(1988, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Tudor", 34, 2 },
                    { 666, new DateTime(1985, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Cojoc", 34, 1 },
                    { 667, new DateTime(2001, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Avram", 34, 3 },
                    { 668, new DateTime(1996, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Albu", 34, 0 },
                    { 669, new DateTime(1998, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Dumitrescu", 34, 2 },
                    { 670, new DateTime(1987, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Nistor", 34, 1 },
                    { 671, new DateTime(2006, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Tudor", 34, 3 },
                    { 672, new DateTime(2007, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Ionescu", 34, 0 },
                    { 673, new DateTime(2001, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Petrescu", 34, 2 },
                    { 674, new DateTime(1996, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Popa", 34, 1 },
                    { 675, new DateTime(2005, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Vasilescu", 34, 3 },
                    { 676, new DateTime(1986, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Tudor", 34, 0 },
                    { 677, new DateTime(1988, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Nistor", 34, 2 },
                    { 678, new DateTime(1987, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cristian Popa", 34, 1 },
                    { 679, new DateTime(1997, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Petrescu", 34, 3 },
                    { 680, new DateTime(1990, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Petrescu", 34, 0 },
                    { 681, new DateTime(1985, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Georgescu", 35, 2 },
                    { 682, new DateTime(1994, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Cojoc", 35, 1 },
                    { 683, new DateTime(2005, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrei Ionescu", 35, 3 },
                    { 684, new DateTime(2004, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Cristea", 35, 0 },
                    { 685, new DateTime(1986, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Avram", 35, 2 },
                    { 686, new DateTime(1989, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Popa", 35, 1 },
                    { 687, new DateTime(1989, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Enache", 35, 3 },
                    { 688, new DateTime(1991, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Petrescu", 35, 0 },
                    { 689, new DateTime(1997, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Petrescu", 35, 2 },
                    { 690, new DateTime(1994, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Vasilescu", 35, 1 },
                    { 691, new DateTime(2001, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denis Tudor", 35, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 692, new DateTime(1991, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Popa", 35, 0 },
                    { 693, new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Vasilescu", 35, 2 },
                    { 694, new DateTime(1999, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Radu Enache", 35, 1 },
                    { 695, new DateTime(2001, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Popa", 35, 3 },
                    { 696, new DateTime(1993, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Stan", 35, 0 },
                    { 697, new DateTime(1987, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihai Neagu", 35, 2 },
                    { 698, new DateTime(1985, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Enache", 35, 1 },
                    { 699, new DateTime(1989, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Neagu", 35, 3 },
                    { 700, new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sorin Dumitrescu", 35, 0 },
                    { 701, new DateTime(2006, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Popa", 36, 2 },
                    { 702, new DateTime(2007, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandru Neagu", 36, 1 },
                    { 703, new DateTime(2002, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vlad Stan", 36, 3 },
                    { 704, new DateTime(2005, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Neagu", 36, 0 },
                    { 705, new DateTime(1987, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Vasilescu", 36, 2 },
                    { 706, new DateTime(1994, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emil Petrescu", 36, 1 },
                    { 707, new DateTime(2000, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Zamfir", 36, 3 },
                    { 708, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Dinu", 36, 0 },
                    { 709, new DateTime(1998, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Petrescu", 36, 2 },
                    { 710, new DateTime(1991, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Nistor", 36, 1 },
                    { 711, new DateTime(1989, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriel Cojoc", 36, 3 },
                    { 712, new DateTime(2006, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Voicu", 36, 0 },
                    { 713, new DateTime(1996, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Ionescu", 36, 2 },
                    { 714, new DateTime(1986, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florin Zamfir", 36, 1 },
                    { 715, new DateTime(1993, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Valentin Voicu", 36, 3 },
                    { 716, new DateTime(1996, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Popescu", 36, 0 },
                    { 717, new DateTime(2005, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Cojocaru", 36, 2 },
                    { 718, new DateTime(1986, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adrian Nistor", 36, 1 },
                    { 719, new DateTime(2001, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Voicu", 36, 3 },
                    { 720, new DateTime(2006, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cosmin Voicu", 36, 0 },
                    { 801, new DateTime(1997, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola Mitrovic", 41, 2 },
                    { 802, new DateTime(1996, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milos Jovic", 41, 1 },
                    { 803, new DateTime(2007, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko Stojkovic", 41, 3 },
                    { 804, new DateTime(1988, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefan Vesic", 41, 0 },
                    { 805, new DateTime(1988, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dusan Petrovic", 41, 2 },
                    { 806, new DateTime(1988, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vladimir Savic", 41, 1 },
                    { 807, new DateTime(1995, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aleksandar Radovanovic", 41, 3 },
                    { 808, new DateTime(2003, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nemanja Zivkovic", 41, 0 },
                    { 809, new DateTime(2000, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka Tadic", 41, 2 },
                    { 810, new DateTime(1986, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jovan Popovic", 41, 1 },
                    { 811, new DateTime(2004, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petar Milinkovic", 41, 3 },
                    { 812, new DateTime(2005, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uros Milenkovic", 41, 0 },
                    { 813, new DateTime(1994, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Branislav Pavlovic", 41, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 814, new DateTime(2006, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan Simic", 41, 1 },
                    { 815, new DateTime(1990, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goran Kostic", 41, 3 },
                    { 816, new DateTime(1988, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dragan Matic", 41, 0 },
                    { 817, new DateTime(1994, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slobodan Ristic", 41, 2 },
                    { 818, new DateTime(1988, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoran Gajic", 41, 1 },
                    { 819, new DateTime(1992, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Milan Nikolic", 41, 3 },
                    { 820, new DateTime(2001, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bogdan Lazic", 41, 0 },
                    { 821, new DateTime(2002, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ivan Kovacic", 42, 2 },
                    { 822, new DateTime(1993, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luka Perisic", 42, 1 },
                    { 823, new DateTime(2004, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marko Brekalo", 42, 3 },
                    { 824, new DateTime(2005, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josip Livakovic", 42, 0 },
                    { 825, new DateTime(1995, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ante Gvardiol", 42, 2 },
                    { 826, new DateTime(1986, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Karlo Orsic", 42, 1 },
                    { 827, new DateTime(2002, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dario Melnjak", 42, 3 },
                    { 828, new DateTime(2005, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomislav Majer", 42, 0 },
                    { 829, new DateTime(2004, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stipe Juranovic", 42, 2 },
                    { 830, new DateTime(1985, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fran Barisic", 42, 1 },
                    { 831, new DateTime(2003, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domagoj Brozovic", 42, 3 },
                    { 832, new DateTime(1986, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mario Budimir", 42, 0 },
                    { 833, new DateTime(1987, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Filip Vrsaljko", 42, 2 },
                    { 834, new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krunoslav Musa", 42, 1 },
                    { 835, new DateTime(1989, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lovro Colak", 42, 3 },
                    { 836, new DateTime(2000, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matija Skoric", 42, 0 },
                    { 837, new DateTime(1989, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikola Palaversa", 42, 2 },
                    { 838, new DateTime(2006, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petar Bradaric", 42, 1 },
                    { 839, new DateTime(1994, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sime Tudor", 42, 3 },
                    { 840, new DateTime(1997, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zvonimir Caleta-Car", 42, 0 },
                    { 841, new DateTime(2007, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giorgos Papadopoulos", 43, 2 },
                    { 842, new DateTime(1985, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dimitris Stamatopoulos", 43, 1 },
                    { 843, new DateTime(1997, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasilis Karagounis", 43, 3 },
                    { 844, new DateTime(1986, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kostas Ninis", 43, 0 },
                    { 845, new DateTime(1986, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nikolaos Mitroglou", 43, 2 },
                    { 846, new DateTime(2002, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giannis Tzavellas", 43, 1 },
                    { 847, new DateTime(1987, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anastasios Manolas", 43, 3 },
                    { 848, new DateTime(2006, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panagiotis Samaris", 43, 0 },
                    { 849, new DateTime(2007, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christos Siovas", 43, 2 },
                    { 850, new DateTime(2007, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andreas Bouchalakis", 43, 1 },
                    { 851, new DateTime(1989, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spyros Kourbelis", 43, 3 },
                    { 852, new DateTime(1994, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lefteris Zeca", 43, 0 },
                    { 853, new DateTime(1986, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stavros Giakoumakis", 43, 2 },
                    { 854, new DateTime(2007, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apostolos Tsimikas", 43, 1 },
                    { 855, new DateTime(1999, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonis Koulouris", 43, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 856, new DateTime(1990, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marios Retsos", 43, 0 },
                    { 857, new DateTime(2004, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manolis Bakakis", 43, 2 },
                    { 858, new DateTime(2000, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sotiris Masouras", 43, 1 },
                    { 859, new DateTime(2004, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petros Lampropoulos", 43, 3 },
                    { 860, new DateTime(2007, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thanasis Pelkas", 43, 0 },
                    { 861, new DateTime(2002, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emre Yilmaz", 44, 2 },
                    { 862, new DateTime(2004, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mehmet Demir", 44, 1 },
                    { 863, new DateTime(2007, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmet Kilic", 44, 3 },
                    { 864, new DateTime(1997, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mustafa Ozturk", 44, 0 },
                    { 865, new DateTime(1997, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hakan Kaya", 44, 2 },
                    { 866, new DateTime(2001, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murat Aydin", 44, 1 },
                    { 867, new DateTime(2007, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali Korkmaz", 44, 3 },
                    { 868, new DateTime(1996, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serkan Gunes", 44, 0 },
                    { 869, new DateTime(1997, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burak Cetin", 44, 2 },
                    { 870, new DateTime(2002, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cem Yildirim", 44, 1 },
                    { 871, new DateTime(1993, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Baris Sahin", 44, 3 },
                    { 872, new DateTime(1993, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eren Erdogan", 44, 0 },
                    { 873, new DateTime(2002, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Can Polat", 44, 2 },
                    { 874, new DateTime(1995, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Okan Turan", 44, 1 },
                    { 875, new DateTime(2003, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sefa Acar", 44, 3 },
                    { 876, new DateTime(2006, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gokhan Kara", 44, 0 },
                    { 877, new DateTime(1986, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yusuf Durmaz", 44, 2 },
                    { 878, new DateTime(1990, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Umut Aslan", 44, 1 },
                    { 879, new DateTime(1991, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Halil Dogan", 44, 3 },
                    { 880, new DateTime(1995, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fatih Guler", 44, 0 },
                    { 881, new DateTime(2001, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordi Garcia", 45, 2 },
                    { 882, new DateTime(1997, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sergio Martinez", 45, 1 },
                    { 883, new DateTime(1985, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andres Lopez", 45, 3 },
                    { 884, new DateTime(1997, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro Hernandez", 45, 0 },
                    { 885, new DateTime(1999, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alejandro Gonzalez", 45, 2 },
                    { 886, new DateTime(1989, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Perez", 45, 1 },
                    { 887, new DateTime(1988, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Sanchez", 45, 3 },
                    { 888, new DateTime(1985, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Ramirez", 45, 0 },
                    { 889, new DateTime(1987, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manuel Torres", 45, 2 },
                    { 890, new DateTime(2002, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francisco Flores", 45, 1 },
                    { 891, new DateTime(2007, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ruben Ruiz", 45, 3 },
                    { 892, new DateTime(1994, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonio Alonso", 45, 0 },
                    { 893, new DateTime(1989, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel Moreno", 45, 2 },
                    { 894, new DateTime(1995, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rafael Navarro", 45, 1 },
                    { 895, new DateTime(2000, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jesus Serrano", 45, 3 },
                    { 896, new DateTime(1991, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvaro Jimenez", 45, 0 },
                    { 897, new DateTime(1998, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jose Molina", 45, 2 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 898, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor Castro", 45, 1 },
                    { 899, new DateTime(2006, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pablo Ortega", 45, 3 },
                    { 900, new DateTime(1986, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucas Delgado", 45, 0 },
                    { 901, new DateTime(1997, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lukas Müller", 46, 2 },
                    { 902, new DateTime(1994, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maximilian Schmidt", 46, 1 },
                    { 903, new DateTime(1998, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Felix Schneider", 46, 3 },
                    { 904, new DateTime(1997, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leon Fischer", 46, 0 },
                    { 905, new DateTime(2006, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Julian Weber", 46, 2 },
                    { 906, new DateTime(1986, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moritz Meyer", 46, 1 },
                    { 907, new DateTime(1988, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Florian Wagner", 46, 3 },
                    { 908, new DateTime(1996, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tobias Becker", 46, 0 },
                    { 909, new DateTime(2003, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simon Hoffmann", 46, 2 },
                    { 910, new DateTime(1998, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Schäfer", 46, 1 },
                    { 911, new DateTime(1999, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nico Koch", 46, 3 },
                    { 912, new DateTime(1988, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominik Richter", 46, 0 },
                    { 913, new DateTime(1995, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marcel Klein", 46, 2 },
                    { 914, new DateTime(1998, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fabian Wolf", 46, 1 },
                    { 915, new DateTime(2005, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benedikt Neumann", 46, 3 },
                    { 916, new DateTime(1990, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebastian Schwarz", 46, 0 },
                    { 917, new DateTime(2003, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philipp Zimmermann", 46, 2 },
                    { 918, new DateTime(1998, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannes Braun", 46, 1 },
                    { 919, new DateTime(1996, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick Krüger", 46, 3 },
                    { 920, new DateTime(1987, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matthias Hofmann", 46, 0 },
                    { 921, new DateTime(1987, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pierre Dupont", 47, 2 },
                    { 922, new DateTime(1995, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jean Durand", 47, 1 },
                    { 923, new DateTime(1992, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michel Lefevre", 47, 3 },
                    { 924, new DateTime(1988, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Claude Martin", 47, 0 },
                    { 925, new DateTime(1996, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippe Bernard", 47, 2 },
                    { 926, new DateTime(2007, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alain Petit", 47, 1 },
                    { 927, new DateTime(1988, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacques Robert", 47, 3 },
                    { 928, new DateTime(1991, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luc Richard", 47, 0 },
                    { 929, new DateTime(2002, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eric Simon", 47, 2 },
                    { 930, new DateTime(2001, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicolas Laurent", 47, 1 },
                    { 931, new DateTime(1987, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernard Michel", 47, 3 },
                    { 932, new DateTime(1993, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Olivier Garcia", 47, 0 },
                    { 933, new DateTime(1998, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laurent Moreau", 47, 2 },
                    { 934, new DateTime(1997, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Didier Fournier", 47, 1 },
                    { 935, new DateTime(2000, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patrick Girard", 47, 3 },
                    { 936, new DateTime(1992, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sebastien Andre", 47, 0 },
                    { 937, new DateTime(1991, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vincent Guerin", 47, 2 },
                    { 938, new DateTime(1989, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antoine Boyer", 47, 1 },
                    { 939, new DateTime(2000, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guillaume Garnier", 47, 3 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BirthDate", "PlayerName", "TeamsId", "Position" },
                values: new object[,]
                {
                    { 940, new DateTime(1990, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thierry Chevalier", 47, 0 },
                    { 941, new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Smith", 48, 2 },
                    { 942, new DateTime(1985, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Jones", 48, 1 },
                    { 943, new DateTime(1988, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Taylor", 48, 3 },
                    { 944, new DateTime(1998, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael Williams", 48, 0 },
                    { 945, new DateTime(2000, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Brown", 48, 2 },
                    { 946, new DateTime(1998, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Davies", 48, 1 },
                    { 947, new DateTime(1998, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Richard Evans", 48, 3 },
                    { 948, new DateTime(1999, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles Thomas", 48, 0 },
                    { 949, new DateTime(1989, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joseph Roberts", 48, 2 },
                    { 950, new DateTime(1999, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thomas Johnson", 48, 1 },
                    { 951, new DateTime(1986, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Walker", 48, 3 },
                    { 952, new DateTime(1994, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daniel Wright", 48, 0 },
                    { 953, new DateTime(1988, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Thompson", 48, 2 },
                    { 954, new DateTime(1986, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark White", 48, 1 },
                    { 955, new DateTime(2005, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Donald Edwards", 48, 3 },
                    { 956, new DateTime(1999, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven Green", 48, 0 },
                    { 957, new DateTime(2007, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edward Harris", 48, 2 },
                    { 958, new DateTime(2006, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brian Lewis", 48, 1 },
                    { 959, new DateTime(1997, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ronald Clarke", 48, 3 },
                    { 960, new DateTime(1998, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anthony Hall", 48, 0 },
                    { 961, new DateTime(1993, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marco Rossi", 49, 2 },
                    { 962, new DateTime(1986, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luca Russo", 49, 1 },
                    { 963, new DateTime(2003, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matteo Ferrari", 49, 3 },
                    { 964, new DateTime(1996, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alessandro Esposito", 49, 0 },
                    { 965, new DateTime(1996, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giovanni Bianchi", 49, 2 },
                    { 966, new DateTime(1990, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrea Romano", 49, 1 },
                    { 967, new DateTime(1987, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Davide Colombo", 49, 3 },
                    { 968, new DateTime(1991, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Francesco Ricci", 49, 0 },
                    { 969, new DateTime(2005, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simone Marino", 49, 2 },
                    { 970, new DateTime(1994, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabriele Greco", 49, 1 },
                    { 971, new DateTime(1993, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Federico Bruno", 49, 3 },
                    { 972, new DateTime(2001, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stefano Gallo", 49, 0 },
                    { 973, new DateTime(1996, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roberto Costa", 49, 2 },
                    { 974, new DateTime(1988, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonio DeLuca", 49, 1 },
                    { 975, new DateTime(1989, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paolo Mancini", 49, 3 },
                    { 976, new DateTime(1998, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riccardo Lombardi", 49, 0 },
                    { 977, new DateTime(2001, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giuseppe Moretti", 49, 2 },
                    { 978, new DateTime(2005, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicola Barbieri", 49, 1 },
                    { 979, new DateTime(2003, 8, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fabio Fontana", 49, 3 },
                    { 980, new DateTime(2000, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salvatore Santoro", 49, 0 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "SeatName", "SeatPrice", "SeatType", "StadiumId" },
                values: new object[] { 1, "A1", 150, 1, 1 });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "SeatName", "SeatPrice", "SeatType", "StadiumId" },
                values: new object[,]
                {
                    { 2, "A2", 150, 1, 1 },
                    { 3, "B1", 50, 0, 1 },
                    { 4, "B2", 50, 0, 1 },
                    { 5, "C1", 50, 0, 1 },
                    { 6, "C2", 50, 0, 1 },
                    { 7, "D1", 50, 0, 1 },
                    { 8, "D2", 50, 0, 1 },
                    { 9, "E1", 50, 0, 1 },
                    { 10, "E2", 50, 0, 1 },
                    { 11, "A1", 150, 1, 11 },
                    { 12, "A2", 150, 1, 11 },
                    { 13, "B1", 50, 0, 11 },
                    { 14, "B2", 50, 0, 11 },
                    { 15, "C1", 50, 0, 11 },
                    { 16, "C2", 50, 0, 11 },
                    { 17, "D1", 50, 0, 11 },
                    { 18, "D2", 50, 0, 11 },
                    { 19, "E1", 50, 0, 11 },
                    { 20, "E2", 50, 0, 11 },
                    { 21, "A1", 150, 1, 21 },
                    { 22, "A2", 150, 1, 21 },
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
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[] { 1, 1, 9, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2890), "Comentariu de la user 9 pentru știrea 1." });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 1, 1, 1, 11 },
                    { 2, 1, 1, 1 },
                    { 3, 1, 1, 194 },
                    { 4, 1, 3, 47 },
                    { 5, 1, 3, 56 },
                    { 6, 1, 3, 158 },
                    { 7, 1, 4, 136 },
                    { 8, 1, 5, 98 },
                    { 9, 1, 5, 113 },
                    { 10, 1, 5, 111 },
                    { 11, 1, 7, 230 },
                    { 12, 1, 7, 221 },
                    { 13, 1, 7, 363 },
                    { 14, 1, 7, 369 },
                    { 15, 1, 7, 364 },
                    { 16, 1, 8, 250 },
                    { 17, 1, 8, 254 },
                    { 18, 1, 8, 258 },
                    { 19, 1, 8, 343 },
                    { 20, 1, 8, 357 },
                    { 21, 1, 8, 358 },
                    { 22, 1, 9, 262 },
                    { 23, 1, 9, 277 },
                    { 24, 1, 9, 336 },
                    { 25, 1, 10, 293 },
                    { 26, 1, 10, 299 },
                    { 27, 1, 10, 310 },
                    { 28, 1, 10, 313 },
                    { 29, 1, 10, 317 },
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
                    { 41, 1, 15, 484 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 42, 1, 15, 586 },
                    { 43, 1, 15, 581 },
                    { 44, 1, 16, 185 },
                    { 45, 1, 16, 192 },
                    { 46, 1, 16, 110 },
                    { 47, 1, 17, 121 },
                    { 48, 1, 17, 125 },
                    { 49, 1, 17, 135 },
                    { 50, 1, 17, 100 },
                    { 51, 1, 18, 151 },
                    { 52, 1, 18, 156 },
                    { 53, 1, 18, 61 },
                    { 54, 1, 18, 65 },
                    { 55, 1, 19, 41 },
                    { 56, 1, 20, 2 },
                    { 57, 1, 20, 14 },
                    { 58, 1, 20, 11 },
                    { 59, 1, 20, 15 },
                    { 60, 1, 20, 25 },
                    { 61, 1, 21, 381 },
                    { 62, 1, 21, 384 },
                    { 63, 1, 22, 321 },
                    { 64, 1, 22, 338 },
                    { 65, 1, 22, 281 },
                    { 66, 1, 22, 294 },
                    { 67, 1, 23, 261 },
                    { 68, 1, 23, 274 },
                    { 69, 1, 23, 276 },
                    { 70, 1, 24, 361 },
                    { 71, 1, 24, 241 },
                    { 72, 1, 25, 222 },
                    { 73, 1, 25, 235 },
                    { 74, 1, 26, 581 },
                    { 75, 1, 26, 593 },
                    { 76, 1, 26, 595 },
                    { 77, 1, 27, 539 },
                    { 78, 1, 27, 521 },
                    { 79, 1, 27, 481 },
                    { 80, 1, 28, 462 },
                    { 81, 1, 28, 479 },
                    { 82, 1, 29, 561 },
                    { 83, 1, 29, 445 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 84, 1, 29, 441 },
                    { 85, 1, 29, 459 },
                    { 86, 1, 30, 401 },
                    { 87, 1, 30, 412 },
                    { 88, 1, 30, 427 },
                    { 89, 1, 30, 440 },
                    { 90, 1, 31, 32 },
                    { 91, 1, 31, 198 },
                    { 92, 1, 31, 189 },
                    { 93, 1, 32, 17 },
                    { 94, 1, 33, 66 },
                    { 95, 1, 33, 77 },
                    { 96, 1, 33, 168 },
                    { 97, 1, 33, 177 },
                    { 98, 1, 34, 82 },
                    { 99, 1, 34, 84 },
                    { 100, 1, 34, 89 },
                    { 101, 1, 35, 113 },
                    { 102, 1, 35, 131 },
                    { 103, 1, 36, 233 },
                    { 104, 1, 36, 399 },
                    { 105, 1, 37, 217 },
                    { 106, 1, 37, 215 },
                    { 107, 1, 38, 280 },
                    { 108, 1, 38, 274 },
                    { 109, 1, 38, 273 },
                    { 110, 1, 38, 371 },
                    { 111, 1, 38, 376 },
                    { 112, 1, 38, 362 },
                    { 113, 1, 38, 378 },
                    { 114, 1, 39, 300 },
                    { 115, 1, 39, 293 },
                    { 116, 1, 40, 315 },
                    { 117, 1, 40, 336 },
                    { 118, 1, 40, 334 },
                    { 119, 1, 41, 600 },
                    { 120, 1, 41, 599 },
                    { 121, 1, 41, 589 },
                    { 122, 1, 42, 441 },
                    { 123, 1, 42, 453 },
                    { 124, 1, 42, 413 },
                    { 125, 1, 42, 420 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 126, 1, 43, 569 },
                    { 127, 1, 44, 485 },
                    { 128, 1, 45, 521 },
                    { 129, 1, 45, 523 },
                    { 133, 1, 46, 191 },
                    { 134, 1, 46, 198 },
                    { 135, 1, 46, 127 },
                    { 136, 1, 47, 160 },
                    { 143, 1, 49, 8 },
                    { 144, 1, 49, 77 },
                    { 146, 1, 50, 36 },
                    { 147, 1, 50, 53 },
                    { 148, 1, 51, 387 },
                    { 149, 1, 51, 398 },
                    { 150, 1, 51, 336 },
                    { 151, 1, 52, 314 },
                    { 152, 1, 53, 372 },
                    { 153, 1, 53, 291 },
                    { 154, 1, 53, 295 },
                    { 155, 1, 55, 237 },
                    { 156, 1, 55, 241 },
                    { 157, 1, 56, 581 },
                    { 161, 1, 58, 569 },
                    { 162, 1, 58, 486 },
                    { 164, 1, 60, 425 },
                    { 165, 1, 60, 431 },
                    { 166, 1, 60, 441 },
                    { 167, 1, 60, 445 },
                    { 168, 1, 61, 42 },
                    { 169, 1, 61, 46 },
                    { 170, 1, 62, 65 },
                    { 171, 1, 62, 32 },
                    { 172, 1, 62, 38 },
                    { 173, 1, 62, 27 },
                    { 174, 1, 63, 91 },
                    { 175, 1, 63, 11 },
                    { 176, 1, 64, 175 },
                    { 177, 1, 65, 137 },
                    { 178, 1, 65, 149 },
                    { 179, 1, 65, 158 },
                    { 180, 1, 65, 154 },
                    { 181, 1, 66, 259 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 182, 1, 68, 295 },
                    { 184, 1, 68, 211 },
                    { 185, 1, 69, 370 },
                    { 186, 1, 69, 374 },
                    { 187, 1, 69, 380 },
                    { 188, 1, 70, 335 },
                    { 189, 1, 70, 347 },
                    { 193, 1, 72, 424 },
                    { 194, 1, 72, 432 },
                    { 195, 1, 72, 422 },
                    { 196, 1, 73, 500 },
                    { 199, 1, 73, 406 },
                    { 200, 1, 74, 563 },
                    { 201, 1, 74, 573 },
                    { 203, 1, 75, 541 },
                    { 204, 1, 75, 547 },
                    { 206, 1, 76, 181 },
                    { 207, 1, 76, 187 },
                    { 208, 1, 76, 156 },
                    { 209, 1, 77, 132 },
                    { 211, 1, 77, 128 },
                    { 212, 1, 78, 6 },
                    { 213, 1, 78, 113 },
                    { 215, 1, 79, 96 },
                    { 216, 1, 80, 54 },
                    { 217, 1, 80, 61 },
                    { 218, 1, 80, 74 },
                    { 219, 1, 80, 75 },
                    { 220, 1, 81, 391 },
                    { 221, 1, 82, 377 },
                    { 223, 1, 82, 340 },
                    { 224, 1, 83, 319 },
                    { 225, 1, 83, 320 },
                    { 226, 1, 84, 234 },
                    { 227, 1, 85, 251 },
                    { 228, 1, 85, 265 },
                    { 229, 1, 85, 277 },
                    { 232, 1, 86, 581 },
                    { 233, 1, 86, 595 },
                    { 234, 1, 86, 583 },
                    { 236, 1, 87, 566 },
                    { 237, 1, 88, 407 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 238, 1, 89, 425 },
                    { 242, 1, 90, 461 },
                    { 243, 1, 90, 471 },
                    { 244, 1, 90, 472 },
                    { 245, 1, 91, 61 },
                    { 246, 1, 91, 193 },
                    { 248, 1, 92, 54 },
                    { 249, 1, 93, 101 },
                    { 250, 1, 93, 120 },
                    { 251, 1, 93, 37 },
                    { 252, 1, 94, 122 },
                    { 253, 1, 94, 129 },
                    { 254, 1, 94, 134 },
                    { 255, 1, 95, 141 },
                    { 256, 1, 95, 152 },
                    { 257, 1, 95, 171 },
                    { 259, 1, 96, 393 },
                    { 260, 1, 97, 291 },
                    { 262, 1, 97, 252 },
                    { 263, 1, 98, 316 },
                    { 265, 1, 99, 332 },
                    { 266, 1, 99, 219 },
                    { 267, 1, 101, 471 },
                    { 269, 1, 101, 600 },
                    { 274, 1, 102, 445 },
                    { 277, 1, 104, 420 },
                    { 278, 1, 104, 539 },
                    { 280, 1, 105, 561 },
                    { 281, 1, 105, 570 },
                    { 282, 1, 105, 573 },
                    { 283, 1, 106, 191 },
                    { 284, 1, 106, 181 },
                    { 285, 1, 106, 177 },
                    { 287, 1, 108, 22 },
                    { 288, 1, 108, 39 },
                    { 289, 1, 108, 125 },
                    { 290, 1, 109, 112 },
                    { 291, 1, 109, 59 },
                    { 292, 1, 110, 77 },
                    { 293, 1, 110, 87 },
                    { 294, 1, 111, 399 },
                    { 295, 1, 111, 381 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 296, 1, 112, 212 },
                    { 297, 1, 112, 217 },
                    { 299, 1, 113, 237 },
                    { 301, 1, 113, 332 },
                    { 302, 1, 113, 333 },
                    { 304, 1, 114, 253 },
                    { 305, 1, 115, 289 },
                    { 306, 1, 115, 298 },
                    { 307, 1, 116, 593 },
                    { 308, 1, 116, 594 },
                    { 309, 1, 116, 581 },
                    { 310, 1, 116, 577 },
                    { 311, 1, 117, 405 },
                    { 319, 1, 119, 514 },
                    { 320, 1, 120, 488 },
                    { 321, 1, 121, 81 },
                    { 322, 1, 121, 86 },
                    { 331, 1, 125, 178 },
                    { 332, 1, 125, 11 },
                    { 333, 1, 125, 6 },
                    { 335, 1, 127, 313 },
                    { 342, 1, 131, 593 },
                    { 344, 1, 132, 515 },
                    { 352, 1, 135, 407 },
                    { 353, 1, 136, 185 },
                    { 354, 1, 136, 191 },
                    { 356, 1, 138, 153 },
                    { 360, 1, 139, 123 },
                    { 368, 1, 143, 250 },
                    { 372, 1, 145, 315 },
                    { 373, 1, 145, 311 },
                    { 382, 1, 149, 480 },
                    { 383, 1, 149, 471 },
                    { 384, 1, 150, 504 },
                    { 385, 1, 150, 502 },
                    { 386, 1, 150, 496 },
                    { 387, 1, 271, 12 },
                    { 388, 1, 272, 167 },
                    { 391, 1, 274, 632 },
                    { 392, 1, 275, 88 },
                    { 393, 1, 275, 91 },
                    { 394, 1, 275, 653 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 395, 1, 278, 157 },
                    { 397, 1, 279, 18 },
                    { 398, 1, 280, 22 },
                    { 399, 1, 280, 25 },
                    { 400, 1, 280, 33 },
                    { 401, 1, 281, 611 },
                    { 402, 1, 281, 49 },
                    { 403, 1, 283, 653 },
                    { 405, 1, 284, 661 },
                    { 409, 1, 286, 712 },
                    { 410, 1, 286, 719 },
                    { 411, 1, 286, 708 },
                    { 413, 1, 287, 8 },
                    { 414, 1, 287, 13 },
                    { 415, 1, 287, 19 },
                    { 416, 1, 287, 15 },
                    { 417, 1, 289, 661 },
                    { 418, 1, 290, 137 },
                    { 419, 1, 290, 140 },
                    { 421, 1, 290, 717 },
                    { 422, 1, 290, 713 },
                    { 423, 1, 290, 706 },
                    { 425, 1, 293, 653 },
                    { 426, 1, 293, 661 },
                    { 427, 1, 294, 137 },
                    { 428, 1, 295, 14 },
                    { 429, 1, 295, 16 },
                    { 430, 1, 295, 4 },
                    { 433, 1, 297, 17 },
                    { 434, 1, 297, 6 },
                    { 435, 1, 297, 2 },
                    { 436, 1, 298, 651 },
                    { 437, 1, 301, 6 },
                    { 438, 1, 301, 12 },
                    { 439, 1, 301, 801 },
                    { 440, 1, 301, 807 },
                    { 441, 1, 302, 821 },
                    { 442, 1, 303, 851 },
                    { 443, 1, 303, 857 },
                    { 444, 1, 303, 852 },
                    { 445, 1, 303, 954 },
                    { 446, 1, 303, 945 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 447, 1, 304, 938 },
                    { 448, 1, 304, 937 },
                    { 449, 1, 305, 899 },
                    { 450, 1, 305, 902 },
                    { 451, 1, 306, 961 },
                    { 452, 1, 306, 964 },
                    { 453, 1, 306, 969 },
                    { 454, 1, 307, 831 },
                    { 455, 1, 308, 901 },
                    { 456, 1, 308, 911 },
                    { 457, 1, 308, 868 },
                    { 458, 1, 308, 869 },
                    { 459, 1, 308, 865 },
                    { 460, 1, 309, 934 },
                    { 461, 1, 309, 854 },
                    { 462, 1, 310, 958 },
                    { 463, 1, 311, 17 },
                    { 464, 1, 311, 7 },
                    { 465, 1, 311, 821 },
                    { 466, 1, 312, 851 },
                    { 467, 1, 312, 813 },
                    { 468, 1, 312, 801 },
                    { 469, 1, 312, 802 },
                    { 470, 1, 313, 871 },
                    { 471, 1, 313, 873 },
                    { 472, 1, 314, 958 },
                    { 473, 1, 315, 919 },
                    { 474, 1, 315, 939 },
                    { 475, 1, 316, 813 },
                    { 476, 1, 316, 816 },
                    { 477, 1, 316, 819 },
                    { 478, 1, 316, 868 },
                    { 479, 1, 317, 831 },
                    { 480, 1, 317, 833 },
                    { 481, 1, 318, 964 },
                    { 482, 1, 318, 899 },
                    { 483, 1, 319, 933 },
                    { 484, 1, 319, 13 },
                    { 485, 1, 320, 951 },
                    { 486, 1, 320, 948 },
                    { 487, 1, 320, 949 },
                    { 488, 1, 321, 9 }
                });

            migrationBuilder.InsertData(
                table: "PlayerStatisticsPerGame",
                columns: new[] { "Id", "Goals", "GameId", "PlayerId" },
                values: new object[,]
                {
                    { 489, 1, 321, 856 },
                    { 490, 1, 322, 871 },
                    { 491, 1, 322, 869 },
                    { 492, 1, 322, 823 },
                    { 493, 1, 322, 824 },
                    { 494, 1, 323, 804 },
                    { 495, 1, 323, 813 },
                    { 496, 1, 323, 816 },
                    { 497, 1, 324, 912 },
                    { 498, 1, 324, 908 },
                    { 499, 1, 325, 951 },
                    { 500, 1, 325, 942 },
                    { 501, 1, 325, 931 },
                    { 502, 1, 325, 921 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2182), 1, 1, 1 },
                    { 2, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2185), 1, 2, 2 },
                    { 3, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2186), 1, 3, 3 },
                    { 4, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2187), 1, 4, 4 },
                    { 5, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2188), 1, 5, 5 },
                    { 6, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2189), 6, 11, 6 },
                    { 7, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2190), 6, 12, 7 },
                    { 8, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2191), 6, 13, 8 },
                    { 9, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2192), 6, 14, 9 },
                    { 10, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2193), 6, 15, 10 },
                    { 11, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2194), 11, 21, 11 },
                    { 12, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2195), 11, 22, 22 },
                    { 13, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2195), 11, 23, 23 },
                    { 14, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2196), 11, 24, 24 },
                    { 15, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2197), 11, 25, 25 },
                    { 16, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2198), 20, 1, 6 },
                    { 17, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2199), 20, 2, 7 },
                    { 18, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2200), 20, 3, 8 },
                    { 19, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2201), 20, 4, 9 },
                    { 20, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2202), 20, 5, 10 },
                    { 21, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2202), 20, 6, 11 },
                    { 22, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2203), 20, 7, 12 },
                    { 23, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2204), 20, 8, 13 },
                    { 24, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2205), 25, 11, 14 },
                    { 25, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2206), 25, 12, 15 },
                    { 26, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2206), 25, 13, 16 },
                    { 27, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2207), 25, 14, 17 },
                    { 28, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2208), 25, 15, 18 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 29, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2209), 30, 21, 19 },
                    { 30, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2210), 30, 22, 20 },
                    { 31, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2210), 30, 23, 21 },
                    { 32, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2211), 30, 24, 22 },
                    { 33, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2212), 30, 25, 23 },
                    { 34, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2213), 30, 26, 24 },
                    { 35, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2214), 30, 27, 25 },
                    { 36, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2215), 30, 28, 26 },
                    { 37, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2216), 30, 29, 27 },
                    { 38, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2216), 49, 1, 28 },
                    { 39, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2217), 49, 2, 29 },
                    { 40, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2218), 49, 3, 30 },
                    { 41, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2219), 49, 4, 31 },
                    { 42, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2220), 49, 5, 1 },
                    { 43, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2220), 49, 6, 2 },
                    { 44, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2221), 49, 7, 3 },
                    { 45, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2222), 54, 11, 4 },
                    { 46, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2223), 54, 12, 5 },
                    { 47, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2224), 54, 13, 6 },
                    { 48, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2224), 54, 14, 7 },
                    { 49, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2225), 59, 21, 8 },
                    { 50, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2226), 59, 22, 9 },
                    { 51, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2227), 59, 23, 10 },
                    { 52, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2228), 59, 24, 11 },
                    { 53, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2228), 59, 25, 12 },
                    { 54, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2229), 59, 26, 13 },
                    { 55, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2230), 59, 27, 14 },
                    { 56, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2231), 78, 1, 15 },
                    { 57, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2231), 78, 2, 16 },
                    { 58, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2232), 78, 3, 17 },
                    { 59, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2233), 78, 4, 18 },
                    { 60, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2234), 78, 5, 19 },
                    { 61, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2235), 78, 6, 20 },
                    { 62, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2235), 78, 7, 21 },
                    { 63, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2236), 78, 8, 22 },
                    { 64, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2237), 83, 11, 23 },
                    { 65, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2238), 83, 12, 24 },
                    { 66, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2270), 83, 13, 25 },
                    { 67, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2271), 83, 14, 26 },
                    { 68, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2271), 83, 15, 27 },
                    { 69, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2272), 83, 16, 28 },
                    { 70, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2273), 83, 17, 29 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 71, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2274), 83, 18, 30 },
                    { 72, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2275), 88, 21, 31 },
                    { 73, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2275), 88, 22, 1 },
                    { 74, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2276), 88, 23, 2 },
                    { 75, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2277), 88, 24, 3 },
                    { 76, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2278), 88, 25, 4 },
                    { 77, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2279), 88, 26, 5 },
                    { 78, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2279), 88, 27, 6 },
                    { 79, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2280), 107, 1, 7 },
                    { 80, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2281), 107, 2, 8 },
                    { 81, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2282), 107, 3, 9 },
                    { 82, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2283), 107, 4, 10 },
                    { 83, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2283), 107, 5, 11 },
                    { 84, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2284), 107, 6, 12 },
                    { 85, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2285), 107, 7, 13 },
                    { 86, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2286), 107, 8, 14 },
                    { 87, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2287), 112, 11, 15 },
                    { 88, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2287), 112, 12, 16 },
                    { 89, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2288), 112, 13, 17 },
                    { 90, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2289), 112, 14, 18 },
                    { 91, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2290), 112, 15, 19 },
                    { 92, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2290), 112, 16, 20 },
                    { 93, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2291), 112, 17, 21 },
                    { 94, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2292), 112, 18, 22 },
                    { 95, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2293), 112, 19, 23 },
                    { 96, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2294), 117, 21, 24 },
                    { 97, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2294), 117, 22, 25 },
                    { 98, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2295), 117, 23, 26 },
                    { 99, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2296), 117, 24, 27 },
                    { 100, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2297), 117, 25, 28 },
                    { 101, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2298), 117, 26, 29 },
                    { 102, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2298), 117, 27, 30 },
                    { 103, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2299), 117, 28, 31 },
                    { 104, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2300), 117, 29, 1 },
                    { 105, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2301), 117, 30, 2 },
                    { 106, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2302), 271, 1, 3 },
                    { 107, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2302), 271, 2, 4 },
                    { 108, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2303), 271, 3, 5 },
                    { 109, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2304), 271, 4, 6 },
                    { 110, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2305), 271, 5, 7 },
                    { 111, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2306), 271, 6, 8 },
                    { 112, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2306), 271, 7, 9 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "DateReservation", "GameId", "SeatId", "UserId" },
                values: new object[,]
                {
                    { 113, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2307), 271, 8, 10 },
                    { 114, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2308), 271, 9, 11 },
                    { 115, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2309), 271, 10, 12 },
                    { 116, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2310), 287, 1, 13 },
                    { 117, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2310), 287, 2, 14 },
                    { 118, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2311), 287, 3, 15 },
                    { 119, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2312), 287, 4, 16 },
                    { 120, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2313), 287, 5, 17 },
                    { 121, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2313), 287, 6, 18 },
                    { 122, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2314), 287, 7, 19 },
                    { 123, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2315), 287, 8, 20 },
                    { 124, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2316), 287, 9, 21 },
                    { 125, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2317), 287, 10, 22 },
                    { 126, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2317), 295, 1, 23 },
                    { 127, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2318), 295, 2, 24 },
                    { 128, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2319), 295, 3, 25 },
                    { 129, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2320), 295, 4, 26 },
                    { 130, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2322), 295, 5, 27 },
                    { 131, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2323), 295, 6, 28 },
                    { 132, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2323), 295, 7, 29 },
                    { 133, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2324), 295, 8, 30 },
                    { 134, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2325), 295, 9, 31 },
                    { 135, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2326), 295, 10, 1 },
                    { 136, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2326), 301, 1, 2 },
                    { 137, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2327), 301, 2, 3 },
                    { 138, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2359), 301, 3, 4 },
                    { 139, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2361), 301, 4, 5 },
                    { 140, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2361), 301, 5, 6 },
                    { 141, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2362), 301, 6, 7 },
                    { 142, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2363), 311, 1, 8 },
                    { 143, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2364), 311, 2, 9 },
                    { 144, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2365), 311, 3, 10 },
                    { 145, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2365), 311, 4, 11 },
                    { 146, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2366), 311, 5, 12 },
                    { 147, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2367), 311, 6, 13 },
                    { 148, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2368), 321, 1, 14 },
                    { 149, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2369), 321, 2, 15 },
                    { 150, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2370), 321, 3, 16 },
                    { 151, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2370), 321, 4, 17 },
                    { 152, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2371), 321, 5, 18 },
                    { 153, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2372), 321, 6, 19 },
                    { 154, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2373), 321, 7, 20 }
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
                column: "AwayTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_CompetitionId",
                table: "Games",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_HomeTeamId",
                table: "Games",
                column: "HomeTeamId");

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
                name: "IX_PlayerStatisticsPerCompetition_CompetitionId",
                table: "PlayerStatisticsPerCompetition",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatisticsPerCompetition_PlayerId",
                table: "PlayerStatisticsPerCompetition",
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
                column: "SeatId");

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
                name: "PlayerStatisticsPerCompetition");

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
