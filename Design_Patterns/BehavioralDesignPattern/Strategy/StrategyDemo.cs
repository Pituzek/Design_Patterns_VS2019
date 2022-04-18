using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.BehavioralDesignPattern.Strategy
{
    public static class StrategyDemo
    {
        public static void Run()
        {
            CompressionContext ctx = new CompressionContext(new ZipCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            ctx.SetStrategy(new RarCompression());
            ctx.CreateArchive("DotNetDesignPattern");
            Console.Read();
        }
    }
}
