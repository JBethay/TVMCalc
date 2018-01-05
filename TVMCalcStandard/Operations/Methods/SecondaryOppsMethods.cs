using System;
using System.Collections.Generic;
using System.Text;
using TVMCalc.Operations.ObjctTemps;


namespace TVMCalc.Operations.Methods
{
    /// <summary>
    /// Secondary Calculation Methods (In a BAII Plus you are required to hit the second key)
    /// </summary>
    public static class SecondaryOppsMethods
    {
        /// <summary>
        /// This Method preforms an Amortization Calculation (giving the user the balance, interest paid, and principle paid
        /// between time p1 and p2. Note that p1 & p2 and be period 1 (start of loan) and period 10 (potential end of loan) or 
        /// P1 & P2 could both be for period five which would provide the balance at P5, as well as principle and interest paid for that period.
        /// </summary>
        /// <param name="tObj"></param>
        /// <param name="aObj"></param>
        /// <returns></returns>
        public static AmortObject AmortCompute(TvmObject tObj, AmortObject aObj)
        {
            var r = tObj.I / 100;
            aObj.C_Bal = tObj.Pv;

            for (int i = 1; i <= aObj.P2; i++)
            {
                aObj.I_Paid = aObj.C_Bal * r;                   
                aObj.P_Paid = tObj.Pmt + aObj.I_Paid;
                aObj.C_Bal = aObj.C_Bal + aObj.P_Paid;

                if (i >= aObj.P1)
                {
                    aObj.IntPaid = aObj.IntPaid + aObj.I_Paid;
                    aObj.PrnPaid = aObj.PrnPaid + aObj.P_Paid;
                }
            }
            aObj.EndBal = aObj.C_Bal;
            aObj.IntPaid = aObj.IntPaid * -1;
            return aObj;
        }

        /// <summary>
        /// This method returns a random value less then 1 but greater then 0, 
        /// used for generating a random percentage if the user converts the value to a percentage. 
        /// </summary>
        /// <returns></returns>
        public static double RandCompute()
        {
            Random rand = new Random();
            double x = rand.NextDouble();
            return x;
        }
        /// <summary>
        /// This method rounds a parameter to a specified number of decimal places. 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"> Count of decimals desired to round</param>
        /// <returns></returns>
        public static double RoundCompute(double x, int y)
        {
            double result = Math.Round(x, y);
            return result;
        }

        /// <summary>
        /// This method computes the Sine or the ratio of the length of the side that is opposite that angle to the length of the longest side of the triangle (the hypotenuse).
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double SinCompute(double x)
        {
            x = Math.Sin(x * Math.PI/180);
            return x;
        }
        /// <summary>
        /// This method computes the Cosine or the ratio of the side adjacent to an acute angle (in a right-angled triangle) to the hypotenuse. 
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double CosCompute(double x)
        {
            x = Math.Cos(x * Math.PI / 180);
            return x;
        }
        /// <summary>
        /// This method computes the Tangent or the opposite side to the adjacent side.
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double TanCompute(double x)
        {
            x = Math.Tan(x * Math.PI / 180);
            return x;
        }
        /// <summary>
        /// This method returns the angle whose sine is the parameter.
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double AsinCompute(double x)
        {
            x = Math.Asin(x) * 180 / Math.PI;
            return x;
        }
        /// <summary>
        /// This method returns the angle whose cosine is the parameter.
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double AcosCompute(double x)
        {
            x = Math.Acos(x) * 180 / Math.PI;
            return x;
        }
        /// <summary>
        /// This method returns the angle whose tangent is the parameter.
        /// This is in Degrees NOT Radian, .Net Framework uses radians by default.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double AtanCompute(double x)
        {
            x = Math.Atan(x) * 180 / Math.PI;
            return x;
        }

        /// <summary>
        /// This method computes the permutation of two parameters.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static double NprCompute(double n, double r)
        {
            double z = 0;

            if (n < 1)
            {
                n = 1;
            }
            if (r < 1)
            {
                r = 1;
            }
            if (n - r == 0 || n-r < 0)
            {
                z = n.Factorial_Recursion() / 1;
            }
            else
            {
                z = n.Factorial_Recursion() / (n-r).Factorial_Recursion();
            }
            return z;
        }
        /// <summary>
        /// This method computes the combination of two parameters.
        /// </summary>
        /// <param name="n"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public static double NcrCompute(double n, double r)
        {
            double z = 0;
            if (n < 1)
            {
                n = 1;
            }

            if (r < 1)
            {
                r = 1;
            }

            if (n - r == 0 || n - r < 0)
            {
                z = n.Factorial_Recursion() / (r.Factorial_Recursion() * 1);
            }
            else
            {
                z = n.Factorial_Recursion() / (r.Factorial_Recursion() * ((n-r).Factorial_Recursion()));
            }
            return z;
        }
    }
}


            



