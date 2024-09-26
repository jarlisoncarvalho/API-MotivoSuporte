using Microsoft.EntityFrameworkCore;
using MotivoSuporte.Data;
using MotivoSuporte.Repository.Interfaces;
using MotivoSuporte.Repository;

namespace MotivoSuporte
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração do banco de dados
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(connectionString)); // Altere para UseSqlServer

            // Registrar o repositório como um serviço no container de injeção de dependência
            builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            builder.Services.AddScoped<IMotivoSuporteRepository, MotivoSuporteRepository>();
            builder.Services.AddScoped<IMotivosRepository, MotivoRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure o pipeline HTTP
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
