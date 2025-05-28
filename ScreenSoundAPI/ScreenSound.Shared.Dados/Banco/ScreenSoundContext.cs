using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using ScreenSound.Shared.Modelos.Modelos;

namespace ScreenSound.Banco;
// Classe que representa o contexto do banco de dados para o Entity Framework
public class ScreenSoundContext : DbContext
{
    // DbSet representa tabelas no banco de dados
    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
    public DbSet<Genero> Generos { get; set; }

    // Construtor obrigatório para receber as opções de configuração (usado pela factory)
    public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options)
    {
    }

    // Método usado para configurar o modelo de relacionamento entre entidades
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurando relacionamento muitos-para-muitos entre Musica e Genero
        modelBuilder.Entity<Musica>()
            .HasMany(m => m.Generos)
            .WithMany(g => g.Musicas);
    }
}