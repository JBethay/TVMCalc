using System;
using System.Collections.Generic;
using System.Text;
using TVMCalc.Operations.BasicOpps;
using TVMCalc.Operations.ObjctTemps;
using Microsoft.VisualBasic;


namespace TVMCalc.Operations.Methods
{
    public static class TVMCfMethods
    {
        //CashFlow Functions (NPV IRR Calculations)
        /// <summary>
        /// Computes the Net Present Value or NPV of a list of provided cash flows at a set interest rate.
        /// </summary>
        public static double OppsCfNPVMethod (CfObject cfoObject)
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
            cfoObject.CashFlows = args_cf;
            return cfoObject.NPV;
        }
        /* public static double OppsCfIrrMethod (CfObject cfObject)
        {

            var args_cf = cfObject.CashFlows;
            var args_f = cfObject.Frequency;
            var count = args_cf.Count;
            var t = 0;
            var t2 = 0;
            int maxIterationCount = 10000;
            double absoluteAccuracy = 1E-10;
            double x0 = 0;
            double x1;
            int i = 0;

            // Adjust the CF list for the frequency of the Cash flows
            for (int x = 0; x < count; x++)
            {
                if (x != 0)
                {
                    t2++;
                };
                for (int y = 1; y < args_f[x]; y++)
                {
                    double cf = cfObject.CashFlows[t2];
                    args_cf.Insert(t2, cf);
                    t2++;
                }
            };

            // Lookup rate
            //x0 = cfObject.I / 100;

            // Initialize net present value
            double value = 0;
            double valueD = 0;

            while (i < maxIterationCount)
            {
                // Loop on all values
                for (int z = 0; z < count; z++)
                {
                    for (int x = 0; x < args_f[z]; x++)
                    {
                        value += args_cf[t] / Math.Pow(1 + x0, (t + 1));
                        valueD += -t * args_cf[t] / Math.Pow(1 + x0, (t + 1));
                        t++;
                    }
                }
                // Return NPV
                cfObject.NPV = value + cfObject.CF0;
                value = cfObject.NPV;
                valueD = (valueD + cfObject.CF0);
                t = 0;

                // the essense of the Newton-Raphson Method
                x1 = x0 - value / valueD;
                if (Math.Abs(x1 - x0) <= absoluteAccuracy)
                {
                    return x1;
                }
                x0 = x1;
                ++i;
            }
            return x0*100; 
        } */
    }
}
