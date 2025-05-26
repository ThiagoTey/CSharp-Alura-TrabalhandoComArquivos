using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndPoinsMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas", ([FromServices] DAL<Musica> dal) =>
        {
            var Musicas = dal.Listar();

            var MusicasResponse = Musicas.Select(m =>
                new MusicaResponse(m.Id, m.Nome, m.Artista.Nome, m.Artista!.Id, m.AnoLancamento)
            );

            return Results.Ok(dal.Listar());
        });

        app.MapGet("/Musica/{nome}", ([FromServices] DAL<Musica> dal, string nome) =>
        {
            var musica = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));

            if (musica == null)
            {
                return Results.NotFound();
            }

            var musicaResponse = new MusicaResponse(
                musica.Id,
                musica.Nome,
                musica.Artista?.Nome ?? "Desconhecido",
                musica.Artista?.Id ?? 0,
                musica.AnoLancamento
            );

            return Results.Ok(musicaResponse);
        });

        app.MapPost("/Musicas", ([FromServices] DAL<Musica> dal,[FromServices] DAL<Artista> artDal, [FromBody] MusicaRequest musicaRequest) =>
        {
            var artista = artDal.RecuperarPor(a => a.Id == musicaRequest.ArtistaId);

            var musica = new Musica(musicaRequest.Nome);
            musica.Artista = artista;
            if(musicaRequest.AnoLancamento == 0)
            {
                musica.AnoLancamento = null;
            }
            else
            {
                musica.AnoLancamento = musicaRequest.AnoLancamento;
            }

            dal.Adicionar(musica);
            return Results.Ok();
        });

        app.MapPut("/Musicas", ([FromServices] DAL<Musica> dal, [FromBody] MusicaRequestEdit musicaRequest) =>
        {
            var musicaAAtualizar = dal.RecuperarPor(a => a.Id == musicaRequest.Id);

            if (musicaAAtualizar == null)
            {
                return Results.NotFound();
            }

            musicaAAtualizar.Nome = musicaRequest.Nome;
            musicaAAtualizar.AnoLancamento = musicaRequest.AnoLancamento;

            dal.Atualizar(musicaAAtualizar);

            return Results.Ok();
        });

        app.MapDelete("/Musica/{id}", ([FromServices] DAL<Musica> dal, int id) =>
        {
            var musicaRecuperada = dal.RecuperarPor(a => a.Id == id);

            if (musicaRecuperada == null)
            {
                return Results.NotFound();
            }

            dal.Remover(musicaRecuperada);

            return Results.NoContent();
        });
    }
}
