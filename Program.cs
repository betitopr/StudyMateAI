using StudyMateIA.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios
Configure.ConfigureServices(builder);

var app = builder.Build();

// Configurar pipeline
Configure.ConfigurePipeline(app);

app.Run();
