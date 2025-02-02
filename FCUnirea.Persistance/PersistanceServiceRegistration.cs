using FCUnirea.Domain.IRepositories;
using FCUnirea.Persistance.Data;
using FCUnirea.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FCUnirea.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FCUnireaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FCUnireaConnectionString")));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICompetitionsRepository, CompetitionsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ITeamsRepository, TeamsRepository>();
            services.AddScoped<IPlayersRepository, PlayersRepository>();
            services.AddScoped<IStadiumsRepository, StadiumsRepository>();
            services.AddScoped<ISeatsRepository, SeatsRepository>();
            services.AddScoped<IGamesRepository, GamesRepository>();
            services.AddScoped<ITicketsRepository, TicketsRepository>();
            services.AddScoped<ITeamStatisticsRepository, TeamStatisticsRepository>();
            services.AddScoped<IPlayerStatisticsPerCompetitionRepository, PlayerStatisticsPerCompetitionRepository>();
            services.AddScoped<IPlayerStatisticsPerGameRepository, PlayerStatisticsPerGameRepository>();
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<IFeedbacksRepository, FeedbacksRepository>();


            return services;
        }
    }
}
