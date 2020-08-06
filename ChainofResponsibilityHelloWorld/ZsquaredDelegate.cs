using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChainofResponsibilityHelloWorld
{
    public delegate void ZsquaredDelegate(ZsquaredContext z);

    public delegate Task ZsquaredDelegateAsync(ZsquaredContext z);
}
