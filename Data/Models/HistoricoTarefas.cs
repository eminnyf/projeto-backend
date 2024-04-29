using GerenciamentoUsuarioAPI.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoUsarioAPI.Data.Models
{
    public class HistoricoTarefa
    {
        [Key]
        public int Id { get; set; }

        public string? Titulo { get; set; } // operador '?' marca como anulável

        public string? Descricao { get; set; } 

        [DataType(DataType.Date)] 
        public DateTime? DataDeVencimento { get; set; }

        public bool Concluida { get; set; }

        public DateTime DataModificacao { get; set; }

        public int? IdDaTarefa { get; set; }

        [ForeignKey("IdDaTarefa")]
        public virtual Tarefa Tarefa { get; set; }



    }
}
