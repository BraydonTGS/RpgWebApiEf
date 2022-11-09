using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreRelationships.Data;
using Microsoft.AspNetCore.Mvc;

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
    }
}

