using DataAccess;
using DataAccess.Repository;
using System;
using System.Linq;
using System.Web.UI;
using Telerik.Web.UI;
namespace QuangIchTest.DanhMuc.Form4
{
    public partial class FormEdit : System.Web.UI.Page
    {
        BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
        NHANSURepository resNhanSu = new NHANSURepository();
        HocSinhRepository resHocSinh = new HocSinhRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int itemID = int.Parse(Request["ID"].ToString());
                var data = context.HOC_SINH.FirstOrDefault(p => p.ID == itemID);
                if (data != null)
                    LoadDataControl(data);
            }

        }
        private void LoadDataControl(HOC_SINH data)
        {
            rcbNhomLop.SelectedValue = data.MA_KHOI.ToString();
            rcbLop.DataSource = resHocSinh.getLop(data.MA_KHOI);
            rcbLop.DataBind();
            rcbLop.SelectedValue = data.MA_LOP.ToString();
            txtMa.Text = data.MA.ToString();
            rcbTinh.SelectedValue = data.MA_TINH.ToString();
            rcbHuyen.DataSource = resNhanSu.getHuyen(data.MA_TINH);
            rcbHuyen.DataBind();
            if (!string.IsNullOrEmpty(data.MA_HUYEN))
            {
                rcbHuyen.SelectedValue = data.MA_HUYEN.ToString();
                rcbXa.DataSource = resNhanSu.getXa(data.MA_TINH, data.MA_HUYEN);
                rcbXa.DataBind();
                if(!string.IsNullOrEmpty(data.MA_XA))
                    rcbXa.SelectedValue = data.MA_XA.ToString();
            }
            txtHoTen.Text = data.HO_TEN.ToString().Trim();
            rcbGioiTinh.SelectedValue = data.MA_GIOI_TINH.ToString().Trim();
            dbNgaySinh.SelectedDate = data.NGAY_SINH;
            txtNoiinh.Text = data.NOI_SINH.ToString();
            rcbDanToc.SelectedValue = data.MA_DAN_TOC.ToString().Trim();
            rcbTrangThaiHS.SelectedValue = data.MA_TRANG_THAI_HIEN_TAI.ToString().Trim();
            if (!string.IsNullOrEmpty(data.MA_QUOC_TICH))
                rcbQuocTich.SelectedValue = data.MA_QUOC_TICH.ToString().Trim();
            if (!string.IsNullOrEmpty(data.MA_KHU_VUC))
                rcbLoaiKhuVuc.SelectedValue = data.MA_KHU_VUC.ToString().Trim();
            if (data.IS_HOC_2_BUOI == 1)
                chkIsHoc2Buoi.Checked = true;
            if (data.IS_CHA_DT == 1)
                chkIsChaDT.Checked = true;
            if (data.IS_ME_DT == 1)
                chkIsMeDT.Checked = true;
            if (data.IS_HOC_SINH_BAN_TRU_DAN_NUOI == 1)
                chkhslopbantru.Checked = true;
            if (!string.IsNullOrEmpty(data.MA_HOC_BAN_TRU))
                rcbBanTru.SelectedValue = data.MA_HOC_BAN_TRU.ToString().Trim();
            if (!string.IsNullOrEmpty(data.MA_LOAI_KHUYET_TAT))
                rcbKhuyetTat.SelectedValue = data.MA_LOAI_KHUYET_TAT.ToString().Trim();
            if (!string.IsNullOrEmpty(data.MA_DIEN_CHINH_SACH))
                rcbDoituongCS.SelectedValue = data.MA_DIEN_CHINH_SACH.ToString().Trim();
            if (!string.IsNullOrEmpty(data.TEN_CHA))
                txtCha.Text = data.TEN_CHA.ToString();
            if (!string.IsNullOrEmpty(data.TEN_ME))
                txtMe.Text = data.TEN_ME.ToString();
            if (!string.IsNullOrEmpty(data.TEN_NGUOI_DD))
                txtNguoiDoDau.Text = data.TEN_NGUOI_DD.ToString();
            if (!string.IsNullOrEmpty(data.NGHE_NGHIEP_CHA))
                txtNgheNghiepCha.Text = data.NGHE_NGHIEP_CHA.ToString();
            if (!string.IsNullOrEmpty(data.NGHE_NGHIEP_ME))
                txtNgheNghiepMe.Text = data.NGHE_NGHIEP_ME.ToString();
            if (!string.IsNullOrEmpty(data.NGHE_NGHIEP_NGUOI_DD))
                txtNgheNgiemDoDau.Text = data.NGHE_NGHIEP_NGUOI_DD;
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
            rcbLop.SelectedIndex = 0;

        }
        protected void rcbTrangThaiHS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

        }
        protected void btn_Save(object sender, EventArgs e)
        {
            HOC_SINH detail = new HOC_SINH();
            detail.ID = int.Parse(Request["ID"].ToString());
            detail.MA_KHOI = rcbNhomLop.SelectedValue.ToString();
            detail.MA_LOP = rcbLop.SelectedValue.ToString();
            detail.MA = txtMa.Text.ToString().Trim();
            detail.MA_TINH = rcbTinh.SelectedValue.ToString();
            if (rcbHuyen.SelectedIndex > -1)
                detail.MA_HUYEN = rcbHuyen.SelectedValue.ToString();
            if (rcbXa.SelectedIndex > -1)
                detail.MA_XA = rcbXa.SelectedValue.ToString();
            detail.HO_TEN = txtHoTen.Text.ToString();
            detail.NGAY_SINH = DateTime.Parse(dbNgaySinh.SelectedDate.ToString());
            detail.MA_GIOI_TINH = rcbGioiTinh.SelectedValue.ToString();
            detail.NOI_SINH = txtNoiinh.Text.ToString().Trim();
            detail.MA_TRANG_THAI_HIEN_TAI = rcbTrangThaiHS.SelectedValue.ToString();
            detail.MA_DAN_TOC = rcbDanToc.SelectedValue.ToString();
            if (rcbQuocTich.SelectedIndex > -1)
                detail.MA_QUOC_TICH = rcbQuocTich.SelectedValue.ToString();
            if (rcbLoaiKhuVuc.SelectedIndex > -1)
                detail.MA_KHU_VUC = rcbLoaiKhuVuc.SelectedValue.ToString();
            if (chkIsHoc2Buoi.Checked)
                detail.IS_HOC_2_BUOI = 1;
            if (chkIsChaDT.Checked)
                detail.IS_CHA_DT = 1;
            if (chkIsMeDT.Checked)
                detail.IS_ME_DT = 1;
            if (chkhslopbantru.Checked)
                detail.IS_HOC_SINH_LOP_BTRU = 1;
            if (rcbBanTru.SelectedIndex > -1)
                detail.MA_HOC_BAN_TRU = rcbBanTru.SelectedValue.ToString();
            if (rcbKhuyetTat.SelectedIndex > -1)
                detail.MA_LOAI_KHUYET_TAT = rcbKhuyetTat.SelectedValue.ToString();
            if (rcbDoituongCS.SelectedIndex > -1)
                detail.MA_DIEN_CHINH_SACH = rcbDoituongCS.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(txtCha.Text))
                detail.TEN_CHA = txtCha.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(txtMe.Text))
                detail.TEN_ME = txtMe.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(txtNguoiDoDau.Text))
                detail.TEN_NGUOI_DD = txtNguoiDoDau.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(txtNgheNghiepCha.Text))
                detail.NGHE_NGHIEP_CHA = txtNgheNghiepCha.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(txtNgheNghiepMe.Text))
                detail.NGHE_NGHIEP_ME = txtNgheNghiepMe.Text.ToString().Trim();
            if (!string.IsNullOrEmpty(txtNgheNgiemDoDau.Text))
                detail.NGHE_NGHIEP_NGUOI_DD = txtNgheNgiemDoDau.Text.ToString().Trim();
            detail.MA_CAP_HOC = "01";
            detail.MA_TRUONG = "14150";
            detail.MA_NAM_HOC = 2016;

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
    }
}