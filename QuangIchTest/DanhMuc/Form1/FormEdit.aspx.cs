using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using DataAccess.Repository;
using DataAccess;
using DataAccess.SqlCommandQuangIch;
using System.Data;

namespace QuangIchTest.DanhMuc.Form1
{
    public partial class FormEdit : System.Web.UI.Page
    {
        Form1Repository res = new Form1Repository();
        DbAcessProvider data = new DbAcessProvider();
        public int IsBanTru;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string itemID = Request["ID"].ToString();
                if (!string.IsNullOrEmpty(itemID))
                {
                   
                    var dataTable = data.ExecuteCommand(String.Format(Form1Command.queryGetById, itemID));

                    LoadDataControl(dataTable);
                }
            }

        }
        private void LoadDataControl(DataTable data)
        {
           
            txtMa.Text = data.Rows[0]["MA"].ToString();
            txtTen.Text = data.Rows[0]["TEN"].ToString();
            txtThutu.Text = string.IsNullOrEmpty(data.Rows[0]["THU_TU"].ToString()) ? "" : data.Rows[0]["THU_TU"].ToString();

            RadComboBox1.SelectedValue = data.Rows[0]["MA_CAP_HOC"].ToString();
            RadComboBox1.DataBind();
            rcbKieuMonHoc.SelectedValue = string.IsNullOrEmpty(data.Rows[0]["KIEU_MON_HOC"].ToString()) ? "2" : data.Rows[0]["KIEU_MON_HOC"].ToString();
        }
        protected void load(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {



        }
        protected void btn_Save(object sender, EventArgs e)
        {
            string itemID = Request["ID"].ToString();
            data.ExecuteCommand(String.Format(Form1Command.queryUpdateRecord, itemID, RadComboBox1.SelectedValue.ToString(), int.Parse(rcbKieuMonHoc.SelectedValue.ToString()),string.IsNullOrEmpty(txtThutu.Text)?"= null":"= "+ int.Parse(txtThutu.Text)));
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);
            //ClientScript.RegisterStartupScript(btnGhi.GetType(), "mykey", "CloseAndRebind();", true);



        }

    }
}