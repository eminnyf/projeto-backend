using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GerenciamentoUsuarioAPI.Models;

namespace GerenciamentoUsuarioAPI.Services
{
    public class ServicoUsuarioAleatorio
    {
        private readonly HttpClient _httpClient;

         public ServicoUsuarioAleatorio(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient)); // Verifique se o HttpClient é nulo
        }

        public async Task<DadosUsuarioResponse> ObterDadosUsuarioAleatorio()
        {
            try
            {
                var resposta = await _httpClient.GetAsync("https://randomuser.me/api/");
                resposta.EnsureSuccessStatusCode();
                var conteudo = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<DadosUsuarioResponse>(conteudo);
            }
             catch (HttpRequestException ex) // Use HttpRequestException para capturar exceções de HTTP

            {
                throw new ApplicationException("Erro ao buscar dados da API Random User Generator", ex);
            }
        }
    }

    // Classe para representar a resposta da API Random User Generator
    public class DadosUsuarioResponse
    {
        public List<ResultadoUsuario> Results { get; set; }
        public Info Info { get; set; }
        public IEnumerable<ResultadoUsuario> Resultados { get; set; } // Corrigindo o tipo de dados
    }

    // Classe para representar um usuário
    public class ResultadoUsuario
    {
        public Name Name { get; set; }
        public string Email { get; set; }

        // Adicione outras propriedades conforme necessário
    }

    // Classe para representar o nome do usuário
    public class Name
    {
        // Propriedades
        public string First { get; set; }
        public string Last { get; set; }
    }

    // Classe para representar informações adicionais
    public class Info
    {
        public string Seed { get; set; }
        public int Results { get; set; }
        public int Page { get; set; }
        public string Version { get; set; }
    }
}
