using Microsoft.AspNetCore.Mvc;
using GerenciamentoUsuarioAPI.Services;
using GerenciamentoUsuarioAPI.Models; // Importe o namespace dos modelos
using System;
using System.Threading.Tasks;
using GerenciamentoUsarioAPI.Data;

namespace GerenciamentoUsuarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ServicoUsuarioAleatorio _servicoUsuarioAleatorio; 
        private readonly GerenciamentoBD _contexto;

        public UsuarioController(ServicoUsuarioAleatorio servicoUsuarioAleatorio, GerenciamentoBD contexto)
        {
            _servicoUsuarioAleatorio = servicoUsuarioAleatorio ?? throw new ArgumentNullException(nameof(servicoUsuarioAleatorio));
            _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        [HttpPost("GerarUsuarios")]
        public async Task<IActionResult> GerarUsuarios()
        {
            try
            {
                // Consumir a API Random User Generator
                var dadosUsuario = await _servicoUsuarioAleatorio.ObterDadosUsuarioAleatorio();

                // Armazenar os usuários no banco de dados
                foreach (var resultado in dadosUsuario.Resultados)
                {
                    var novoUsuario = new Usuario // Usando o namespace completo para a classe Usuario
                    {
                        PrimeiroNome = resultado.Name.First,
                        Sobrenome = resultado.Name.Last,
                        Email = resultado.Email,
                        // Adicione outras propriedades conforme necessário
                    };

                    _contexto.Usuarios.Add(novoUsuario);
                }

                await _contexto.SaveChangesAsync();

                return Ok("Usuários gerados e armazenados com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao gerar e armazenar usuários: " + ex.Message);
            }
        }
    }
}
