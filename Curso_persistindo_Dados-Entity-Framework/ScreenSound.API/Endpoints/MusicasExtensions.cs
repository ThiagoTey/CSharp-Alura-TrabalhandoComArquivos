using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class MusicasExtensions
{
    public static void AddEndPoinsMusicas(this WebApplication app)
    {
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

            if (musicaAAtualizar == null)
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

            if (musicaRecuperada == null)
            {
                return Results.NotFound();
            }

            dal.Remover(musicaRecuperada);

            return Results.NoContent();
        });
    }
}
