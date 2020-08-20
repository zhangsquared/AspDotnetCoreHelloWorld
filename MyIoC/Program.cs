using MyIoC.Implementations;
using MyIoC.Interfaces;
using System;

namespace MyIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test();
            AnotherTest();

            Console.ReadKey();
        }

        private static void Test()
        {
            IMyContainer container = new MyContainer();

            // constructor DI
            container.Register<IWebService, WebServce>();
            container.Register<IAService, AService>();
            container.Register<IBService, BService>();
            container.Register<ICService, CService>();
            container.Register<IDALService, MySqlDALServce>();
            // property DI
            container.Register<IPropertyService, PropertyService>();
            // method DI
            container.Register<IMethodService, MethodService>();
            IWebService w = container.Resolve<IWebService>();
            w.PService.Show();
            w.MService.Show();

            // constuctor with constant parameters
            container.Register<IIntService, IntService>(constParams: new object[] { 1, 3 });
            IIntService s = container.Resolve<IIntService>(); // s.GetI == 1; s.GetJ == 3

            // 1 interface, more than 1 implementation
            string shortName = "Mongo";
            container.Register<IDALService, MongoDALService>(shortName: shortName);
            IDALService mySql = container.Resolve<IDALService>();
            IDALService mongo = container.Resolve<IDALService>(shortName);
            ICService cService = container.Resolve<ICService>(); // here the IDAL for cService should be MongoDALService
            var another = cService.AnotherMongo;
        }

        private static void AnotherTest()
        {
            IMyContainer container = new MyContainer();

            // constructor DI
            container.Register<IWebService, WebServce>();
            container.Register<IAService, AService>();
            container.Register<IBService, BService>();
            container.Register<IDALService, MySqlDALServce>();
           

        }
    }
}
