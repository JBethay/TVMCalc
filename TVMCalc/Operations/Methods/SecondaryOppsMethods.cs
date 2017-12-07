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
    }
}


            



