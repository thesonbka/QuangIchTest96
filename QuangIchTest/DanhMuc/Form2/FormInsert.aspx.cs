using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.SqlCommandQuangIch;
using Telerik.Web.UI;
using System.Data;
using DataAccess.Repository;
using DataAccess.IRepository;

namespace QuangIchTest.DanhMuc.Form2
{
    public partial class FormInsert : System.Web.UI.Page
    {
      
        NHANSURepository resNhanSu = new NHANSURepository();

        
        DbAcessProvider dbaProvider = new DbAcessProvider();
        string MATRUONG = "14150";
        string MANAMHOC = "2017";
        string MASOGIAODUC = "17";
        protected void Page_Load(object sender, EventArgs e)
        {
            BinDataCombobox();

        }
        public void BinDataCombobox()
        {
            rcbDiemTruong.DataSource = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryComboboxDiemtruong, MATRUONG));
            rcbDiemTruong.DataBind();
        }
    
        protected void LoadChangeComboxCapHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string NhomLop = rcbNhomLop.SelectedValue;
            DataTable data = dbaProvider.ExecuteCommand(String.Format(Form2Command.queryNhomtre, NhomLop));
            rcbNhomTuoi.DataSource = data;
            rcbNhomTuoi.DataBind();
         
            rcbNhomTuoi.ClearSelection();
            rcbNhomTuoi.Text = string.Empty;
        }
        protected void btn_Save(object sender, EventArgs e)
        {
            string MACAPHOC = "01";
            string MaLop = txtMaLop.Text.Trim();
            string MaKhoi = rcbNhomLop.SelectedValue;
            string NhomTuoi = rcbNhomTuoi.SelectedValue;
            string TEN = txtTen.Text.Trim();
            string ThuTu = string.IsNullOrEmpty(txtThutu.Text) ? "null" : "" + int.Parse(txtThutu.Text);
            string IsBanTru = chkBanTru.Checked == true ? "1" : "0";
            string IsDay2Buoi = chk2buoi.Checked == true ? " 1" : " 0";
            string MaDiemTruong = string.IsNullOrEmpty(rcbDiemTruong.SelectedValue) ? " null" : " ' " + rcbDiemTruong.SelectedValue + "'";
            dbaProvider.ExecuteCommand(String.Format(Form2Command.queryAddRecord, MaLop, MASOGIAODUC, MATRUONG, MANAMHOC, MaKhoi, NhomTuoi, TEN, ThuTu,IsBanTru,IsDay2Buoi,MaDiemTruong,MACAPHOC));
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);

        }
    }
}