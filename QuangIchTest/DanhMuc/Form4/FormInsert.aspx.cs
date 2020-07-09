using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form4
{
    public partial class FormInsert : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        NHANSURepository resNhanSu = new NHANSURepository();
        HocSinhRepository resHocSinh = new HocSinhRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoadHuyen(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string maTinh = rcbTinh.SelectedValue;
            rcbHuyen.DataSource = resNhanSu.getHuyen(maTinh);
            rcbHuyen.DataBind();
        }
        protected void LoadXa(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string maTinh = rcbTinh.SelectedValue;
            string maHuyen = rcbHuyen.SelectedValue;
            rcbXa.DataSource = resNhanSu.getXa(maTinh, maHuyen);
            rcbXa.DataBind();
        }
        protected void LoadChangeLopHoc(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            rcbLop.DataSource = resHocSinh.getLop(nhomLop);
            rcbLop.DataBind();
           
        }
        protected void btn_Save(object sender, EventArgs e)
        {

        }



    }
}