/*using EntityFramework7Relationships.DTOs;
using EntityFramework7Relationships.Models;
using EntityFramework7Relationships.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Relationships.Controllers;

[ApiController]
[Route("[controller]")]
public class TlouController : ControllerBase
{
    private readonly DataContext _context;

    public TlouController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
    {
        var newCharacter = new Character
            {
                Name = request.Name
            }
            ;
        var backPack = new BackPack { Description = request.BackPack.Description, Character = newCharacter };
        var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = newCharacter }).ToList();
        var factions = request.Factions.Select(f => new Faction
            { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

        newCharacter.BackPack = backPack;
        newCharacter.Weapons = weapons;
        newCharacter.Factions = factions;
        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();
        return Ok(await _context.Characters.Include(c => c.BackPack).Include(c => c.Weapons).ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAllCharacters()
    {
        var characters = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .ToListAsync();

        return Ok(characters);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);
        return Ok(character);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, CharacterCreateDto request)
    {
        var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null) return NotFound();

        character.Name = request.Name;

        // Update backpack if provided
        if (request.BackPack != null) character.BackPack.Description = request.BackPack.Description;

        // Update weapons if provided
        if (request.Weapons != null)
        {
            _context.Weapons.RemoveRange(character.Weapons);
            character.Weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, CharacterId = id }).ToList();
        }

        // Update factions if provided
        if (request.Factions != null)
        {
            var newFactions = request.Factions.Select(f => new Faction
                { Name = f.Name, Characters = new List<Character> { character } });

            var oldFactions = character.Factions.ToList();
            character.Factions.Clear();
            foreach (var faction in oldFactions) _context.Entry(faction).State = EntityState.Deleted;

            character.Factions.AddRange(newFactions);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null) return NotFound();

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}*/

using EntityFramework7Relationships.DTOs;
using EntityFramework7Relationships.Models;
using EntityFramework7Relationships.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework7Relationships.Controllers;

[ApiController]
[Route("[controller]")]
public class TlouController : ControllerBase
{
    private readonly DataContext _context;

    public TlouController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<List<Character>>> CreateCharacter(CharacterCreateDto request)
    {
        var newCharacter = new Character
            {
                Name = request.Name
            }
            ;
        var backPack = new BackPack { Description = request.BackPack.Description, Character = newCharacter };
        var weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, Character = newCharacter }).ToList();
        var factions = request.Factions.Select(f => new Faction
            { Name = f.Name, Characters = new List<Character> { newCharacter } }).ToList();

        newCharacter.BackPack = backPack;
        newCharacter.Weapons = weapons;
        newCharacter.Factions = factions;
        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();
        return Ok(await _context.Characters.Include(c => c.BackPack).Include(c => c.Weapons).ToListAsync());
    }

    [HttpGet]
    public async Task<ActionResult<List<Character>>> GetAllCharacters()
    {
        var characters = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .ToListAsync();

        return Ok(characters);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacterById(int id)
    {
        var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);
        return Ok(character);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCharacter(int id, CharacterCreateDto request)
    {
        var character = await _context.Characters
            .Include(c => c.BackPack)
            .Include(c => c.Weapons)
            .Include(c => c.Factions)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (character == null) return NotFound();

        character.Name = request.Name;

        // Update backpack if provided
        if (request.BackPack != null) character.BackPack.Description = request.BackPack.Description;

        // Update weapons if provided
        if (request.Weapons != null)
        {
            _context.Weapons.RemoveRange(character.Weapons);
            character.Weapons = request.Weapons.Select(w => new Weapon { Name = w.Name, CharacterId = id }).ToList();
        }

        // Update factions if provided
        if (request.Factions != null)
        {
            var newFactions = request.Factions.Select(f => new Faction
                { Name = f.Name, Characters = new List<Character> { character } });

            var oldFactions = character.Factions.ToList();
            character.Factions.Clear();
            foreach (var faction in oldFactions) _context.Entry(faction).State = EntityState.Deleted;

            character.Factions.AddRange(newFactions);
        }

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCharacter(int id)
    {
        var character = await _context.Characters.FindAsync(id);
        if (character == null) return NotFound();

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}



