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
    
    public partial class DM_XA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_XA()
        {
            this.HOC_SINH = new HashSet<HOC_SINH>();
            this.NHAN_SU = new HashSet<NHAN_SU>();
            this.TRUONGs = new HashSet<TRUONG>();
        }
    
        public decimal ID { get; set; }
        public string MA { get; set; }
        public int MA_NAM_HOC { get; set; }
        public string MA_TINH { get; set; }
        public Nullable<decimal> ID_HUYEN { get; set; }
        public string MA_HUYEN { get; set; }
        public string TEN { get; set; }
        public Nullable<int> THU_TU { get; set; }
        public Nullable<decimal> NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<decimal> NGUOI_SUA { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public string CAP { get; set; }
    
        public virtual DM_TINH DM_TINH { get; set; }
        public virtual NAM_HOC NAM_HOC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOC_SINH> HOC_SINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAN_SU> NHAN_SU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUONG> TRUONGs { get; set; }
        public virtual DM_HUYEN DM_HUYEN { get; set; }
    }
}
