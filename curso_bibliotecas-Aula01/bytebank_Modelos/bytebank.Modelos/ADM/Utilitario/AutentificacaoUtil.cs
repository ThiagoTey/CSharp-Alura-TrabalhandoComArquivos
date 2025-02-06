namespace bytebank_Modelos.bytebank.Modelos.ADM.Utilitario;

internal class AutentificacaoUtil
{
    public bool ValidarSenha(string senhaVerdadeira, string senhaTentativa)
    {
        return senhaTentativa.Equals(senhaVerdadeira);
    }
}
