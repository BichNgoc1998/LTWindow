using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class EmployeeBEL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ngsinh { get; set; }
        public string Cccd { get; set; }
        public string Ngcap { get; set; }
        public string Gioitinh { get; set; }
        public string Image { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public int Sdt { get; set; }
        public int MaBang { get; set; }
        public int MaPhong { get; set; }
        public DegreeBEL Bang { get; set; }
        public string TenBang
        {
            get { return Bang.Tenbang; }
        }
        public DepartmentBEL Phong { get; set; }
        public string TenPhong
        {
            get { return Phong.Tenphong; }
        }
    }
}
