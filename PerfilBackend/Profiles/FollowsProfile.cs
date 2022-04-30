using AutoMapper;
using PerfilBackend.Models;
using PerfilBackend.Dtos;
namespace PerfilBackend.Profiles{
    public class FollowsProfile : Profile{
        public FollowsProfile()
        {
            // source -> Target
            CreateMap<Follows, FollowsReadDto>();
            CreateMap<FollowsCreateDto, Follows>();
        }
    }
}