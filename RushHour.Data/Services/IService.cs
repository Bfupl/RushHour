using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RushHour.Data.Entities;

namespace RushHour.Data.Services
{
    public interface IService<T> where T : BaseEntity
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
