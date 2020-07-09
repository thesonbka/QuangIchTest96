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
        public Form3InsertUpdateViewModel getById(int itemID)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.NHAN_SU
                        where obj.ID == itemID
                        select new Form3InsertUpdateViewModel
                        {
                            MA = obj.MA,
                            EMAIL = obj.EMAIL,
                            HO_TEN = obj.HO_TEN,
                            DI_DONG = obj.DI_DONG,
                            NGAY_SINH = obj.NGAY_SINH,
                            MA_DAN_TOC = obj.MA_DAN_TOC,
                            MA_TRANG_THAI_CAN_BO = obj.MA_TRANG_THAI_CAN_BO,
                            MA_TON_GIAO = obj.MA_TON_GIAO,
                            SO_CMTND = obj.SO_CMTND,
                            MA_TINH = obj.MA_TINH,
                            MA_HUYEN = obj.MA_HUYEN,
                            MA_XA = obj.MA_XA,
                            QUE_QUAN = obj.QUE_QUAN,
                            MA_GIOI_TINH = obj.MA_GIOI_TINH,
                            MA_NHOM_CAN_BO = obj.MA_NHOM_CAN_BO,
                            MA_HINH_THUC_HOP_DONG = obj.MA_HINH_THUC_HOP_DONG,
                            MA_LOAI_CAN_BO = obj.MA_LOAI_CAN_BO,
                            MA_NGACH = obj.MA_NGACH,
                            MA_MON_DAY = obj.MA_MON_DAY,
                            MA_SO_NGACH = obj.MA_SO_NGACH,
                            PC_THU_HUT = obj.PC_THU_HUT,
                            HE_SO_LUONG = obj.HE_SO_LUONG,
                            PC_THAM_NIEN = obj.PC_THAM_NIEN,
                            NGAY_HUONG_LUONG = obj.NGAY_HUONG_LUONG,
                            MA_BAC_LUONG = obj.MA_BAC_LUONG,
                            MA_BOI_DUONG_TX = obj.MA_BOI_DUONG_TX,
                            MA_NGOAI_NGHU = obj.MA_NGOAI_NGU,
                            MA_CHUYEN_MON_1 = obj.MA_CHUYEN_MON_1,
                            MA_TRINH_DO_CHUYEN_MON = obj.MA_TRINH_DO_CHUYEN_MON,
                            MA_TRINH_DO_NGOAI_NGU = obj.MA_TRINH_DO_NGOAI_NGU,
                            MA_TRINH_DO_1 = obj.MA_TRINH_DO_1,
                            MA_TRINH_DO_LLCT = obj.MA_TRINH_DO_LLCT,
                            MA_TRINH_DO_TIN_HOC = obj.MA_TRINH_DO_TIN_HOC,
                            MA_CHUYEN_MON_2 = obj.MA_CHUYEN_MON_2,
                            MA_TRINH_DO_QLGD = obj.MA_TRINH_DO_QLGD,
                            MA_TRINH_DO_2 = obj.MA_TRINH_DO_2    
                        };
            return query.FirstOrDefault();
        }
        public List<ListItem> getDanToc()
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_DAN_TOC
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();

        }
        public List<ListItem> getTonGiao()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TON_GIAO
                        orderby obj.MA descending
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrangThaiCB()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRANG_THAI_CAN_BO
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getGioiTinh()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_GIOI_TINH
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTinh()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TINH
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getHuyen(String maTinh)
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_HUYEN
                        where obj.MA_TINH == maTinh
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getXa(string maTinh,string maHuyen)
        {
            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_XA
                        where obj.MA_TINH ==maTinh
                        && obj.MA_HUYEN == maHuyen
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();

        }
        public List<ListItem> getVitri()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_NHOM_CAN_BO
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getNhomChucVu()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_LOAI_CAN_BO
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getHinhThucHopDong()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_HINH_THUC_HOP_DONG
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getNgach()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_NGACH
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getDayNhomLop()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_MON_DAY_GV
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getBacLuong()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_BAC_LUONG
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getNgoaiNgu()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_NGOAI_NGU
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getChuyenMon()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_CHUYEN_MON
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoDaoTaoNgoaiNghu()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO_NGOAI_NGU
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoChuyenMonNghiepVu()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoChinh()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoLLCT()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO_LLCT
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoTinHoc()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO_TIN_HOC
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getTrinhDoQLGD()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_TRINH_DO_QLGD
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
        }
        public List<ListItem> getBoiDuongTX()
        {

            var context = new BO_GIAO_DUC_TEMPEntities();
            var query = from obj in context.DM_BOI_DUONG_TX
                        select new ListItem
                        {
                            MA = obj.MA,
                            TEN = obj.TEN
                        };
            return query.ToList();
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
