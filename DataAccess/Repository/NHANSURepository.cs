using DataAccess.IRepository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class NHANSURepository:EFRepository<NHAN_SU>
    {
        
        
        public NHANSURepository()
        {
            
        }
        public List<Form3ViewModel> GetPage(string MADINHDANH, string HOTEN, string CAPHOC,  out int totalRecord)
        {
            
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.NHAN_SU
                        where (string.IsNullOrEmpty(MADINHDANH)||obj.MA.Contains(MADINHDANH))
                        &&(string.IsNullOrEmpty(HOTEN)|| obj.HO_TEN.Contains(HOTEN))
                        &&(string.IsNullOrEmpty(CAPHOC)|| obj.MA_CAP_HOC == CAPHOC)
                       
                        orderby obj.MA
                        select new Form3ViewModel
                        {
                            ID = obj.ID.ToString(),
                            MA = obj.MA,
                            HOTEN = obj.HO_TEN,
                            NGAYSINH = obj.NGAY_SINH.HasValue?obj.NGAY_SINH.Value.ToString():"",                          
                            GIOITINH = obj.DM_GIOI_TINH.TEN,
                            TRANGTHAI = obj.DM_TRANG_THAI_CAN_BO.TEN,
                            DANTOC = context.DM_DAN_TOC.FirstOrDefault(t=>t.MA==obj.MA_DAN_TOC).TEN,
                            TENVITRI = obj.DM_NHOM_CAN_BO.TEN,
                            TENNHOM = obj.DM_LOAI_CAN_BO.TEN,
                            HINHTHUC = obj.DM_HINH_THUC_HOP_DONG.TEN,
                            TRINHDO = obj.DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU.TEN,
                            MACAPHOC = context.DM_CAP_HOC.FirstOrDefault(r=>r.MA==obj.MA_CAP_HOC).TEN,

                        };
            totalRecord = query.Count();
            return query.ToList();
                        





        }
        public NHAN_SU GetById(int Id)
        {
            try
            {
                BO_GIAO_DUC_TEMPEntities context = new BO_GIAO_DUC_TEMPEntities();
                return context.NHAN_SU.First(dk => dk.ID == Id);
            }
            catch { return null; }
        }
        public int DeleteById(int Id)
        {
            try
            {
                NHAN_SU entity = this.GetById(Id);
                if (entity != null)
                    this.Delete(entity);
                return 1;
            }
            catch { return 0; }
        }

    }
}
