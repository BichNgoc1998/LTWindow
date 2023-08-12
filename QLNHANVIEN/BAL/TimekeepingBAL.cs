using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class TimekeepingBAL
    {
        TimekeepingDAL dal = new TimekeepingDAL();
        public List<TimekeepingBEL> ReadTimekeeping()
        {
            List<TimekeepingBEL> lstTime = dal.ReadTimekeeping();
            return lstTime;
        }

        public void NewTimekeeping(TimekeepingBEL nv)
        {
            dal.NewTimekeeping(nv);
        }

        public void DeleteTimekeeping(TimekeepingBEL nv)
        {
            dal.DeleteTimekeeping(nv);
        }

        public void EditTimekeeping(TimekeepingBEL nv)
        {
            dal.EditTimekeeping(nv);
        }

        internal TimekeepingBEL GetTimekeepingId(int TimekeepingId)
        {
            List<TimekeepingBEL> Timekeepings = ReadTimekeeping();
            return Timekeepings.FirstOrDefault(c => c.Manv == TimekeepingId);
        }
    }
}
