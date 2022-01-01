using AutoMapper;
using inspectorApi.Dtos.Character;
using inspectorApi.Models;

namespace inspectorApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddChracterDto, Character>();
        }

    }
}