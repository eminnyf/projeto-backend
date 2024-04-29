using Microsoft.EntityFrameworkCore;
using GerenciamentoUsarioAPI.Data.Models;
using GerenciamentoUsuarioAPI.Models;
using GerenciamentoUsuarioAPI.Data.Models;

namespace GerenciamentoUsarioAPI.Data
{
    public class GerenciamentoBD : DbContext
    {
        public GerenciamentoBD(DbContextOptions<GerenciamentoBD> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Define o relacionamento entre a entidade Tarefa e Usuario.
            modelBuilder.Entity<Tarefa>()
                .HasOne(tarefa => tarefa.Usuario) // Um pra Um
                .WithMany(tarefa => tarefa.Tarefas) // Muitas para um
                .HasForeignKey(tarefa => tarefa.IdDoUsuario) // Chave estrangeira
                .IsRequired();

            // Define o relacionamento entre a entidade HistoricoTarefa e Tarefa
            modelBuilder.Entity<HistoricoTarefa>()
          .HasOne(historico => historico.Tarefa)
          .WithMany(historico => historico.Historico)
          .HasForeignKey(historico => historico.IdDaTarefa);
        }
    }

}
