using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlCommandQuangIch
{
    public class Form3Command
    {
        public static string queryGetAll = @"SELECT COUNT(0) OVER() AS TOTAL_ROW, nhansu.ID,nhansu.MA_CAP_HOC AS MACAPHOC, nhansu.MA AS MA ,nhansu.HO_TEN AS HOTEN ,nhansu.NGAY_SINH AS NGAYSINH,gioitinh.TEN AS GIOITINH
        ,trangthai.TEN AS TRANGTHAI,dantoc.TEN AS DANTOC,nhomcanbo.TEN AS TENVITRI,loaicanbo.TEN AS TENNHOM,
        hinhthuc.TEN AS HINHTHUC,trinhdo.TEN AS TRINHDO
        FROM dbo.NHAN_SU AS nhansu LEFT JOIN dbo.DM_GIOI_TINH AS gioitinh ON nhansu.MA_GIOI_TINH = gioitinh.MA
        LEFT JOIN dbo.DM_TRANG_THAI_CAN_BO AS trangthai ON nhansu.MA_TRANG_THAI_CAN_BO = trangthai.MA
        LEFT JOIN dbo.DM_DAN_TOC AS dantoc ON nhansu.MA_DAN_TOC = dantoc.MA 
        LEFT JOIN dbo.DM_NHOM_CAN_BO AS nhomcanbo ON nhansu.MA_NHOM_CAN_BO = nhomcanbo.MA
        LEFT JOIN dbo.DM_LOAI_CAN_BO AS loaicanbo ON nhansu.MA_LOAI_CAN_BO = loaicanbo.MA
        LEFT JOIN dbo.DM_HINH_THUC_HOP_DONG AS hinhthuc ON nhansu.MA_HINH_THUC_HOP_DONG = hinhthuc.MA
        LEFT JOIN dbo.DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU AS trinhdo ON nhansu.MA_TRINH_DO_CHUYEN_MON = trinhdo.MA ORDER BY nhansu.MA OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

        public static string queryGetMaCapHoc = @"SELECT COUNT(0) OVER() AS TOTAL_ROW, nhansu.ID,nhansu.MA_CAP_HOC AS MACAPHOC, nhansu.MA AS MA ,nhansu.HO_TEN AS HOTEN ,nhansu.NGAY_SINH AS NGAYSINH,gioitinh.TEN AS GIOITINH
        ,trangthai.TEN AS TRANGTHAI,dantoc.TEN AS DANTOC,nhomcanbo.TEN AS TENVITRI,loaicanbo.TEN AS TENNHOM,
        hinhthuc.TEN AS HINHTHUC,trinhdo.TEN AS TRINHDO
        FROM dbo.NHAN_SU AS nhansu LEFT JOIN dbo.DM_GIOI_TINH AS gioitinh ON nhansu.MA_GIOI_TINH = gioitinh.MA
        LEFT JOIN dbo.DM_TRANG_THAI_CAN_BO AS trangthai ON nhansu.MA_TRANG_THAI_CAN_BO = trangthai.MA
        LEFT JOIN dbo.DM_DAN_TOC AS dantoc ON nhansu.MA_DAN_TOC = dantoc.MA 
        LEFT JOIN dbo.DM_NHOM_CAN_BO AS nhomcanbo ON nhansu.MA_NHOM_CAN_BO = nhomcanbo.MA
        LEFT JOIN dbo.DM_LOAI_CAN_BO AS loaicanbo ON nhansu.MA_LOAI_CAN_BO = loaicanbo.MA
        LEFT JOIN dbo.DM_HINH_THUC_HOP_DONG AS hinhthuc ON nhansu.MA_HINH_THUC_HOP_DONG = hinhthuc.MA
        LEFT JOIN dbo.DM_TRINH_DO_CHUYEN_MON_NGHIEP_VU AS trinhdo ON nhansu.MA_TRINH_DO_CHUYEN_MON = trinhdo.MA WHERE nhansu.MA_CAP_HOC = '{2}' ORDER BY nhansu.MA OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

    }
}
