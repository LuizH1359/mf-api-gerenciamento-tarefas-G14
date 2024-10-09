using System.ComponentModel.DataAnnotations;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class AuthenticateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
