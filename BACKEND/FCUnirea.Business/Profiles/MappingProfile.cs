
using AutoMapper;
using FCUnirea.Business.Models;
using FCUnirea.Domain.Entities;

namespace FCUnirea.Business.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Comments, CommentsModel>().ReverseMap();
            CreateMap<Competitions, CompetitionsModel>().ReverseMap();
            CreateMap<Games, GamesModel>().ReverseMap();
            CreateMap<News, NewsModel>().ReverseMap();
            CreateMap<Players, PlayersModel>().ReverseMap();
            CreateMap<PlayerStatisticsPerCompetition, PlayerStatisticsPerCompetitionModel>().ReverseMap();
            CreateMap<PlayerStatisticsPerGame, PlayerStatisticsPerGameModel>().ReverseMap();
            CreateMap<Seats, SeatsModel>().ReverseMap();
            CreateMap<Stadiums, StadiumsModel>().ReverseMap();
            CreateMap<Teams, TeamsModel>().ReverseMap();
            CreateMap<TeamStatistics, TeamStatisticsModel>().ReverseMap();
            CreateMap<Tickets, TicketsModel>().ReverseMap();
            CreateMap<Users, UsersModel>().ReverseMap();
            //
            CreateMap<Users, LoginModel>().ReverseMap();
            CreateMap<Users, UserProfileModel>().ReverseMap();
            CreateMap<Users, ChangePasswordModel>().ReverseMap();


        }
    }
}
