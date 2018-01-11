using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.ObjctTemps
{
    public class CfObject
    {
        public double CF0_Npv { get; set; }
        public double CF0_Irr { get; set; }
        public double I_Npv {get; set; }
        public double NPV { get; set; }
        public double IRR { get; set; }
        public List<double> CashFlows_Npv { get; set; }
        public List<double> CashFlows_Irr { get; set; }
        public List<double> Frequency_Npv { get; set; }
        public List<double> Frequency_Irr { get; set; }

        public double CF0_Input { get; set; }
        public double I_Input { get; set; }
        public List<double> Frequency_Input { get; set; }
        public List<double> CashFlows_Input { get; set; }
    }
}
