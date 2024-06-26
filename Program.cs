using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using GerenciamentoUsarioAPI.Data;

namespace GerenciamentoUsuarioAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:7265");
                });
    }
}
