using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt.Models;

namespace Projekt.Controllers
{
    [Produces("application/json")]
    [Route("api/DiningExperiencesApi")]
    public class DiningExperiencesApiController : Controller
    {
        private readonly ProjektContext _context;

        public DiningExperiencesApiController(ProjektContext context)
        {
            _context = context;
        }

        // GET: api/DiningExperiencesApi
        [HttpGet]
        public IEnumerable<DiningExperience> GetDiningExperience()
        {
            return _context.DiningExperience;
        }

        // GET: api/DiningExperiencesApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiningExperience([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diningExperience = await _context.DiningExperience.SingleOrDefaultAsync(m => m.Id == id);

            if (diningExperience == null)
            {
                return NotFound();
            }

            return Ok(diningExperience);
        }

        private bool DiningExperienceExists(int id)
        {
            return _context.DiningExperience.Any(e => e.Id == id);
        }
    }
}