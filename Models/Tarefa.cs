using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Tarefas")]
    public class Tarefa : BaseEntity
    {
        [Required]
        public string Nome { get; set; }

        [Required]

        public string Descricao { get; set; }

        [Required]
        public bool Realizada { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

    }
}
