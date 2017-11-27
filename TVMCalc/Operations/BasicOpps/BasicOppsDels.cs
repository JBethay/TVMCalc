using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.BasicOpps
{
    public static class BasicOppsDels
    {
        public delegate double OppsTvmDelegate(double n, double i, double pv, double pmt, double fv);
        public delegate double OppsTwoDelegate(double x, double y); // may need to move this outside of the class. 
        public delegate double OppsOneDelegate(double x);

        public static OppsTwoDelegate addDel = (x, y) => x + y;
        public static OppsTwoDelegate subtractDel = (x, y) => x - y;
        public static OppsTwoDelegate multiplyDel = (x, y) => x * y;
        public static OppsTwoDelegate devideDel = (x, y) => x / y;
        public static OppsTwoDelegate powerDel = (x, y) => Math.Pow(x, y);

        public static OppsOneDelegate percentDel = (x) => x / 100;
        public static OppsOneDelegate sqrtDel = (x) => Math.Sqrt(x);
        public static OppsOneDelegate squareDel = (x) => Math.Pow(x, 2);
        public static OppsOneDelegate oneOverDel = (x) => 1 / x;
        public static OppsOneDelegate naturalLogDel = (x) => Math.Log(x);

        //TVM *regular annuity* calculations
        public static OppsTvmDelegate nDel = (n, i,pv,pmt,fv)=>
        {
            i=i / 100;
            n = Math.Log((((fv * -1) * (i)) + pmt) / ((i * pv) + pmt)) / (Math.Log(1 + i));
            return n;
        };
        //Need to finish calc for i
        /*public static OppsTvmDelegate iDel = (n, i, pv, pmt, fv) =>
        {
        //stuff
        };*/
        public static OppsTvmDelegate pvDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pv = (1 / i) * (Math.Pow((1 + i), (n * -1))) * (((-1 * fv) * i) - ((pmt * (Math.Pow((1 + i), n)))) + pmt);
            return pv;
        };
        public static OppsTvmDelegate pmtDel = (n, i, pv, pmt, fv) => 
        {
            i = i / 100;
            pmt = -1 * ((i * (fv + (pv * (Math.Pow((1 + i), n))))) / (Math.Pow((1 + i), n) - 1));
            return pmt;
        };
        public static OppsTvmDelegate fvDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            fv = (1 / i) * (((i * -1) * (pv * (Math.Pow((1 + i), n)))) - (pmt * (Math.Pow((1 + i), n))) + pmt);
            return fv;
        };

    }
}
