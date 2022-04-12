using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.DependencyInjection.PropertyInjection
{
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }
    //DAL - data access layer
    public class EmployeeDAL : IEmployeeDAL // Service
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>();
            //Get the Employees from the Database
            //for now we hard coded the employees
            ListEmployees.Add(new Employee() { Id = 1, Name = "Pranaya", Department = "IT" });
            ListEmployees.Add(new Employee() { Id = 2, Name = "Kumar", Department = "HR" });
            ListEmployees.Add(new Employee() { Id = 3, Name = "Rout", Department = "Payroll" });
            return ListEmployees;
        }
    }
}
