using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuangIchTest
{
	public partial class _default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string query = "Select Ten from docgia";
            DbAcessProvider dbaProvider = new DbAcessProvider();
			DataTable dtData = dbaProvider.ExecuteCommandHome(query);

        }
	}
}