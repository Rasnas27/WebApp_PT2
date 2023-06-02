using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiPTI.Data;
using webApiPTI.Models;

namespace webApiPTI.Controllers
{
   
    public class ProfessorController : Controller
    {
        private readonly Context _context;

        public ProfessorController(Context context)
        {
            _context = context;
        }

        // GET: api/Professor
        [HttpGet]
        public ActionResult<IEnumerable<Professor>> GetProfessores()
        {
            var professores = _context.Professor.ToList();
            return Ok(professores);
        }

        // GET: api/Professor/5
        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessor(int id)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Id_Professor == id);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // GET: api/Professor/Pedro
        [HttpGet("{nome}")]
        public ActionResult<Professor> GetProfessorByName(string nome)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Nome == nome);

            if (professor == null)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        // POST: api/Professor
        [HttpPost]
        public ActionResult<Professor> CreateProfessor(Professor professor)
        {
            _context.Professor.Add(professor);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id_Professor }, professor);
        }

        // PUT: api/Professor/5
        [HttpPut("{id}")]
        public IActionResult UpdateProfessor(int id, Professor professor)
        {
            if (id != professor.Id_Professor)
            {
                return BadRequest();
            }

            _context.Entry(professor).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Professor/5
        [HttpDelete("{id}")]
        public ActionResult<Professor> DeleteProfessor(int id)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Id_Professor == id);

            if (professor == null)
            {
                return NotFound();
            }

            _context.Professor.Remove(professor);
            _context.SaveChanges();

            return Ok(professor);
        }

        [HttpPost("Login")]
        public ActionResult<Professor> LoginProfessor(string login, string senha)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Login == login);

            if (professor == null || professor.Senha != senha)
            {
                return NotFound();
            }

            return Ok(professor);
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

    }
}
