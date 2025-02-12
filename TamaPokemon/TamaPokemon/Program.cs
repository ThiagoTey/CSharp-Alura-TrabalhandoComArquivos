
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

        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true, // Ignora Lestras maiusculas e minusculas
        };

        string jsonResponse = await response.Content.ReadAsStringAsync();

        PokemonResponse pokemonData = JsonSerializer.Deserialize<PokemonResponse>(jsonResponse, options);

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

async Task ShowUniquePokemon(string pokemonName)
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

        Console.WriteLine($"{pokemon.Name} Peso : {pokemon.Weight} - Altura {pokemon.Height} - ID {pokemon.Id}");

        foreach (AbilityWrapper ability in pokemon.Abilities)
        {
            Console.WriteLine($"Habilidade : {ability.Ability.Name}");
        }
    }
    catch (Exception)
    {

        throw;
    }

}

await ShowUniquePokemon("ditto");