using TamaPokemon.Models;
using TamaPokemon.Service;
using TamaPokemon.View;

namespace TamaPokemon.Controller;

public class TamaPokemonController
{

    public TamaPokemonController(string name)
    {
        this.menu = new(name);
    }

    private TamaPokemonView menu { get; set; }

    public Pokemon AdoptedPokemon { get; set; }

    public async Task Start()
    {
        menu.StartMenu();

        string option = Console.ReadLine()!;
        switch (option)
        {
            case "1":
                menu.ChooseAdoptedPokemon();

                string pokemonName = await PokemonService.ShowPokemonList();
                Console.WriteLine("Pokemon escolhido : " + pokemonName);
                Pokemon pokemon = await PokemonService.GetUniquePokemon(pokemonName);
                await AdoptPokemonOptions(pokemon);

                break;
            case "2":
                Console.WriteLine("Ver seus mascotes");
                if(AdoptedPokemon != null)
                {
                    menu.PokemonDetails(AdoptedPokemon);
                    await Start();
                    break;
                }
                Console.WriteLine("Você ainda não tem nenhum pokemon adotado");
                await Start();
                break;
            case "3":
                Console.WriteLine("Sair");
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }

    public async Task AdoptPokemonOptions(Pokemon pokemon)
    {
        menu.AdoptPokemonOptions(pokemon);
        string option = Console.ReadLine()!;
        switch (option)
        {
            case "1":
                menu.PokemonDetails(pokemon);
                await AdoptPokemonOptions(pokemon);
                break;
            case "2":
                AdoptedPokemon = pokemon;
                menu.AdoptPokemon();
                break;
            case "3":
                await Start();
                break;
            default:
                Console.WriteLine("Opção invalida");
                break;
        }
    }
}
