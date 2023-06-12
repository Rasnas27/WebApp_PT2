using Microsoft.EntityFrameworkCore;
using webApiPTI.Helper;
using webApiPTI.Models;
using webApiPTI.Repositorios.Interfaces;

namespace webApiPTI.Repositorios
{
    public class AlunoRepositorio : RepositorioBase, IAlunoRepositorio
    {
        private readonly SessionHelper _session = new SessionHelper();
        public async Task<Aluno> CriarAsync(Aluno aluno)
        {
            Professor prof = _session.SearchUserSession();

            aluno.ProfessorId = prof.Id_Professor;

            await _db.Aluno.AddAsync(aluno);
           await _db.SaveChangesAsync();

            return aluno;
        }

        public async Task<List<Aluno>> GetAllAsync()
        {
            Professor prof = _session.SearchUserSession();

            return await _db.Aluno
                      .AsNoTracking()
                      .Where(x => x.ProfessorId == prof.Id_Professor)
                      .ToListAsync();
        }

        public async Task<Aluno> GetByIdAsync(int id)
        {
            return await _db.Aluno
                     .FirstOrDefaultAsync(x => x.Id_Aluno == id);
        }
    }
}
