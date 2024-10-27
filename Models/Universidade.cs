using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace guiaUnivesitario.Models
{
    [Table("Universidades")]
    public class Universidade
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a cidade")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o estado")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o cep")]
        public int Cep { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o curso")]
        public string Curso { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Avaliação do MEC")]
        [Display(Name ="Avaliação do MEC")]
        public int avaliacaoMEC { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Avaliação do Aluno")]
        [Display(Name = "Avaliação do Aluno")]
        public int avaliacaoAluno { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Avaliação do Professor")]
        [Display(Name = "Avaliação do Professor")]
        public int avaliacaoProfessor { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o comentário")]
        [Display(Name = "Comentário")]
        public string Comentario { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o preço")]
        public int Preco { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Site")]
        public string Site { get; set; }

    }
}
