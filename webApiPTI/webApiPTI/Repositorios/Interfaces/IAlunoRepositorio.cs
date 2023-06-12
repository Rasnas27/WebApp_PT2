using webApiPTI.Models;

namespace webApiPTI.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<Aluno> GetByIdAsync(int id);
        Task<List<Aluno>> GetAllAsync();
        Task<Aluno> CriarAsync(Aluno aluno);
    }
}
