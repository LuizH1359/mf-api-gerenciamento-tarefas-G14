using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class DisciplinasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        
        public DisciplinasEnum Nome { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }
    }

}
