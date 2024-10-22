using System.ComponentModel.DataAnnotations;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class AuthenticateDto
    {
        [Required]
        public string Email { get; set; } // Assumindo que o login será por e-mail

        [Required]
        public string Senha { get; set; }
    }
}
