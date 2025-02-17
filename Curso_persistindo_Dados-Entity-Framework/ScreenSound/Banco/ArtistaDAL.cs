using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

internal class ArtistaDAL : DAL<Artista>
{

    public ArtistaDAL(ScreenSoundContext context) : base(context) { }

    public override Artista ProcurarPeloNome(string nome)
    {
        return context.Artistas.FirstOrDefault(a => a.Nome == nome);
    }
}
