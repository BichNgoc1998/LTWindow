using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class PositionBAL
    {
        PositionDAL dal = new PositionDAL();
        public List<PositionBEL> ReadPositionList()
        {
            List<PositionBEL> lstChuc = dal.ReadPositionList();
            return lstChuc;
        }
    }
}
