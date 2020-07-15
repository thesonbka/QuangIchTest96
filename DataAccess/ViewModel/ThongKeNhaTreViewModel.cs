using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
   public class ThongKeNhaTreViewModel
    {
        public int Type { get; set; }   
        public string TT { get; set; }
        public string CHITIEU { get; set; }
        public string DONVITINH { get; set; }
        public string MASO { get; set; }
        public int TongSoTotal { get; set; }
        public int TongSoCongLap { get; set; }
        public int TongSoTuThuc { get; set; }
        public int TongSoDanLap { get; set; }

    }
}
