using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.BAL
{
    public class EmployeeBAL
    {
        // Remove this line that causes the recursive instantiation issue
        // EmployeeBAL dal = new EmployeeBAL();

        public List<EmployeeBEL> ReadEmployee()
        {
            // Instantiate the DAL class where appropriate
            EmployeeDAL dal = new EmployeeDAL(); // Assuming you have an EmployeeDAL class

            List<EmployeeBEL> lstNV = dal.ReadEmployee();
            return lstNV;
        }

        public void NewEmployee(EmployeeBEL nv)
        {
            EmployeeDAL dal = new EmployeeDAL(); // Instantiate the DAL class
            dal.NewEmployee(nv);
        }

        public void DeleteEmployee(EmployeeBEL nv)
        {
            EmployeeDAL dal = new EmployeeDAL(); // Instantiate the DAL class
            dal.DeleteEmployee(nv);
        }

        public void EditEmployee(EmployeeBEL nv)
        {
            EmployeeDAL dal = new EmployeeDAL(); // Instantiate the DAL class
            dal.EditEmployee(nv);
        }
        public List<EmployeeBEL> Timkiem(EmployeeBEL c)
        {
            EmployeeDAL dal = new EmployeeDAL();
            List<EmployeeBEL> lstNV = dal.timkiem(c);
            return lstNV;
        }

        internal EmployeeBEL GetEmployeeById(int employeeId)
        {
            List<EmployeeBEL> employees = ReadEmployee();
            return employees.FirstOrDefault(c => c.Id == employeeId);
        }
    }
}
