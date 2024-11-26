using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FCUnirea.Data.Migrations
{
    public partial class CreateFCUNIREAComplete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    news_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    text = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.comment_id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    competition_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    competition_type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.competition_id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    feedback_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: false),
                    review = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.feedback_id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    game_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    home_team_id = table.Column<int>(type: "int", nullable: false),
                    away_team_id = table.Column<int>(type: "int", nullable: false),
                    game_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stadium_id = table.Column<int>(type: "int", nullable: false),
                    home_team_score = table.Column<int>(type: "int", nullable: false),
                    away_team_score = table.Column<int>(type: "int", nullable: false),
                    tickets_sold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.game_id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    news_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    text = table.Column<string>(type: "TEXT", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.news_id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    player_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    birth_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.player_id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerCompetiton",
                columns: table => new
                {
                    statistic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    goals = table.Column<int>(type: "int", nullable: false),
                    assists = table.Column<int>(type: "int", nullable: false),
                    saves = table.Column<int>(type: "int", nullable: false),
                    yellow_cards = table.Column<int>(type: "int", nullable: false),
                    red_cards = table.Column<int>(type: "int", nullable: false),
                    minutes_played = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerCompetiton", x => x.statistic_id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatisticsPerGame",
                columns: table => new
                {
                    statistic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    goals = table.Column<int>(type: "int", nullable: false),
                    assists = table.Column<int>(type: "int", nullable: false),
                    passes_completed = table.Column<int>(type: "int", nullable: false),
                    saves = table.Column<int>(type: "int", nullable: false),
                    red_cards = table.Column<int>(type: "int", nullable: false),
                    yellow_cards = table.Column<int>(type: "int", nullable: false),
                    minutes_played = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatisticsPerGame", x => x.statistic_id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    seat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    seat_type = table.Column<int>(type: "int", nullable: false),
                    seat_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seat_price = table.Column<int>(type: "int", nullable: false),
                    reserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.seat_id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    stadium_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    stadium_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    stadium_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seat_id = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.stadium_id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    team_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    team_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    team_type = table.Column<int>(type: "int", nullable: false),
                    is_internal = table.Column<bool>(type: "bit", nullable: false),
                    record = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.team_id);
                });

            migrationBuilder.CreateTable(
                name: "TeamStatistics",
                columns: table => new
                {
                    statistic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    competition_id = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false),
                    games_played = table.Column<int>(type: "int", nullable: false),
                    total_wins = table.Column<int>(type: "int", nullable: false),
                    total_losses = table.Column<int>(type: "int", nullable: false),
                    total_draws = table.Column<int>(type: "int", nullable: false),
                    goals_scored = table.Column<int>(type: "int", nullable: false),
                    goals_conceded = table.Column<int>(type: "int", nullable: false),
                    total_points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStatistics", x => x.statistic_id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ticket_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    game_id = table.Column<int>(type: "int", nullable: false),
                    seat_id = table.Column<int>(type: "int", nullable: false),
                    date_reservation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ticket_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hashed_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone_number = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_user);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PlayerStatisticsPerCompetiton");

            migrationBuilder.DropTable(
                name: "PlayerStatisticsPerGame");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "TeamStatistics");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
