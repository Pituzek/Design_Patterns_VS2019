using System;
using DesignPatterns.Singleton;
using DesignPatterns.DependencyInjection;

namespace Design_Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***************************");
            Console.WriteLine("** Design patterns demos **");
            Console.WriteLine("***************************");
            Console.WriteLine("");

            //SingletonDemoV1Example();
            //SingletonDemoV2Example();

            DependencyInjectionDemo_ConstructorInjection();

            //dotnettutorials.net/lesson/setter-dependency-injection-design-pattern-csharp/
        }

        #region SingletonDemos
        private static void SingletonDemoV2Example()
        {
            Parallel.Invoke(
                () => PrintTeacherDetails(),
                () => PrintStudentDetails());
        }
        private static void PrintTeacherDetails()
        {
            SingletonDemoV2ThreadSafe fromTeacher = SingletonDemoV2ThreadSafe.GetInstance;
            fromTeacher.PrintDetails("From Teacher");
        }
        private static void PrintStudentDetails()
        {
            SingletonDemoV2ThreadSafe fromStudent = SingletonDemoV2ThreadSafe.GetInstance;
            fromStudent.PrintDetails("From Student");
        }
        static void SingletonDemoV1Example()
        {
            SingletonDemoV1 fromTeacher = SingletonDemoV1.GetInstance;
            fromTeacher.PrintDetails("From Teacher");
            SingletonDemoV1 fromStudent = SingletonDemoV1.GetInstance;
            fromStudent.PrintDetails("From Student");

            /*
             * 
             From the above output, clearly shows that the private constructor is executed only once even though 
             we have called the GetInstance property twice and print the counter value to 1 hence it proves that 
             the singleton instance is created only once. The way we implement the singleton design pattern in the
             above example is not to thread-safe. It means in a multithreaded environment, it will able to create multiple
             instances of the singleton class. How to make the singleton class thread-safe we will discuss in the Thread-Safe Singleton Design Pattern article.
             * 
             */

            /*
             * 
             Some Real-time scenarios where you can use the Singleton Design Pattern:
             Service Proxies: As we know invoking a Service API is an extensive operation in an application. The process that taking most of the time is creating the Service client in order to invoke the service API. If you create the Service proxy as Singleton then it will improve the performance of your application.
             Facades: You can also create Database connections as Singleton which can improve the performance of the application.
             Logs: In an application, performing the I/O operation on a file is an expensive operation. If you create your Logger as Singleton then it will improve the performance of the I/O operation.
             Data sharing: If you have any constant values or configuration values then you can keep these values in Singleton So that these can be read by other components of the application.
             Caching: As we know fetching the data from a database is a time-consuming process. In your application, you can cache the master and configuration in memory which will avoid the DB calls. In such situations, the Singleton class can be used to handle the caching with thread synchronization in an efficient manner which drastically improves the performance of the application. 
             * 
             */

            Console.ReadKey();
        }
        #endregion

        #region Dependency Injection Demo
        static void DependencyInjectionDemo_ConstructorInjection()
        {
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
            var list = employeeBL.GetAllEmployees();
            foreach (var employee in list)
            {
                Console.WriteLine(employee.Name);
            }
        }
        #endregion
    }
}
}
