using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class LoginDAL:DBConnection
    {
        public List<LoginBEL> ReadAccount()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Account", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<LoginBEL> lstAcc = new List<LoginBEL>();
            while (reader.Read())
            {
                LoginBEL acc = new LoginBEL();
                acc.Acc_name = reader["Acc_name"].ToString();
                acc.Acc_password = reader["Acc_password"].ToString();
                lstAcc.Add(acc);
            }

            conn.Close();
            return lstAcc;
        }
    }
}
