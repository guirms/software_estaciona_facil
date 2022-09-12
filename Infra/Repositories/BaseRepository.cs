﻿using Infra.Context;
using Infra.Interfaces;

namespace Infra.Repositories;

public class BaseRepository<T>: IBaseRepository<T> where T : class
{
    protected readonly ConfigContext Contexto;

    public BaseRepository(ConfigContext contexto)
    {
        Contexto = contexto;
    }

    public void Add(T objeto)
    {
        Contexto.Set<T>().Add(objeto);
        Contexto.SaveChanges();
    }

    public void Update(T objeto)
    {
        Contexto.Set<T>().Update(objeto);
        Contexto.SaveChanges();
    }

    public T? GetById(int id)
    {
        return Contexto.Set<T>().Find(id);
    }

    public IList<T> GetAll()
    {
        return Contexto.Set<T>().ToList();
    }

    public void Delete(int id)
    {
        var objeto = GetById(id);
        if (objeto != null) Contexto.Set<T>().Remove(objeto);
        Contexto.SaveChanges();        }
        
    public void Dispose()
    {
        Contexto.Dispose();
    }
}