namespace bytebank_GeradorChavePix;

public static class GeradorPix
{
    public static string getChavePix()
    {
        return Guid.NewGuid().ToString();
    }

    public static List<string> GetChavesPix(int numeroChaves)
    {
        if(numeroChaves <= 0)
        {
            return null;
        }

        var chaves = new List<string>();

        for(int i = 0; i < numeroChaves; i++)
        {
            chaves.Add(Guid.NewGuid().ToString());
        }

        return chaves;
    }
}
