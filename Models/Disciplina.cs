using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Disciplinas")]
    public class Disciplina : BaseEntity
    {
        [Required]
        public DisciplinasEnum Nome { get; set; }

        [Required]

        public int UsuarioId { get; set; }

        [Required]

        public Usuario Usuario { get; set; }


        public ICollection<Nota> Notas { get; set; }



    }

    public enum DisciplinasEnum
    {
        Português,
        Matématica,
        Geografia
    }
}


// armazenar resposta em um enum e depois na hora de selecionar utilizar
