using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.SqlCommandQuangIch;
using DataAccess;
namespace QuangIchTest.DanhMuc.Form1
{
    public partial class index : System.Web.UI.Page
    {
        DbAcessProvider dbaProvider = new DbAcessProvider();
        string queryCombobox = Form1Command.QueryGetComBoboxCapHoc;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCombobox();           
        }
        public void LoadCombobox()
        {
            RadComboBox1.DataTextField = "TEN";
            RadComboBox1.DataValueField = "ID";
            RadComboBox1.DataSource = dbaProvider.ExecuteCommandHome(queryCombobox);
            RadComboBox1.DataBind();
        }
    }
}