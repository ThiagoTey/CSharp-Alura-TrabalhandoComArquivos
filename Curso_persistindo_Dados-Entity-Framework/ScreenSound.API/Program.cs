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
// Adiciona o serviço o objeto de DAL de Musicas
builder.Services.AddTransient<DAL<Musica>>();

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

app.MapDelete("/Artista/{id}", ([FromServices] DAL<Artista> dal, int id) =>
{
    var artista = dal.RecuperarPor(a => a.Id == id);
    if (artista == null)
    {
        return Results.NotFound();
    }
    dal.Remover(artista);
    return Results.NoContent();
});

app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artista.Id);

    if (artistaAAtualizar == null)
    {
        return Results.NotFound();
    }

    artistaAAtualizar.Nome = artista.Nome;
    artistaAAtualizar.FotoPerfil = artista.FotoPerfil;
    artistaAAtualizar.Bio = artista.Bio;

    dal.Atualizar(artistaAAtualizar);

    return Results.Ok();
});

app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Musica/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
{
    var musica = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));

    if (musica == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(musica);
});

app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    dal.Adicionar(musica);
    return Results.Ok();
});

app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] Musica musica) =>
{
    var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musica.Id);

    if(musicaAAtualizar == null)
    {
        return Results.NotFound();
    }

    musicaAAtualizar.Artista = musica.Artista;
    musicaAAtualizar.Nome = musica.Nome;
    musicaAAtualizar.AnoLancamento = musica.AnoLancamento;

    dal.Atualizar(musicaAAtualizar);

    return Results.Ok();
});

app.MapDelete("/Musica/{id}", ([FromServices] DAL<Musica> dal, int id) =>
{
    var musicaRecuperada = dal.RecuperarPor(a => a.Id == id);

    if(musicaRecuperada == null)
    {
        return Results.NotFound();
    }

    dal.Remover(musicaRecuperada);

    return Results.NoContent();
});

app.Run();
