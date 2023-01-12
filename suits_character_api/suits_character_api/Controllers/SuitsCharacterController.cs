using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using suits_character_api.Data;

namespace suits_character_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuitsCharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public SuitsCharacterController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuitsCharacter>>> GetSuitsCharacter()
        {
            return Ok(await _context.SuitsCharacters.ToListAsync());
            
        }

        [HttpPost]
        public async Task<ActionResult<SuitsCharacter>> PostSuitsCharacter(SuitsCharacter character)
        {
            _context.SuitsCharacters.Add(character);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuitsCharacters.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<SuitsCharacter>> PutSuitsCharacter(SuitsCharacter character)
        {
            var dbCharacter = await _context.SuitsCharacters.FindAsync(character.Id);
            if(dbCharacter == null)
                return BadRequest("Character not found");
            
            dbCharacter.Name = character.Name;
            dbCharacter.FirstName = character.FirstName;
            dbCharacter.LastName = character.LastName;
            dbCharacter.JobTitle = character.JobTitle;
            dbCharacter.Company = character.Company;
            
            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuitsCharacters.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuitsCharacter>> DeleteSuitsCharacter(int id)
        {
            var dbCharacter = await _context.SuitsCharacters.FindAsync(id);
            if(dbCharacter == null)
                return BadRequest("Character not found");
            _context.SuitsCharacters.Remove(dbCharacter);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuitsCharacters.ToListAsync());
        }
    }
}
