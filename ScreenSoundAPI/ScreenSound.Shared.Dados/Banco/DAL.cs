using System.Linq.Expressions;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

// Classe genérica de acesso a dados (Data Access Layer - DAL)
// Permite realizar operações comuns com qualquer entidade (classe) do banco de dados
public class DAL<T> where T : class
{
    // Instância do contexto do Entity Framework
    private readonly ScreenSoundContext context;

    // Construtor que recebe o contexto injetado por dependência
    public DAL(ScreenSoundContext context)
    {
        this.context = context;
    }

    // Lista todos os registros da tabela referente ao tipo T
    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }

    // Adiciona um novo objeto do tipo T ao banco e salva as alterações
    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges(); // Importante: salva imediatamente
    }

    // Remove um objeto do tipo T do banco e salva as alterações
    public void Remover(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }

    // Atualiza um objeto existente do tipo T no banco
    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }

    // Procura o primeiro item que atende à condição usando LINQ (em memória)
    // ⚠️ ATENÇÃO: como recebe um Func<T, bool>, a consulta pode ser feita em memória
    public T? ProcurarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    // Lista os objetos que satisfazem a condição informada (executada no banco via Expression)
    public IEnumerable<T> ListarPorCondicao(Expression<Func<T, bool>> condicao)
    {
        return context.Set<T>().Where(condicao).ToList(); // Executado via SQL
    }

    // Recupera o primeiro objeto que satisfaz uma condição
    // ⚠️ Como `Func<T, bool>` é um delegate, a consulta pode ser feita fora do banco (menos eficiente)
    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }
}
