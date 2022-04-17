using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.ChainOfResponsibility
{
    public static class ChainOfResponsibilityDemo
    {
        public static void Run()
        {
            ATM atm = new ATM();
            Console.WriteLine("\n Requested Amount 4600");
            atm.withdraw(4600);
            Console.WriteLine("\n Requested Amount 1900");
            atm.withdraw(1900);
            Console.WriteLine("\n Requested Amount 600");
            atm.withdraw(600);
            Console.Read();
        }
    }
}
