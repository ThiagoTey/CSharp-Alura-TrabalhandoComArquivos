using System.Text.Json.Serialization;

namespace TamaPokemon.Models;

public class Pokemon
{
    public string Name { get; set; }
}

public class PokemonResponse
{
    public List<Pokemon> Results { get; set; } = new();
    public string Next { get; set; } = string.Empty;
    public string Previous { get; set; } = string.Empty;
}