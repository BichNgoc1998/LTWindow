﻿using QLNHANVIEN.DAL;
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
            DegreeDAL dal = new DegreeDAL();

            List<DegreeBEL> lstBang = dal.ReadDegreeList();
            return lstBang;
        }
    }
}
