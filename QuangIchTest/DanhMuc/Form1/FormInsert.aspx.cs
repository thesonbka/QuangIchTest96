using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.SqlCommandQuangIch;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form1
{
    public partial class FormInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //DbAcessProvider dbaProvider = new DbAcessProvider();
                //var data = dbaProvider.ExecuteCommand(Form1Command.queryComboboxCapHoc);
                //RadComboBox1.DataTextField = "TEN";
                //RadComboBox1.DataValueField = "MA";
                //RadComboBox1.DataSource = data;
                //RadComboBox1.DataBind();
            }

        }
        protected void btn_Save(object sender, EventArgs e)
        {
            
            string KieuMonHoc = rcbKieuMonHoc.SelectedValue;   
            
            string MA = txtMa.Text.ToString();
            string TEN = txtTen.Text.ToString();
            string MACAPHOC = RadComboBox1.SelectedValue.ToString();
            string ThuTu = txtThutu.Text;            
            DbAcessProvider dbaProvider = new DbAcessProvider();
            dbaProvider.ExecuteCommand(String.Format(Form1Command.queryAddRecord, MA, TEN, MACAPHOC, string.IsNullOrEmpty(KieuMonHoc) ? ",null" : ","+KieuMonHoc, string.IsNullOrEmpty(ThuTu)?",null":","+ThuTu));
           
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);





        }
    }
}