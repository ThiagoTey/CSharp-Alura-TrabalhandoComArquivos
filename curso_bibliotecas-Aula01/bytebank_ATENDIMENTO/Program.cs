using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_GeradorChavePix;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();

Console.WriteLine(GeradorPix.getChavePix());

var listaChaves = GeradorPix.GetChavesPix(5);

foreach(var chave in listaChaves)
{
    Console.WriteLine(chave);
}