using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class DepartmentDAL : DBConnection
    {
        public List<DepartmentBEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Phongban", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<DepartmentBEL> lstPhong = new List<DepartmentBEL>();
            while (reader.Read())
            {
                DepartmentBEL phong = new DepartmentBEL();
                phong.Maphong = int.Parse(reader["maphong"].ToString());
                phong.Tenphong = reader["tenphong"].ToString();
                lstPhong.Add(phong);
            }
            conn.Close();
            return lstPhong;
        }

        public DepartmentBEL ReadDepartment(int maphong)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from Phongban where maphong= "+ maphong.ToString(), conn);
           

            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentBEL phong = new DepartmentBEL();
            if (reader.HasRows && reader.Read())
            {
                phong.Maphong = int.Parse(reader["maphong"].ToString());
                phong.Tenphong = reader["tenphong"].ToString();
            }
            conn.Close();
            return phong;
        }

    }
}
