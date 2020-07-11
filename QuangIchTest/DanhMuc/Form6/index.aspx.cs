using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccess.Repository;
using DataAccess;
using DataAccess.ViewModel;

namespace QuangIchTest.DanhMuc.Form6
{
    public partial class index : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        ThongKeRepository resThongKe = new ThongKeRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            List<Form6ViewModel> list = resThongKe.getPage();
            RadGrid1.DataSource = list;
            
           
        }
    }
}