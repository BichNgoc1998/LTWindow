using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class TypeoemDAL : DBConnection
    {
        public List<TypeoemBEL> ReadTypeList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from loainhanvien", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<TypeoemBEL> lstLoai = new List<TypeoemBEL>();
            while (reader.Read())
            {
                TypeoemBEL loai = new TypeoemBEL();
                loai.Maloai = int.Parse(reader["maloai"].ToString());
                loai.Tenloai = reader["tenloai"].ToString();
                lstLoai.Add(loai);
            }
            conn.Close();
            return lstLoai;
        }

        public TypeoemBEL ReadType(int maloai)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from loainhanvien where maloai=" + maloai.ToString(), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            TypeoemBEL loai = new TypeoemBEL();
            if (reader.HasRows && reader.Read())
            {
                loai.Maloai = int.Parse(reader["maloai"].ToString());
                loai.Tenloai = reader["tenloai"].ToString();
            }
            conn.Close();
            return loai;
        }
    }
}
