using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.API.Endpoints;

public static class ArtistasExtensions
{
    public static void AddEndPointsArtistas(this WebApplication app)
    {
        app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
        {
            var artistas = dal.Listar();

            var artistasResponse = artistas.Select(a =>
                new ArtistaResponse(a.Id, a.Nome, a.Bio, a.FotoPerfil)
            );
            return Results.Ok(artistasResponse);
        });

        app.MapGet("/Artista/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
        {
            var artista = dal.RecuperarPor(a => a.Nome.ToLower().Equals(nome.ToLower()));
            if (artista is null)
            {
                return Results.NotFound();
            }

            var artistaResponse = new ArtistaResponse(
                artista.Id,
                artista.Nome,
                artista.Bio,
                artista.FotoPerfil
            );

            return Results.Ok(artistaResponse);
        });

        app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {

            var artista = new Artista(artistaRequest.Nome, artistaRequest.Bio);

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

        app.MapPut("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] ArtistaRequestEdit artistaRequestEdit) =>
        {
            var artistaAAtualizar = dal.RecuperarPor(a => a.Id == artistaRequestEdit.Id);

            if (artistaAAtualizar == null)
            {
                return Results.NotFound();
            }

            artistaAAtualizar.Nome = artistaRequestEdit.Nome;
            artistaAAtualizar.Bio = artistaRequestEdit.Bio;

            dal.Atualizar(artistaAAtualizar);

            return Results.Ok();
        });
    }
}
