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
    public Pokemon AdoptedPokemon { get; set; }

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
                await ChooseAdoptedPokemon();
                break;
            case "2":
                Console.WriteLine("Ver seus mascotes");
                AdoptedPokemonDetails();
                break;
            case "3":
                Console.WriteLine("Sair");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    public async Task ChooseAdoptedPokemon()
    {
        ShowOptionTitle("Adotar um mascote");
        Console.WriteLine("Escolha um pokemon : ");
        string pokemonName = await ShowPokemonList();
        
        Console.WriteLine("Pokemon escolhido : " + pokemonName);
        Pokemon pokemon = await GetUniquePokemon(pokemonName);
        await AdoptPokemonOptions(pokemon);
    }

    public async Task AdoptPokemonOptions(Pokemon pokemon)
    {
        ShowOptionTitle("");
        Console.WriteLine($"{Name} voce deseja");
        Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
        Console.WriteLine($"2 - Adotar {pokemon.Name}");
        Console.WriteLine($"3 - Voltar {pokemon.Name}");

        string option = Console.ReadLine()!;
        switch (option)
        {
            case "1":
                ShowOptionTitle("");
                pokemon.ShowDetails();
                Console.ReadKey();
                await AdoptPokemonOptions(pokemon);
                break;
            case "2":
                Console.WriteLine("Adotar pokemon");
                AdoptedPokemon = pokemon;
                Console.WriteLine("Pokemon adotado com sucesso, o ovo esta chovando : ");
                Console.WriteLine(@"                                                                                                                    
                                ████████                                  
                              ██        ██                                
                            ██▒▒▒▒        ██                              
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                          ██▒▒▒▒▒▒      ▒▒▒▒██                            
                        ██  ▒▒▒▒        ▒▒▒▒▒▒██                          
                        ██                ▒▒▒▒██                          
                      ██▒▒      ▒▒▒▒▒▒          ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒        ██                        
                      ██      ▒▒▒▒▒▒▒▒▒▒    ▒▒▒▒██                        
                      ██▒▒▒▒  ▒▒▒▒▒▒▒▒▒▒  ▒▒▒▒▒▒██                        
                        ██▒▒▒▒  ▒▒▒▒▒▒    ▒▒▒▒██                          
                        ██▒▒▒▒            ▒▒▒▒██                          
                          ██▒▒              ██                            
                            ████        ████                              
                                ████████                                                                                                                                                                        
");
                break;
            case "3":
                await Start();
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    public void AdoptedPokemonDetails()
    {
        ShowOptionTitle("Mascote adotado");
        if (AdoptedPokemon != null)
        {
            AdoptedPokemon.ShowDetails();
        }
        else
        {
            Console.WriteLine("Voce ainda não adotou um pokemon");
        }
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

    public async Task<Pokemon> GetUniquePokemon(string pokemonName)
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
