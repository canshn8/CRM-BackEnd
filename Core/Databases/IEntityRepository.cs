﻿using Core.Entities;
using Core.Entities.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;

namespace Core.DataAccess.Databases
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        DeleteResult Delete(string id);
        ReplaceOneResult Update(T entity);
        DeleteResult DeleteMany(Expression<Func<T, bool>> filter = null);
        List<T> GetAllWithPage(int page, int limit);
    }
}
