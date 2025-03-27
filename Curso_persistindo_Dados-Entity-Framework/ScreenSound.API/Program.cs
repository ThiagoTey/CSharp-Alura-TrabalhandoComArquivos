using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o serviço de contexto banco de dados para utilizar na aplicação
builder.Services.AddDbContext<ScreenSoundContext>();
// Adiciona o serviço o objeto de DAL de artistas
builder.Services.AddTransient<DAL<Artista>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artista/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
{
    var artista =  dal.RecuperarPor( a => a.Nome.ToLower().Equals(nome.ToLower()));
    if(artista is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(artista);
});

app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    if (string.IsNullOrEmpty(artista.FotoPerfil))
    {
        artista.FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    dal.Adicionar(artista);
    return Results.Ok();
});

app.MapDelete("Artistas/{id}", ([FromServices] DAL<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista == null)
    {
        return Results.NotFound();
    }
    dal.Remover(artista);
    return Results.NoContent();
});

app.Run();
