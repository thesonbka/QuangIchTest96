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
    
    public partial class DM_LOAI_HINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_LOAI_HINH()
        {
            this.TRUONGs = new HashSet<TRUONG>();
        }
    
        public string MA { get; set; }
        public string TEN { get; set; }
        public Nullable<int> IS_MN { get; set; }
        public Nullable<int> IS_C1 { get; set; }
        public Nullable<int> IS_C2 { get; set; }
        public Nullable<int> IS_C3 { get; set; }
        public Nullable<int> IS_GDTX { get; set; }
        public Nullable<int> THU_TU { get; set; }
        public Nullable<decimal> NGUOI_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<decimal> NGUOI_SUA { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRUONG> TRUONGs { get; set; }
    }
}
