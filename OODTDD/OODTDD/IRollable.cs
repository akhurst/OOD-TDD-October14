using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OODTDD
{
    public interface IRollable
    {
        int LastValue { get; }
        int Roll();
    }
}
