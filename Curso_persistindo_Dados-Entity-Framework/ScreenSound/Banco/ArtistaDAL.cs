using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        var lista = new List<Artista>();
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "SELECT * FROM Artistas";
        SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string nomeArtista = Convert.ToString(dataReader["Nome"]);
            string bioArtista = Convert.ToString(dataReader["Bio"]);
            int idArtista = Convert.ToInt32(dataReader["Id"]);
            Artista artista = new(nomeArtista, bioArtista) { Id = idArtista };

            lista.Add(artista);
        }

        return lista;
    }

    public void Adicionar(Artista artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();

        string sql = "INSERT INTO Artistas (Nome,FotoPerfil, Bio) VALUES (@Nome, @PerfilPadrao, @Bio)";
        SqlCommand command = new SqlCommand(sql, connection);
        
        command.Parameters.AddWithValue("@Nome", artista.Nome);
        command.Parameters.AddWithValue("@PerfilPadrao", artista.FotoPerfil);
        command.Parameters.AddWithValue("@Bio", artista.Bio); 

        int retorno = command.ExecuteNonQuery();

        if (retorno == 0)
        {
            throw new Exception("Erro ao inserir artista");
        }
    }

    public void Remover(int id)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "DELETE FROM Artistas WHERE Id = @Id";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Id", id);
        int retorno = command.ExecuteNonQuery();
        if (retorno == 0)
        {
            throw new Exception("Erro ao remover artista");
        }   
    }

    public void Atualizar(int id, Artista Artista)
    {
        using var connection = new Connection().ObterConexao();
        connection.Open();
        string sql = "UPDATE Artistas SET Nome = @Nome, FotoPerfil = @FotoPerfil, Bio = @Bio WHERE Id = @Id";
        SqlCommand command = new SqlCommand(sql, connection);

        command.Parameters.AddWithValue("@Nome", Artista.Nome);
        command.Parameters.AddWithValue("@FotoPerfil", Artista.FotoPerfil);
        command.Parameters.AddWithValue("@Bio", Artista.Bio);
        command.Parameters.AddWithValue("@Id", id);

        int retorno = command.ExecuteNonQuery();
        if (retorno == 0)
        {
            throw new Exception("Erro ao atualizar artista");
        }
    }
}
