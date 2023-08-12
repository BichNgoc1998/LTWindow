using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class TimekeepingBEL
    {
        public int Manv { get; set; }
        public string Tennv { get; set; }
        public StatusBEL Tinhtrang { get; set; }
        public string Tentt
        {
            get { return Tinhtrang.Tentt; }
        }
        public string Ngay { get; set; }
    }
}
