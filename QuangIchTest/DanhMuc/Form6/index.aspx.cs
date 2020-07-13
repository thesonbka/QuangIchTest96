using DataAccess;
using DataAccess.Repository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form6
{
    public partial class index : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        ThongKeRepository resThongKe = new ThongKeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }
        protected void LoadDataGridGioiTinh(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            RadGrid1.Rebind();
        }
        protected void LoadDataGridDanToc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void LoadDataGridLoaiHinh(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string loaiHinh = rcbLoaiHinh.SelectedValue;
            string danToc = rcbDanToc.SelectedValue;
            string gioiTinh = rcbGioiTinh.SelectedValue;
            List<Form6ViewModel> list = resThongKe.getPage(loaiHinh, danToc, gioiTinh, out int totalRecord);
            RadGrid1.VirtualItemCount = totalRecord;
            list.Take(RadGrid1.PageSize).Skip(e.StartRowIndex);
            RadGrid1.DataSource = list;


        }
    }
}