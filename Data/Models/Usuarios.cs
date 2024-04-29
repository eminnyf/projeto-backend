using GerenciamentoUsuarioAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GerenciamentoUsuarioAPI.Models

{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeDeUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string Senha { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }


        // Relacionamento com Tarefas
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();

        // Utilizando para propriedados do nome
        [Required]
        [StringLength(50)]
        public string PrimeiroNome { get; set; }

        [Required]
        [StringLength(50)]
        public string Sobrenome { get; set; }
    }

}