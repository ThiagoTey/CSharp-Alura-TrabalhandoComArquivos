using System.Text.Json;
using System.Threading.Tasks;
using TamaPokemon.Models;

namespace TamaPokemon.Menu;

public class Menu
{
    public Menu(string name)
    {
        Name = name;
    }
    public string Name { get; set; }

    public static void ShowOptionTitle(string? title)
    {
        Console.WriteLine($"\n--------------- {title} ----------------");
    }

    public async Task Start()
    {
        ShowOptionTitle("Menu");
        Console.WriteLine($"\nBem vindo {Name}, Voce deseja :");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
        string option = Console.ReadLine()!;
        switch (option)
        {
            case "1":
                await AdoptPokemon();
                break;
            case "2":
                Console.WriteLine("Ver seus mascotes");
                break;
            case "3":
                Console.WriteLine("Sair");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    public async Task AdoptPokemon()
    {
        ShowOptionTitle("Adotar um mascote");
        Console.WriteLine("Escolha um pokemon : ");
        string pokemonName = await ShowPokemonList();
        
        Console.WriteLine("Pokemon escolhido : " + pokemonName);
    }

    public async Task<string> ShowPokemonList()
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

            for(int i = 0; i < pokemonData.Results.Count; i++)
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

    public async Task ShowUniquePokemon(string pokemonName)
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

}
