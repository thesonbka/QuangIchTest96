using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.IRepository;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.IRepository
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public IUnitOfWork UnitOfWork { get; set; }
        private readonly IDbSet<T> dbSet;
        BO_GIAO_DUC_TEMPEntities dataContext = new BO_GIAO_DUC_TEMPEntities();

        protected EFRepository()
        {
            dbSet = dataContext.Set<T>();



        }

        public virtual IQueryable<T> All()
        {
            return dbSet.AsQueryable();
        }

        public IQueryable<T> Find(Func<T, bool> expression)
        {
            return dbSet.Where(expression).AsQueryable();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Save()
        {
            UnitOfWork.Save();
        }

        public List<ListItem> getListComboItemBase(string TableName, string DefaultItem, string DataTextField = "TEN", string DataValueField = "ID", string WhereClause = "", string OrderBy = "")
        {
            throw new NotImplementedException();
        }

        public List<ListItem> getListIntComboItemBase(string TableName, string DefaultItem, string DataTextField = "TEN", string DataValueField = "ID", string WhereClause = "", string OrderBy = "")
        {
            throw new NotImplementedException();
        }

    }

}

