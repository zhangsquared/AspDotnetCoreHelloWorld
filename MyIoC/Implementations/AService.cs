using MyIoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyIoC.Implementations
{
    public class AService : IAService
    {
        private readonly IDALService dal;

        public AService(IDALService dalService)
        {
            dal = dalService;
        }

    }
}
