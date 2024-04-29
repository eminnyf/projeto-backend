using Microsoft.AspNetCore.Mvc;
using GerenciamentoUsuarioAPI.Services;
using GerenciamentoUsuarioAPI.Models; 
using System;
using System.Threading.Tasks;
using GerenciamentoUsarioAPI.Data;
using Microsoft.EntityFrameworkCore;


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
                // Consumo da API Random User Generator
                var dadosUsuario = await _servicoUsuarioAleatorio.ObterDadosUsuarioAleatorio();

                // Armazenar os usuários no banco de dados
                foreach (var resultado in dadosUsuario.Resultados)
                {
                    var nomeUsuario = $"{resultado.Name.First.ToLower()}.{resultado.Name.Last.ToLower()}"; // Concatena primeiro nome e sobrenome

                    var novoUsuario = new Usuario
                    {
                        NomeDeUsuario = nomeUsuario,
                        Senha = "", // Defina a senha conforme necessário
                        Email = resultado.Email,
                        PrimeiroNome = resultado.Name.First,
                        Sobrenome = resultado.Name.Last,
                    };

                    _contexto.Usuarios.Add(novoUsuario);
                }

                await _contexto.SaveChangesAsync();

                return Ok("Usuários gerados e armazenados com sucesso!");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, "Erro ao acessar a API Random User Generator: " + ex.Message);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Erro ao salvar usuários no banco de dados: " + ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu um erro inesperado: " + ex.Message);
            }
        }
    }
}
