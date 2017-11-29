using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;

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

        //TVM *regular annuity* calculations *END MODE*
        public static OppsTvmDelegate nDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            n = Math.Log((((fv * -1) * (i)) + pmt) / ((i * pv) + pmt)) / (Math.Log(1 + i));
            return n;
        };
        //Calc for i, this implements Newton's method
        public static OppsTvmDelegate iDel = (n, i, pv, pmt, fv) =>
        {
            double t = 0;
            double estimate = 0.01;

            // Set the max epsilon for end of iteration
            var epsMax = 1e-10;

            // Set the max number of iterations
            var itrMax = 10;

            // Newton's method
            double y, y0, y1, x0, x1 = 0;
            double f = 0;
            double z = 0;
            i = estimate;
            if (Math.Abs(i) < epsMax)
            {
                y = pv * (1 + n * i) + pmt * (1 + i * t) * n + fv;
            }
            else
            {
                f = Math.Exp(n * Math.Log(1 + i));
                y = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
            }
            y0 = pv + pmt * n + fv;
            y1 = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
            z = x0 = 0;
            x1 = i;
            while ((Math.Abs(y0 - y1) > epsMax) && (z < itrMax))
            {
                i = (y1 * x0 - y0 * x1) / (y1 - y0);
                x0 = x1;
                x1 = i;
                if (Math.Abs(i) < epsMax)
                {
                    y = pv * (1 + n * i) + pmt * (1 + i * t) * n + fv;
                }
                else
                {
                    f = Math.Exp(n * Math.Log(1 + i));
                    y = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
                }
                y0 = y1;
                y1 = y;
                ++z;
            }
            i = i * 100; 
            return i;
        }; 
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

        //TVM *annuity due* calculations *BEG MODE*
        public static OppsTvmDelegate nAdDel = (n, i, pv, pmt, fv) => //X
        {
            i = i / 100;
            //n = (Math.Log(1 + (fv / (pmt * (1 + i))) * i)) / (Math.Log(1 + i));
            //n = ((-1 * Math.Log(1 + i * (1 - (pv / pmt)))) / Math.Log(1 + i)) + 1;
            //n = (1 / Math.Log(i + 1)) * (Math.Log((((-1 * fv) * i) + (i * pmt) + pmt) / (i * pmt) + (i * pv) + pmt));   FORMULA***
            return n;
        };
        //Calc for i, this implements Newton's method
        public static OppsTvmDelegate iAdDel = (n, i, pv, pmt, fv) =>
        {
            double t = 1;
            double estimate = 0.01;

            // Set the max epsilon for end of iteration
            var epsMax = 1e-10;

            // Set the max number of iterations
            var itrMax = 10;

            // Newton's method
            double y, y0, y1, x0, x1 = 0;
            double f = 0;
            double z = 0;
            i = estimate;
            if (Math.Abs(i) < epsMax)
            {
                y = pv * (1 + n * i) + pmt * (1 + i * t) * n + fv;
            }
            else
            {
                f = Math.Exp(n * Math.Log(1 + i));
                y = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
            }
            y0 = pv + pmt * n + fv;
            y1 = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
            z = x0 = 0;
            x1 = i;
            while ((Math.Abs(y0 - y1) > epsMax) && (z < itrMax))
            {
                i = (y1 * x0 - y0 * x1) / (y1 - y0);
                x0 = x1;
                x1 = i;
                if (Math.Abs(i) < epsMax)
                {
                    y = pv * (1 + n * i) + pmt * (1 + i * t) * n + fv;
                }
                else
                {
                    f = Math.Exp(n * Math.Log(1 + i));
                    y = pv * f + pmt * (1 / i + t) * (f - 1) + fv;
                }
                y0 = y1;
                y1 = y;
                ++z;
            }
            i = i * 100;
            return i;
        };
        public static OppsTvmDelegate pvAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pv = (-1 * fv) * Math.Pow((i + 1), (n * -1)) - pmt + pmt * Math.Pow((i + 1), (n * -1)) - (pmt / i) + (pmt / i) * Math.Pow((i + 1), (n * -1));
            return pv;
        };
        public static OppsTvmDelegate pmtAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pmt = -1 * ((i * (fv + pv * Math.Pow((i + 1), n))) / (i * Math.Pow((i + 1), n) - i + Math.Pow((i + 1), n) - 1));
            return pmt;
        };
        public static OppsTvmDelegate fvAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            fv = (1 / i) * ((i * -1) * (pmt * Math.Pow((i + 1), n) - pmt + pv * Math.Pow((i + 1), n)) - pmt * Math.Pow((i + 1), n) + pmt);
            return fv;
        };


    }
}


