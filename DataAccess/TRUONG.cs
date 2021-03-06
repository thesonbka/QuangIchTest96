//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TRUONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRUONG()
        {
            this.HOC_SINH = new HashSet<HOC_SINH>();
            this.HOC_SINH_TOT_NGHIEP = new HashSet<HOC_SINH_TOT_NGHIEP>();
            this.LOPs = new HashSet<LOP>();
            this.LOP_MON = new HashSet<LOP_MON>();
            this.NHAN_SU = new HashSet<NHAN_SU>();
            this.TONG_KET = new HashSet<TONG_KET>();
            this.TONG_KET_C1 = new HashSet<TONG_KET_C1>();
            this.SUC_KHOE_NUOI_DUONG = new HashSet<SUC_KHOE_NUOI_DUONG>();
            this.DIEM_TRUONG = new HashSet<DIEM_TRUONG>();
        }
    
        public decimal ID { get; set; }
        public int MA_NAM_HOC { get; set; }
        public string MA_SO_GD { get; set; }
        public string MA { get; set; }
        public string TEN { get; set; }
        public string MA_NHOM_CAP_HOC { get; set; }
        public string DS_CAP_HOC { get; set; }
        public Nullable<decimal> ID_PHONG_GD { get; set; }
        public string MA_PHONG_GD { get; set; }
        public string MA_TINH { get; set; }
        public Nullable<decimal> ID_HUYEN { get; set; }
        public string MA_HUYEN { get; set; }
        public Nullable<decimal> ID_XA { get; set; }
        public string MA_XA { get; set; }
        public string DIA_CHI { get; set; }
        public string MA_LOAI_HINH_TRUONG { get; set; }
        public string MA_LOAI_TRUONG { get; set; }
        public string MA_KHU_VUC { get; set; }
        public string MA_DAT_CHUAN_DANH_GIA_CLGD { get; set; }
        public string MA_TRUC_THUOC { get; set; }
        public string MA_DU_AN { get; set; }
        public Nullable<int> SO_DIEM_TRUONG { get; set; }
        public string DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string WEBSITE { get; set; }
        public string VI_TRI_BAN_DO { get; set; }
        public string HIEU_TRUONG { get; set; }
        public string DIEN_THOAI_HIEU_TRUONG { get; set; }
        public string EMAIL_HIEU_TRUONG { get; set; }
        public Nullable<int> IS_CO_CHI_BO_DANG { get; set; }
        public Nullable<int> IS_DAT_CHUAN_QG { get; set; }
        public Nullable<int> IS_TRUONG_QUOC_TE { get; set; }
        public Nullable<int> IS_CAP_MN { get; set; }
        public Nullable<int> IS_CAP_TH { get; set; }
        public Nullable<int> IS_CAP_THCS { get; set; }
        public Nullable<int> IS_CAP_THPT { get; set; }
        public Nullable<int> IS_CAP_GDTX { get; set; }
        public Nullable<int> IS_HOC_SINH_KHUYET_TAT { get; set; }
        public Nullable<int> IS_HOC_SINH_BAN_TRU { get; set; }
        public Nullable<int> IS_HOC_SINH_NOI_TRU { get; set; }
        public Nullable<int> IS_VUNG_DAC_BIET_KHO_KHAN { get; set; }
        public Nullable<int> IS_DAT_CHAT_LUONG_TOI_THIEU { get; set; }
        public Nullable<int> IS_2_BUOI_NGAY { get; set; }
        public Nullable<int> DIEN_TICH { get; set; }
        public Nullable<int> THU_TU { get; set; }
        public Nullable<decimal> NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<decimal> NGUOI_SUA { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<System.DateTime> NAM_THANH_LAP { get; set; }
        public Nullable<int> IS_DAY_NGHE_PHO_THONG { get; set; }
        public Nullable<int> IS_CO_LOP_KHONG_CHUYEN { get; set; }
        public Nullable<int> IS_KY_NANG_SONG_GDXH { get; set; }
    
        public virtual DM_MUC_DAT_CHUAN_QG_CLGD DM_MUC_DAT_CHUAN_QG_CLGD { get; set; }
        public virtual DM_NHOM_CAP_HOC DM_NHOM_CAP_HOC { get; set; }
        public virtual DM_TINH DM_TINH { get; set; }
        public virtual DM_TRUC_THUOC DM_TRUC_THUOC { get; set; }
        public virtual DM_XA DM_XA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOC_SINH> HOC_SINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOC_SINH_TOT_NGHIEP> HOC_SINH_TOT_NGHIEP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP> LOPs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOP_MON> LOP_MON { get; set; }
        public virtual NAM_HOC NAM_HOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAN_SU> NHAN_SU { get; set; }
        public virtual PHONG_GD PHONG_GD { get; set; }
        public virtual SO_GD SO_GD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONG_KET> TONG_KET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONG_KET_C1> TONG_KET_C1 { get; set; }
        public virtual DM_HUYEN DM_HUYEN { get; set; }
        public virtual DM_KHU_VUC DM_KHU_VUC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUC_KHOE_NUOI_DUONG> SUC_KHOE_NUOI_DUONG { get; set; }
        public virtual DM_LOAI_HINH DM_LOAI_HINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEM_TRUONG> DIEM_TRUONG { get; set; }
    }
}
