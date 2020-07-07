using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class Form1Repository
    {
      
        public DM_MON_HOC GetById(int id)
        {
            BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
            return context.DM_MON_HOC.FirstOrDefault(p => p.ID == id);
        }
    }
}
