using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using webApiPTI.Data;
using webApiPTI.Models;

namespace webApiPTI.Controllers
{
   
    public class ContratoController : Controller
    {
        private readonly Context _context;

        public ContratoController(Context context)
        {
            _context = context;
        }

        // GET: api/Contrato
        [HttpGet]
        public ActionResult<IEnumerable<Contrato>> GetContratos()
        {
            var contratos = _context.Contrato.ToList();
            return Ok(contratos);
        }

        // GET: api/Contrato/5
        [HttpGet("{id}")]
        public ActionResult<Contrato> GetContrato(int id)
        {
            var contrato = _context.Contrato.FirstOrDefault(c => c.id_Contrato == id);

            if (contrato == null)
            {
                return NotFound();
            }

            return Ok(contrato);
        }

        // POST: api/Contrato
        [HttpPost]
        public ActionResult<Contrato> CreateContrato(Contrato contrato)
        {
            _context.Contrato.Add(contrato);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetContrato), new { id = contrato.id_Contrato }, contrato);
        }

        // PUT: api/Contrato/5
        [HttpPut("{id}")]
        public IActionResult UpdateContrato(int id, Contrato contrato)
        {
            if (id != contrato.id_Contrato)
            {
                return BadRequest();
            }

            _context.Entry(contrato).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Contrato/5
        [HttpDelete("{id}")]
        public ActionResult<Contrato> DeleteContrato(int id)
        {
            var contrato = _context.Contrato.FirstOrDefault(c => c.id_Contrato == id);

            if (contrato == null)
            {
                return NotFound();
            }

            _context.Contrato.Remove(contrato);
            _context.SaveChanges();

            return Ok(contrato);
        }
    }
}
