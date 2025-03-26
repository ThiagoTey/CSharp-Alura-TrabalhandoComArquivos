using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/Artistas", () =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artista/{nome}", (string nome) =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    var artista =  dal.RecuperarPor( a => a.Nome.ToLower().Equals(nome.ToLower()));
    if(artista is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(artista);
});

app.MapPost("/Artistas", ([FromBody] Artista artista) =>
{
    var dal = new DAL<Artista>(new ScreenSoundContext());
    if (string.IsNullOrEmpty(artista.FotoPerfil))
    {
        artista.FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    dal.Adicionar(artista);
    return Results.Ok();
});

app.Run();
