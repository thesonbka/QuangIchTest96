﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BO_GIAO_DUC_TEMPEntities : DbContext
    {
        public BO_GIAO_DUC_TEMPEntities()
            : base("name=BO_GIAO_DUC_TEMPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DM_CAP_HOC> DM_CAP_HOC { get; set; }
        public virtual DbSet<DM_MON_HOC> DM_MON_HOC { get; set; }
        public virtual DbSet<LOP> LOPs { get; set; }
        public virtual DbSet<LOP_MON> LOP_MON { get; set; }
        public virtual DbSet<DM_GIOI_TINH> DM_GIOI_TINH { get; set; }
        public virtual DbSet<DM_LY_DO_THOI_HOC> DM_LY_DO_THOI_HOC { get; set; }
        public virtual DbSet<DM_MIEN_GIAM_HOC_PHI> DM_MIEN_GIAM_HOC_PHI { get; set; }
        public virtual DbSet<DM_MON_DAY_GV> DM_MON_DAY_GV { get; set; }
        public virtual DbSet<DM_MUC_DAT_CHUAN_QG_CLGD> DM_MUC_DAT_CHUAN_QG_CLGD { get; set; }
        public virtual DbSet<DM_NGACH> DM_NGACH { get; set; }
        public virtual DbSet<DM_NGANH_DAO_TAO> DM_NGANH_DAO_TAO { get; set; }
        public virtual DbSet<DM_NGOAI_NGU> DM_NGOAI_NGU { get; set; }
        public virtual DbSet<DM_NGOAI_NGU_HS_NHAN_SU> DM_NGOAI_NGU_HS_NHAN_SU { get; set; }
        public virtual DbSet<DM_NHIEM_VU_KIEM_NHIEM> DM_NHIEM_VU_KIEM_NHIEM { get; set; }
        public virtual DbSet<DM_NHOM_CAN_BO> DM_NHOM_CAN_BO { get; set; }
        public virtual DbSet<DM_NHOM_CAP_HOC> DM_NHOM_CAP_HOC { get; set; }
        public virtual DbSet<DM_NHOM_CHUYEN_NGANH> DM_NHOM_CHUYEN_NGANH { get; set; }
        public virtual DbSet<DM_NHOM_MAU> DM_NHOM_MAU { get; set; }
        public virtual DbSet<DM_NHOM_TUOI_MN> DM_NHOM_TUOI_MN { get; set; }
        public virtual DbSet<DM_NUOC> DM_NUOC { get; set; }
        public virtual DbSet<DM_PHAN_BAN> DM_PHAN_BAN { get; set; }
        public virtual DbSet<DM_SO_TIET_NGOAI_NGU> DM_SO_TIET_NGOAI_NGU { get; set; }
        public virtual DbSet<DM_THOI_DIEM_DANH_GIA> DM_THOI_DIEM_DANH_GIA { get; set; }
        public virtual DbSet<DM_TIENG_DAN_TOC> DM_TIENG_DAN_TOC { get; set; }
        public virtual DbSet<DM_TIET_HOC> DM_TIET_HOC { get; set; }
        public virtual DbSet<DM_TINH> DM_TINH { get; set; }
        public virtual DbSet<DM_TON_GIAO> DM_TON_GIAO { get; set; }
        public virtual DbSet<DM_TOT_NGHIEP> DM_TOT_NGHIEP { get; set; }
        public virtual DbSet<DM_TRANG_THAI_CAN_BO> DM_TRANG_THAI_CAN_BO { get; set; }
        public virtual DbSet<DM_TRANG_THAI_HOC_SINH> DM_TRANG_THAI_HOC_SINH { get; set; }
        public virtual DbSet<DM_TRINH_DO> DM_TRINH_DO { get; set; }
        public virtual DbSet<DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU> DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU { get; set; }
        public virtual DbSet<DM_TRINH_DO_LLCT> DM_TRINH_DO_LLCT { get; set; }
        public virtual DbSet<DM_TRINH_DO_NGOAI_NGU> DM_TRINH_DO_NGOAI_NGU { get; set; }
        public virtual DbSet<DM_TRINH_DO_QLGD> DM_TRINH_DO_QLGD { get; set; }
        public virtual DbSet<DM_TRINH_DO_QLNN> DM_TRINH_DO_QLNN { get; set; }
        public virtual DbSet<DM_TRINH_DO_TIN_HOC> DM_TRINH_DO_TIN_HOC { get; set; }
        public virtual DbSet<DM_TRINH_DO_VAN_HOA> DM_TRINH_DO_VAN_HOA { get; set; }
        public virtual DbSet<DM_TRUC_THUOC> DM_TRUC_THUOC { get; set; }
        public virtual DbSet<DM_VT_VIEC_LAM> DM_VT_VIEC_LAM { get; set; }
        public virtual DbSet<DM_VUNG_KHO_KHAN> DM_VUNG_KHO_KHAN { get; set; }
        public virtual DbSet<DM_XA> DM_XA { get; set; }
        public virtual DbSet<HOC_SINH> HOC_SINH { get; set; }
        public virtual DbSet<HOC_SINH_TOT_NGHIEP> HOC_SINH_TOT_NGHIEP { get; set; }
        public virtual DbSet<NAM_HOC> NAM_HOC { get; set; }
        public virtual DbSet<NHAN_SU> NHAN_SU { get; set; }
        public virtual DbSet<NHOM_QUYEN> NHOM_QUYEN { get; set; }
        public virtual DbSet<PHONG_BAN> PHONG_BAN { get; set; }
        public virtual DbSet<PHONG_GD> PHONG_GD { get; set; }
        public virtual DbSet<SO_GD> SO_GD { get; set; }
        public virtual DbSet<SUC_KHOE_NUOI_DUONG> SUC_KHOE_NUOI_DUONG { get; set; }
        public virtual DbSet<TONG_KET> TONG_KET { get; set; }
        public virtual DbSet<TONG_KET_C1> TONG_KET_C1 { get; set; }
        public virtual DbSet<TRUONG> TRUONGs { get; set; }
        public virtual DbSet<DM_DAN_TOC> DM_DAN_TOC { get; set; }
        public virtual DbSet<DM_LOAI_CAN_BO> DM_LOAI_CAN_BO { get; set; }
        public virtual DbSet<DM_HINH_THUC_HOP_DONG> DM_HINH_THUC_HOP_DONG { get; set; }
        public virtual DbSet<DM_HUYEN> DM_HUYEN { get; set; }
        public virtual DbSet<DM_BAC_LUONG> DM_BAC_LUONG { get; set; }
        public virtual DbSet<DM_CHUYEN_MON> DM_CHUYEN_MON { get; set; }
        public virtual DbSet<DM_BOI_DUONG_TX> DM_BOI_DUONG_TX { get; set; }
    }
}
