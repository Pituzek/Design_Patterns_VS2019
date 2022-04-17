using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Iterator
{
    interface AbstractCollection
    {
        Iterator CreateIterator();
    }
}
