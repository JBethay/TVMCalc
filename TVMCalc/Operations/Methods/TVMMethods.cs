using System;
using System.Collections.Generic;
using System.Text;
using TVMCalc.Operations.ObjctTemps;

namespace TVMCalc.Operations.Methods
{
    /// <summary>
    /// The methods below are used to the Time Value of Money Values 
    /// </summary>
    public static class TVMMethods
    {
        //TVM *regular annuity* calculations *END MODE*
        /// <summary>
        /// Computes the number of periods in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static double NCompute (TvmObject obj)
        {
            double n = 0;
            var i = obj.I;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

            i = i / 100;
            n = Math.Log((((fv * -1) * (i)) + pmt) / ((i * pv) + pmt)) / (Math.Log(1 + i));
            return n;
        }
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Regular Annuity or payment at end of the period.
        /// </summary>
        public static double ICompute (TvmObject obj)
        {
            var n = obj.N;
            double i = 0;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

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
        }
        /// <summary>
        /// Computes the present value in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static double PvCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            double pv = 0;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

            i = i / 100;
            pv = (1 / i) * (Math.Pow((1 + i), (n * -1))) * (((-1 * fv) * i) - ((pmt * (Math.Pow((1 + i), n)))) + pmt);
            return pv;
        }
        /// <summary>
        /// Computes the payment in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static double PmtCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            var pv = obj.Pv;
            double pmt = 0;
            var fv = obj.Fv;

            i = i / 100;
            pmt = -1 * ((i * (fv + (pv * (Math.Pow((1 + i), n))))) / (Math.Pow((1 + i), n) - 1));
            return pmt;
        }
        /// <summary>
        /// Computes the future value in a TVM equation. Regular Annuity or payment at end of the period.
        /// </summary>
        public static double FvCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            double fv = 0;

            i = i / 100;
            fv = (1 / i) * (((i * -1) * (pv * (Math.Pow((1 + i), n)))) - (pmt * (Math.Pow((1 + i), n))) + pmt);
            return fv;
        }

        //TVM *annuity due* calculations *BEG MODE*
        /// <summary>
        /// Computes the number of periods in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double NAdCompute (TvmObject obj)
        {
            double n = 0;
            var i = obj.I;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

            i = i / 100;
            n = Math.Log((((fv * -1) * (i)) + (i * pmt) + pmt) / ((i * pv) + (i * pmt) + pmt)) / (Math.Log(1 + i));
            return n;
        }
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double IAdCompute (TvmObject obj)
        {
            var n = obj.N;
            double i = 0;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

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
        }
        /// <summary>
        /// Computes the present value in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double PvAdCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            double pv = 0;
            var pmt = obj.Pmt;
            var fv = obj.Fv;

            i = i / 100;
            pv = (-1 * fv) * Math.Pow((i + 1), (n * -1)) - pmt + pmt * Math.Pow((i + 1), (n * -1)) - (pmt / i) + (pmt / i) * Math.Pow((i + 1), (n * -1));
            return pv;
        }
        /// <summary>
        /// Computes the payment in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double PmtAdCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            var pv = obj.Pv;
            double pmt = 0;
            var fv = obj.Fv;

            i = i / 100;
            pmt = -1 * ((i * (fv + pv * Math.Pow((i + 1), n))) / (i * Math.Pow((i + 1), n) - i + Math.Pow((i + 1), n) - 1));
            return pmt;
        }
        /// <summary>
        /// Computes the future value in a TVM equation. Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double FvAdCompute (TvmObject obj)
        {
            var n = obj.N;
            var i = obj.I;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            double fv = 0;

            i = i / 100;
            fv = (1 / i) * ((i * -1) * (pmt * Math.Pow((i + 1), n) - pmt + pv * Math.Pow((i + 1), n)) - pmt * Math.Pow((i + 1), n) + pmt);
            return fv;
        }
    }
}
