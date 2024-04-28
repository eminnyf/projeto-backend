using GerenciamentoUsarioAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;

namespace GerenciamentoUsuarioAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração do Entity Framework Core
            services.AddDbContext<GerenciamentoBD>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("GerenciamentoBD")));

            // Verificação da conexão com o banco de dados
            VerificarConexaoBancoDeDados(Configuration);

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Aqui você pode adicionar middleware para lidar com exceções de produção
                // app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Método para verificar a conexão com o banco de dados
        private void VerificarConexaoBancoDeDados(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GerenciamentoBD");

            try
            {
                using var connection = new NpgsqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Conexão bem-sucedida com o banco de dados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
