using AutoMapper;
using inspectorApi.Data;
using inspectorApi.Dtos.Character;
using inspectorApi.Models;
using Microsoft.EntityFrameworkCore;

namespace inspectorApi.Services.CharacterService
{
    public class CharacterService : IcharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _Context;

        public CharacterService(IMapper mapper,DataContext Context)
        {
            _mapper = mapper;
            _Context = Context;
        }
        //private static List<Character> characters = new List<Character> {
        //    new Character(),
        //    new Character {id=1,name="sam"},
        //    new Character {id=2,name="david"}
        //};
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddChracterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            
            _Context.Add(character);
            await _Context.SaveChangesAsync();
            serviceResponse.Data = await _Context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacters = await _Context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetSingle(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var dbCharacter = await _Context.Characters.SingleOrDefaultAsync(c=>c.id==id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _Context.Characters.FirstOrDefaultAsync(c => c.id == updateCharacter.id);

                character.name = updateCharacter.name;
                character.HitPoints = updateCharacter.HitPoints;
                character.Strength = updateCharacter.Strength;
                character.Defence = updateCharacter.Defence;
                character.Intelegents = updateCharacter.Intelegents;
                character.Class = updateCharacter.Class;

                await _Context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            }
            catch (Exception ex)
            {
                serviceResponse.Succsess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await _Context.Characters.FirstAsync(c => c.id == id);
                _Context.Characters.Remove(character);
                await _Context.SaveChangesAsync();
                serviceResponse.Data = _Context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            }
            catch (Exception ex)
            {

                serviceResponse.Succsess = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}