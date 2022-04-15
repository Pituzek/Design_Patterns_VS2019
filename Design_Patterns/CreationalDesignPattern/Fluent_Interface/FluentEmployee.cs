using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Fluent_Interface
{
    public class FluentEmployee
    {
        private Employee emp = new Employee();

        public FluentEmployee SetName(string fullName)
        {
            emp.FullName = fullName;
            return this;
        }

        public FluentEmployee Born(string dateOfBirth)
        {

            emp.DateOfBirth = Convert.ToDateTime(dateOfBirth);
            return this;
        }

        public FluentEmployee WorkingOn(string department)
        {
            emp.Department = department;
            return this;
        }

        public FluentEmployee StaysAt(string address)
        {
            emp.Address = address;
            return this;
        }
    }
}
