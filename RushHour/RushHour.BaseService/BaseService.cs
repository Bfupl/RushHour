using RushHour.BaseService.Domain;
using RushHour.Common.Interfaces;
using RushHour.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.BaseService
{
    public class BaseService<T> : IService<T> where T : BaseModel
    {
        private UnitOfWork unitOfWork;
        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public T Get(int id)
        {
            return unitOfWork.GetRepository<T>().Get(id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return unitOfWork.GetRepository<T>().Get(filter);
        }

        public IEnumerable<T> GetAll()
        {
            return unitOfWork.GetRepository<T>().GetAll().ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return unitOfWork.GetRepository<T>().GetAll(filter).ToList();
        }

        public bool Insert(T entity)
        {
            if (!IsValid(entity))
            {
                return false;
            }

            try
            {
                OnBeforeInsert();
                unitOfWork.GetRepository<T>().Insert(entity);
                unitOfWork.Commit();
                OnAfterInsert();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public virtual bool IsValid(T entity)
        {
            return true;
        }

        public virtual void OnAfterDelete()
        {
        }

        public virtual void OnAfterInsert()
        {
        }

        public virtual void OnAfterUpdate()
        {
        }

        public void OnBeforeDelete()
        {
        }

        public void OnBeforeInsert()
        {
        }

        public void OnBeforeUpdate()
        {

        }

        public bool Update(T entity)
        {
            if (!IsValid(entity))
            {
                return false;
            }
            try
            {
                OnBeforeUpdate();
                unitOfWork.GetRepository<T>().Update(entity);
                unitOfWork.Commit();
                OnAfterUpdate();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(T entity)
        {
            if (!IsValid(entity))
            {
                return false;
            }
            try
            {
                OnBeforeDelete();
                unitOfWork.GetRepository<T>().Delete(entity);
                unitOfWork.Commit();
                OnAfterDelete();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

    }
}
