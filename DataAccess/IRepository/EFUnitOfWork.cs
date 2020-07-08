using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace DataAccess.IRepository
{
	public class EFUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EFUnitOfWork()
		{
			Context = new BO_GIAO_DUC_TEMPEntities();
		}

		public void Save()
		{
			Context.SaveChanges();
		}

		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		
		public string ConnectionString
		{
			get { return Context.Database.Connection.ConnectionString; }
			set { Context.Database.Connection.ConnectionString = value; }
		}
	}
}
