using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Tarefas")]
    public class TarefasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário informar o nome da tarefa.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar a descrição da tarefa.")]

        public string Descricao { get; set; }

        [Required]
        public bool Realizada { get; set; }

        [Required]
        public int UsuarioId { get; set; }


    }
}
