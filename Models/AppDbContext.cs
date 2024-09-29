using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace mf_api_gerenciamento_tarefas_G14.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Relacionamento Usuário / Disciplinas (1:N)
            builder.Entity<Usuario>()
           .HasMany(u => u.Disciplinas)
           .WithOne(d => d.Usuario)
           .HasForeignKey(d => d.UsuarioId) //define chave estrangeira
           .OnDelete(DeleteBehavior.Restrict);

            //Relacionamento Disciplina / Notas
            builder.Entity<Disciplina>()
            .HasMany(d => d.Notas)
            .WithOne(n => n.Disciplina)
            .HasForeignKey(n => n.DisciplinaId)
            .OnDelete(DeleteBehavior.Restrict);
 
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Nota> Notas { get; set; }

    }
}
