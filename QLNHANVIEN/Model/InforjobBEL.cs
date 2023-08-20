using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class InforjobBEL
    {
        public int Manv { get; set; }
        public string Ngvaolam { get; set; }
        public string Congviec { get; set; }
        public float Muclg { get; set; }
        public int Hso { get; set; }
        public int Tknh { get; set; }
        public string Nghang { get; set; }
        public TypeoemBEL Loai { get; set; }
        public string TenLoaiNV
        {
            get { return Loai.Tenloai; }
        }
        public PositionBEL Chucvu { get; set; }
        public string TenChucVu
        {
            get { return Chucvu.Tench; }
        }
        public DepartmentBEL Phong { get; set; }
        public string TenPhong
        {
            get { return Phong.Tenphong; }
        }
    }
}
