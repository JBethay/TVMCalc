using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.BasicOpps
{
    public static class BasicOppsDels
    {
       public delegate double OppsDelegate(double x, double y); // may need to move this outside of the class. 

       public static OppsDelegate addDel = (x, y) => x + y;
       public static OppsDelegate subtractDel = (x, y) => x - y;
       public static OppsDelegate multiplyDel = (x, y) => x * y;
       public static OppsDelegate devideDel = (x, y) => x / y;


    }
}
