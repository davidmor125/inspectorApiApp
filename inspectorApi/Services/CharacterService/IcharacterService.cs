using System.Collections.Generic;
using inspectorApi.Dtos.Character;
using inspectorApi.Models;

namespace inspectorApi.Services.CharacterService
{
    public interface IcharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetSingle(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddChracterDto character);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}