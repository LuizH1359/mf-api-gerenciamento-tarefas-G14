using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class NotasDto : BaseEntity
    {
        [Required(ErrorMessage = "É necessário informar o valor da nota.")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0, 10, ErrorMessage = "O valor da nota deve estar entre 0 e 10.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A disciplina é obrigatória.")]
        public int DisciplinaId { get; set; }

        [Required(ErrorMessage = "É necessário informar o ID do usuário.")]
        public int UsuarioId { get; set; }
    }
}
