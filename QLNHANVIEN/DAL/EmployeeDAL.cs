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
                    nv.Image = reader["hinh"].ToString();
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
                "gt=@gt, hinh=@hinh, diachi=@diachi, email=@email, sdt=@sdt, id_bang=@id_bang, id_phong=@id_phong WHERE id=@id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", nv.Id));
            cmd.Parameters.Add(new SqlParameter("@name", nv.Name));
            cmd.Parameters.Add(new SqlParameter("@ngsinh", nv.Ngsinh));
            cmd.Parameters.Add(new SqlParameter("@cccd", nv.Cccd));
            cmd.Parameters.Add(new SqlParameter("@ngcap", nv.Ngcap));
            cmd.Parameters.Add(new SqlParameter("@gt", nv.Gioitinh));

            if (!string.IsNullOrEmpty(nv.Image))
            {
                cmd.Parameters.Add(new SqlParameter("@hinh", nv.Image));
            }
            else
            {
                cmd.Parameters.Add(new SqlParameter("@hinh", DBNull.Value)); // Use DBNull.Value for NULL
            }

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

            // Xóa các bản ghi liên quan từ bảng chamcong
            SqlCommand deleteChamcongCmd = new SqlCommand("DELETE FROM chamcong WHERE manv = @manv", conn);
            deleteChamcongCmd.Parameters.Add(new SqlParameter("@manv", nv.Id));
            deleteChamcongCmd.ExecuteNonQuery();

            // Xóa các bản ghi liên quan từ bảng ttcv
            SqlCommand deleteTtcvCmd = new SqlCommand("DELETE FROM ttcv WHERE manv = @manv", conn);
            deleteTtcvCmd.Parameters.Add(new SqlParameter("@manv", nv.Id));
            deleteTtcvCmd.ExecuteNonQuery();

            // Xóa bản ghi nhân viên
            SqlCommand deleteEmployeeCmd = new SqlCommand("DELETE FROM Employee WHERE id = @id", conn);
            deleteEmployeeCmd.Parameters.Add(new SqlParameter("@id", nv.Id));
            deleteEmployeeCmd.ExecuteNonQuery();

            conn.Close();
        }
            public void NewEmployee(EmployeeBEL nv)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Employee (id, name, ngsinh, cccd, ngcap, gt,hinh, diachi, email, sdt, id_bang, id_phong) " +
            "VALUES (@id, @name, @ngsinh, @cccd, @ngcap, @gt,@hinh, @diachi, @email, @sdt, @id_bang, @id_phong)", conn);
                cmd.Parameters.Add(new SqlParameter("@id", nv.Id));
                cmd.Parameters.Add(new SqlParameter("@name", nv.Name));
                cmd.Parameters.Add(new SqlParameter("@ngsinh", nv.Ngsinh));
                cmd.Parameters.Add(new SqlParameter("@cccd", nv.Cccd));
                cmd.Parameters.Add(new SqlParameter("@ngcap", nv.Ngcap));
                cmd.Parameters.Add(new SqlParameter("@gt", nv.Gioitinh));
                cmd.Parameters.Add(new SqlParameter("@hinh", nv.Image));
                cmd.Parameters.Add(new SqlParameter("@diachi", nv.Diachi));
                cmd.Parameters.Add(new SqlParameter("@email", nv.Email));
                cmd.Parameters.Add(new SqlParameter("@sdt", nv.Sdt));
                cmd.Parameters.Add(new SqlParameter("@id_bang", nv.MaBang));
                cmd.Parameters.Add(new SqlParameter("@id_phong", nv.MaPhong));

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            public List<EmployeeBEL> timkiem(EmployeeBEL c)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from employee where name LIKE '%' + @name + '%' ", conn);
                cmd.Parameters.Add(new SqlParameter("@name", c.Name));
                SqlDataReader reader = cmd.ExecuteReader();

                List<EmployeeBEL> lstNV = new List<EmployeeBEL>();

                while (reader.Read())
                {
                    EmployeeBEL nv = new EmployeeBEL();
                    nv.Id = int.Parse(reader["id"].ToString());
                    nv.Name = reader["name"].ToString();
                    nv.Ngsinh = reader["ngsinh"].ToString();
                    nv.Cccd = reader["cccd"].ToString();
                    nv.Ngcap = reader["ngcap"].ToString();
                    nv.Gioitinh = reader["gt"].ToString();
                    nv.Image = reader["hinh"].ToString();
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
    }
    }
