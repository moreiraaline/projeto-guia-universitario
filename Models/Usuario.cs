using System.ComponentModel.DataAnnotations.Schema;

namespace guiaUnivesitario.Models
{
    public class Usuario
    {
        public int Id { get; set; } // Chave primária
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // Armazenar senhas de forma segura é importante, considere usar hashing.

        [NotMapped] // Para não mapear esta propriedade na base de dados
        public string ConfirmarSenha { get; set; }
    }
}
