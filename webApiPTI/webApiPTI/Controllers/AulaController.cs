using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiPTI.Data;
using webApiPTI.Models;

namespace webApiPTI.Controllers
{

    public class AulaController : Controller
    {
        private readonly Context _context;

        public AulaController(Context context)
        {
            _context = context;
        }

        // GET: api/Aula
        [HttpGet]
        public ActionResult<IEnumerable<Aula>> GetAulas()
        {
            var aulas = _context.Aula.ToList();
            return Ok(aulas);
        }

        // GET: api/Aula/5
        [HttpGet("{id}")]
        public ActionResult<Aula> GetAula(int id)
        {
            var aula = _context.Aula.FirstOrDefault(a => a.Id_Aula == id);

            if (aula == null)
            {
                return NotFound();
            }

            return Ok(aula);
        }

        // POST: api/Aula
        [HttpPost]
        public ActionResult<Aula> CreateAula(Aula aula)
        {
            _context.Aula.Add(aula);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetAula), new { id = aula.Id_Aula }, aula);
        }

        // PUT: api/Aula/5
        [HttpPut("{id}")]
        public IActionResult UpdateAula(int id, Aula aula)
        {
            if (id != aula.Id_Aula)
            {
                return BadRequest();
            }

            _context.Entry(aula).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Aula/5
        [HttpDelete("{id}")]
        public ActionResult<Aula> DeleteAula(int id)
        {
            var aula = _context.Aula.FirstOrDefault(a => a.Id_Aula == id);

            if (aula == null)
            {
                return NotFound();
            }

            _context.Aula.Remove(aula);
            _context.SaveChanges();

            return Ok(aula);
        }
    }
}
