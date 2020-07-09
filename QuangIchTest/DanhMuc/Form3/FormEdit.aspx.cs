using DataAccess;
using DataAccess.Repository;
using DataAccess.ViewModel;
using System;
using System.Web.UI;
using Telerik.Web.UI;

namespace QuangIchTest.DanhMuc.Form3
{
    public partial class FormEdit : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
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
            txtMa.Text = data.MA;
            txtMail.Text = data.EMAIL;
            txtHoTen.Text = data.HO_TEN;
            txtDienThoai.Text = data.DI_DONG;
            dbNgaySinh.SelectedDate = data.NGAY_SINH;          
            rcbDanToc.SelectedValue = data.MA_DAN_TOC;
            rcbTrangThaiCB.SelectedValue = data.MA_TRANG_THAI_CAN_BO;
            txtSoCMT.Text = data.SO_CMTND.ToString().Trim();
            if (!string.IsNullOrEmpty(data.MA_TINH))
            {
                rcbTinh.SelectedValue = data.MA_TINH;
                rcbHuyen.DataSource = resNhanSu.getHuyen(data.MA_TINH);
                rcbHuyen.DataBind();
                if (!string.IsNullOrEmpty(data.MA_HUYEN))
                {
                    rcbHuyen.SelectedValue = data.MA_HUYEN.ToString();
                    rcbXa.DataSource = resNhanSu.getXa(data.MA_TINH, data.MA_HUYEN);
                    rcbXa.DataBind();
                    rcbXa.SelectedValue = data.MA_XA.ToString();
                }
            }           
            rcbGioiTinh.SelectedValue = data.MA_GIOI_TINH;
            txtKhuPho.Text = data.QUE_QUAN;
            rcbViTri.SelectedValue = data.MA_NHOM_CAN_BO;
            if (!string.IsNullOrEmpty(data.MA_TON_GIAO))
                rcbTonGiao.SelectedValue = data.MA_TON_GIAO.ToString();
            if (!string.IsNullOrEmpty(data.MA_HINH_THUC_HOP_DONG))
                rcbHinhThucHD.SelectedValue = data.MA_HINH_THUC_HOP_DONG.ToString();
            if (!string.IsNullOrEmpty(data.MA_LOAI_CAN_BO))
                rcbNhomChucVu.SelectedValue = data.MA_LOAI_CAN_BO.ToString();
            if (!string.IsNullOrEmpty(data.MA_NGACH))
                rcbNgach.SelectedValue = data.MA_NGACH.ToString();
            if (!string.IsNullOrEmpty(data.MA_MON_DAY))
                rcbDayNhomLop.SelectedValue = data.MA_MON_DAY.ToString();
            if (!string.IsNullOrEmpty(data.MA_SO_NGACH))
                txtMaSo.Text = data.MA_SO_NGACH.ToString();
            if(!string.IsNullOrEmpty(data.HE_SO_LUONG))            
                txtHeSoLuong.Text = data.HE_SO_LUONG.ToString();
            txtMucPhuCapThamNien.Text = data.PC_THAM_NIEN.ToString();
            txtPhuCapNghe.Text = data.PC_THU_HUT.ToString();
            dateNgayHuongLuong.SelectedDate = data.NGAY_HUONG_LUONG;
            if (!string.IsNullOrEmpty(data.MA_BAC_LUONG))
                rcbBacLuong.SelectedValue = data.MA_BAC_LUONG.ToString();
            if (!string.IsNullOrEmpty(data.MA_BOI_DUONG_TX))
                rcbBoiDuongTX.SelectedValue = data.MA_BOI_DUONG_TX.ToString();
            if (!string.IsNullOrEmpty(data.MA_NGOAI_NGHU))
                rcbNgoaiNguChinh.SelectedValue = data.MA_NGOAI_NGHU.ToString();
            if (!string.IsNullOrEmpty(data.MA_CHUYEN_MON_1))
                rcbChuyenNghanhChinh.SelectedValue = data.MA_CHUYEN_MON_1.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_CHUYEN_MON))
                rcbTrinhDoChuyenMon.SelectedValue = data.MA_TRINH_DO_CHUYEN_MON.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_NGOAI_NGU))
                rcbTrinhDoDaoTaoNgoaiNgu.SelectedValue = data.MA_TRINH_DO_NGOAI_NGU.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_1))
                rcbTrinhDo1.SelectedValue = data.MA_TRINH_DO_1.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_LLCT))
                rcbTrinhDoLLCT.SelectedValue = data.MA_TRINH_DO_LLCT.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_TIN_HOC))
                rcbTrinhDoTinHoc.SelectedValue = data.MA_TRINH_DO_TIN_HOC.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_QLGD))
                rcbQuanLyGD.SelectedValue = data.MA_TRINH_DO_QLGD.ToString();
            if (!string.IsNullOrEmpty(data.MA_CHUYEN_MON_2))
                rcbChuyenMon2.SelectedValue = data.MA_CHUYEN_MON_2.ToString();
            if (!string.IsNullOrEmpty(data.MA_TRINH_DO_2))
                rcbTrinhDo2.SelectedValue = data.MA_TRINH_DO_2.ToString();

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
            detail.ID = int.Parse(Request["ID"].ToString());
            detail.MA = txtMa.Text.Trim();
            if (!string.IsNullOrEmpty(txtMail.Text.Trim()))
                detail.EMAIL = txtMail.Text.Trim();
            detail.HO_TEN = txtHoTen.Text.Trim();
            if (!string.IsNullOrEmpty(txtDienThoai.Text.Trim()))
                detail.DI_DONG = txtDienThoai.Text.Trim();
            detail.NGAY_SINH = DateTime.Parse(dbNgaySinh.SelectedDate.ToString());
            detail.MA_DAN_TOC = rcbDanToc.SelectedValue;
            detail.MA_TRANG_THAI_CAN_BO = rcbTrangThaiCB.SelectedValue;
            if (rcbTonGiao.SelectedIndex > -1)
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
                detail.PC_THU_HUT = Convert.ToDecimal(txtPhuCapNghe.Text);
            }
            catch
            {

            }
            if (!string.IsNullOrEmpty(txtHeSoLuong.Text))
                detail.HE_SO_LUONG = txtHeSoLuong.Text.Trim();


            detail.PC_THAM_NIEN = null;
            try
            {
                detail.PC_THAM_NIEN = Convert.ToDecimal(txtMucPhuCapThamNien.Text);
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
                context.Entry(detail).State = System.Data.Entity.EntityState.Modified;
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