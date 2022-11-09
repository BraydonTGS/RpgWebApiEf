﻿using System;
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

            var characters = await _context.Characters.Where(c => c.UserID == userId).ToListAsync();

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
    }
}

