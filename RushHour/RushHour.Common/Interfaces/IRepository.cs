

using RushHour.BaseService.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RushHour.Common.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
