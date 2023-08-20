using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class TimekeepingBAL
    {
        TimekeepingDAL dal = new TimekeepingDAL();
        public List<TimekeepingBEL> ReadTimekeeping()
        {
            List<TimekeepingBEL> lstTime = dal.ReadTimekeeping();
            return lstTime;
        }

        public void NewTimekeeping(TimekeepingBEL nv)
        {
            dal.NewTimekeeping(nv);
        }

        public void DeleteTimekeeping(TimekeepingBEL nv)
        {
            dal.DeleteTimekeeping(nv);
        }

        public void EditTimekeeping(TimekeepingBEL nv)
        {
            dal.EditTimekeeping(nv);
        }

        internal TimekeepingBEL GetTimekeepingId(int TimekeepingId)
        {
            List<TimekeepingBEL> Timekeepings = ReadTimekeeping();
            return Timekeepings.FirstOrDefault(c => c.Manv == TimekeepingId);
        }
        private string connectionString = @"Data Source=DESKTOP-TF0RLMK;Initial Catalog=QLNV;User Id=sa;Password=sa";
        public List<int> GetEmployeeIds()
        {
            SqlConnection conn = new SqlConnection(connectionString);// Create your connection
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT id FROM employee", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<int> employeeIds = new List<int>();
            while (reader.Read())
            {
                int id = (int)reader["id"];
                employeeIds.Add(id);
            }

            conn.Close();

            return employeeIds;
        }
        public string GetEmployeeName(int employeeId)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT name FROM employee WHERE id = @id", conn);
            cmd.Parameters.Add(new SqlParameter("@id", employeeId));

            string employeeName = cmd.ExecuteScalar() as string;

            conn.Close();

            return employeeName;
        }

    }
}
