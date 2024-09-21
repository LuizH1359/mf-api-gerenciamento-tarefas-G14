using System.ComponentModel.DataAnnotations;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
