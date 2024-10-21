using System.ComponentModel.DataAnnotations;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class DisciplinasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "É necessário informar a porcentagem necessária para aprovação.")]
        [Range(0, 100, ErrorMessage = "A porcentagem deve estar entre 0 e 100.")]
        public decimal PorcentagemNecessaria { get; set; }
    }
}