using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class StatusDAL: DBConnection
    {
        public List<StatusBEL> ReadStatusList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from tinhtrang", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<StatusBEL> lstTT = new List<StatusBEL>();
            while (reader.Read())
            {
                StatusBEL tt = new StatusBEL();
                tt.Matt = int.Parse(reader["matt"].ToString());
                tt.Tentt = reader["tentt"].ToString();
                lstTT.Add(tt);
            }
            conn.Close();
            return lstTT;
        }

        public StatusBEL ReadStatus(int matt)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from tinhtrang where matt=" + matt.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            StatusBEL tt = new StatusBEL();
            if (reader.HasRows && reader.Read())
            {
                tt.Matt = int.Parse(reader["matt"].ToString());
                tt.Tentt = reader["tentt"].ToString();
            }
            conn.Close();
            return tt;
        }
    }
}
