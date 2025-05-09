﻿using System.Linq.Expressions;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

public class DAL<T> where T : class
{
    private readonly ScreenSoundContext context;
    public DAL(ScreenSoundContext context)
    {
        this.context = context;
    }
    public IEnumerable<T> Listar()
    {
        return context.Set<T>().ToList();
    }
    public void Adicionar(T objeto)
    {
        context.Set<T>().Add(objeto);
        context.SaveChanges();
    }
    public void Remover(T objeto)
    {
        context.Set<T>().Remove(objeto);
        context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        context.Set<T>().Update(objeto);
        context.SaveChanges();
    }
    public T? ProcurarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPorCondicao(Expression<Func<T, bool>> condicao)
    {
        return context.Set<T>().Where(condicao).ToList();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return context.Set<T>().FirstOrDefault(condicao);
    }

}
