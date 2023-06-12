using Newtonsoft.Json;
using webApiPTI.Models;

namespace webApiPTI.Helper
{
    public class SessionHelper
    {
        private HttpContextAccessor _httpContext = new HttpContextAccessor();

        //Busca sessão do usuário
        public Professor SearchUserSession()
        {
            string userSession = _httpContext.HttpContext.Session.GetString("userLogedSession");

            if (string.IsNullOrEmpty(userSession)) return null;

            return JsonConvert.DeserializeObject<Professor>(userSession);

        }

        //Cria sessão do usuário
        public void CreateSession(Professor user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("userLogedSession", value);
        }

        //Remove sessão do usuário
        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("userLogedSession");

        }
    }
}
