using webApiPTI.Models;
using webApiPTI.Repositorios.Interfaces;

namespace webApiPTI.Repositorios
{
    public class LoginRepositorio : RepositorioBase, ILoginRepositorio
    {
        public Professor ConfereLogin(LoginModel login)
        {
            Professor profName = _db.Professor
                                .Where(x => x.Login == login.UserName)
                                .FirstOrDefault();

            if (profName != null)
            {
                 
                if (profName.Senha == login.Password)
                {
                    return profName;
                }
                return null;
            }

            return null;
        }
    }
}
