using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApiPTI.Models;

namespace webApiPTI.ViewComponentes
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("userLogedSession");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Professor prof = JsonConvert.DeserializeObject<Professor>(sessaoUsuario);

            return View(prof);
        }
    }
}
