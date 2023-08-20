using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class PositionBEL
    {
        public int Mach { get; set; }
        public string Tench { get; set; }
        public List<InforjobBEL> Inforjobs { get; set; }
    }
}
