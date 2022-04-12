using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Singleton
{
    // https://dotnettutorials.net/lesson/thread-safe-singleton-design-pattern/
    public sealed class SingletonDemoV2ThreadSafe
    {
        private static int counter = 0;
        private static readonly object InstanceLock = new object();
        private static SingletonDemoV2ThreadSafe instance = null;
        public static SingletonDemoV2ThreadSafe GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (InstanceLock)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonDemoV2ThreadSafe();
                        }
                    }

                }
                return instance;
            }
        }

        private SingletonDemoV2ThreadSafe()
        {
            counter++;
            Console.WriteLine("Counter value " + counter.ToString());
        }

        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
}
