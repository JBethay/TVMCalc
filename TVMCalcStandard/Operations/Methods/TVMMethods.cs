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

            try
            {
                i = i / 100;
                n = Math.Log((((fv * -1) * (i)) + pmt) / ((i * pv) + pmt)) / (Math.Log(1 + i));
                return n;
            }
            catch
            {
                throw new System.ArgumentException();
            }

        }
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Regular Annuity or payment at end of the period.
        /// </summary>
        public static double ICompute (TvmObject obj)
        {
            var n = obj.N;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;
            var type = 0;
            var guess = 0.1;

            try
            {
                int itrMax = 20;
                double espMax = 1e-10;

                double y, y1, rate = 0, f = 0, count = 0;

                double i = guess;

                f = Math.Pow(1 + i, n);
                y = pv * f + pmt * ((f - 1) / i) * (1 + i * type) + fv;

                //first derivative:
                y1 = (f * ((pmt * n * type + n * pv) * Math.Pow(i, 2) + (pmt * n - pmt) * i - pmt) + pmt * i + pmt) / (Math.Pow(i, 3) + Math.Pow(i, 2));

                rate = i - y / y1;

                while ((Math.Abs(i - rate) > espMax) && (count < itrMax))
                {
                    i = rate;

                    f = Math.Pow(1 + i, n);
                    y = pv * f + pmt * ((f - 1) / i) * (1 + i * type) + fv;

                    //first derivative:                    
                    y1 = (f * ((pmt * n * type + n * pv) * Math.Pow(i, 2) + (pmt * n - pmt) * i - pmt) + pmt * i + pmt) / (Math.Pow(i, 3) + Math.Pow(i, 2));

                    rate = i - y / y1;
                    ++count;
                }

                i = rate;
                return i * 100;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                pv = (1 / i) * (Math.Pow((1 + i), (n * -1))) * (((-1 * fv) * i) - ((pmt * (Math.Pow((1 + i), n)))) + pmt);
                return pv;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {

                i = i / 100;
                pmt = -1 * ((i * (fv + (pv * (Math.Pow((1 + i), n))))) / (Math.Pow((1 + i), n) - 1));
                return pmt;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                fv = (1 / i) * (((i * -1) * (pv * (Math.Pow((1 + i), n)))) - (pmt * (Math.Pow((1 + i), n))) + pmt);
                return fv;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                n = Math.Log((((fv * -1) * (i)) + (i * pmt) + pmt) / ((i * pv) + (i * pmt) + pmt)) / (Math.Log(1 + i));
                return n;
            }
            catch
            {
                throw new System.ArgumentException();
            }
        }
        /// <summary>
        /// Computes the interest rate in a TVM equation, note that this method utilizes Newton's Method
        /// to iterate through possible options to find the best fit as interest rate cannot be directly computed.
        /// Annuity Due or payment at the beginning of the period.
        /// </summary>
        public static double IAdCompute (TvmObject obj)
        {
            var n = obj.N;
            var pv = obj.Pv;
            var pmt = obj.Pmt;
            var fv = obj.Fv;
            var type = 1;
            var guess = 0.1;

            try
            {
                int itrMax = 20;
                double espMax = 1e-10;

                double y, y1, rate = 0, f = 0, count = 0;

                double i = guess;

                f = Math.Pow(1 + i, n);
                y = pv * f + pmt * ((f - 1) / i) * (1 + i * type) + fv;

                //first derivative:
                y1 = (f * ((pmt * n * type + n * pv) * Math.Pow(i, 2) + (pmt * n - pmt) * i - pmt) + pmt * i + pmt) / (Math.Pow(i, 3) + Math.Pow(i, 2));

                rate = i - y / y1;

                while ((Math.Abs(i - rate) > espMax) && (count < itrMax))
                {

                    i = rate;

                    f = Math.Pow(1 + i, n);
                    y = pv * f + pmt * ((f - 1) / i) * (1 + i * type) + fv;

                    //first derivative:                    
                    y1 = (f * ((pmt * n * type + n * pv) * Math.Pow(i, 2) + (pmt * n - pmt) * i - pmt) + pmt * i + pmt) / (Math.Pow(i, 3) + Math.Pow(i, 2));

                    rate = i - y / y1;
                    ++count;
                }

                i = rate;
                return i * 100;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                pv = (-1 * fv) * Math.Pow((i + 1), (n * -1)) - pmt + pmt * Math.Pow((i + 1), (n * -1)) - (pmt / i) + (pmt / i) * Math.Pow((i + 1), (n * -1));
                return pv;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                pmt = -1 * ((i * (fv + pv * Math.Pow((i + 1), n))) / (i * Math.Pow((i + 1), n) - i + Math.Pow((i + 1), n) - 1));
                return pmt;
            }
            catch
            {
                throw new System.ArgumentException();
            }
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

            try
            {
                i = i / 100;
                fv = (1 / i) * ((i * -1) * (pmt * Math.Pow((i + 1), n) - pmt + pv * Math.Pow((i + 1), n)) - pmt * Math.Pow((i + 1), n) + pmt);
                return fv;
            }
            catch
            {
                throw new System.ArgumentException();
            }
        }     
    }
}
