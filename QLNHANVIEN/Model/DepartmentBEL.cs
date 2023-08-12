using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class DepartmentBEL
    {
        public int Maphong { get; set; }
        public string Tenphong { get; set; }
        public List<EmployeeBEL> Employees { get; set; }
    }
}
