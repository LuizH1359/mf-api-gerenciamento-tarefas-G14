using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mf_api_gerenciamento_tarefas_G14.Models;


namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Usuários")]
    public class Usuario : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } //  colocar Senha

      public ICollection<Disciplina> Disciplinas { get; set; }

    }
}
