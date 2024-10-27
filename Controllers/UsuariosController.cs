using guiaUnivesitario.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace guiaUnivesitario.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor que injeta o contexto do banco de dados
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // Método para exibir a página de login
        public IActionResult Login()
        {
            return View();
        }

        // Método para exibir a página de cadastro
        public IActionResult Cadastro()
        {
            return View();
        }

        public async Task<IActionResult> Cadastrar(Usuario usuario)
        {
            // Valida o modelo recebido
            if (ModelState.IsValid)
            {
                // Verifica se o email já está cadastrado
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuario.Email))
                {
                    TempData["Error"] = "Este email já está cadastrado."; // Mensagem de erro
                    return RedirectToAction("Cadastro"); // Redireciona para a view de cadastro com erro
                }

                // Verifica se as senhas são iguais
                if (usuario.Senha != usuario.ConfirmarSenha)
                {
                    TempData["Error"] = "As senhas não coincidem."; // Mensagem de erro
                    return RedirectToAction("Cadastro"); // Redireciona para a view de cadastro com erro
                }

                // Adiciona o usuário ao banco de dados
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cadastro realizado com sucesso!"; // Mensagem de sucesso
                return RedirectToAction("Login"); // Redireciona para a página de login após o cadastro
            }

            // Retorna a view de cadastro com o modelo se houver erro de validação
            return View("Cadastro", usuario);
        }



        // Método para processar o login
        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            // Verifica se o usuário existe
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario == null)
            {
                TempData["Error"] = "Email ou senha inválidos."; // Mensagem de erro
                return RedirectToAction("Login"); // Retorna a view com erro
            }

            // Aqui você deve implementar a lógica para manter o usuário logado (por exemplo, usando cookies)
            // Exemplo: criar um cookie de autenticação ou redirecionar para a página inicial
            return RedirectToAction("Index", "Home"); // Redireciona para a página inicial após login
        }
    }
}
