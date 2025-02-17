using ScreenSound.Modelos;

namespace ScreenSound.Banco;

class MusicasDAL : DAL<Musica>
{
    public MusicasDAL(ScreenSoundContext context) : base(context) { }

    public override Musica ProcurarPeloNome(string nome)
    {
        return context.Musicas.FirstOrDefault(m => m.Nome == nome);
    }
}
