using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Observer
{
    public interface IObserver
    {
        void update(string availability);
    }
}
