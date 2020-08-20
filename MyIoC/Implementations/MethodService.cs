using MyIoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyIoC.Implementations
{
    public class MethodService : IMethodService
    {
        public void Show()
        {
            Console.WriteLine("MethodService Show");
        }
    }
}
