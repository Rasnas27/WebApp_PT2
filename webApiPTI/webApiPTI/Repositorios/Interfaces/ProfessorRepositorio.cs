using webApiPTI.Models;

namespace webApiPTI.Repositorios.Interfaces
{
    public class ProfessorRepositorio : RepositorioBase, IProfessorRepositorio
    {
        public async Task<Professor> Criar(Professor professor)
        {
           await _db.Professor.AddAsync(professor);
          await  _db.SaveChangesAsync();

            return professor;
        }
    }
}
