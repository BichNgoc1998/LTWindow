using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class DegreeBAL
    {
        public List<DegreeBEL> ReadDegreeList()
        {
            // Instantiate the DAL class where appropriate
            DegreeDAL dal = new DegreeDAL(); // Assuming you have a DegreeDAL class

            List<DegreeBEL> lstBang = dal.ReadDegreeList();
            return lstBang;
        }
    }
}
