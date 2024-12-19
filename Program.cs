using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Habilita o CORS para todas as origens
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()   // Permite qualquer origem
              .AllowAnyHeader()   // Permite qualquer cabe�alho
              .AllowAnyMethod());  // Permite qualquer m�todo
});
// Configurar o caminho para arquivos est�ticos (Frontend)
var frontendPath = Path.Combine(Directory.GetCurrentDirectory(), "dist");


var app = builder.Build();

// Ativa o CORS com a pol�tica "AllowAll"
app.UseCors("AllowAll");
// Servir arquivos est�ticos do diret�rio Frontend
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(frontendPath),
    RequestPath = ""
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
// Mapear rotas para o Backend


app.UseRouting();
app.MapControllers();

app.Run();
