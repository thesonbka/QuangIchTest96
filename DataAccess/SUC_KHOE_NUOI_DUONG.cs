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
    
    public partial class SUC_KHOE_NUOI_DUONG
    {
        public decimal ID { get; set; }
        public Nullable<int> MA_NAM_HOC { get; set; }
        public string MA_SO_GD { get; set; }
        public Nullable<decimal> ID_PHONG_GD { get; set; }
        public string MA_PHONG_GD { get; set; }
        public Nullable<decimal> ID_TRUONG { get; set; }
        public string MA_TRUONG { get; set; }
        public string MA_CAP_HOC { get; set; }
        public string MA_KHOI { get; set; }
        public Nullable<decimal> ID_LOP { get; set; }
        public string MA_LOP { get; set; }
        public Nullable<decimal> ID_HOC_SINH { get; set; }
        public string MA_HOC_SINH { get; set; }
        public Nullable<int> IS_KHAM_SUC_KHOE_DINH_KY_KY1 { get; set; }
        public Nullable<int> IS_THEO_DOI_BIEU_DO_CAN_NANG_KY1 { get; set; }
        public string MA_KENH_TANG_TRUONG_CAN_NANG_KY1 { get; set; }
        public Nullable<int> IS_THEO_DOI_BIEU_DO_CHIEU_CAO_KY1 { get; set; }
        public Nullable<int> IS_SUY_DINH_DUONG_THE_THAP_COI_KY1 { get; set; }
        public Nullable<int> IS_KHAM_SUC_KHOE_DINH_KY_KY2 { get; set; }
        public Nullable<int> IS_THEO_DOI_BIEU_DO_CAN_NANG_KY2 { get; set; }
        public string MA_KENH_TANG_TRUONG_CAN_NANG_KY2 { get; set; }
        public Nullable<int> IS_THEO_DOI_BIEU_DO_CHIEU_CAO_KY2 { get; set; }
        public Nullable<int> IS_SUY_DINH_DUONG_THE_THAP_COI_KY2 { get; set; }
        public Nullable<System.DateTime> NGAY_TAO { get; set; }
        public Nullable<System.DateTime> NGAY_SUA { get; set; }
        public Nullable<decimal> NGUOI_TAO { get; set; }
        public Nullable<decimal> NGUOI_SUA { get; set; }
    
        public virtual DM_CAP_HOC DM_CAP_HOC { get; set; }
        public virtual HOC_SINH HOC_SINH { get; set; }
        public virtual LOP LOP { get; set; }
        public virtual NAM_HOC NAM_HOC { get; set; }
        public virtual PHONG_GD PHONG_GD { get; set; }
        public virtual SO_GD SO_GD { get; set; }
        public virtual TRUONG TRUONG { get; set; }
    }
}
