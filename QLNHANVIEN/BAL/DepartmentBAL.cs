using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class DepartmentBAL
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            // Instantiate the DAL class where appropriate
            DepartmentDAL dal = new DepartmentDAL(); // Assuming you have a DepartmentDAL class

            List<DepartmentBEL> lstPhong = dal.ReadDepartmentList();
            return lstPhong;
        }
    }
}
