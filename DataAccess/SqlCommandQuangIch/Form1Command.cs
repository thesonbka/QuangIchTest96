using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlCommandQuangIch
{
    public class Form1Command
    {        
        public static string queryComboboxCapHoc = @"Select MA,TEN FROM DM_CAP_HOC ORDER BY  MA DESC ";
        public static string queryGetCaphoc = @"SELECT COUNT(0) OVER() AS TOTAL_ROW,MONHOC.ID, MONHOC.MA,MONHOC.TEN,CAPHOC.TEN," + "CASE WHEN MONHOC.KIEU_MON_HOC =1 THEN N'Tính điểm '"+ "WHEN MONHOC.KIEU_MON_HOC = 2 THEN N'Nhận xét'"+ "ELSE N'' END AS KIEUMON,"+ "MONHOC.THU_TU FROM dbo.DM_MON_HOC AS MONHOC LEFT JOIN dbo.DM_CAP_HOC AS CAPHOC ON MONHOC.MA_CAP_HOC = CAPHOC.MA"+ " WHERE CAPHOC.MA = {0}  ORDER BY MONHOC.MA OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY";
        public static string queryGetAll = @"SELECT COUNT(0) OVER() AS TOTAL_ROW,MONHOC.ID, MONHOC.MA,MONHOC.TEN,CAPHOC.TEN," + "CASE WHEN MONHOC.KIEU_MON_HOC =1 THEN N'Tính điểm '" + "WHEN MONHOC.KIEU_MON_HOC = 2 THEN N'Nhận xét'" + "ELSE N'' END AS KIEUMON," + "MONHOC.THU_TU FROM dbo.DM_MON_HOC AS MONHOC LEFT JOIN dbo.DM_CAP_HOC AS CAPHOC ON MONHOC.MA_CAP_HOC = CAPHOC.MA" + "  ORDER BY MONHOC.MA OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY";
        public static string deleteMonhocId = @"delete from dbo.DM_MON_HOC WHERE ID IN ({0})";
        public static string queryAddRecord = @"insert into dm_mon_hoc" + "(MA,TEN,MA_CAP_HOC,KIEU_MON_HOC,THU_TU) " + "VALUES " + "('{0}','{1}','{2}' {3} {4})";
        public static string queryUpdateRecord = @"UPDATE dbo.DM_MON_HOC SET MA_CAP_HOC='{1}',KIEU_MON_HOC={2},THU_TU {3} WHERE ID={0}";
        public static string queryGetById = @"SELECT ID,MA,TEN,MA_CAP_HOC,KIEU_MON_HOC,THU_TU FROM dbo.DM_MON_HOC  WHERE ID= {0} ";
    }
}
