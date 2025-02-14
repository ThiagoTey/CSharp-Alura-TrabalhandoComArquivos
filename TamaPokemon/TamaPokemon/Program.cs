
using System.Text.Json;
using TamaPokemon.Menu;
using TamaPokemon.Models;

string name;

void Start()
{
    Console.WriteLine(@" _____                     ____       _                              
|_   _|_ _ _ __ ___   __ _|  _ \ ___ | | _____ _ __ ___   ___  _ __  
  | |/ _` | '_ ` _ \ / _` | |_) / _ \| |/ / _ \ '_ ` _ \ / _ \| '_ \ 
  | | (_| | | | | | | (_| |  __/ (_) |   <  __/ | | | | | (_) | | | |
  |_|\__,_|_| |_| |_|\__,_|_|   \___/|_|\_\___|_| |_| |_|\___/|_| |_|");

    Console.WriteLine("Qual é o seu nome?");
    name = Console.ReadLine()!;
}

Start();

Menu menu = new(name);
await menu.Start();