using System;
using webApiPTI.Data;

namespace webApiPTI.Repositorios
{
    public class RepositorioBase
    {
        protected readonly Context _db;


        public RepositorioBase(Context db = null)
        {
            _db = db ?? new Context();
        }
    }
}
