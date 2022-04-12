using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Singleton
{
    /*
    * 
    We created the Singleton class as sealed which ensures that the class cannot be inherited and object instantiation
    is restricted in the derived class. The class is created with a private constructor which will ensure that the class
    is not going to be instantiated from outside the class. Again we declared the instance variable as private and also initialized
    it with the null value which ensures that only one instance of the class is created based on the null condition.
    The public property GetInstance is used to return only one instance of the class by checking the value of the private variable instance.
    The public method PrintDetails can be invoked from outside the class through the singleton instance.
    We are done with our first version of the singleton design pattern implementation. Let’s use this in our Main method of Program class.
    So, copy and paste the following code in the program class
    * 
    */

    // class has to be SEALED !
    // The above output clearly shows that the counter value has incremented to 2 which proves that the private constructor executed twice and hence it creates multiple instances of the singleton class. So, by removing the sealed keyword we can inherit the singleton class, and also possible to create multiple objects of the singleton class. This violates singleton design principles.
    // https://dotnettutorials.net/lesson/singleton-class-sealed/
    public sealed class SingletonDemoV1
    {
        private static int counter = 0;
        private static SingletonDemoV1 instance = null;
        public static SingletonDemoV1 GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingletonDemoV1();
                return instance;
            }
        }

        public SingletonDemoV1()
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
