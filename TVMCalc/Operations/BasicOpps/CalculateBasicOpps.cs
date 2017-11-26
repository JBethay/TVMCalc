using System;
using System.Collections.Generic;
using System.Text;
using static TVMCalc.Operations.BasicOpps.BasicOppsDels;

namespace TVMCalc.Operations.BasicOpps
{
    public static class CalculateBasicOpps
    {
        public static double Calculate(double x, double y, OppsDelegate del)
        {
            var result = del(x, y);
            return result;
        }

        public static double Calculate(double x, OppsSingleDelegate del)
        {
            var result = del(x);
            return result;
        }
    }
}
