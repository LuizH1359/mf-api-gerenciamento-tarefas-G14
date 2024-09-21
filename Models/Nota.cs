using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Notas")]
    public class Nota : BaseEntity
    {
        [Column(TypeName = "decimal(5, 2)")]
        [Range(0,10)]   // conferir se a necessidade
        public decimal Valor { get; set; }

        public int DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}
