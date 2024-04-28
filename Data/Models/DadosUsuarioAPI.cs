namespace GerenciamentoUsuarioAPI.Models
{
    public class UsuarioAleatorio
    {
        // Propriedades
        public string Usuario {get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        // Construtor
        public UsuarioAleatorio()
        {
            PrimeiroNome = ""; // Inicializando PrimeiroNome com uma string vazia
            Sobrenome = ""; // Inicializando Sobrenome com uma string vazia
            Email = ""; // Inicializando Email com uma string vazia
        }

        // Adicione outras propriedades conforme necessário, como data de nascimento, gênero, etc.
    }
}
