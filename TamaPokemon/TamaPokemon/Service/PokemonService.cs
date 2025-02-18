using System.Text.Json;
using TamaPokemon.Models;

namespace TamaPokemon.Service;

public class PokemonService
{
    public static async Task<string> ShowPokemonList()
    {
        using HttpClient client = new HttpClient();

        try
        {
            string url = "https://pokeapi.co/api/v2/pokemon";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true, // Ignora Lestras maiusculas e minusculas
            };

            string jsonResponse = await response.Content.ReadAsStringAsync();

            PokemonResponse pokemonData = JsonSerializer.Deserialize<PokemonResponse>(jsonResponse, options);

            for (int i = 0; i < pokemonData.Results.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {pokemonData.Results[i].Name}");
            }

            Console.WriteLine("Escolha seu pokemon : ");
            int pokemonIndex = int.Parse(Console.ReadLine()!);
            return pokemonData.Results[pokemonIndex - 1].Name;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Aconteceu uma exeção : " + ex.Message);
            throw;
        }
    }

    public static async Task<Pokemon> GetUniquePokemon(string pokemonName)
    {
        string url = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";
        using HttpClient client = new HttpClient();

        try
        {
            HttpResponseMessage response = await client.GetAsync(url);

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true, // Ignora Lestras maiusculas e minusculas
            };

            string jsonResponse = await response.Content.ReadAsStringAsync();

            Pokemon pokemon = JsonSerializer.Deserialize<Pokemon>(jsonResponse, options);
            return pokemon;

        }
        catch (Exception)
        {

            throw;
        }

    }
}
