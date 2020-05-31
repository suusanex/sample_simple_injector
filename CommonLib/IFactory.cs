using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DITest
{
    public interface IFactory
    {
        void CreateInstance(out IDITestClass diTestClass);
    }

}
