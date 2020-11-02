using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Towsif_DAL.Base;

namespace Towsif_BLL.BaseManager
{
    public class BaseManager<T> where T : class
    {
        protected Repository<T> Repository;


        public BaseManager(Repository<T> repository)
        {
            Repository = repository;
        }

        public virtual List<T> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return Repository.GetById(id);
        }

        public virtual bool Save(T entity)
        {
            return Repository.Save(entity);
        }

        public virtual bool Update(T entity)
        {
            return Repository.Update(entity);
        }
        public bool Remove(T entity)
        {
            return Repository.Remove(entity);
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            return Repository.Get(predicate);
        }
    }
}
