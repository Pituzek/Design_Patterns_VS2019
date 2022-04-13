using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Abstract_Factory
{
    public class Dog : Animal
    {
        public string speak()
        {
            return "Bark bark";
        }
    }
}
