namespace bytebank_GeradorChavePix;

/// <summary>
/// Classe que gera chaves Pix utilizando o formato Guid
/// </summary>
public static class GeradorPix
{
    /// <summary>
    /// Metodo que retorna uma chave aleatória de Pix.
    /// </summary>
    /// <returns>Retorna uma chave Pix no formato String</returns>
    public static string getChavePix()
    {
        return Guid.NewGuid().ToString();
    }

    /// <summary>
    /// Metodo que retorna uma lista de aleatória chaves pix.
    /// </summary>
    /// <param name="numeroChaves">Quantidade de chaves a serem retornadas.</param>
    /// <returns>Lista de string</returns>
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
