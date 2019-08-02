using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public interface ILoggable
    {
        /*Once defined it can be implemented in any class that wants to take on the loggable role or support the loggable class*/
        string Log();
    }
}
