using Microsoft.EntityFrameworkCore;
using ScreenSound.Banco;

// Helper Utilizado Para ajuda na criação do contexto do banco de dados
public static class ContextHelper
{
    public static ScreenSoundContext CriarContexto()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ScreenSoundContext>();
        var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        optionsBuilder.UseSqlServer(connectionString).UseLazyLoadingProxies();

        return new ScreenSoundContext(optionsBuilder.Options);
    }
}
