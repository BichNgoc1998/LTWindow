using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.DAL
{
    public class EmployeeDAL : DBConnection
    {
        public List<EmployeeBEL> ReadEmployee()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<EmployeeBEL> lstNV = new List<EmployeeBEL>();
            DegreeDAL bang = new DegreeDAL();
            DepartmentDAL phong = new DepartmentDAL();
            while (reader.Read())
            {
                EmployeeBEL nv = new EmployeeBEL();
                nv.Id = int.Parse(reader["id"].ToString());
                nv.Name = reader["name"].ToString();
                nv.Ngsinh = reader["ngsinh"].ToString();
                nv.Cccd = reader["cccd"].ToString();
                nv.Ngcap = reader["ngcap"].ToString();
                nv.Gioitinh = reader["gt"].ToString();
                nv.Diachi = reader["diachi"].ToString();
                nv.Email = reader["email"].ToString();
                nv.Sdt = int.Parse(reader["sdt"].ToString());
                nv.MaBang = int.Parse(reader["id_bang"].ToString());
                nv.MaPhong = int.Parse(reader["id_phong"].ToString());


                lstNV.Add(nv);
            }

            conn.Close();
            return lstNV;

        }
        public void EditEmployee(EmployeeBEL nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Employee SET name=@name, ngsinh=@ngsinh, cccd=@cccd, ngcap=@ngcap, " +
                "gt=@gt, diachi=@diachi, email=@email, sdt=@sdt, id_bang=@id_bang, id_phong=@id_phong WHERE id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", nv.Id));
            cmd.Parameters.Add(new SqlParameter("@name", nv.Name));
            cmd.Parameters.Add(new SqlParameter("@ngsinh", nv.Ngcap));
            cmd.Parameters.Add(new SqlParameter("@cccd", nv.Cccd));
            cmd.Parameters.Add(new SqlParameter("@ngcap", nv.Ngcap));
            cmd.Parameters.Add(new SqlParameter("@gt", nv.Gioitinh));
            cmd.Parameters.Add(new SqlParameter("@diachi", nv.Diachi));
            cmd.Parameters.Add(new SqlParameter("@email", nv.Email));
            cmd.Parameters.Add(new SqlParameter("@sdt", nv.Sdt));
            cmd.Parameters.Add(new SqlParameter("@id_bang", nv.MaBang));
            cmd.Parameters.Add(new SqlParameter("@id_phong", nv.MaPhong));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void DeleteEmployee(EmployeeBEL nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", nv.Id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void NewEmployee(EmployeeBEL nv)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee (id, name, ngsinh, cccd, ngcap, gt, diachi, email, sdt, id_bang, id_phong) " +
        "VALUES (@id, @name, @ngsinh, @cccd, @ngcap, @gt, @diachi, @email, @sdt, @id_bang, @id_phong)", conn);
            cmd.Parameters.Add(new SqlParameter("@id", nv.Id));
            cmd.Parameters.Add(new SqlParameter("@name", nv.Name));
            cmd.Parameters.Add(new SqlParameter("@ngsinh", nv.Ngsinh));
            cmd.Parameters.Add(new SqlParameter("@cccd", nv.Cccd));
            cmd.Parameters.Add(new SqlParameter("@ngcap", nv.Ngcap));
            cmd.Parameters.Add(new SqlParameter("@gt", nv.Gioitinh));
            cmd.Parameters.Add(new SqlParameter("@diachi", nv.Diachi));
            cmd.Parameters.Add(new SqlParameter("@email", nv.Email));
            cmd.Parameters.Add(new SqlParameter("@sdt", nv.Sdt));
            cmd.Parameters.Add(new SqlParameter("@id_bang", nv.MaBang));
            cmd.Parameters.Add(new SqlParameter("@id_phong", nv.MaPhong));

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
