﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Music.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(int id, T entity);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> All();
        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
