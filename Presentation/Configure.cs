using Microsoft.EntityFrameworkCore;
using StudyMateIA.Infrastructure.Data;

namespace StudyMateIA.Presentation;

public class Configure
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Cargar configuración desde la carpeta AppSettings
        builder.Configuration
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Presentation/AppSettings/appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("Presentation/AppSettings/appsettings.Development.json", optional: true)
            .AddEnvironmentVariables();

        // Agregar controladores y servicios base
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Configurar DbContext con MySQL
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<StudyMateAiContext>(options =>
            options.UseMySql(connectionString, ServerVersion.Parse("8.0.34-mysql")));
    }

    public static void ConfigurePipeline(WebApplication app)
    {
        // Configurar pipeline HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}
