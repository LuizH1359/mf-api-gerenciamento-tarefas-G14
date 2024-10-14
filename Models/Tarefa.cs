using System.ComponentModel.DataAnnotations;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class Tarefa : BaseEntity
    {
        [Required]
        public string Nome { get; set; }

        [Required]

        public string Descricao { get; set; }

        [Required]
        public bool Realizada { get; set; }

    }
}
