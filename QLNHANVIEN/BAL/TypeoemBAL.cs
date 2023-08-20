using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class TypeoemBAL
    {
        TypeoemDAL dal = new TypeoemDAL();
        public List<TypeoemBEL> ReadTypeList()
        {
            List<TypeoemBEL> lstLoai = dal.ReadTypeList();
            return lstLoai;
        }
    }
}
