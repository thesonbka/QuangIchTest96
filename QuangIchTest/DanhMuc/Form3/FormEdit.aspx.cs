using DataAccess.Repository;
using DataAccess.ViewModel;
using System;
using System.Web.UI;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form3
{
    public partial class FormEdit : System.Web.UI.Page
    {
        NHANSURepository resNhanSu = new NHANSURepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string itemID = Request["ID"].ToString();
                if (!string.IsNullOrEmpty(itemID))
                {
                    Form3InsertUpdateViewModel data = resNhanSu.getById(int.Parse(itemID));
                    LoadDataControl(data);
                }
            }

        }
        private void LoadDataControl(Form3InsertUpdateViewModel data)
        {
            txtDienThoai.Text = data.DI_DONG;
            txtMa.Text = data.MA;
            txtMail.Text = data.EMAIL;
            txtHoTen.Text = data.HO_TEN;
            //dbNgaySinh.SelectedDate = data.NGAY_SINH;
            rcbDanToc.SelectedValue = data.MA_DAN_TOC;
            rcbTrangThaiCB.SelectedValue = data.MA_TRANG_THAI_CAN_BO;
            if (!string.IsNullOrEmpty(data.MA_DAN_TOC))
                rcbTonGiao.SelectedValue = data.MA_TON_GIAO;
            txtSoCMT.Text = data.SO_CMTND;
            if (!string.IsNullOrEmpty(data.MA_TINH))
                rcbTinh.SelectedValue = data.MA_TINH;
            if (!string.IsNullOrEmpty(data.MA_HUYEN))
                rcbHuyen.SelectedValue = data.MA_HUYEN;
            if (!string.IsNullOrEmpty(data.MA_XA))
                rcbXa.SelectedValue = data.MA_XA;
            txtKhuPho.Text = data.QUE_QUAN.ToString();
            rcbGioiTinh.SelectedValue = data.MA_GIOI_TINH;
            rcbViTri.SelectedValue = data.MA_NHOM_CAN_BO;
            if (!string.IsNullOrEmpty(data.MA_HINH_THUC_HOP_DONG))
                rcbHinhThucHD.SelectedValue = data.MA_HINH_THUC_HOP_DONG;
            if (!string.IsNullOrEmpty(data.MA_LOAI_CAN_BO))
                rcbHinhThucHD.SelectedValue = data.MA_LOAI_CAN_BO;
            if (!string.IsNullOrEmpty(data.MA_NGACH))
                rcbHinhThucHD.SelectedValue = data.MA_NGACH;
            if (!string.IsNullOrEmpty(data.MA_MON_DAY))
                rcbDayNhomLop.SelectedValue = data.MA_MON_DAY;
            
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
        protected void btn_Save(object sender, EventArgs e)
        {
            Form3InsertUpdateViewModel detail = new Form3InsertUpdateViewModel();

            detail.MA = txtMa.Text.Trim();
            detail.EMAIL = txtMail.Text.Trim();
            detail.HO_TEN = txtHoTen.Text.Trim();
            detail.DI_DONG = txtDienThoai.Text.Trim();
            detail.NGAY_SINH = DateTime.Parse(dbNgaySinh.SelectedDate.ToString());
            detail.MA_DAN_TOC = rcbDanToc.SelectedValue;
            detail.MA_TRANG_THAI_CAN_BO = rcbTrangThaiCB.SelectedValue;
            detail.MA_TON_GIAO = rcbTonGiao.SelectedValue;



            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);
        }
        protected void rcbViTri_LoadHinhThucHopDong(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string maViTri = rcbViTri.SelectedValue;
            rcbHinhThucHD.DataBind();
            RadComboBoxItem item = new RadComboBoxItem();
            item = rcbHinhThucHD.FindItemByText(rcbHinhThucHD.Text);
            if (item != null)
            {
                rcbHinhThucHD.SelectedValue = item.Value;
            }
            else
            {
                rcbHinhThucHD.ClearSelection();
                rcbHinhThucHD.Text = string.Empty;


            }

        }
        protected void rcbNgach_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            txtMaSo.Text = rcbNgach.SelectedValue;

        }
        protected void rcbNgoaiNgu_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(rcbNgoaiNguChinh.SelectedValue))
            {
                rcbTrinhDoDaoTaoNgoaiNgu.ClearSelection();
                rcbTrinhDoDaoTaoNgoaiNgu.Text = string.Empty;

            }
        }

    }
}