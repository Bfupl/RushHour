using RushHour.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.Data.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private readonly RushHourDbContext context;
        private readonly IDictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UnitOfWork()
        {
            this.context = new RushHourDbContext();
        }

        public Repository<T> GetRepository<T>() where T : BaseEntity
        {
            Type typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                Type typeOfRepository = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeOfRepository, this.context));
            }

            return (Repository<T>)this.repositories[typeOfModel];
        }

        public void Commit()
        {
            this.context.SaveChanges();

        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }
    }
}
