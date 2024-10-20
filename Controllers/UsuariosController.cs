using Microsoft.AspNetCore.Mvc;

namespace guiaUnivesitario.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Login()
        {
            return View(); // Certifique-se de que exista uma View chamada Login.cshtml
        }
    }
}
