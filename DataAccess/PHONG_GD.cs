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
    
    public partial class PHONG_GD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHONG_GD()
        {
            this.HOC_SINH = new HashSet<HOC_SINH>();
            this.HOC_SINH_TOT_NGHIEP = new HashSet<HOC_SINH_TOT_NGHIEP>();
            this.LOPs = new HashSet<LOP>();
            this.LOP_MON = new HashSet<LOP_MON>();
            this.NHAN_SU = new HashSet<NHAN_SU>();
            this.TONG_KET_C1 = new HashSet<TONG_KET_C1>();
            this.TONG_KET = new HashSet<TONG_KET>();
            this.TRUONGs = new HashSet<TRUONG>();
            this.SUC_KHOE_NUOI_DUONG = new HashSet<SUC_KHOE_NUOI_DUONG>();
            this.DIEM_TRUONG = new HashSet<DIEM_TRUONG>();
        }
    
        public decimal ID { get; set; }
        public string MA { get; set; }
        public int MA_NAM_HOC { get; set; }
        public string MA_SO_GD { get; set; }
        public string MA_TABMIS { get; set; }
        public string MA_DVSDCS { get; set; }
        public string TEN { get; set; }
        public string MA_TINH { get; set; }
        public Nullable<decimal> ID_HUYEN { get; set; }
        public string MA_HUYEN { get; set; }
        public string DIA_CHI { get; set; }
        public string DIEN_THOAI { get; set; }
        public string EMAIL { get; set; }
        public string FAX { get; set; }
        public string WEBSITE { get; set; }
        public string TRUONG_PHONG { get; set; }
        public string DIEN_THOAI_TRUONG_PHONG { get; set; }
        public string EMAIL_TRUONG_PHONG { get; set; }
        public string CAN_BO_PHU_TRACH { get; set; }
        public string DIEN_THOAI_CAN_BO_PHU_TRACH { get; set; }
        public string EMAIL_CAN_BO_PHU_TRACH { get; set; }
        public Nullable<int> THU_TU { get; set; }
        public Nullable<int> TRANG_THAI { get; set; }
        public Nullable<decimal> NGUOI_SUA { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<decimal> NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
    
        public virtual DM_TINH DM_TINH { get; set; }
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
        public virtual SO_GD SO_GD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONG_KET_C1> TONG_KET_C1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TONG_KET> TONG_KET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUONG> TRUONGs { get; set; }
        public virtual DM_HUYEN DM_HUYEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SUC_KHOE_NUOI_DUONG> SUC_KHOE_NUOI_DUONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIEM_TRUONG> DIEM_TRUONG { get; set; }
    }
}
