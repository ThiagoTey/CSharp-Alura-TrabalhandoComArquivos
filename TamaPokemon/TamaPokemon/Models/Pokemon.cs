using System.Text.Json.Serialization;

namespace TamaPokemon.Models;

public class Pokemon
{
    public string Name { get; set; }
    public int Id { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public List<AbilityWrapper> Abilities { get; set; } = new();

    public void ShowDetails()
    {
        Console.WriteLine($"{Name} Peso : {Weight} - Altura {Height} - ID {Id}");

        foreach (AbilityWrapper ability in Abilities)
        {
            Console.WriteLine($"Habilidade : {ability.Ability.Name}");
        }
    }
}

public class PokemonResponse
{
    public List<Pokemon> Results { get; set; } = new();
    public string Next { get; set; } = string.Empty;
    public string Previous { get; set; } = string.Empty;
}

public class AbilityWrapper
{
    public Ability Ability { get; set; }
    [JsonPropertyName("is_hidden")]
    public Boolean IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string Url { get; set; }
}