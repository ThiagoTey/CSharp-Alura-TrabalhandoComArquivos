using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
// Adiciona o serviço de contexto banco de dados para utilizar na aplicação
builder.Services.AddDbContext<ScreenSoundContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
           .UseLazyLoadingProxies());

// Adiciona o serviço o objeto de DAL de artistas
builder.Services.AddTransient<DAL<Artista>>();
// Adiciona o serviço o objeto de DAL de Musicas
builder.Services.AddTransient<DAL<Musica>>();
// Adiciona o serviço o objeto de DAL de Genero
builder.Services.AddTransient<DAL<Genero>>();

//Adiciona o serviço do Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Funções para adicionar os endPoints com suas funções
app.AddEndPointsArtistas();
app.AddEndPoinsMusicas();
app.AddEndPoinsGeneros();

// https://localhost:7239/Swagger/index.html para ver documentação de todos os endPoints com o Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.Run();