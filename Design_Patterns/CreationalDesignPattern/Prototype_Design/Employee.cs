using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Prototype_Design
{
    public class Employee
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public Employee GetClone()
        {
            return (Employee)this.MemberwiseClone();
        }
    }
}
