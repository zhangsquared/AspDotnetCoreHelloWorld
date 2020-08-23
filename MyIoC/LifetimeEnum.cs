using System;
using System.Collections.Generic;
using System.Text;

namespace MyIoC
{
    public enum LifetimeEnum
    {
        Transient,
        Scope,
        Singleton,
        PerThread
    }
}
