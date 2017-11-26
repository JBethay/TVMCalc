using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.BasicOpps
{
    public static class BasicOppsDels
    {
        public delegate double OppsDelegate(double x, double y); // may need to move this outside of the class. 
        public delegate double OppsSingleDelegate(double x);

        public static OppsDelegate addDel = (x, y) => x + y;
        public static OppsDelegate subtractDel = (x, y) => x - y;
        public static OppsDelegate multiplyDel = (x, y) => x * y;
        public static OppsDelegate devideDel = (x, y) => x / y;
        public static OppsDelegate powerDel = (x, y) => Math.Pow(x, y);

        public static OppsSingleDelegate percentDel = (x) => x / 100;
        public static OppsSingleDelegate sqrtDel = (x) => Math.Sqrt(x);
        public static OppsSingleDelegate squareDel = (x) => Math.Pow(x, 2);
        public static OppsSingleDelegate oneOverDel = (x) => 1 / x;
        public static OppsSingleDelegate naturalLogDel = (x) => Math.Log(x);





    }
}
