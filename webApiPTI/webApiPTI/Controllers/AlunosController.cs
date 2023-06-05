using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApiPTI.Data;
using webApiPTI.Models;

namespace webApiPTI.Controllers
{
   
    public class AlunosController : Controller
    {
        private readonly Context _context;

        public AlunosController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Alunos()
        {
            var alunosResult = await GetAlunos();
            var alunos = alunosResult.Value; 
            foreach(Aluno aluno in alunos)
            {
                aluno.DefinirPagamentoRecorrente(aluno.Pagamento.Day);
            }
            return View(alunos);
        }

        // GET: api/Aluno
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunos()
        {
           return await _context.Aluno.ToListAsync();
        }

        // GET: api/Aluno/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunoById(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }

        [HttpGet("Alunos/FindAlunoByName/{nome}")]
        public async Task<ActionResult<Aluno>> GetAlunoByName(string nome)
        {
            var aluno = await _context.Aluno.FirstOrDefaultAsync(a => a.Nome == nome);

            if (aluno == null)
            {
                return NotFound();
            }

            return aluno;
        }


        // POST: api/Aluno
        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAluno(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            await _context.SaveChangesAsync();

            return RedirectToAction("Alunos");
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAluno(int id, Aluno aluno)
        {
            if (id != aluno.Id_Aluno)
            {
                return BadRequest();
            }

            _context.Entry(aluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        [Route("/Alunos/ExcluirAluno/{id}")]
        public async Task<IActionResult> ExcluirAluno(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }

            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();

            return RedirectToPage("Alunos");
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.Id_Aluno == id);
        }
       
    }
}
