using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System.Collections.Generic;

namespace QLNHANVIEN.BAL
{
    public class StatusBAL
    {
        StatusDAL dal = new StatusDAL();

        public List<StatusBEL> ReadStatusList()
        {
            List<StatusBEL> lstTime = dal.ReadStatusList();
            return lstTime;
        }
    }
}
