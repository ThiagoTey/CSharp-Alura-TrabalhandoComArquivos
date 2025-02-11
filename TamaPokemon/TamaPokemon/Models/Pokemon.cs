using System.Text.Json.Serialization;

namespace TamaPokemon.Models;

public class Pokemon
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}

public class PokemonResponse
{
    [JsonPropertyName("results")]
    public List<Pokemon> Results { get; set; } = new();
}