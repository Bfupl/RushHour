

using RushHour.BaseService.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RushHour.Common.Interfaces
{
    public interface IService<T> where T : BaseModel
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter);

        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);

        void OnBeforeInsert();
        bool Insert(T entity);
        void OnAfterInsert();

        void OnBeforeUpdate();
        bool Update(T entity);
        void OnAfterUpdate();

        void OnBeforeDelete();
        bool Delete(T entity);
        void OnAfterDelete();

        bool IsValid(T entity);
    }
}
