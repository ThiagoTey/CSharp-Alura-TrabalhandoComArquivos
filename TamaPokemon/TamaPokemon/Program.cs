
using System.Text.Json;
using TamaPokemon.Models;

async Task ShowPokemonList()
{
    using HttpClient client = new HttpClient();

    try
    {
        string url = "https://pokeapi.co/api/v2/pokemon";
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();

        PokemonResponse pokemonData = JsonSerializer.Deserialize<PokemonResponse>(jsonResponse);

        foreach (Pokemon pokemon in pokemonData.Results)
        {
            Console.WriteLine(pokemon.Name);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Aconteceu uma exeção : " + ex.Message);
        throw;
    }
}

await ShowPokemonList();