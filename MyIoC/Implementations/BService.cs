using MyIoC.Attributes;
using MyIoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyIoC.Implementations
{
    public class BService : IBService
    {
        private readonly IDALService dal;
        private readonly IAService a;

        [MyChosenCtor]
        public BService(IDALService dalService)
        {
            dal = dalService;
        }

        public BService(IDALService dalService, IAService aService)
        {
            dal = dalService;
            a = aService;
        }

    }
}
