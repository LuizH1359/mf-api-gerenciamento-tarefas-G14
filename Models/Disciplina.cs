using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Disciplinas")]
    public class Disciplina : BaseEntity
    {
        [Required(ErrorMessage = "É necessário selecionar uma disciplina.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário selecionar o usuário.")]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Nota> Notas { get; set; }


    }
}
//<<<<<<< EndpointsDisciplina


//ignorar acento, maiusculo ou minusculo 
//entidade separada e rota separada também
// melhorar os relacionamentos com disciplina
// armazenar resposta em um enum e depois na hora de selecionar utilizar
//>>>>>>> master
