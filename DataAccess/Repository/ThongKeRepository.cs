using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.ViewModel;

namespace DataAccess.Repository
{
   public  class ThongKeRepository
    {
        //public int getMonth(DateTime current,DateTime namsinh)
        //{
        //    return Math.Abs((current.Month - namsinh.Month)) + 12 * (current.Year - namsinh.Year);
        //}
        public List<Form6ViewModel> getPage(string loaiHinh,string danToc,string gioiTinh, out int totalRecord)
        {
            List<Form6ViewModel> listGetPage = new List<Form6ViewModel>();
            var context = new BO_GIAO_DUC_TEMPEntities();
            List<string> listMASoGD = context.HOC_SINH.Where(p=>p.MA_SO_GD !=null).Select(p => p.MA_SO_GD).Distinct().ToList();
            int STT = 0;
            foreach (var item in listMASoGD)
            {
                STT++;
                Form6ViewModel detail = new Form6ViewModel();
                detail.STT = STT.ToString();
                detail.TENSOGIAODUC = context.SO_GD.Where(p => p.MA == item).Select(p=>p.TEN).FirstOrDefault();

                detail.NHATRETONGSOHOCSINH = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "16" && p.MA_SO_GD==item && (string.IsNullOrEmpty(danToc)||p.MA_DAN_TOC==danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH==gioiTinh) &&((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG==loaiHinh)))).Count();

                detail.NHATRE3TO12 = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "16" && p.MA_SO_GD == item && context.LOPs.Any(k=>k.MA ==p.MA_LOP && k.MA_NHOM_TUOI_MN=="01") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.NHATRE13TO24 = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "16" && p.MA_SO_GD == item && context.LOPs.Any(k => k.MA == p.MA_LOP && k.MA_NHOM_TUOI_MN == "02") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.NHATRE25TO36 = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "16" && p.MA_SO_GD == item && context.LOPs.Any(k => k.MA == p.MA_LOP && k.MA_NHOM_TUOI_MN == "03") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.NHATRE36TO = 0;

                detail.MAUGIAOTONGSOHOCSINH = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "17" && p.MA_SO_GD == item && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.MAUGIAOTREDUOI3T = 0;

                detail.MAUGIAOTRE3TO4T = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "17" && p.MA_SO_GD == item && context.LOPs.Any(k => k.MA == p.MA_LOP && k.MA_NHOM_TUOI_MN == "04") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.MAUGIAOTRE4T5T = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "17" && p.MA_SO_GD == item && context.LOPs.Any(k => k.MA == p.MA_LOP && k.MA_NHOM_TUOI_MN == "05") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.MAUGIAOTRE5T6T = context.HOC_SINH.Where(p => p.MA_CAP_HOC == "01" && p.MA_KHOI == "17" && p.MA_SO_GD == item && context.LOPs.Any(k => k.MA == p.MA_LOP && k.MA_NHOM_TUOI_MN == "06") && (string.IsNullOrEmpty(danToc) || p.MA_DAN_TOC == danToc) && (string.IsNullOrEmpty(gioiTinh) || p.MA_GIOI_TINH == gioiTinh) && ((string.IsNullOrEmpty(loaiHinh) || context.TRUONGs.Any(k => k.ID == p.ID_TRUONG && k.MA_LOAI_HINH_TRUONG == loaiHinh)))).Count();

                detail.MAUGIAOTRETEN6T = 0;               
                listGetPage.Add(detail);
            }            
            totalRecord = listGetPage.Count();
            return listGetPage.OrderByDescending(p=>p.NHATRETONGSOHOCSINH+ p.MAUGIAOTONGSOHOCSINH).ToList();           
        }
    }
}
