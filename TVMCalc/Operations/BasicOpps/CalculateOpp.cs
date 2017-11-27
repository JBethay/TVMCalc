using System;
using System.Collections.Generic;
using System.Text;
using static TVMCalc.Operations.BasicOpps.BasicOppsDels;

namespace TVMCalc.Operations.BasicOpps
{
    public static class CalculateOpp
    {
        public static double Calculate(double x, OppsOneDelegate del)
        {
            var result = del(x);
            return result;
        }

        public static double Calculate(double x, double y, OppsTwoDelegate del)
        {
            var result = del(x, y);
            return result;
        }

        public static double Calculate(double n, double i, double pv, double pmt, double fv, OppsTvmDelegate del)
        {
            var result = del(n,i,pv,pmt,fv);
            return result;
        }
    }
}
