using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
	public interface IRepository<T>
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Find(Func<T, bool> expression);
		void Add(T entity);
		void Delete(T entity);
		void Save();
		List<ListItem> getListComboItemBase(string DefaultItem, string DataTextField = "TEN", string DataValueField = "ID", string TableName = "", string WhereClause = "", string OrderBy = "");
		List<ListItem> getListIntComboItemBase(string DefaultItem, string DataTextField = "TEN", string DataValueField = "ID", string TableName = "", string WhereClause = "", string OrderBy = "");
	}
}
