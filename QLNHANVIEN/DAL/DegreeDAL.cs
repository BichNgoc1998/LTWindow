using QLNHANVIEN.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace QLNHANVIEN.DAL
{
        public class DegreeDAL : DBConnection
        {
            public List<DegreeBEL> ReadDegreeList()
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Bangcap", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                List<DegreeBEL> lstBang = new List<DegreeBEL>();
                while (reader.Read())
                {
                    DegreeBEL bang = new DegreeBEL();
                    bang.Mabang = int.Parse(reader["mabang"].ToString());
                    bang.Tenbang = reader["tenbang"].ToString();
                    lstBang.Add(bang);
                }
                conn.Close();
                return lstBang;
            }

        public DegreeBEL ReadDegree(int mabang)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from Bangcap where mabang = "+mabang.ToString(), conn);

            SqlDataReader reader = cmd.ExecuteReader();
            DegreeBEL bang = new DegreeBEL();
            if (reader.HasRows && reader.Read())
            {
                bang.Mabang = int.Parse(reader["mabang"].ToString());
                bang.Tenbang = reader["tenbang"].ToString();
            }
            conn.Close();
            return bang;
        }

    }
}