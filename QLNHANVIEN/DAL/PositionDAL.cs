using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class PositionDAL : DBConnection
    {
        public List<PositionBEL> ReadPositionList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from chucvu", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<PositionBEL> lstChuc = new List<PositionBEL>();
            while (reader.Read())
            {
                PositionBEL chuc = new PositionBEL();
                chuc.Mach = int.Parse(reader["mach"].ToString());
                chuc.Tench = reader["tench"].ToString();
                lstChuc.Add(chuc);
            }
            conn.Close();
            return lstChuc;
        }

        public PositionBEL ReadPosition(int mach)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from chucvu where mach=" + mach.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            PositionBEL chuc = new PositionBEL();
            if (reader.HasRows && reader.Read())
            {
                chuc.Mach = int.Parse(reader["mach"].ToString());
                chuc.Tench = reader["tench"].ToString();
            }
            conn.Close();
            return chuc;
        }
    }
}
