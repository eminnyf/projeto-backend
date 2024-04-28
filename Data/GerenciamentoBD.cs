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
      modelBuilder.Entity<Tarefa>()
          .HasOne(tarefa => tarefa.Usuario) 
          .WithMany(tarefa => tarefa.Tarefas)
          .HasForeignKey(tarefa => tarefa.IdDoUsuario)
          .IsRequired();

      modelBuilder.Entity<HistoricoTarefa>()
          .HasOne(historico => historico.Tarefa) // Tarefa que originou a alteração
          .WithMany(historico => historico.Historico) // Muitas alterações para uma Tarefa
          .HasForeignKey(historico => historico.IdDaTarefa); // Chave estrangeira em HistoricoTarefa
    }
  }

}
