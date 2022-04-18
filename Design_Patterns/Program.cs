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
using ObjectAdapter = Design_Patterns.StructuralDesignPattern.Adapter.ObjectAdapter;
using ClassAdapter = Design_Patterns.StructuralDesignPattern.Adapter.ClassAdapter;
using FacadeDesign = Design_Patterns.StructuralDesignPattern.Facade;
using DecoratorDesign = Design_Patterns.StructuralDesignPattern.Decorator;
using BridgeDesign = Design_Patterns.StructuralDesignPattern.Bridge;
using CompositeDesign = Design_Patterns.StructuralDesignPattern.Composite;
using ProxyDesign = Design_Patterns.StructuralDesignPattern.Proxy;
using FlyweightDesign = Design_Patterns.StructuralDesignPattern.Flyweight;

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

            ///<summary>
            /// Adapter Design Demo - object type
            /// </summary>
            AdapterObjectDemo();

            ///<summary>
            /// Adapter Design Demo - class type only difference in EmployeeAdapter (inherits ThirdPartyBillingSystem.cs)
            /// </summary>
            AdapterClassDemo();

            ///<summary>
            /// Facade Demo
            /// </summary>
            FacadeDemo();

            ///<summary>
            /// Decorator Demo
            /// </summary>
            DecoratorDemo();

            ///<summary>
            /// Bridge Demo
            /// </summary>
            BridgeDemo();

            ///<summary>
            /// Composite Demo
            /// </summary>
            CompositeDemo();

            ///<summary>
            /// Proxy Demo
            /// </summary>
            ProxyDemo();

            ///<summary>
            /// Flyweight Demo
            /// </summary>
            FlyweightDemo();

            ///<summary>
            /// Iterator Demo
            /// </summary>
            IteratorDemo();

            ///<summary>
            /// Observer Demo
            /// </summary>
            ObserverDemo();

            ///<summary>
            /// Chain of responsibility demo
            /// </summary>
            ChainOfResponsibilityDemo();

            ///<summary>
            /// State Demo
            /// </summary>
            StateDemo();

            ///<summary>
            /// Template Demo
            /// </summary>
            TemplateDemo();

            ///<summary>
            /// Command Demo
            /// </summary>
            CommandDemo();

            ///<summary>
            /// Visitor Demo
            /// </summary>
            VisitorDemo();

            ///<summary>
            /// Strategy Demo
            /// </summary>
            StrategyDemo();

            ///<summary>
            /// Interpreter Demo
            /// </summary>
            InterpreterDemo();

            ///<summary>
            /// Mediator Demo
            /// </summary>
            MediatorDemo();

            ///<summary>
            /// Memento Demo
            /// </summary>
            MementoDemo();

        }

        // Creational design patterns

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

        // Structural design patterns

        #region Adapter_Object
        // https://dotnettutorials.net/lesson/adapter-design-pattern/
        // real time example https://dotnettutorials.net/lesson/adapter-design-pattern-real-time-example/
        static void AdapterObjectDemo()
        {
            string[,] employeesArray = new string[5, 4]
          {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
          };

            ObjectAdapter.ITarget target = new ObjectAdapter.EmployeeAdapter();
            Console.WriteLine("HR system passes employee string array to Adapter");
            target.ProcessCompanySalary(employeesArray);
            Console.Read();
        }
        #endregion

        #region AdapterClass

        static void AdapterClassDemo()
        {
            string[,] employeesArray = new string[5, 4]
         {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
         };

            ClassAdapter.ITarget target = new ClassAdapter.EmployeeAdapter();
            Console.WriteLine("HR system passes employee string array to Adapter");
            target.ProcessCompanySalary(employeesArray);
            Console.Read();
        }
        #endregion

        #region Facade
        // https://dotnettutorials.net/lesson/facade-design-pattern/
        static void FacadeDemo()
        {
            FacadeDesign.Order order = new FacadeDesign.Order();
            order.PlaceOrder();
            Console.Read();
        }

        #endregion

        #region Decorator
        // https://dotnettutorials.net/lesson/decorator-design-pattern/
        static void DecoratorDemo()
        {
            DecoratorDesign.ICar bmwCar1 = new DecoratorDesign.BMWCar();
            bmwCar1.ManufactureCar();
            Console.WriteLine(bmwCar1 + "\n");
            DecoratorDesign.DieselCarDecorator carWithDieselEngine = new DecoratorDesign.DieselCarDecorator(bmwCar1);
            carWithDieselEngine.ManufactureCar();
            Console.WriteLine();
            DecoratorDesign.ICar bmwCar2 = new DecoratorDesign.BMWCar();
            DecoratorDesign.PetrolCarDecorator carWithPetrolEngine = new DecoratorDesign.PetrolCarDecorator(bmwCar2);
            carWithPetrolEngine.ManufactureCar();
            Console.ReadKey();
        }

        #endregion

        #region Bridge
        // https://dotnettutorials.net/lesson/bridge-design-pattern/
        static void BridgeDemo()
        {
            BridgeDesign.SonyRemoteControl sonyRemoteControl = new BridgeDesign.SonyRemoteControl(new BridgeDesign.SonyLedTv());
            sonyRemoteControl.SwitchOn();
            sonyRemoteControl.SetChannel(101);
            sonyRemoteControl.SwitchOff();

            Console.WriteLine();
            BridgeDesign.SamsungRemoteControl samsungRemoteControl = new BridgeDesign.SamsungRemoteControl(new BridgeDesign.SamsungLedTv());
            samsungRemoteControl.SwitchOn();
            samsungRemoteControl.SetChannel(202);
            samsungRemoteControl.SwitchOff();

            Console.ReadKey();
        }

        #endregion

        #region Composite
        // https://dotnettutorials.net/lesson/composite-design-pattern/
        static void CompositeDemo()
        {
            //Creating Leaf Objects
            CompositeDesign.IComponent hardDisk = new CompositeDesign.Leaf("Hard Disk", 2000);
            CompositeDesign.IComponent ram = new CompositeDesign.Leaf("RAM", 3000);
            CompositeDesign.IComponent cpu = new CompositeDesign.Leaf("CPU", 2000);
            CompositeDesign.IComponent mouse = new CompositeDesign.Leaf("Mouse", 2000);
            CompositeDesign.IComponent keyboard = new CompositeDesign.Leaf("Keyboard", 2000);
            //Creating composite objects
            CompositeDesign.Composite motherBoard = new CompositeDesign.Composite("Peripherals");
            CompositeDesign.Composite cabinet = new CompositeDesign.Composite("Cabinet");
            CompositeDesign.Composite peripherals = new CompositeDesign.Composite("Peripherals");
            CompositeDesign.Composite computer = new CompositeDesign.Composite("Computer");
            //Creating tree structure
            //Ading CPU and RAM in Mother board
            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);
            //Ading mother board and hard disk in Cabinet
            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);
            //Ading mouse and keyborad in peripherals
            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);
            //Ading cabinet and peripherals in computer
            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);
            //To display the Price of Computer
            computer.DisplayPrice();
            Console.WriteLine();
            //To display the Price of Keyboard
            keyboard.DisplayPrice();
            Console.WriteLine();
            //To display the Price of Cabinet
            cabinet.DisplayPrice();
            Console.Read();
        }

        #endregion

        #region Proxy

        static void ProxyDemo()
        {
            Console.WriteLine("Client passing employee with Role Developer to folderproxy");
            ProxyDesign.Employee emp1 = new ProxyDesign.Employee("Anurag", "Anurag123", "Developer");
            ProxyDesign.SharedFolderProxy folderProxy1 = new ProxyDesign.SharedFolderProxy(emp1);
            folderProxy1.PerformRWOperations();
            Console.WriteLine();
            Console.WriteLine("Client passing employee with Role Manager to folderproxy");
            ProxyDesign.Employee emp2 = new ProxyDesign.Employee("Pranaya", "Pranaya123", "Manager");
            ProxyDesign.SharedFolderProxy folderProxy2 = new ProxyDesign.SharedFolderProxy(emp2);
            folderProxy2.PerformRWOperations();
            Console.Read();
        }

        #endregion

        #region Flyweight
        // https://dotnettutorials.net/lesson/flyweight-design-pattern/
        static void FlyweightDemo()
        {
            Console.WriteLine("\n Red color Circles ");
            for (int i = 0; i < 3; i++)
            {
                FlyweightDesign.Circle circle = (FlyweightDesign.Circle)FlyweightDesign.ShapeFactory.GetShape("circle");
                circle.SetColor("Red");
                circle.Draw();
            }
            Console.WriteLine("\n Green color Circles ");
            for (int i = 0; i < 3; i++)
            {
                FlyweightDesign.Circle circle = (FlyweightDesign.Circle)FlyweightDesign.ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }
            Console.WriteLine("\n Blue color Circles");
            for (int i = 0; i < 3; ++i)
            {
                FlyweightDesign.Circle circle = (FlyweightDesign.Circle)FlyweightDesign.ShapeFactory.GetShape("circle");
                circle.SetColor("Green");
                circle.Draw();
            }
            Console.WriteLine("\n Orange color Circles");
            for (int i = 0; i < 3; ++i)
            {
                FlyweightDesign.Circle circle = (FlyweightDesign.Circle)FlyweightDesign.ShapeFactory.GetShape("circle");
                circle.SetColor("Orange");
                circle.Draw();
            }
            Console.WriteLine("\n Black color Circles");
            for (int i = 0; i < 3; ++i)
            {
                FlyweightDesign.Circle circle = (FlyweightDesign.Circle)FlyweightDesign.ShapeFactory.GetShape("circle");
                circle.SetColor("Black");
                circle.Draw();
            }
            Console.ReadKey();
        }

        #endregion

        // Behavioral design patterns

        #region Iterator
        // https://dotnettutorials.net/lesson/iterator-design-pattern/
        static void IteratorDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Iterator.IteratorDemo.Run();
        }

        #endregion

        #region Observer
        // https://dotnettutorials.net/lesson/observer-design-pattern/

        static void ObserverDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Observer.ObserverDemo.Run();
        }

        #endregion

        #region Chain_of_responsibility
        // https://dotnettutorials.net/lesson/chain-of-responsibility-design-pattern/
        static void ChainOfResponsibilityDemo()
        {
            Design_Patterns.BehavioralDesignPattern.ChainOfResponsibility.ChainOfResponsibilityDemo.Run();
        }

        #endregion

        #region State
        // https://dotnettutorials.net/lesson/state-design-pattern/
        static void StateDemo()
        {
            BehavioralDesignPattern.State.StateDemo.Run();
        }

        #endregion

        #region Template
        // 

        static void TemplateDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Template.TemplateDemo.Run();
        }

        #endregion

        #region Command
        // https://dotnettutorials.net/lesson/command-design-pattern/
        static void CommandDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Command.CommandDemo.Run();
        }

        #endregion

        #region Visitor
        // https://dotnettutorials.net/lesson/visitor-design-pattern/
        static void VisitorDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Visitor.VisitorDemo.Run();
        }

        #endregion

        #region Strategy
        // https://dotnettutorials.net/lesson/strategy-design-pattern/
        static void StrategyDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Strategy.StrategyDemo.Run();
        }

        #endregion

        #region Interpreter
        // https://dotnettutorials.net/lesson/interpreter-design-pattern/
        static void InterpreterDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Interpreter.InterpreterDemo.Run();
        }

        #endregion

        #region Mediator
        // https://dotnettutorials.net/lesson/mediator-design-pattern/
        static void MediatorDemo()
        {
            Design_Patterns.BehavioralDesignPattern.Mediator.MediatorDemo.Run();
        }

        #endregion

        #region Memento
        // https://dotnettutorials.net/lesson/memento-design-pattern/
        static void MementoDemo()
        {

        }

        #endregion


    }
}

