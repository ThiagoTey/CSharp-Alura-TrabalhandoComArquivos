
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using ScreenSound.Banco;

namespace ScreenSound.Shared.Dados.Banco;

// Essa classe permite que o EF Core crie o contexto em tempo de design (sem rodar o app)
public class ScreenSoundContextFactory : IDesignTimeDbContextFactory<ScreenSoundContext>
{
    // Método chamado pelo EF Core durante comandos como Add-Migration e Update-Database
    public ScreenSoundContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ScreenSoundContext>();

        // String de conexão com o banco de dados (use a mesma do projeto original)
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Configura o contexto para usar SQL Server e proxies para Lazy Loading
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies();

        // Retorna uma nova instância do contexto configurado
        return new ScreenSoundContext(optionsBuilder.Options);
    }
}