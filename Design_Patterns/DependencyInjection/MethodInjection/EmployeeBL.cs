using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.DependencyInjection.MethodInjection
{
    class EmployeeBL // Client
    {
        public IEmployeeDAL employeeDAL;

        public List<Employee> GetAllEmployees(IEmployeeDAL _employeeDAL)
        {
            employeeDAL = _employeeDAL;
            return employeeDAL.SelectAllEmployees();
        }
    }
}
