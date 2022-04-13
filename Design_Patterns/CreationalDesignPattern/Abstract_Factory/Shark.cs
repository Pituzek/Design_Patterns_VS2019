using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Abstract_Factory
{
    public class Shark : Animal
    {
        public string speak()
        {
            return "Cannot Speak";
        }
    }
}
