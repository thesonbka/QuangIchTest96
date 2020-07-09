using DataAccess.Repository;
using System;
using System.Web.UI;
using Telerik.Web.UI;
using DataAccess.ViewModel;
using DataAccess;

namespace QuangIchTest.DanhMuc.Form3
{
    public partial class FormInsert : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        NHANSURepository resNhanSu = new NHANSURepository();
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
        protected void btn_Save(object sender, EventArgs e)
        {
            NHAN_SU detail = new NHAN_SU();
            detail.MA = txtMa.Text.Trim();
            if(!string.IsNullOrEmpty(txtMail.Text.Trim()))
               detail.EMAIL = txtMail.Text.Trim();
            detail.HO_TEN = txtHoTen.Text.Trim();
            if (!string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
                detail.DI_DONG = txtDienThoai.Text.Trim();
            detail.NGAY_SINH = DateTime.Parse(dbNgaySinh.SelectedDate.ToString());
            detail.MA_DAN_TOC = rcbDanToc.SelectedValue;
            detail.MA_TRANG_THAI_CAN_BO = rcbTrangThaiCB.SelectedValue;
            if(rcbTonGiao.SelectedIndex>-1)
                detail.MA_TON_GIAO = rcbTonGiao.SelectedValue;
            detail.SO_CMTND = txtSoCMT.Text.Trim();
            if (rcbTinh.SelectedIndex > -1)
                detail.MA_TINH = rcbTinh.SelectedValue;
            if (rcbHuyen.SelectedIndex > -1)
                detail.MA_HUYEN = rcbHuyen.SelectedValue;
            if (rcbXa.SelectedIndex > -1)
                detail.MA_XA = rcbXa.SelectedValue;
            if (!string.IsNullOrEmpty(txtKhuPho.Text))
                detail.QUE_QUAN = txtKhuPho.Text;
            if (rcbGioiTinh.SelectedIndex > -1)
                detail.MA_GIOI_TINH = rcbGioiTinh.SelectedValue;
            detail.MA_NHOM_CAN_BO = rcbViTri.SelectedValue;

            if (rcbHinhThucHD.SelectedIndex > -1)
                detail.MA_HINH_THUC_HOP_DONG = rcbHinhThucHD.SelectedValue;
            if (rcbNhomChucVu.SelectedIndex > -1)
                detail.MA_LOAI_CAN_BO = rcbNhomChucVu.SelectedValue;
            if (rcbNgach.SelectedIndex > -1)
                detail.MA_NGACH = rcbNgach.SelectedValue;
            if (rcbDayNhomLop.SelectedIndex > -1)
                detail.MA_MON_DAY = rcbDayNhomLop.SelectedValue;
            if (!string.IsNullOrEmpty(txtMaSo.Text))
                detail.MA_SO_NGACH = txtMaSo.Text;
            detail.PC_THU_HUT = null;
            try
            {
                detail.PC_THU_HUT = Convert.ToDecimal(tbPhuCapThuHutNghe.Text);
            }
            catch
            {

            }
            if (!string.IsNullOrEmpty(tbHeSo.Text))
                detail.HE_SO_LUONG = tbHeSo.Text.Trim();
           
            
            detail.PC_THAM_NIEN = null;
            try
            {
                detail.PC_THAM_NIEN = Convert.ToDecimal(tbPhuCapThamNien.Text);
            }
            catch
            {

            }
            try
            {
                detail.NGAY_HUONG_LUONG = DateTime.Parse(dateNgayHuongLuong.SelectedDate.ToString());
            }
            catch
            {
                detail.NGAY_HUONG_LUONG = null;
            }
            if (rcbBacLuong.SelectedIndex > -1)
                detail.MA_BAC_LUONG = rcbBacLuong.SelectedValue;
            if (rcbBoiDuongTX.SelectedIndex > -1)
                detail.MA_BOI_DUONG_TX = rcbBoiDuongTX.SelectedValue;
            if (rcbNgoaiNguChinh.SelectedIndex > -1)
                detail.MA_TRINH_DO_NGOAI_NGU = rcbNgoaiNguChinh.SelectedValue;
            if (rcbChuyenNghanhChinh.SelectedIndex > -1)
                detail.MA_CHUYEN_MON_1 = rcbChuyenNghanhChinh.SelectedValue;
            if (rcbTrinhDoChuyenMon.SelectedIndex > -1)
                detail.MA_TRINH_DO_CHUYEN_MON = rcbTrinhDoChuyenMon.SelectedValue;
            if (rcbTrinhDoDaoTaoNgoaiNgu.SelectedIndex > -1)
                detail.MA_TRINH_DO_NGOAI_NGU = rcbTrinhDoDaoTaoNgoaiNgu.SelectedValue;
            if (rcbTrinhDo1.SelectedIndex > -1)
                detail.MA_TRINH_DO_1 = rcbTrinhDo1.SelectedValue;
            if (rcbTrinhDoLLCT.SelectedIndex > -1)
                detail.MA_TRINH_DO_LLCT = rcbTrinhDoLLCT.SelectedValue;
            if (rcbTrinhDoTinHoc.SelectedIndex > -1)
                detail.MA_TRINH_DO_TIN_HOC = rcbTrinhDoTinHoc.SelectedValue;
            if (rcbChuyenMon2.SelectedIndex > -1)
                detail.MA_CHUYEN_MON_2 = rcbBoiDuongTX.SelectedValue;
            if (rcbQuanLyGD.SelectedIndex > -1)
                detail.MA_TRINH_DO_QLGD = rcbQuanLyGD.SelectedValue;
            if (rcbTrinhDo2.SelectedIndex > -1)
                detail.MA_TRINH_DO_2 = rcbTrinhDo2.SelectedValue;

            try
            {
                context.NHAN_SU.Add(detail);
                context.SaveChanges();
            }
            catch
            {


            }
            
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