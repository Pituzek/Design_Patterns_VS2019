﻿using System;
using Design_Patterns.Singleton;
using Design_Patterns.DependencyInjection;
using System.Threading.Tasks;
using ConstructorInject = Design_Patterns.DependencyInjection.ConstructorInjection;
using PropertyInject = Design_Patterns.DependencyInjection.PropertyInjection;
using MethodInject = Design_Patterns.DependencyInjection.MethodInjection;
using FactoryDesign = Design_Patterns.CreationalDesignPattern.Factory_Design;
using FactoryMethodDesign = Design_Patterns.CreationalDesignPattern.Factory_Method_Design;
using System.Collections.Generic;

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

            ///<summary>
            /// Singleton Demos
            ///</summary>
            SingletonDemoV1Example();
            SingletonDemoV2Example();

            ///<summary>
            /// Dependency Injection Demos
            ///</summary>
            DependencyInjectionDemo_ConstructorInjection();
            DependencyInjectionDemo_PropertyInjection();
            DependencyInjectionDemo_MethodInjection();

            //dotnettutorials.net/lesson/setter-dependency-injection-design-pattern-csharp/

            ///<summary>
            /// Factory Design Demo
            /// </summary>
            FactoryDesignDemo();

            ///<summary>
            /// Factory Method Design Demo
            /// </summary>
            FactoryMethodDesignDemo();

        }

        #region Singleton_Demos
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
            ConstructorInject.EmployeeBL employeeBL = new ConstructorInject.EmployeeBL(new ConstructorInject.EmployeeDAL());
            var list = employeeBL.GetAllEmployees();
            foreach (var employee in list)
            {
                Console.WriteLine(employee.Name);
            }

            Console.ReadKey();
        }

        static void DependencyInjectionDemo_PropertyInjection()
        {
            //https://dotnettutorials.net/lesson/setter-dependency-injection-design-pattern-csharp/
            PropertyInject.EmployeeBL employeeBL = new PropertyInject.EmployeeBL(); // Client
            employeeBL.employeeDataObject = new PropertyInject.EmployeeDAL(); // Service inject

            List<PropertyInject.Employee> ListEmployee = employeeBL.GetAllEmployees();
            foreach (PropertyInject.Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.Id, emp.Name, emp.Department);
            }

            Console.ReadKey();
        }

        static void DependencyInjectionDemo_MethodInjection()
        {
            //Create object of EmployeeBL class
            MethodInject.EmployeeBL employeeBL = new MethodInject.EmployeeBL();

            //Call to GetAllEmployees method with proper object.
            List<MethodInject.Employee> ListEmployee = employeeBL.GetAllEmployees(new MethodInject.EmployeeDAL());
            foreach (MethodInject.Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.Id, emp.Name, emp.Department);
            }

            Console.ReadKey();

        }

        #endregion

        #region Factory_Design

        static void FactoryDesignDemo()
        {
            FactoryDesign.CreditCard cardDetails = FactoryDesign.CreditCardFactory.GetCreditCard("Platinum");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.WriteLine("Invalid card type");
            }

            Console.ReadKey();
        }

        #endregion

        #region Factory_Method_Design

        static void FactoryMethodDesignDemo()
        {
            FactoryMethodDesign.CreditCard creditCard = new FactoryMethodDesign.ConcreteCreator.PlatinumFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }

            Console.WriteLine("--------------");

            creditCard = new FactoryMethodDesign.ConcreteCreator.MoneyBackFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }

        #endregion

    }
}

