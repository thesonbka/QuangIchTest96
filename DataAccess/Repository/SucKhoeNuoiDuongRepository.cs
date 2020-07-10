using DataAccess.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class SucKhoeNuoiDuongRepository
    {
        public List<Form5ViewModel> getPage(string nhomLop, string lop, out int totalRecord)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.SUC_KHOE_NUOI_DUONG    
                        where (string.IsNullOrEmpty(nhomLop) ||obj.MA_KHOI==nhomLop)
                        &&(string.IsNullOrEmpty(lop) || obj.MA_LOP ==lop)
                        && obj.MA_CAP_HOC =="01"
                        select new Form5ViewModel
                        {
                            ID = obj.ID.ToString(),
                            IDHOCSINH = obj.ID_HOC_SINH.ToString(),
                            HOTEN = context.HOC_SINH.FirstOrDefault(p=>p.ID==obj.ID_HOC_SINH).HO_TEN,
                            NGAYSINH = context.HOC_SINH.FirstOrDefault(p => p.ID == obj.ID_HOC_SINH).NGAY_SINH,
                            GIOITINH = context.DM_GIOI_TINH.FirstOrDefault(k=>k.MA ==context.HOC_SINH.FirstOrDefault(p=>p.ID==obj.ID_HOC_SINH).MA_GIOI_TINH).TEN,
                            CHIEUCAO = obj.CHIEU_CAO,
                            CANNANG = obj.CAN_NANG,
                            TENCANTANGTRUONG = context.DM_KENH_TANG_TRUONG_CAN_NANG.FirstOrDefault(p=>p.MA==obj.MA_KENH_TANG_TRUONG_CAN_NANG_KY1).TEN,
                            
                           
                        };
          
            totalRecord = query.Count();
            return query.ToList();
        }

    }
}
