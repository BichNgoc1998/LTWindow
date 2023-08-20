using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class TypeoemBEL
    {
        public int Maloai { get; set; }
        public string Tenloai { get; set; }
        public List<InforjobBEL> Inforjobs { get; set; }
    }
}
