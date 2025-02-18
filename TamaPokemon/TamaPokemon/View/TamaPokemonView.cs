using System.Xml.Linq;
using TamaPokemon.Models;
using TamaPokemon.Service;

namespace TamaPokemon.View;

public class TamaPokemonView
{
    public TamaPokemonView(string name)
    {
        PlayerName = name;
    }
    public string PlayerName { get; set; }

    public void ShowOptionTitle(string? title)
    {
        Console.WriteLine($"\n--------------- {title} ----------------");
    }

    public void StartMenu()
    {
        ShowOptionTitle("Menu");
        Console.WriteLine($"\nBem vindo {PlayerName}, Voce deseja :");
        Console.WriteLine("1 - Adotar um mascote virtual");
        Console.WriteLine("2 - Ver seus mascotes");
        Console.WriteLine("3 - Sair");
    }

    public void ChooseAdoptedPokemon()
    {
        ShowOptionTitle("Adotar um mascote");
        Console.WriteLine("Escolha um pokemon :");
    }

    public void AdoptPokemonOptions(Pokemon pokemon)
    {
        ShowOptionTitle("");
        Console.WriteLine($"{PlayerName} voce deseja");
        Console.WriteLine($"1 - Saber mais sobre o {pokemon.Name}");
        Console.WriteLine($"2 - Adotar {pokemon.Name}");
        Console.WriteLine($"3 - Voltar {pokemon.Name}");
    }

    public void PokemonDetails(Pokemon pokemon)
    {
        ShowOptionTitle("Detalhes Pokemon");
        pokemon.ShowDetails();
        Console.ReadKey();
    }

    public void AdoptPokemon()
    {
        Console.WriteLine("Adotar pokemon");
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
    }
}
