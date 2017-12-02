using System;
using System.Collections.Generic;
using System.Text;
using TVMCalc.Operations.BasicOpps;
using TVMCalc.Operations.ObjctTemps;


namespace TVMCalc.Operations.OppsDelegates
{
    /// <summary>
    /// Note that the delegates below act like methods and are used to create a more dynamic "Calculate" method
    /// Where the type of calculation is demerited by the delegate that is passed into the method overload. 
    /// </summary>
    public static class TVMOppsDels
    {
        public delegate double OppsTvmDelegate(double n, double i, double pv, double pmt, double fv);
        public delegate double OppsCfTvmDelegate(CfObject CfObject);

        //TVM *regular annuity* calculations *END MODE*
        /// <summary>
        /// Computes the number of periods in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static OppsTvmDelegate nDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            n = Math.Log((((fv * -1) * (i)) + pmt) / ((i * pv) + pmt)) / (Math.Log(1 + i));
            return n;
        };
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Regular Annuity or payment at end of the period.
        /// </summary>
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
        /// <summary>
        /// Computes the present value in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static OppsTvmDelegate pvDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pv = (1 / i) * (Math.Pow((1 + i), (n * -1))) * (((-1 * fv) * i) - ((pmt * (Math.Pow((1 + i), n)))) + pmt);
            return pv;
        };
        /// <summary>
        /// Computes the payment in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static OppsTvmDelegate pmtDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pmt = -1 * ((i * (fv + (pv * (Math.Pow((1 + i), n))))) / (Math.Pow((1 + i), n) - 1));
            return pmt;
        };
        /// <summary>
        /// Computes the future value in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static OppsTvmDelegate fvDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            fv = (1 / i) * (((i * -1) * (pv * (Math.Pow((1 + i), n)))) - (pmt * (Math.Pow((1 + i), n))) + pmt);
            return fv;
        };

        //TVM *annuity due* calculations *BEG MODE*
        /// <summary>
        /// Computes the number of periods in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static OppsTvmDelegate nAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            n = Math.Log((((fv * -1) * (i)) + (i * pmt) + pmt) / ((i * pv) + (i * pmt) + pmt)) / (Math.Log(1 + i));
            return n;
        };
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Annuity Due or payment at the beginning of the period.
        /// </summary>
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
        /// <summary>
        /// Computes the present value in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static OppsTvmDelegate pvAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pv = (-1 * fv) * Math.Pow((i + 1), (n * -1)) - pmt + pmt * Math.Pow((i + 1), (n * -1)) - (pmt / i) + (pmt / i) * Math.Pow((i + 1), (n * -1));
            return pv;
        };
        /// <summary>
        /// Computes the payment in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static OppsTvmDelegate pmtAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            pmt = -1 * ((i * (fv + pv * Math.Pow((i + 1), n))) / (i * Math.Pow((i + 1), n) - i + Math.Pow((i + 1), n) - 1));
            return pmt;
        };
        /// <summary>
        /// Computes the future value in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static OppsTvmDelegate fvAdDel = (n, i, pv, pmt, fv) =>
        {
            i = i / 100;
            fv = (1 / i) * ((i * -1) * (pmt * Math.Pow((i + 1), n) - pmt + pv * Math.Pow((i + 1), n)) - pmt * Math.Pow((i + 1), n) + pmt);
            return fv;
        };

        //CashFlow Functions (NPV IRR Calculations)
        /// <summary>
        /// Computes the Net Present Value or NPV of a list of provided cash flows at a set interest rate.
        /// </summary>
        public static OppsCfTvmDelegate npvDel = (cfoObject) =>
        {
            var args_cf = cfoObject.CashFlows;
            var args_f = cfoObject.Frequency;
            var count = args_cf.Count;
            var t = 0;
            var t2 = 0;

            // Adjust the CF list for the frequency of the Cash flows
            for (int x = 0; x < count; x++)
            {
                if (x != 0)
                {
                    t2++;
                };
                for (int y = 1; y < args_f[x]; y++)
                {
                    double cf = cfoObject.CashFlows[t2];
                    args_cf.Insert(t2, cf);
                    t2++;
                }
            };

            // Lookup rate
            double rate = cfoObject.I / 100;

            // Initialize net present value
            double value = 0;

            // Loop on all values

            for (int z = 0; z < count; z++)
            {
                for (int x = 0; x < args_f[z]; x++)
                {
                    value += args_cf[t] / Math.Pow(1 + rate, (t + 1));
                    t++;
                }
            }

            // Return net present value
            cfoObject.NPV = value + cfoObject.CF0;
            return cfoObject.NPV;
        };

    }
}
