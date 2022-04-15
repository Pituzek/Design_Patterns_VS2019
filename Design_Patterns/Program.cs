using System;
using Design_Patterns.Singleton;
using Design_Patterns.DependencyInjection;
using System.Threading.Tasks;
using System.Collections.Generic;
using ConstructorInject = Design_Patterns.DependencyInjection.ConstructorInjection;
using PropertyInject = Design_Patterns.DependencyInjection.PropertyInjection;
using MethodInject = Design_Patterns.DependencyInjection.MethodInjection;
using FactoryDesign = Design_Patterns.CreationalDesignPattern.Factory_Design;
using FactoryMethodDesign = Design_Patterns.CreationalDesignPattern.Factory_Method_Design;
using AbstractFactoryDesign = Design_Patterns.CreationalDesignPattern.Abstract_Factory;
using BuilderDesign = Design_Patterns.CreationalDesignPattern.Builder_Design;
using FluentInterface = Design_Patterns.CreationalDesignPattern.Fluent_Interface;
using PrototypeDesign = Design_Patterns.CreationalDesignPattern.Prototype_Design;
using PrototypeDesignDeepCopy = Design_Patterns.CreationalDesignPattern.Prototype_Design.Deep_Copy;


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

            ///<summary>
            /// Abstract Factory Design Demo
            /// </summary>
            /// 
            AbstractFactoryDesignDemo();

            ///<summary>
            /// Builder Design Demo
            /// </summary>
            BuilderDesignDemo();

            ///<summary>
            /// Fluent Interface Design Demo
            /// </summary>
            FluentInterfaceDemo();

            ///<summary>
            /// Prototype Design Demo
            /// </summary>
            PrototypeDesignDemo();

            ///<summary>
            /// Prototype Design Deep Copy Demo
            /// </summary>
            PrototypeDesignDeepCopyDemo();



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

        // https://dotnettutorials.net/lesson/factory-method-design-pattern-csharp/

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

        #region Abstract_Factory_Design_demo

        // https://dotnettutorials.net/lesson/abstract-factory-design-pattern-csharp/
        private static void AbstractFactoryDesignDemo()
        {
            AbstractFactoryDesign.Animal animal = null;
            AbstractFactoryDesign.AnimalFactory animalFactory = null;
            string speakSound = null;
            // Create the Sea Factory object by passing the factory type as Sea
            animalFactory = AbstractFactoryDesign.AnimalFactory.CreateAnimalFactory("Sea");
            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();
            // Get Octopus Animal object by passing the animal type as Octopus
            animal = animalFactory.GetAnimal("Octopus");
            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();
            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            Console.WriteLine();
            Console.WriteLine("--------------------------");
            // Create Land Factory object by passing the factory type as Land
            animalFactory = AbstractFactoryDesign.AnimalFactory.CreateAnimalFactory("Land");
            Console.WriteLine("Animal Factory type : " + animalFactory.GetType().Name);
            Console.WriteLine();
            // Get Lion Animal object by passing the animal type as Lion
            animal = animalFactory.GetAnimal("Lion");
            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();
            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            Console.WriteLine();
            // Get Cat Animal object by passing the animal type as Cat
            animal = animalFactory.GetAnimal("Cat");
            Console.WriteLine("Animal Type : " + animal.GetType().Name);
            speakSound = animal.speak();
            Console.WriteLine(animal.GetType().Name + " Speak : " + speakSound);
            Console.Read();
        }
        #endregion

        #region Builder_Design_Demo
        // https://dotnettutorials.net/lesson/builder-design-pattern/
        static void BuilderDesignDemo()
        {
            // Client Code
            BuilderDesign.Report report;
            BuilderDesign.ReportDirector reportDirector = new BuilderDesign.ReportDirector();
            // Construct and display Reports
            BuilderDesign.PDFReport pdfReport = new BuilderDesign.PDFReport();
            report = reportDirector.MakeReport(pdfReport);
            report.DisplayReport();
            Console.WriteLine("-------------------");
            BuilderDesign.ExcelReport excelReport = new BuilderDesign.ExcelReport();
            report = reportDirector.MakeReport(excelReport);
            report.DisplayReport();

            Console.ReadKey();
        }

        #endregion

        #region Fluent_Interface_Demo
        // https://dotnettutorials.net/lesson/fluent-interface-design-pattern/
        static void FluentInterfaceDemo()
        {
            FluentInterface.FluentEmployee obj = new FluentInterface.FluentEmployee();

            obj.SetName("Peter")
                .Born("18/12/1990")
                .WorkingOn("Posts")
                .StaysAt("Poznan");
        }

        #endregion

        #region Prototype_Design_Demo
        // https://dotnettutorials.net/lesson/prototype-design-pattern/
        static void PrototypeDesignDemo()
        {
            // Shallow copy
            // https://dotnettutorials.net/lesson/shallow-copy-and-deep-copy/

            PrototypeDesign.Employee emp1 = new PrototypeDesign.Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";

            PrototypeDesign.Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";
            // Metoda MemberwiseClone() w klasie Employee pozwala stworzyc kopie elementu! Gdybym nie uzyl .GetClone() tylko przyrownal emp2 = emp1 to wtedy zmiana w jednym obiekcie powodowalaby zmiane w obu (w obu obiektach bylaby przypisana ta sama referencja do danej)

            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Department: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Department: " + emp2.Department);
            Console.ReadKey();
        }

        #endregion

        #region Prototype_Design_Deep_Copy_Demo

        static void PrototypeDesignDeepCopyDemo()
        {
            PrototypeDesignDeepCopy.Employee emp1 = new PrototypeDesignDeepCopy.Employee();
            emp1.Name = "Anurag";
            emp1.Department = "IT";
            emp1.EmpAddress = new PrototypeDesignDeepCopy.Address() { address = "BBSR" };
            PrototypeDesignDeepCopy.Employee emp2 = emp1.GetClone();
            emp2.Name = "Pranaya";
            emp2.EmpAddress.address = "Mumbai";
            Console.WriteLine("Emplpyee 1: ");
            Console.WriteLine("Name: " + emp1.Name + ", Address: " + emp1.EmpAddress.address + ", Dept: " + emp1.Department);
            Console.WriteLine("Emplpyee 2: ");
            Console.WriteLine("Name: " + emp2.Name + ", Address: " + emp2.EmpAddress.address + ", Dept: " + emp2.Department);
            Console.Read();

        }

        #endregion
    }
}

