using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlCommandQuangIch
{
   public class Form5Command
    {
        public static string insertHocSinhToSucKhoeNuoiDuong = @"INSERT INTO suc_khoe_nuoi_duong (ID_HOC_SINH,MA_HOC_SINH,MA_CAP_HOC,MA_KHOI,MA_LOP)
SELECT ID,MA,MA_CAP_HOC,MA_KHOI,MA_LOP FROM dbo.HOC_SINH WHERE MA_CAP_HOC ='01' AND MA_KHOI = '{0}' AND MA_LOP = '{1}'";
    }
}
