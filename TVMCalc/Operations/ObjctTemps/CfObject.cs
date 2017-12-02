using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.ObjctTemps
{
    public struct CfObject
    {
        public double CF0 { get; set; }
        public double I { get; set; }
        public double NPV { get; set; }
        public double IRR { get; set; }
        public List<double> CashFlows { get; set; }
        public List<double> Frequency { get; set; }
    }
}
