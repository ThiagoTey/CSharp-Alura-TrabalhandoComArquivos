using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Atendimento;
using bytebank_GeradorChavePix;
using GeradorXml_Json;
Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
//new ByteBankAtendimento().AtendimentoCliente();

//Console.WriteLine(GeradorPix.getChavePix());

//var listaChaves = GeradorPix.GetChavesPix(5);

//foreach(var chave in listaChaves)
//{
//    Console.WriteLine(chave);
//}

ContaCorrente contaTeste = new(1234, "12345-123412");
ContaCorrente contaTeste1 = new(412, "34534-1asd");
ContaCorrente contaTeste2 = new(3145, "1245-5436");
ContaCorrente contaTeste3 = new(4567, "24567-5678");
ContaCorrente contaTeste4 = new(124123, "2458-2345");

List<ContaCorrente> listaDeContas = new() { contaTeste, contaTeste1, contaTeste2, contaTeste3, contaTeste4 };

//GeradorXml.GerarXml(contaTeste);

GeradorXml.GerarArquivosXml(listaDeContas);