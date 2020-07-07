using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlCommandQuangIch
{
    public class Form2Command
    {
        public static string queryNhomlop = @" SELECT MA,TEN FROM DM_KHOI where MA_CAP_HOC = '01'";
        public static string queryNhomtre = @"SELECT MA,TEN FROM dbo.DM_NHOM_TUOI_MN WHERE MA_NHOM_TRE='{0}'";
        public static string queryGridview = @"SELECT COUNT(0) OVER() AS TOTAL_ROW, lop.ID,lop.MA,lop.TEN,khoi.TEN AS TENNHOMLOP,nhomtuoi.TEN AS TENNHOMTUOI,diemtruong.ten AS TENDIEMTRUONG,lop.IS_BAN_TRU,lop.THU_TU,lop.MA_CAP_HOC,lop.MA_DIEM_TRUONG,lop.MA_NHOM_TUOI_MN,lop.ID_TRUONG,lop.MA_TRUONG,lop.ID_DIEM_TRUONG
        FROM dbo.LOP AS lop
        LEFT JOIN dbo.DM_NHOM_TUOI_MN AS nhomtuoi  ON  lop.MA_NHOM_TUOI_MN = nhomtuoi.MA LEFT JOIN dbo.DM_KHOI AS khoi
        ON nhomtuoi.MA_NHOM_TRE = khoi.MA LEFT JOIN dbo.DIEM_TRUONG AS diemtruong ON lop.MA_DIEM_TRUONG = diemtruong.MA WHERE lop.MA_CAP_HOC='01' and nhomtuoi.MA_NHOM_TRE='{0}'  AND lop.MA_NHOM_TUOI_MN='{1}'
        ORDER BY lop.MA OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY";
        public static string queryGridviewComboxNhomLop = @"SELECT COUNT(0) OVER() AS TOTAL_ROW, lop.ID,lop.MA,lop.TEN,khoi.TEN AS TENNHOMLOP,nhomtuoi.TEN AS TENNHOMTUOI,diemtruong.ten AS TENDIEMTRUONG,lop.IS_BAN_TRU,lop.THU_TU,lop.MA_CAP_HOC,lop.MA_DIEM_TRUONG,lop.MA_NHOM_TUOI_MN,lop.ID_TRUONG,lop.MA_TRUONG,lop.ID_DIEM_TRUONG
        FROM dbo.LOP AS lop
        LEFT JOIN dbo.DM_NHOM_TUOI_MN AS nhomtuoi  ON  lop.MA_NHOM_TUOI_MN = nhomtuoi.MA LEFT JOIN dbo.DM_KHOI AS khoi
        ON nhomtuoi.MA_NHOM_TRE = khoi.MA LEFT JOIN dbo.DIEM_TRUONG AS diemtruong ON lop.MA_DIEM_TRUONG = diemtruong.MA WHERE lop.MA_CAP_HOC='01' and nhomtuoi.MA_NHOM_TRE='{0}'  
         ORDER BY lop.MA OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
        public static string queryAll = @"SELECT COUNT(0) OVER() AS TOTAL_ROW, lop.ID,lop.MA,lop.TEN,khoi.TEN AS TENNHOMLOP,nhomtuoi.TEN AS TENNHOMTUOI,diemtruong.ten AS TENDIEMTRUONG,lop.IS_BAN_TRU,lop.THU_TU,lop.MA_CAP_HOC,lop.MA_DIEM_TRUONG,lop.MA_NHOM_TUOI_MN,lop.ID_TRUONG,lop.MA_TRUONG,lop.ID_DIEM_TRUONG
        FROM dbo.LOP AS lop
        LEFT JOIN dbo.DM_NHOM_TUOI_MN AS nhomtuoi  ON  lop.MA_NHOM_TUOI_MN = nhomtuoi.MA LEFT JOIN dbo.DM_KHOI AS khoi
        ON nhomtuoi.MA_NHOM_TRE = khoi.MA LEFT JOIN dbo.DIEM_TRUONG AS diemtruong ON lop.MA_DIEM_TRUONG = diemtruong.MA WHERE lop.MA_CAP_HOC='01' 
        ORDER BY lop.MA OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";

        public static string queryDeleteId = @"delete from dbo.LOP WHERE ID IN ({0})";

        public static string queryGetById = @"SELECT lop.ID,lop.MA,lop.MA_KHOI AS MAKHOI,lop.TEN,lop.IS_DAY_2_BUOI_NGAY,khoi.TEN AS TENNHOMLOP,nhomtuoi.TEN AS TENNHOMTUOI,diemtruong.ten AS TENDIEMTRUONG,lop.IS_BAN_TRU,lop.THU_TU,lop.MA_CAP_HOC,lop.MA_DIEM_TRUONG,lop.MA_NHOM_TUOI_MN,lop.ID_TRUONG,lop.MA_TRUONG,lop.ID_DIEM_TRUONG
        FROM dbo.LOP AS lop
        LEFT JOIN dbo.DM_NHOM_TUOI_MN AS nhomtuoi  ON  lop.MA_NHOM_TUOI_MN = nhomtuoi.MA LEFT JOIN dbo.DM_KHOI AS khoi
        ON nhomtuoi.MA_NHOM_TRE = khoi.MA LEFT JOIN dbo.DIEM_TRUONG AS diemtruong ON lop.MA_DIEM_TRUONG = diemtruong.MA WHERE lop.ID='{0}' 
        ";

        public static string queryComboboxDiemtruong = @"SELECT MA,TEN  FROM dbo.DIEM_TRUONG WHERE ID_TRUONG = {0} ";

        public static string queryUpdateRecord = @"UPDATE lop SET MA_KHOI='{0}',MA_NHOM_TUOI_MN='{1}',TEN='{2}',THU_TU {3},IS_BAN_TRU = {4},IS_DAY_2_BUOI_NGAY {5},MA_DIEM_TRUONG {6} WHERE ID ={7}";

        public static string queryAddRecord = @"INSERT INTO lop(MA,MA_SO_GD,MA_TRUONG,MA_NAM_HOC,MA_KHOI,MA_NHOM_TUOI_MN,TEN,THU_TU,IS_BAN_TRU,IS_DAY_2_BUOI_NGAY,MA_DIEM_TRUONG,MA_CAP_HOC)
VALUES " + "('{0}','{1}','{2}',{3},'{4}','{5}','{6}',{7},{8},{9},{10},'{11}')";
    }
}
