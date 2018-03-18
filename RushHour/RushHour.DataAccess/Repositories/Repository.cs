using RushHour.BaseService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RushHour.Common.Interfaces;
using System.Data.Entity;
using RushHour.DataAccess.Context;
using System.Linq.Expressions;

namespace RushHour.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private DbContext db;
        private DbSet<T> dbSet;

        public Repository(RushHourDbContext context)
        {
            db = context;
            dbSet = db.Set<T>();
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return dbSet.SingleOrDefault(filter);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return dbSet.Where(filter);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
