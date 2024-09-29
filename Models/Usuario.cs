using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using mf_api_gerenciamento_tarefas_G14.Models;


namespace mf_api_gerenciamento_tarefas_G14.Models
{
    [Table("Usuários")]
    public class Usuario : BaseEntity
    {
        [Required(ErrorMessage ="É necessário informar o nome.")]
        [MaxLength(100,ErrorMessage ="O nome não pode ter mais de 100 caracteres.")]
        [MinLength(4,ErrorMessage ="O nome não pode conter menos de 4 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="É necessário informar o email.")]
        [EmailAddress(ErrorMessage ="Por favor insira um email valido.")]
        [MaxLength(100,ErrorMessage ="O email não pode conter mais de 100 caracteres.")]

        public string Email { get; set; }

        [Required(ErrorMessage ="É necessário informar a senha.")]
        [MinLength(8,ErrorMessage ="A senha não pode conter menos de 8 caracteres.")]
        public string Senha { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }

    }
}
