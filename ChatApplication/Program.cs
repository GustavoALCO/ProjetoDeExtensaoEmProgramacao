using ChatApplication.Aplication.Settings;
using ChatApplication.Dommain.Settings;
using ChatApplication.IOC;

var builder = WebApplication.CreateBuilder(args);

// Adicionando Configurações de Injeção de Dependência para o token jwt
builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));
// Adicionando Configuração do banco de dados
builder.Services.Configure<BDSettings>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();

builder.Services.AddSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
