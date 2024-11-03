using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Disciplinas")]
    public class Disciplina : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário apontar o valor da média de aprovação")]
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0,100,ErrorMessage = "O valor da média deve estar entre 0 e 100.")]
        public int MediaAprovacao { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "É necessário informar a porcentagem necessária para aprovação.")]
        [Range(0, 100, ErrorMessage = "A porcentagem deve estar entre 0 e 100.")]
        public decimal PorcentagemNecessaria { get; set; }

        public decimal Media { get; set; }

        public virtual Usuario Usuario { get; set; }

        public ICollection<Nota> Notas { get; set; }
    }
}
