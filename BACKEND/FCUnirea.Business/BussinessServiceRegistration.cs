
using FCUnirea.Business.Services.IServices;
using FCUnirea.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FCUnirea.Business
{
    public static class BussinessServiceRegistration
    {
        // configureaza si inregistreaza serviciile în containerul de Dependency Injection
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // inregistreaza fiecare serviciu cu o durata scoped(o singura instanta per cerere HTTP).
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<ICompetitionsService, CompetitionsService>();
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<IPlayersService, PlayersService>();
            services.AddScoped<IPlayerStatisticsPerCompetitionService, PlayerStatisticsPerCompetitionService>();
            services.AddScoped<IPlayerStatisticsPerGameService, PlayerStatisticsPerGameService>();
            services.AddScoped<ISeatsService, SeatsService>();
            services.AddScoped<IStadiumsService, StadiumsService>();
            services.AddScoped<ITeamsService, TeamsService>();
            services.AddScoped<ITeamStatisticsService, TeamStatisticsService>();
            services.AddScoped<ITicketsService, TicketsService>();
            services.AddScoped<IUsersService, UsersService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
