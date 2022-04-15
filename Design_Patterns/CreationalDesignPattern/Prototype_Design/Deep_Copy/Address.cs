using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.CreationalDesignPattern.Prototype_Design.Deep_Copy
{
    public class Address
    {
        public string address { get; set; }
        public Address GetClone()
        {
            return (Address)this.MemberwiseClone();
        }
    }
}
