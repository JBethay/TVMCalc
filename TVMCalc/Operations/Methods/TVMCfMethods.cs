using System;
using System.Collections.Generic;
using System.Text;
using TVMCalc.Operations.BasicOpps;
using TVMCalc.Operations.ObjctTemps;
using Microsoft.VisualBasic;


namespace TVMCalc.Operations.Methods
{
    /// <summary>
    /// The methods below are used to calculate both the Net Present Value and the Internal Rate of Return of provided Cash Flows.
    /// </summary>
    public static class TVMCfMethods
    {
        //CashFlow Functions (NPV IRR Calculations)
        /// <summary>
        /// Computes the Net Present Value or NPV of a list of provided cash flows at a set interest rate.
        /// </summary>
        public static double CfNPVMethod (CfObject cfoObject)
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
        /// <summary>
        /// computes the internal rate of return for a set of provided cash flows. Newton's method is utilized.
        /// </summary>
        /// <param name="cfObject"></param>
        /// <returns></returns>
        public static double CfIRRMethod (CfObject cfObject)
        {
            var args_cf = cfObject.CashFlows;
            var args_f = cfObject.Frequency;
            var count = args_cf.Count;
            var t2 = 0;

            // Adjust the CF list for the frequency of the Cash flows
            for (int t = 0; t < count; t++)
            {
                if (t != 0)
                {
                    t2++;
                };
                for (int y = 1; y < args_f[t]; y++)
                {
                    double cf = cfObject.CashFlows[t2];
                    args_cf.Insert(t2, cf);
                    t2++;
                }
            };

            if (cfObject.CF0 > 1e-10 || cfObject.CF0 <-1e-10)
            {
                args_cf.Insert(0, cfObject.CF0);
            }
                
            int itrMax = 20;
            double espMax = 1e-5;
            
            double x = -0.1; //need to start with a negative to allow for negative IRR return values.
            int iter = 0;
            while (iter++ < itrMax)
            {           
                double x1 = 1.0 + x;
                double fx = 0.0;
                double dfx = 0.0;
                for (int i = 0; i < args_cf.Count; i++)
                {
                    double v = args_cf[i];
                    double x1_i = Math.Pow(x1, i);
                    fx += v / x1_i;
                    double x1_i1 = x1_i * x1;
                    dfx += -i * v / x1_i1;                                           
                }

                double new_x = x - fx / dfx;
                double esp = Math.Abs(new_x - x);
            
                if (esp <= espMax)
                {
                    if (x == 0.0 && Math.Abs(new_x) <= espMax)
                    {
                        return 0.0;
                    }
                    else
                    {
                        return new_x * 100;
                    }
                }
                x = new_x;
            }
            return x;
        } 
    }
}
