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
    public class InforjobBAL
    {
        InforjobDAL dal = new InforjobDAL();
        public List<InforjobBEL> ReadInforjob()
        {
            List<InforjobBEL> lstInfo = dal.ReadInforjob();
            return lstInfo;
        }

        public void NewInforjob(InforjobBEL info)
        {
            dal.NewInforjob(info);
        }
        public void DeleteInforjob(InforjobBEL info)
        {
            dal.DeleteInforjob(info);
        }
        public void EditInforjob(InforjobBEL info)
        {
            dal.EditInforjob(info);
        }

        internal InforjobBEL GetInforjobById(int empolyeeId)
        {
            //throw new NotImplementedException();
            List<InforjobBEL> Inforjobs = ReadInforjob();
            return Inforjobs.FirstOrDefault(c => c.Manv == empolyeeId);
        }
        private string connectionString = @"Data Source=DESKTOP-TF0RLMK;Initial Catalog=QLNV;User Id=sa;Password=sa";
        public List<int> GetEmployeeIds()
        {
            SqlConnection conn = new SqlConnection(connectionString); // Create your connection
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
    }
}
