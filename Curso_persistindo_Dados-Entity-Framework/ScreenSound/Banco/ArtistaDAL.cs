using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

class ArtistaDAL
{
    public IEnumerable<Artista> Listar()
    {
        using var context = new ScreenSoundContext();

        return context.Artistas.ToList();
    }

    //public void Adicionar(Artista artista)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexao();
    //    connection.Open();

    //    string sql = "INSERT INTO Artistas (Nome,FotoPerfil, Bio) VALUES (@Nome, @PerfilPadrao, @Bio)";
    //    SqlCommand command = new SqlCommand(sql, connection);
        
    //    command.Parameters.AddWithValue("@Nome", artista.Nome);
    //    command.Parameters.AddWithValue("@PerfilPadrao", artista.FotoPerfil);
    //    command.Parameters.AddWithValue("@Bio", artista.Bio); 

    //    int retorno = command.ExecuteNonQuery();

    //    if (retorno == 0)
    //    {
    //        throw new Exception("Erro ao inserir artista");
    //    }
    //}

    //public void Remover(int id)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexao();
    //    connection.Open();
    //    string sql = "DELETE FROM Artistas WHERE Id = @Id";
    //    SqlCommand command = new SqlCommand(sql, connection);

    //    command.Parameters.AddWithValue("@Id", id);
    //    int retorno = command.ExecuteNonQuery();
    //    if (retorno == 0)
    //    {
    //        throw new Exception("Erro ao remover artista");
    //    }   
    //}

    //public void Atualizar(int id, Artista Artista)
    //{
    //    using var connection = new ScreenSoundContext().ObterConexao();
    //    connection.Open();
    //    string sql = "UPDATE Artistas SET Nome = @Nome, FotoPerfil = @FotoPerfil, Bio = @Bio WHERE Id = @Id";
    //    SqlCommand command = new SqlCommand(sql, connection);

    //    command.Parameters.AddWithValue("@Nome", Artista.Nome);
    //    command.Parameters.AddWithValue("@FotoPerfil", Artista.FotoPerfil);
    //    command.Parameters.AddWithValue("@Bio", Artista.Bio);
    //    command.Parameters.AddWithValue("@Id", id);

    //    int retorno = command.ExecuteNonQuery();
    //    if (retorno == 0)
    //    {
    //        throw new Exception("Erro ao atualizar artista");
    //    }
    //}
}
