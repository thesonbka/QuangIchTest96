using DataAccess.IRepository;
using DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Repository
{
    public class HocSinhRepository
    {
        public List<ListItem> getLoaiHinh()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_LOAI_HINH
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }

        public List<ListItem> getKenhTangtruongCanNang()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_KENH_TANG_TRUONG_CAN_NANG
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getHocBantru()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_HOC_BAN_TRU
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getKhuVuc()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_KHU_VUC                  
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getLoaiKhuyetTat()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_LOAI_KHUYET_TAT
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getQuocTich()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_NUOC
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getDoiTuongChinhSach()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_DIEN_CHINH_SACH
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getNhomLop()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_KHOI
                        where obj.MA_CAP_HOC == "01"
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();            
        }
        public List<ListItem> getLop(string maKhoi)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.LOPs
                        where obj.MA_CAP_HOC == "01"
                        && obj.MA_KHOI ==maKhoi
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrangThaiHS()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRANG_THAI_HOC_SINH                        
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }

        public List<Form4ViewModel> getPage(string nhomLop,string lop,string trangThai, out int totalRecord)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.HOC_SINH
                        where (string.IsNullOrEmpty(nhomLop) || obj.MA_KHOI == nhomLop)
                        && (string.IsNullOrEmpty(lop) || obj.MA_LOP == lop)
                        && (string.IsNullOrEmpty(trangThai) || obj.MA_TRANG_THAI_HIEN_TAI == trangThai)
                        && obj.MA_CAP_HOC == "01"
                        select new Form4ViewModel
                        {
                            ID = obj.ID.ToString(),
                            THUTU = obj.THU_TU,
                            MA = obj.MA,
                            HOTEN = obj.HO_TEN,
                            NGAYSINH = obj.NGAY_SINH.ToString(),
                            GIOTINH = context.DM_GIOI_TINH.FirstOrDefault(p => p.MA == obj.MA_GIOI_TINH).TEN,    
                            DANTOC = context.DM_DAN_TOC.FirstOrDefault(p=>p.MA==obj.MA_DAN_TOC).TEN,
                            TRANGTHAI = context.DM_TRANG_THAI_HOC_SINH.FirstOrDefault(p => p.MA == obj.MA_TRANG_THAI_HIEN_TAI).TEN
                        };
            totalRecord = query.Count();
            return query.ToList();
        }      
    }
}
