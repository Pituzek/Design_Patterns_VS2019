using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.StructuralDesignPattern.Adapter.ClassAdapter
{
    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }
}
