using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModel
{
    public class Form5ViewModel
    {
        public string ID { get; set; }
        public string IDHOCSINH { get; set; }
        public string HOTEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string GIOITINH { get; set; }

        public double? CHIEUCAO { get; set; }

        public double? CANNANG { get; set; }
        public string TENCANTANGTRUONG { get; set; }
        public bool SUYDINHDUONGTHETHAPCOI { get; set; }
        public bool SUYDINHDUONGTHECOICOC { get; set; }
        public bool TREBIBEOPHI { get; set; }
       
    }
}
