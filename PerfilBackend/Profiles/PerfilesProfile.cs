using AutoMapper;
using PerfilBackend.Models;
using PerfilBackend.Dtos;
namespace PerfilBackend.Profiles
{
    public class PerfilesProfile : Profile
    {
        public PerfilesProfile()
        {
            // source -> Target
            CreateMap<Perfil, PerfilReadDto>();
            CreateMap<PerfilCreateDto, Perfil>();
        }
    }
}
