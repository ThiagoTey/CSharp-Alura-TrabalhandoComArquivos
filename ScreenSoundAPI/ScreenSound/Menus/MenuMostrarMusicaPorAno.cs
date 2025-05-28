using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus;

class MenuMostrarMusicaPorAno : Menu
{
    public override void Executar(DAL<Artista> artistaDAL)
    {
        base.Executar(artistaDAL);
        ExibirTituloDaOpcao("Exibir Musica Por Data Lançamento");

        Console.Write("Digite o ano de lancamento que voce deseja buscar : ");
        int anoLancamento = int.Parse(Console.ReadLine()!);
        using var context = ContextHelper.CriarContexto();
        DAL<Musica> musicaDal = new DAL<Musica>(context);
        var musicas = musicaDal.ListarPorCondicao(a => a.AnoLancamento == anoLancamento);

        if (musicas.Any())
        {
            foreach (var musica in musicas)
            {
                musica.ExibirFichaTecnica();
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            return;
        }

        Console.WriteLine($"Não há musicas para o ano {anoLancamento}");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
