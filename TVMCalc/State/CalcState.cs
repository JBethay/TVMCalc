using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.State
{
    /// <summary>
    /// The below is used to set the state of the calculator.
    /// </summary>
    public class CalcState
    {
        public bool Bgn { get; set; }
        public bool Clr_Tvm { get; set; }
        public bool Clr_Work { get; set; }
        public bool Second { get; set; }
        public bool Clear { get; set; }

        public bool Quit { get; set; }
        public bool Set { get; set; }
        public bool Del { get; set; }
        public bool Ins { get; set; }
        public bool Reset { get; set; }
    }
}
