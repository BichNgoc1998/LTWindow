using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class DegreeBEL
    {
        public int Mabang { get; set; }
        public string Tenbang { get; set; }
        public List<EmployeeBEL> Employees { get; set; }
    }
}
