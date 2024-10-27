using guiaUnivesitario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace guiaUnivesitario.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // Exibir a página de login
        public IActionResult Login()
        {
            return View();
        }

        // Exibir a página de cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            // Validar o modelo recebido
            if (ModelState.IsValid)
            {
                // Verificar se o email já está cadastrado
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                {
                    TempData["Error"] = "Este email já está cadastrado."; 
                    return RedirectToAction("Cadastro"); 
                }

                // Verificar se as senhas são iguais
                if (usuario.Senha != usuario.ConfirmarSenha)
                {
                    TempData["Error"] = "As senhas não coincidem."; 
                    return RedirectToAction("Cadastro"); 
                }

                // Adiciona o usuário ao banco de dados
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cadastro realizado com sucesso!"; 
                return RedirectToAction("Login");
            }

            return View("Cadastro", usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            // Verifica se o usuário existe
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                TempData["Error"] = "Email ou senha inválidos."; 
                return RedirectToAction("Login"); 
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
