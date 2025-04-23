using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Endpoints;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de contexto banco de dados para utilizar na aplicação
builder.Services.AddDbContext<ScreenSoundContext>();
// Adiciona o serviço o objeto de DAL de artistas
builder.Services.AddTransient<DAL<Artista>>();
// Adiciona o serviço o objeto de DAL de Musicas
builder.Services.AddTransient<DAL<Musica>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndPoinsMusicas();
app.AddEndPointsArtistas();

app.Run();
