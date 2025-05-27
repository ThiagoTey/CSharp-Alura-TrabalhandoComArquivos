using Microsoft.AspNetCore.Mvc;
using ScreenSound.API.Requests;
using ScreenSound.API.Response;
using ScreenSound.Banco;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.API.Endpoints;

public static class GeneroExtensions
{
    public static void AddEndPoinsGeneros(this WebApplication app)
    {
        app.MapGet("/Generos", ([FromServices] DAL<Genero> dal) =>
        {
            var generos = dal.Listar();

            var generosResponse = generos.Select(g => new GeneroResponse(g.Id, g.Nome));

            return Results.Ok(generosResponse);
        });

        app.MapPost("/Genero", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
        {
            // Verifica se já existe um gênero com o mesmo nome
            var generoExistente = dal.RecuperarPor(g => g.Nome.ToLower().Equals(generoRequest.Nome.ToLower()));

            if(generoExistente is not null)
            {
                return Results.Conflict(new { mensagem = "Já existe um gênero com esse nome." });
            }

            var genero = new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };

            dal.Adicionar(genero);

            return Results.Created($"/Genero/{genero.Id}", genero);
        });
    }
}
