﻿using DataAccess.Repository;
using System;
using System.Web.UI;
using Telerik.Web.UI;
using DataAccess.ViewModel;

namespace QuangIchTest.DanhMuc.Form3
{
    public partial class FormInsert : System.Web.UI.Page
    {
       
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