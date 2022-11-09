using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationships.Data;
using EFCoreRelationships.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCoreRelationships.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {

        private readonly DataContext _context;
        // Constructor Where We Inject the Data Context //
        public CharacterController(DataContext context)
        {
            _context = context;
        }

        // Get Method //
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters.Where(c => c.UserID == userId).Include(c => c.Weapon).Include(c => c.Skills).ToListAsync();
            return characters;
        }

        // Post Method //
        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CreateCharacterDto request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var newCharacter = new Character();

            newCharacter.Name = request.Name;
            newCharacter.RpgClass = request.RpgClass;
            newCharacter.User = user;

            _context.Characters.Add(newCharacter);

            await _context.SaveChangesAsync();

            return await Get(newCharacter.UserID);
        }

        // Post Method Create Weapon//
        [HttpPost("weapon")]
        public async Task<ActionResult<Character>> CreateWeapon(CreateWeaponDto request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
            {
                return NotFound();
            }

            var newWeapon = new Weapon();

            newWeapon.Name = request.Name;
            newWeapon.Damage = request.Damage;
            newWeapon.Character = character;

            _context.Weapons.Add(newWeapon);

            await _context.SaveChangesAsync();

            return character;
        }

        // Post Method Add Skill//
        [HttpPost("skill")]
        public async Task<ActionResult<Character>> AddCharacterSkill(AddCharacterSkillDto request)
        {
            var character = await _context.Characters.Where(c => c.Id == request.CharacterId).Include(c => c.Skills).FirstOrDefaultAsync();
            if (character == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null)
            {
                return NotFound();
            }

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}

