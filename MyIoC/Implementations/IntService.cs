using MyIoC.Attributes;
using MyIoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyIoC.Implementations
{
    public class IntService : IIntService
    {
        private readonly ICService c;

        public int GetI { get; }
        public int GetJ { get; }

        //[MyChosenCtor]
        public IntService(int i)
        {
            GetI = i;
        }

        public IntService([MyConstParam] int i, ICService cService, [MyConstParam]int j)
        {
            GetI = i;
            c = cService;
            GetJ = j;
        }
    }
}
