using DataAccess;
using DataAccess.Repository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form7
{
    public partial class index : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        HocSinhRepository resHocSinh = new HocSinhRepository();
        ThongkeNhaTreRepository resThongKe = new ThongkeNhaTreRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        protected void LoadPhongGD(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string soGD = rcbSoGD.SelectedValue;
            rcbPhongGD.DataSource = resHocSinh.getPhongGD(soGD);
            rcbPhongGD.DataBind();
            
        }
        protected void LoadTruong(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string maPhongGD = rcbPhongGD.SelectedValue;
            rcbTruong.DataSource = resHocSinh.getTruong(maPhongGD);
            rcbTruong.DataBind();          
        }
        protected void LoadGrid(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            RadGrid1.Rebind();
        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            if (!string.IsNullOrEmpty(rcbTruong.SelectedValue))
            {
                List<ThongKeNhaTreViewModel> list = resThongKe.getPageTruong(rcbTruong.SelectedValue);
                RadGrid1.DataSource = list;
            }
            else
            {
                RadGrid1.DataSource = null;
            }
            


        }
    }
}