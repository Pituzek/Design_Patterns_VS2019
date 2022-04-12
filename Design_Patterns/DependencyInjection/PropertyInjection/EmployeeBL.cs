using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.DependencyInjection.PropertyInjection
{
    class EmployeeBL // Client
    {
        private IEmployeeDAL employeeDAL;

        public IEmployeeDAL employeeDataObject
        {
            set
            {
                this.employeeDAL = value;
            }
            get
            {
                if (employeeDataObject == null)
                {
                    throw new Exception("Employee is not initialized");
                }
                else
                {
                    return employeeDAL;
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            return employeeDAL.SelectAllEmployees();
        }
    }
}
