using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlCommandQuangIch
{
    public class Form4Command
    {
        public static string deleteHocSinhId = @"delete fromdbo.HOC_SINH WHERE ID IN ({0})";
    }
}
