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
        //protected void LoadPhongGD(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    string maSoGD = rcbSoGD.SelectedValue;
        //    rcbPhongGD.DataSource = resNhanSu.getPhongGD(maSoGD);
        //    rcbPhongGD.DataBind();
        //}
        //protected void LoadTruong(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        //    string phongGD = rcbSoGD.SelectedValue;
        //    rcbTruong.DataSource = resNhanSu.getPhongGD(phongGD);
        //    rcbTruong.DataBind();
        //}
        protected void rcbTrangThaiHS_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            

        }
        protected void btn_Save(object sender, EventArgs e)
        {
            HOC_SINH detail = new HOC_SINH();
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
            detail.MA_SO_GD = rcbSoGD.SelectedValue;
            detail.MA_CAP_HOC = "01";
            detail.MA_TRUONG = "14150";
            detail.ID_TRUONG = 14150;
            detail.MA_NAM_HOC = 2016;
            
            context.HOC_SINH.Add(detail);
            context.SaveChanges();
            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(typeof(Page), "CloseScript_" + UniqueID, "CloseAndRebind();", true);
        }
    }
}