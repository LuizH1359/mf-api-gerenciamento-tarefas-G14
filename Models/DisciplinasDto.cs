using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class DisciplinasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário apontar o valor da média de aprovação")]
        public int MediaAprovacao { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }
    }

}
