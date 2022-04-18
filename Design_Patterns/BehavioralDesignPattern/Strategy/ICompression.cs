using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Strategy
{
    public interface ICompression
    {
        void CompressFolder(string compressedArchiveFileName);
    }
}
