// OpenAiChatService.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FCUnirea.Business.Models;
using FCUnirea.Business.Services;
using FCUnirea.Business.Services.IServices;
using FCUnirea.Domain.Entities;
using Microsoft.Extensions.Configuration;

public class OpenAiChatService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly IUsersService _usersService;
    private readonly INewsService _newsService;
    private readonly ITeamStatisticsService _teamStatisticsService;
    private readonly ICompetitionsService _competitionsService;
    private readonly ITeamsService _teamsService;
    private readonly IPlayersService _playersService;
    private readonly IGamesService _gamesService;
    private readonly IPlayerStatisticsPerGameService _playerStatisticsPerGameService;
    private readonly IStadiumsService _stadiumsService;
    private readonly ITicketsService _ticketsService;

    public OpenAiChatService(IConfiguration configuration, 
        IUsersService usersService, 
        INewsService newsService,
        ITeamStatisticsService teamStatisticsService,
        ICompetitionsService competitionsService,
        ITeamsService teamsService,
        IPlayersService playersService,
        IGamesService gamesService,
        IPlayerStatisticsPerGameService playerStatisticsPerGameService,
        IStadiumsService stadiumsService,
        ITicketsService ticketsService
        )
    {
        _httpClient = new HttpClient();
        _apiKey = configuration["OpenAI:ApiKey"];
        _usersService = usersService;
        _newsService = newsService;
        _teamStatisticsService = teamStatisticsService;
        _competitionsService = competitionsService;
        _teamsService = teamsService;
        _playersService = playersService;
        _gamesService = gamesService;
        _playerStatisticsPerGameService = playerStatisticsPerGameService;
        _stadiumsService = stadiumsService;
        _ticketsService = ticketsService;
    }

    public async Task<string> GetReplySmartAsync(string message, string username)
    {

        Users user = null;
        if (!string.IsNullOrEmpty(username))
            user = _usersService.GetByUsername(username);

        string prompt = BuildPrompt(message, user);
        return await GetChatGptReplyAsync(prompt);
    }

    private string BuildPrompt(string message, Users user)
    {
        string msg = message.ToLower();

        // cuvinte cheie pentru fiecare statistică:
        var statsKeywords = new Dictionary<string, Func<TeamStatisticsModel, string>>
        {
            {"puncte", s => $"{s.TeamName} are {s.TotalPoints} puncte."},
            {"victorii", s => $"{s.TeamName} are {s.TotalWins} victorii."},
            {"infrangeri", s => $"{s.TeamName} are {s.TotalLosses} înfrângeri."},
            {"pierderi", s => $"{s.TeamName} are {s.TotalLosses} înfrângeri."},
            {"egaluri", s => $"{s.TeamName} are {s.TotalDraws} egaluri."},
            {"meciuri", s => $"{s.TeamName} a jucat {s.GamesPlayed} meciuri."},
            {"goluri marcate", s => $"{s.TeamName} a marcat {s.GoalsScored} goluri."},
            {"goluri primite", s => $"{s.TeamName} a primit {s.GoalsConceded} goluri."}
        };

        var echipeNoastre = new[]
                {
            new { Key = "unirea cf youth",  Name = "FC Unirea CF Youth", CompetitionId = 7, TeamId = 21},
            new { Key = "unirea u21",       Name = "FC Unirea U21",      CompetitionId = 4, TeamId = 11},
            new { Key = "unirea",           Name = "FC Unirea",          CompetitionId = 1, TeamId = 1 }
        };



        if (user != null)
        {
            //UsersTable
            if (msg.Contains("email"))
                return $"Utilizatorul a întrebat: '{message}'. Adresa de email a utilizatorului este: {user.Email}.";
            if (msg.Contains("username"))
                return $"Utilizatorul a întrebat: '{message}'. Username-ul este: {user.Username}.";
            if (msg.Contains("nume"))
                return $"Utilizatorul a întrebat: '{message}'. Numele tau este: {user.FirstName} {user.LastName}.";
            //NewsTable
            if (msg.Contains("stiri")|| msg.Contains("news") || msg.Contains("ultimele") || msg.Contains("recente"))
            {
                var newsList = _newsService.GetNews().Take(3).ToList(); // ultimele 3 stiri
                if (newsList.Any())
                {
                    var summaries = newsList.Select(n =>
                        $"- {n.Title}: {n.Text.Substring(0, Math.Min(100, n.Text.Length))}...").ToList();

                    return $"Utilizatorul a întrebat: '{message}'. Ultimele știri pentru FC Unirea sunt:\n{string.Join("\n", summaries)}\nRăspunde politicos și prietenos ca asistent FC Unirea, reamintind utilizatorului să verifice secțiunea de știri pentru detalii.";
                }
                else
                {
                    return $"Momentan nu există știri noi în platformă.";
                }
            }
            //TeamStatisticsTable
            foreach (var ek in echipeNoastre)
            {
                if (msg.Contains(ek.Key))
                {
                    // vezi ce statistică vrea userul
                    foreach (var kvp in statsKeywords)
                    {
                        if (msg.Contains(kvp.Key))
                        {
                            var statsList = _teamStatisticsService.GetStandingsByCompetitionAsync(ek.CompetitionId).Result.ToList();
                            var stat = statsList.FirstOrDefault(s => s.TeamName.ToLower().Contains(ek.Name.ToLower()));
                            if (stat != null)
                            {
                                return $"Utilizatorul a întrebat: '{message}'.\n{kvp.Value(stat)}";
                            }
                            else
                            {
                                return $"Nu există date pentru {ek.Name}.";
                            }
                        }
                    }
                }
            }
            //CompetitionsTable
            if (msg.Contains("competitii") || msg.Contains("competiții") || msg.Contains("competitions") || msg.Contains("joaca in") || msg.Contains("joacă în") || msg.Contains("participa in") || msg.Contains("participă în"))
            {
                // Caz FC Unirea (seniori)
                if (msg.Contains("fc unirea") || (msg.Contains("unirea") && !msg.Contains("u21") && !msg.Contains("youth")))
                {
                    var competitions = _competitionsService.GetCompetitions()
                        .Where(c => c.Id >= 1 && c.Id <= 3)
                        .ToList();
                    var compNames = competitions.Select(c => c.CompetitionName).ToList();
                    return $"FC Unirea (seniori) participă în următoarele competiții:\n- {string.Join("\n- ", compNames)}";
                }
                // Caz FC Unirea U21
                if (msg.Contains("u21"))
                {
                    var competitions = _competitionsService.GetCompetitions()
                        .Where(c => c.Id >= 4 && c.Id <= 6)
                        .ToList();
                    var compNames = competitions.Select(c => c.CompetitionName).ToList();
                    return $"FC Unirea U21 participă în următoarele competiții:\n- {string.Join("\n- ", compNames)}";
                }
                // Caz FC Unirea Youth
                if (msg.Contains("youth") || msg.Contains("cf youth"))
                {
                    var competitions = _competitionsService.GetCompetitions()
                        .Where(c => c.Id >= 7 && c.Id <= 9)
                        .ToList();
                    var compNames = competitions.Select(c => c.CompetitionName).ToList();
                    return $"FC Unirea Youth participă în următoarele competiții:\n- {string.Join("\n- ", compNames)}";
                }
            }
            //TeamsTable
            if (msg.Contains("echipele noastre") || msg.Contains("ce echipe avem") ||
                msg.Contains("echipe fc unirea") || msg.Contains("subechipe") || msg.Contains("echipe interne"))
            {
                var teams = _teamsService.GetInternalTeamsAsync().Result.ToList();
                if (teams.Any())
                {
                    var teamNames = teams.Select(t => $"- {t.TeamName}");
                    return $"Echipele FC Unirea (echipele noastre) sunt:\n{string.Join("\n", teamNames)}";
                }
                else
                {
                    return "Momentan nu există echipe interne definite.";
                }
            }
            // PlayersTable
            if ((msg.Contains("jucatori") || msg.Contains("jucători") || msg.Contains("lot") || msg.Contains("player")))
            {
                string instructiune = "(Te rog să afișezi această listă exact, fără reformulare.)";


                if (msg.Contains("cf youth") || msg.Contains("youth"))
                {
                    var players = _playersService.GetPlayersByTeam(21);
                    var playerNames = players.Select(p => $"- {p.PlayerName} - {p.Position}").ToList();
                    if (playerNames.Any())
                        return $"{instructiune}\nJucătorii echipei FC Unirea CF Youth sunt:\n{string.Join("\n", playerNames)}";
                    else
                        return $"Momentan nu există jucători înregistrați pentru FC Unirea CF Youth.";
                }

                if (msg.Contains("u21"))
                {
                    var players = _playersService.GetPlayersByTeam(11);
                    var playerNames = players.Select(p => $"- {p.PlayerName} - {p.Position}").ToList();
                    if (playerNames.Any())
                        return $"{instructiune}\nJucătorii echipei FC Unirea U21 sunt:\n{string.Join("\n", playerNames)}";
                    else
                        return $"Momentan nu există jucători înregistrați pentru FC Unirea U21.";
                }

                if ((msg.Contains("fc unirea") || msg.Contains("unirea")) && !msg.Contains("u21") && !msg.Contains("youth"))
                {
                    var players = _playersService.GetPlayersByTeam(1);
                    var playerNames = players.Select(p => $"- {p.PlayerName} - {p.Position}").ToList();
                    if (playerNames.Any())
                        return $"{instructiune}\nJucătorii echipei FC Unirea sunt:\n{string.Join("\n", playerNames)}";
                    else
                        return $"Momentan nu există jucători înregistrați pentru FC Unirea.";
                }
            }
            //GamesTable
            if ((msg.Contains("ultimul meci") || msg.Contains("ultimul rezultat") || msg.Contains("rezultatul ultimului meci") || msg.Contains("a facut in ultimul meci")) &&
                (msg.Contains("fc unirea") || msg.Contains("unirea u21") || msg.Contains("unirea youth") || msg.Contains("cf youth") || msg.Contains("u21")))
            {
                // echipa, id și nume
                var ekipa = new { TeamId = 1, Name = "FC Unirea" };
                if (msg.Contains("cf youth") || msg.Contains("unirea youth"))
                    ekipa = new { TeamId = 21, Name = "FC Unirea CF Youth" };
                else if (msg.Contains("u21"))
                    ekipa = new { TeamId = 11, Name = "FC Unirea U21" };

                // cauta meciurile jucate ale echipei, desc
                var games = _gamesService.GetGamesWithTeamNamesByTeam(ekipa.TeamId)
                    .Where(g => g.IsPlayed)
                    .OrderByDescending(g => g.GameDate)
                    .ToList();

                if (games.Any())
                {
                    var lastGame = games.First();
                    string adversar = lastGame.HomeTeamName == ekipa.Name ? lastGame.AwayTeamName : lastGame.HomeTeamName;
                    string scor = $"{lastGame.HomeTeamScore} - {lastGame.AwayTeamScore}";
                    string compet = !string.IsNullOrEmpty(lastGame.CompetitionName) ? $" ({lastGame.CompetitionName})" : "";

                    // marcatyorii
                    var scorers = _playerStatisticsPerGameService.GetScorersForGameAsync(lastGame.Id).Result.ToList();
                    string scorersText = scorers.Any()
                        ? string.Join("\n", scorers.Select(s => $"- {s.PlayerName} ({s.Goals} goluri) [{s.TeamName}]"))
                        : "Nu există informații despre marcatori pentru acest meci.";

                    return $"Utilizatorul a întrebat: '{message}'.\n" +
                           $"Ultimul meci jucat de {ekipa.Name}{compet}:\n" +
                           $"{lastGame.HomeTeamName} vs {lastGame.AwayTeamName}\n" +
                           $"Scor: {scor}\n" +
                           $"Marcatori:\n{scorersText}";
                }
                else
                {
                    return $"Nu există date despre meciuri jucate pentru {ekipa.Name}.";
                }
            }
            //Stadiumstable
            if ((msg.Contains("stadion") || msg.Contains("stadium") || msg.Contains("arena")))
            {
                if (msg.Contains("cf youth") || msg.Contains("youth"))
                {
                    var stadium = _stadiumsService.GetStadium(21);
                    return $"Echipa FC Unirea CF Youth joacă pe stadionul {stadium.StadiumName}.";
                }
                if (msg.Contains("u21"))
                {
                    var stadium = _stadiumsService.GetStadium(11);
                    return $"Echipa FC Unirea U21 joacă pe stadionul {stadium.StadiumName}.";
                }
                if (msg.Contains("fc unirea") || (msg.Contains("unirea") && !msg.Contains("u21") && !msg.Contains("youth")))
                {
                    var stadium = _stadiumsService.GetStadium(1);
                    return $"Echipa FC Unirea joacă pe stadionul {stadium.StadiumName}.";
                }
            }
            //TicketsTable
            if ((msg.Contains("bilete") || msg.Contains("bilet") || msg.Contains("rezervari") || msg.Contains("rezervări")) &&
                (msg.Contains("mele") || msg.Contains("am") || msg.Contains("ale mele") || msg.Contains("rezervat")))
            {
                if (user == null)
                    return "Trebuie să fii autentificat pentru a-ți vedea biletele rezervate!";

                var tickets = _ticketsService.GetTicketsByUserIdAsync(user.Id).Result.ToList();

                var played = tickets.Where(t => t.IsPlayed).ToList();
                var upcoming = tickets.Where(t => !t.IsPlayed).ToList();

                string result = "";

                if (upcoming.Any())
                {
                    var ticketSummaries = upcoming.Select(t =>
                        $"- [VIITOR] {t.HomeTeamName} vs {t.AwayTeamName} ({t.CompetitionName}) la {t.StadiumName}, {t.GameDate:dd MMM yyyy, HH:mm} | Loc: {t.SeatName} {t.SeatType} ({t.SeatPrice} RON)"
                    );
                    result += "Biletele tale pentru meciuri care URMEAZĂ:\n" + string.Join("\n", ticketSummaries) + "\n";
                }
                if (played.Any())
                {
                    var ticketSummaries = played.Select(t =>
                        $"- [JUCAT] {t.HomeTeamName} vs {t.AwayTeamName} ({t.CompetitionName}) la {t.StadiumName}, {t.GameDate:dd MMM yyyy, HH:mm} | Loc: {t.SeatName} {t.SeatType} ({t.SeatPrice} RON)"
                    );
                    result += "Biletele tale pentru meciuri DEJA JUCATE:\n" + string.Join("\n", ticketSummaries);
                }

                if (string.IsNullOrWhiteSpace(result))
                    result = "Momentan nu ai bilete rezervate.";

                return result;
            }





        }
        // fallback generic
        return $"Ești asistentul virtual FC Unirea. Răspunde la întrebarea: \"{message}\" despre bilete, meciuri, profil, etc.";
    }

    public async Task<string> GetChatGptReplyAsync(string prompt)
    {
        var requestBody = new
        {
            model = "gpt-4o-mini-2024-07-18",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var httpRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api.openai.com/v1/chat/completions"),
            Headers =
            {
                { "Authorization", $"Bearer {_apiKey}" }
            },
            Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(httpRequest);
        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseString);
        var reply = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return reply;
    }
}


