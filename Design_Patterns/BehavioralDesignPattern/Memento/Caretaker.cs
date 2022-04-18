using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Memento
{
    public class Caretaker
    {
        private List<Memento> ledTvList = new List<Memento>();
        public void AddMemento(Memento m)
        {
            ledTvList.Add(m);
            Console.WriteLine("LED TV's snapshots Maintained by CareTaker :" + m.GetDetails());
        }
        public Memento GetMemento(int index)
        {
            return ledTvList[index];
        }
    }
}
