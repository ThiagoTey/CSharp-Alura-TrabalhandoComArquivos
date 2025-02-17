using ScreenSound.Modelos;

namespace ScreenSound.Banco;

class MusicasDAL
{
    private readonly ScreenSoundContext context;
    public MusicasDAL(ScreenSoundContext context)
    {
        this.context = context;
    }
    public IEnumerable<Musica> Listar()
    {
        return context.Musicas.ToList();
    }
    public void Adicionar(Musica musica)
    {
        context.Musicas.Add(musica);
        context.SaveChanges();
    }
    public void Remover(Musica musica)
    {
        context.Musicas.Remove(musica);
        context.SaveChanges();
    }
    public void Atualizar(Musica musica)
    {
        context.Musicas.Update(musica);
        context.SaveChanges();
    }
    public Musica ProcurarPeloNome(string nome)
    {
        return context.Musicas.FirstOrDefault(m => m.Nome == nome);
    }
}
