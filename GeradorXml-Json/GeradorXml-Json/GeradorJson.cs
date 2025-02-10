using System.Text.Json;

namespace GeradorXml_Json;

public class GeradorJson
{
    public static void GerarJson<T>(T objeto) where T : class
    {
        string caminho = "ArquivoJson.json";

        try
        {
            using (var fs = new FileStream(caminho, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            using (var jsonWriter = new Utf8JsonWriter(fs, new JsonWriterOptions { Indented = true }))
            {
                JsonSerializer.Serialize(jsonWriter, objeto);
            }
            Console.WriteLine("Arquivo Criado Com sucesso!");
        }
        catch (Exception ex)
        {

            Console.WriteLine("Erro ao criar arquivo json" + ex.Message);
        }
    }

}
