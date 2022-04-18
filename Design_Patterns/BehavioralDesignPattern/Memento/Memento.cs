using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Memento
{
    public class Memento
    {
        public LEDTV ledTV { get; set; }
        public Memento(LEDTV ledTV)
        {
            this.ledTV = ledTV;
        }
        public string GetDetails()
        {
            return "Memento [ledTV=" + ledTV.GetDetails() + "]";
        }
    }
}
