using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChainofResponsibilityHelloWorld
{
    public class ZsquaredPipelineBuilder
    {
        private readonly IList<Func<ZsquaredDelegate, ZsquaredDelegate>> components 
            = new List<Func<ZsquaredDelegate, ZsquaredDelegate>>();

        public ZsquaredPipelineBuilder Use(Func<ZsquaredDelegate, ZsquaredDelegate> middleware)
        {
            components.Add(middleware);
            return this;
        }

        public ZsquaredDelegate Build()
        {
            ZsquaredDelegate app = context =>
            {
                Console.WriteLine("final step");
                context.IsSuccess = false;
            };
            foreach (var component in components.Reverse())
            {
                app = component(app);
            }
            return app;
        }
    }

    public static class MockBuilder
    {
        public static ZsquaredPipelineBuilder BuildMiddleware()
        {
            ZsquaredPipelineBuilder app = new ZsquaredPipelineBuilder();

            // config middleware
            app.Use(next =>
            {
                Console.WriteLine("middleware 1 out");
                ZsquaredDelegate myDelegate = new ZsquaredDelegate(context =>
                {
                    Console.WriteLine("middleware 1 start");
                    next(context);
                    Console.WriteLine("middleware 1 end");
                });
                return myDelegate;
            });
            app.Use(next =>
            {
                Console.WriteLine("middleware 2 out");
                ZsquaredDelegate myDelegate = new ZsquaredDelegate(context =>
                {
                    Console.WriteLine("middleware 2 start");
                    next(context);
                    Console.WriteLine("middleware 2 end");
                });
                return myDelegate;
            });
            app.Use(next =>
            {
                Console.WriteLine("middleware 3 out");
                ZsquaredDelegate myDelegate = new ZsquaredDelegate(context =>
                {
                    Console.WriteLine("middleware 3 start");
                    if (context.Name.Contains("ZZ")) next(context);
                    Console.WriteLine("middleware 3 end");
                });
                return myDelegate;
            });

            return app;
        }
    }
}
