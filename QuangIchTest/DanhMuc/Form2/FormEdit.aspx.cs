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

namespace QuangIchTest.DanhMuc.Form2
{
    public partial class FormEdit : System.Web.UI.Page
    {
        DbAcessProvider dbaProvider = new DbAcessProvider();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //afsff
            if (!IsPostBack)
            {
                string itemID = Request["ID"].ToString();
                if (!string.IsNullOrEmpty(itemID))
                {                 
                    var dataTable = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryGetById, itemID));
                    LoadDataControl(dataTable);
                }
            }

        }
        private void LoadDataControl(DataTable data)
        {
            //abc
            string IDTruong = data.Rows[0]["ID_TRUONG"].ToString();
            rcbDiemTruong.DataSource = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryComboboxDiemtruong,IDTruong ));
            rcbDiemTruong.DataBind();
            if (!string.IsNullOrEmpty(data.Rows[0]["MA_DIEM_TRUONG"].ToString()))
            {
                rcbDiemTruong.SelectedValue = data.Rows[0]["MA_DIEM_TRUONG"].ToString();
            }
            int IsBanTru = 0;
            int _2_Buoi_1_ngay = 0;
            if (!string.IsNullOrEmpty(data.Rows[0]["IS_BAN_TRU"].ToString()))           
                IsBanTru = int.Parse(data.Rows[0]["IS_BAN_TRU"].ToString());
            if (!string.IsNullOrEmpty(data.Rows[0]["IS_DAY_2_BUOI_NGAY"].ToString()))
                _2_Buoi_1_ngay = int.Parse(data.Rows[0]["IS_DAY_2_BUOI_NGAY"].ToString());
            if (!string.IsNullOrEmpty(data.Rows[0]["MA_DIEM_TRUONG"].ToString()))
            {
                rcbDiemTruong.SelectedValue = data.Rows[0]["MA_DIEM_TRUONG"].ToString().Replace(" ","");
            }
            rcbNhomLop.SelectedValue = data.Rows[0]["MAKHOI"].ToString();
            rcbNhomLop.DataBind();

            DataTable dataTable = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryNhomtre, rcbNhomLop.SelectedValue));
            rcbNhomTuoi.DataSource = dataTable;
            rcbNhomTuoi.DataBind();
            rcbNhomTuoi.SelectedValue = data.Rows[0]["MA_NHOM_TUOI_MN"].ToString();

            txtTen.Text = data.Rows[0]["TEN"].ToString();
            txtThutu.Text = string.IsNullOrEmpty(data.Rows[0]["THU_TU"].ToString()) ? "" : data.Rows[0]["THU_TU"].ToString();
            if (IsBanTru == 1)
                chkBanTru.Checked = true;
            if (_2_Buoi_1_ngay == 1)
                chk2buoi.Checked = true;
             
        }
        protected void rcbNhomLop_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string NhomLop = rcbNhomLop.SelectedValue;
            DataTable data = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryNhomtre, NhomLop));
            rcbNhomTuoi.DataSource = data;
            rcbNhomTuoi.ClearSelection();
            rcbNhomTuoi.Text = string.Empty;
           


        }
       
        protected void btn_Save(object sender, EventArgs e)
        {
            string MaKhoi = rcbNhomLop.SelectedValue;
            string NhomTuoi = rcbNhomTuoi.SelectedValue;
            string TEN = txtTen.Text;
            string ThuTu = string.IsNullOrEmpty(txtThutu.Text) ? "= null" : "= " + int.Parse(txtThutu.Text);
            string IsBanTru = chkBanTru.Checked == true ? "1" : "0";
            string IsDay2Buoi = chk2buoi.Checked == true ? " = 1" : "= 0";
            string MaDiemTruong = string.IsNullOrEmpty(rcbDiemTruong.SelectedValue) ? "= null" :"= ' "+rcbDiemTruong.SelectedValue+"'";
            string ID = Request["ID"].ToString();
            dbaProvider.ExecuteCommand(String.Format(Form2Command.queryUpdateRecord,MaKhoi,NhomTuoi,TEN,ThuTu,IsBanTru,IsDay2Buoi,MaDiemTruong,ID));
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);





        }

    }
}