using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class DisciplinasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário apontar o valor da média de aprovação")]
        [Range(0,100,ErrorMessage ="O valor da média deve estar entre 0 e 100.")]
        public int MediaAprovacao { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }
    }

}
