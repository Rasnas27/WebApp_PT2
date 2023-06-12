using webApiPTI.Models;

namespace webApiPTI.Repositorios.Interfaces
{
    public interface IProfessorRepositorio
    {
        Task<Professor> Criar(Professor professor);
    }
}
