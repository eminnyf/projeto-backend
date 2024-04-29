using GerenciamentoUsarioAPI.Data.Models;
using GerenciamentoUsuarioAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GerenciamentoUsuarioAPI.Data.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataDeVencimento { get; set; }

        public bool Concluida { get; set; }

        public int? IdDoUsuario { get; set; }

        [ForeignKey("IdDoUsuario")]
        public virtual Usuario Usuario { get; set; }


        // Relacionamento com HistoricoTarefas
        public ICollection<HistoricoTarefa> Historico { get; set; } = new List<HistoricoTarefa>();
    }
}
