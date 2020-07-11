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

            if (!IsPostBack)
            {
                rcbNhomLop.SelectedIndex = 0;
                rcbNhomLop.DataBind();
                string nhomLop = rcbNhomLop.SelectedValue.ToString();
                rcbLop.DataSource = resHocSinh.getLop(nhomLop);                
                rcbLop.SelectedIndex = 0;
                rcbLop.DataBind();
                string lop = rcbLop.SelectedValue;
                dbaProvider.ExecuteCommand(String.Format(Form5Command.insertHocSinhToSucKhoeNuoiDuong, nhomLop, lop));         
            }
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
            string nhomLop = rcbNhomLop.SelectedValue.ToString();
            rcbLop.ClearSelection();
            rcbLop.DataSource = resHocSinh.getLop(nhomLop);            
            rcbLop.DataBind();
            RadGrid1.Rebind();
                    
        }
        protected void LoadLopGrid1(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string nhomLop = rcbNhomLop.SelectedValue;
            string lop = rcbLop.SelectedValue;
            dbaProvider.ExecuteCommand(String.Format(Form5Command.insertHocSinhToSucKhoeNuoiDuong, nhomLop, lop));
            RadGrid1.Rebind();
            
        }
      
      
        protected void btCapNhat_Click(object sender, EventArgs e)
        {
            foreach (GridDataItem row in RadGrid1.MasterTableView.Items)
            {
                int id = int.Parse(row.GetDataKeyValue("ID").ToString());
                SUC_KHOE_NUOI_DUONG detail = new SUC_KHOE_NUOI_DUONG();
                detail = resSucKhoe.getById(id);
                if (detail != null)
                {
                    detail.ID = id;
                    RadNumericTextBox txtChieuCao = row.FindControl("txtCHIEUCAO") as RadNumericTextBox;
                    RadNumericTextBox txtCanNang = row.FindControl("txtCanNang") as RadNumericTextBox;
                    CheckBox chkTheThapCoi = row.FindControl("chkTheThapCoi") as CheckBox;
                    CheckBox chkTheCoiCoc = row.FindControl("chkTheCoiCoc") as CheckBox;
                    CheckBox chkTreBeoPhi = row.FindControl("chkTreBeoPhi") as CheckBox;
                    RadComboBox rcbKenhTangTruong = row.FindControl("rcbKenhTangTruongCanNang") as RadComboBox;
                    detail.IS_SUY_DINH_DUONG_THE_THAP_COI = chkTheThapCoi.Checked == true ? 1 : 0;
                    detail.IS_SUY_DINH_DUONG_THE_COI_COC = chkTheCoiCoc.Checked == true ? 1 : 0;
                    detail.IS_TRE_BI_BEO_PHI = chkTreBeoPhi.Checked == true ? 1 : 0;
                    if (!string.IsNullOrEmpty(txtChieuCao.Text))
                        detail.CHIEU_CAO = double.Parse(txtChieuCao.Text);
                    if (!string.IsNullOrEmpty(txtCanNang.Text))
                        detail.CAN_NANG = double.Parse(txtCanNang.Text);
                    if (rcbKenhTangTruong.SelectedIndex > -1)
                        detail.MA_KENH_TANG_TRUONG_CAN_NANG_KY1 = rcbKenhTangTruong.SelectedValue;
                    context.Entry(detail).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                
            }
            RadGrid1.Rebind();

        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridDataItem))
            {
                HiddenField hdMA_KENH_TANG_TRUONG_CAN_NANG_KY1 = e.Item.FindControl("hdMA_KENH_TANG_TRUONG_CAN_NANG") as HiddenField;
                RadComboBox rcbKenhTangTruongCanNang = e.Item.FindControl("rcbKenhTangTruongCanNang") as RadComboBox;
                if (hdMA_KENH_TANG_TRUONG_CAN_NANG_KY1 != null)
                    rcbKenhTangTruongCanNang.SelectedValue = hdMA_KENH_TANG_TRUONG_CAN_NANG_KY1.Value;

            }
        }
       
    }
}




