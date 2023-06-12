using Microsoft.AspNetCore.Mvc;
using webApiPTI.Helper;
using webApiPTI.Models;
using webApiPTI.Repositorios.Interfaces;

namespace webApiPTI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepositorio _loginRepositorio;
        private readonly SessionHelper _session = new SessionHelper();

        public LoginController(ILoginRepositorio loginRepositorio)
        {
            _loginRepositorio = loginRepositorio;
        }


        public IActionResult Index()
        {
            if(_session.SearchUserSession()  != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Professor result = _loginRepositorio.ConfereLogin(login);

                    if (result != null)
                    {
                        _session.CreateSession(result);
                        return RedirectToAction("Index", "Home");
                    }

                    
                    return View("Index");
                }

                    return View("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
            
        }

        
        public IActionResult Sair()
        {

                _session.RemoveUserSession();
                
                return RedirectToAction("Index", "Login");

        }

    }
}
