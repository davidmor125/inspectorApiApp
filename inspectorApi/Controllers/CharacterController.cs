using inspectorApi.Dtos.Character;
using inspectorApi.Models;
using inspectorApi.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace inspectorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly IcharacterService _characterService;
        public CharacterController(IcharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetSingle(id));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddChracterDto NewCharactre)
        {
            return Ok(await _characterService.AddCharacter(NewCharactre));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updateCharactre)
        {
            var response = await _characterService.UpdateCharacter(updateCharactre);
            if (response != null)
                return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> DeleteCharacter(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response != null)
                return NotFound(response);
            return Ok(response);
        }
    }
}