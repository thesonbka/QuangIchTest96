using DataAccess;
using DataAccess.Repository;
using DataAccess.SqlCommandQuangIch;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form5
{
    public class BindingData
    {

    }
    public partial class index : System.Web.UI.Page
    {
        DbAcessProvider dbaProvider = new DbAcessProvider();
        SucKhoeNuoiDuongRepository resSucKhoe = new SucKhoeNuoiDuongRepository();
        HocSinhRepository resHocSinh = new HocSinhRepository();
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                rcbNhomLop.SelectedIndex = 0;
                rcbNhomLop.DataBind();
                string nhomLop = rcbNhomLop.SelectedValue.ToString();
                rcbLop.DataSource = resHocSinh.getLop(nhomLop);
                rcbLop.DataBind();
                string maLop = "=null ";
                dbaProvider.ExecuteCommand(String.Format(Form5Command.insertHocSinhToSucKhoeNuoiDuong, nhomLop, maLop));
            }
           
        }
        protected void chkTheThapCoi_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        protected void LoadDataGrid(object sender, GridNeedDataSourceEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            string lop = rcbLop.SelectedValue;
            List<Form5ViewModel> list = resSucKhoe.getPage(nhomLop, lop, out int totalRecord);
            RadGrid1.VirtualItemCount = totalRecord;
            list.Take(RadGrid1.PageSize).Skip(e.StartRowIndex);
            RadGrid1.DataSource = list;


        }
        protected void LoadChangeLopHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            string maLop = "=null ";
            rcbLop.DataSource = resHocSinh.getLop(nhomLop);
            rcbLop.DataBind();
            dbaProvider.ExecuteCommand(String.Format(Form5Command.insertHocSinhToSucKhoeNuoiDuong, nhomLop, maLop));
            RadGrid1.Rebind();
        }
        protected void LoadLopGrid1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            string lop = "='"+rcbLop.SelectedValue+"' ";
            dbaProvider.ExecuteCommand(String.Format(Form5Command.insertHocSinhToSucKhoeNuoiDuong, nhomLop, lop));
            RadGrid1.Rebind();
           
        }
        protected void LoadLopGrid2(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
          
        }

       
        protected void btCapNhat_Click(object sender, EventArgs e)
        {
           
            
        }
        protected void LoadChangeComboxCapHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
    }
}




