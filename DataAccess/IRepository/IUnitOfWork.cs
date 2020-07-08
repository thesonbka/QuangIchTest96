using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace DataAccess.IRepository
{
	public interface IUnitOfWork
	{
		DbContext Context { get; set; }
		void Save();
		bool LazyLoadingEnabled { get; set; }
		
		string ConnectionString { get; set; }
	}
}
