using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class LoginBAL
    {
        LoginDAL dal = new LoginDAL();
        public List<LoginBEL> ReadCustomer()
        {
            List<LoginBEL> lstAcc = dal.ReadAccount();
            return lstAcc;
        }
        internal LoginBEL GetAccountById(string Acc_name)
        {
            throw new NotImplementedException();
            //List<LoginBEL> accounts = ReadAccount();
            //return accounts.FirstOrDefault(c => c.Id == acc_Id);
        }
    }
}
