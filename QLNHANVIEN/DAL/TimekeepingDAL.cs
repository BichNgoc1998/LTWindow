using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class TimekeepingDAL: DBConnection
    {
        public List<TimekeepingBEL> ReadTimekeeping()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from chamcong", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<TimekeepingBEL> lstTime = new List<TimekeepingBEL>();
            StatusDAL tt = new StatusDAL();
            while (reader.Read())
            {
                TimekeepingBEL time = new TimekeepingBEL();
                time.Manv = int.Parse(reader["manv"].ToString());
                time.Tennv = reader["tennv"].ToString();
                time.Tinhtrang = tt.ReadStatus(int.Parse(reader["id_matt"].ToString()));
                time.Ngay = reader["ngay"].ToString();
                lstTime.Add(time);
            }

            conn.Close();
            return lstTime;

        }
        public void EditTimekeeping(TimekeepingBEL time)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update chamcong set tennv=@tennv,id_matt=@id_matt, ngay=@ngay where manv= @manv", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", time.Manv));
            cmd.Parameters.Add(new SqlParameter("@tennv", time.Tennv));
            cmd.Parameters.Add(new SqlParameter("@id_matt", time.Tinhtrang.Matt));
            cmd.Parameters.Add(new SqlParameter("@ngay", time.Ngay));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteTimekeeping(TimekeepingBEL time)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from chamcong where manv = @manv", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", time.Manv));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewTimekeeping(TimekeepingBEL time)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into chamcong values (@manv, @tennv, @id_matt,@ngay)", conn);
            cmd.Parameters.Add(new SqlParameter("@manv", time.Manv));
            cmd.Parameters.Add(new SqlParameter("@tennv", time.Tennv));
            cmd.Parameters.Add(new SqlParameter("@id_matt", time.Tinhtrang.Matt));
            cmd.Parameters.Add(new SqlParameter("@ngay", time.Ngay));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
