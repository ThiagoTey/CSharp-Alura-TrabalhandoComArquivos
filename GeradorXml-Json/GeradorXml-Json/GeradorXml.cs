using System.Xml.Serialization;

namespace GeradorXml_Json;

public class GeradorXml
{
    public static void GerarXml<T>(T objeto) where T : class
    {
        string caminhoArquivo = "ArquivoXml.xml";

        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (var fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                xmlSerializer.Serialize(sw, objeto);
            }

            Console.WriteLine("Arquivo Gerado com sucesso!");
        } catch (Exception ex)
        {
            Console.WriteLine($"Erro ao exportar Xml: {ex.Message}");
        }
    }

    public static void GerarArquivosXml<T>(List<T> listaObjeto) where T : class
    {
        string caminhoArquivo = "ArquivoClasseXml.xml";

        try
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            using (var fs = new FileStream(caminhoArquivo, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                xmlSerializer.Serialize(sw, listaObjeto);
            }

            Console.WriteLine("Arquivo Gerado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao exportar Xml: {ex.Message}");
        }
    }

}
