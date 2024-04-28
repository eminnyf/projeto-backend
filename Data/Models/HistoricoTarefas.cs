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

        public string? Titulo { get; set; } // Marcando como anulável usando o operador '?'

        public string? Descricao { get; set; } // Marcando como anulável usando o operador '?'

        [DataType(DataType.Date)] 
        public DateTime? DataDeVencimento { get; set; }

        public bool Concluida { get; set; }

        public DateTime DataModificacao { get; set; }

        public int? IdDaTarefa { get; set; }
        public virtual Tarefa Tarefa { get; set; }

       

    }
}
