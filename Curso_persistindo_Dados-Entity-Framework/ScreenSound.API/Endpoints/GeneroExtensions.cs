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

            var generosResponse = generos.Select(g => new GeneroResponse(g.Id, g.Nome, g.Descricao));

            return Results.Ok(generosResponse);
        });

        app.MapPost("/Genero", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequest generoRequest) =>
        {
            // Verifica se já existe um gênero com o mesmo nome
            var generoExistente = dal.RecuperarPor(g => g.Nome.ToLower().Equals(generoRequest.Nome.ToLower()));

            if (generoExistente is not null)
            {
                return Results.Conflict(new { mensagem = "Já existe um gênero com esse nome." });
            }

            var genero = new Genero() { Nome = generoRequest.Nome, Descricao = generoRequest.Descricao };

            dal.Adicionar(genero);

            return Results.Created($"/Genero/{genero.Id}", genero);
        });

        app.MapPut("/Genero", ([FromServices] DAL<Genero> dal, [FromBody] GeneroRequestEdit generoRequest) =>
        {
            var generoAAtulizar = dal.ProcurarPor(g => g.Id == generoRequest.Id);

            if (generoAAtulizar is null)
            {
                return Results.NotFound(new { mensagem = "Não há genero com este Id." });
            }

            generoAAtulizar.Descricao = generoRequest.Descricao;
            generoAAtulizar.Nome = generoRequest.Nome;

            dal.Atualizar(generoAAtulizar);

            return Results.Accepted($"/Genero/{generoAAtulizar.Id}", new
            {
                genero = generoAAtulizar,
                mensagem = "Gênero atualizado com sucesso."
            });
        });

        app.MapGet("/Genero/{nome}", ([FromServices] DAL<Genero> dal, string nome) => 
        {
            var generoExistente = dal.RecuperarPor(g => g.Nome.ToLower().Equals(nome.ToLower()));

            if (generoExistente is null)
            {
                return Results.NotFound(new { mensagem = "Não há genero com este Nome." });
            }

            return Results.Ok(generoExistente);
        });
    }
}
