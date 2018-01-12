using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Content.PM;
using static TVMCalcDroid.Helper.HelperCalc;
using static TVMCalc.Operations.Methods.PrimaryOppsMethods;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;
using static TVMCalc.Operations.Methods.TVMCfMethods;
using TVMCalc.Operations.ObjctTemps;
using TVMCalcDroid.Dialogs;


namespace TVMCalcDroid
{
    [Activity(Label = "TVMCalcDroid", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    ScreenOrientation = ScreenOrientation.Portrait)] // Locking screen orientation to Portrait.
    public class MainActivity : Activity
    {
        #region UI Buttons & TextViews
        Button BtnOpen, BtnClose, BtnBack, BtnDevide, Btn7, Btn8, Btn9, BtnMultiply;
        Button Btn4, Btn5, Btn6, BtnMinus, Btn1, Btn2, Btn3, BtnPlus, BtnCEC, Btn0, BtnDot, BtnEquals;
        Button BtnClr, BtnFormat, BtnRound, BtnRand, BtnPercent, BtnPlusMinus;
        Button BtnN, BtnIy, BtnPv, BtnPmt, BtnFv, BtnCf, BtnNpv, BtnIrr, BtnAmort;
        Button BtnPower, BtnSqrt, BtnSquared, BtnOneOver, BtnE, BtnLn;
        Button BtnLog, BtnNpr, BtnNcr, BtnFactorial, BtnSin, BtnCos, BtnTan;
        Button BtnAsin, BtnAcos, BtnAtan;
        TextView CalcDisplay, CalcOppsDisplay;

        #endregion

        #region Properties Used for Button Clicks
        private bool IsOppPerformed { get; set; }
        private bool IsNewInput { get; set; }
        private bool IsOppRepeated { get; set; }
        private bool IsSingleInput { get; set; }
        private bool IsCfValid { get; set; }
        private int Format = 2;
        private int ParenthesisOpen = 0;
        private double Input1 { get; set; }
        private double Input2 { get; set; }
        private double Result = 0;
        private double ResultTrue = 0;
        private string OppPerformed { get; set; }
        private CfObject Cfobjt = new CfObject();
        private Stack<string> Operators = new Stack<string>();
        private Stack<double> Operands = new Stack<double>();
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // Set the view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide(); // Hides the action Bar

            #region Keys & Text Views
            CalcDisplay = FindViewById<TextView>(Resource.Id.Calculator_text_view);
            CalcOppsDisplay = FindViewById<TextView>(Resource.Id.Calculator_textOpps_view);
            BtnOpen = FindViewById<Button>(Resource.Id.Parenthesie_Open_Key);
            BtnClose = FindViewById<Button>(Resource.Id.Parenthesie_Closed_Key);
            BtnBack = FindViewById<Button>(Resource.Id.Back_Key);
            BtnDevide = FindViewById<Button>(Resource.Id.Devide_Key);
            Btn7 = FindViewById<Button>(Resource.Id.Seven_Key);
            Btn8 = FindViewById<Button>(Resource.Id.Eight_Key);
            Btn9 = FindViewById<Button>(Resource.Id.Nine_Key);
            BtnMultiply = FindViewById<Button>(Resource.Id.Multiply_Key);
            Btn4 = FindViewById<Button>(Resource.Id.Four_Key);
            Btn5 = FindViewById<Button>(Resource.Id.Five_Key);
            Btn6 = FindViewById<Button>(Resource.Id.Six_Key);
            BtnMinus = FindViewById<Button>(Resource.Id.Minus_Key);
            Btn1 = FindViewById<Button>(Resource.Id.One_Key);
            Btn2 = FindViewById<Button>(Resource.Id.Two_Key);
            Btn3 = FindViewById<Button>(Resource.Id.Three_Key);
            BtnPlus = FindViewById<Button>(Resource.Id.Plus_Key);
            BtnCEC = FindViewById<Button>(Resource.Id.Clear_Key);
            Btn0 = FindViewById<Button>(Resource.Id.Zero_Key);
            BtnDot = FindViewById<Button>(Resource.Id.Dot_Key);
            BtnEquals = FindViewById<Button>(Resource.Id.Equals_Key);
            BtnClr = FindViewById<Button>(Resource.Id.Clear_Key);
            BtnFormat = FindViewById<Button>(Resource.Id.Format_Key);
            BtnRound = FindViewById<Button>(Resource.Id.RoundCompt_Key);
            BtnRand = FindViewById<Button>(Resource.Id.RandCompt_Key);
            BtnPercent = FindViewById<Button>(Resource.Id.PercentCompt_Key);
            BtnPlusMinus = FindViewById<Button>(Resource.Id.Plus_Minus_Key);
            BtnN = FindViewById<Button>(Resource.Id.N_Key);
            BtnIy = FindViewById<Button>(Resource.Id.Iy_Key);
            BtnPv = FindViewById<Button>(Resource.Id.Pv_Key);
            BtnPmt = FindViewById<Button>(Resource.Id.Pmt_Key);
            BtnFv = FindViewById<Button>(Resource.Id.Fv_Key);
            BtnCf = FindViewById<Button>(Resource.Id.Cf_Key);
            BtnNpv = FindViewById<Button>(Resource.Id.Npv_Key);
            BtnIrr = FindViewById<Button>(Resource.Id.Irr_Key);
            BtnAmort = FindViewById<Button>(Resource.Id.Amort_Key);
            BtnPower = FindViewById<Button>(Resource.Id.PowerCompt_Key);
            BtnSqrt = FindViewById<Button>(Resource.Id.SqrtCompt_Key);
            BtnSquared = FindViewById<Button>(Resource.Id.SquareCompt_Key);
            BtnOneOver = FindViewById<Button>(Resource.Id.OneOver_Key);
            BtnE = FindViewById<Button>(Resource.Id.ECompt_Key);
            BtnLn = FindViewById<Button>(Resource.Id.NaturalLogCompt_Key);
            BtnLog = FindViewById<Button>(Resource.Id.LogCompt_Key);
            BtnNpr = FindViewById<Button>(Resource.Id.Npr_Key);
            BtnNcr = FindViewById<Button>(Resource.Id.Ncr_Key);
            BtnFactorial = FindViewById<Button>(Resource.Id.Factorial_Recursion_Key);
            BtnSin = FindViewById<Button>(Resource.Id.SinCompt_Key);
            BtnCos = FindViewById<Button>(Resource.Id.CosCompt_Key);
            BtnTan = FindViewById<Button>(Resource.Id.TanCompt_Key);
            BtnAsin = FindViewById<Button>(Resource.Id.AsinCompt_Key);
            BtnAcos = FindViewById<Button>(Resource.Id.AcosCompt_Key);
            BtnAtan = FindViewById<Button>(Resource.Id.AtanCompt_Key);
            BtnN = FindViewById<Button>(Resource.Id.N_Key);
            #endregion

            #region Primary & Formating Button_Clicks
            BtnDot.Click += Num_Button_Click;
            Btn0.Click += Num_Button_Click;
            Btn1.Click += Num_Button_Click;
            Btn2.Click += Num_Button_Click;
            Btn3.Click += Num_Button_Click;
            Btn4.Click += Num_Button_Click;
            Btn5.Click += Num_Button_Click;
            Btn6.Click += Num_Button_Click;
            Btn7.Click += Num_Button_Click;
            Btn8.Click += Num_Button_Click;
            Btn9.Click += Num_Button_Click;

            BtnOpen.Click += Open_Button_Click;
            BtnClose.Click += Close_Button_Click;

            BtnPlus.Click += Operator_Click;
            BtnMinus.Click += Operator_Click;
            BtnDevide.Click += Operator_Click;
            BtnMultiply.Click += Operator_Click;
            BtnPower.Click += Operator_Click;
            BtnEquals.Click += Equals_Click;
            BtnClr.Click += CE_Click;
            BtnBack.Click += Back_Click;

            BtnFormat.Click += Format_Click;
            BtnRound.Click += Round_Click;
            BtnPercent.Click += Percent_Click;
            BtnRand.Click += Rand_Button_Click;
            BtnPlusMinus.Click += PlusMinus_Click;
            #endregion

            #region TVM & Secondary Button_Clicks
            BtnN.Click += N_Button_Click;
            BtnIy.Click += Iy_Button_Click;
            BtnPv.Click += Pv_Button_Click;
            BtnPmt.Click += Pmt_Button_Click;
            BtnFv.Click += Fv_Button_Click;
            BtnCf.Click += Cf_Button_Click;
            BtnNpv.Click += Npv_Button_Click;
            BtnIrr.Click += Irr_Button_Click;
            BtnAmort.Click += Amort_Button_Click;

            BtnSqrt.Click += Sqrt_Button_Click;
            BtnSquared.Click += Squared_Button_Click;
            BtnOneOver.Click += OneOver_Button_Click;
            BtnE.Click += E_Button_Click;
            BtnLn.Click += Ln_Button_Click;
            BtnLog.Click += Log_Button_Click;
            BtnNpr.Click += Npr_Button_Click;
            BtnNcr.Click += Ncr_Button_Click;
            BtnFactorial.Click += Factorial_Button_Click;
            BtnSin.Click += Sin_Button_Click;
            BtnCos.Click += Cos_Button_Click;
            BtnTan.Click += Tan_Button_Click;
            BtnAsin.Click += Asin_Button_Click;
            BtnAcos.Click += Acos_Button_Click;
            BtnAtan.Click += Atan_Button_Click;
            #endregion

        }

        #region Primary & Formating Operations
        /// <summary>
        /// Number Key Clicks, restricts the number of decimal clicks to 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Num_Button_Click(object sender, EventArgs e)
        {
            if (IsNewInput == false && CalcDisplay.Text != "") 
            {
                if ((IsOppPerformed == true) || (StringToNum(CalcDisplay.Text) == 0))
                {
                    CalcDisplay.Text = "";
                }
            }

            Button button = (Button)sender;
            IsNewInput = true;
            //CalcOppsDisplay.Text = "";

            if (button.Text == ".")
            {
                if (!CalcDisplay.Text.Contains("."))
                {
                    if (CalcDisplay.Text == "")
                    {
                        CalcDisplay.Text = "0.";
                        Input1 = StringToNum(CalcDisplay.Text);
                    }
                    else
                    {
                        CalcDisplay.Text = $"{CalcDisplay.Text}{button.Text}";
                        Input1 = StringToNum(CalcDisplay.Text);
                    }
                }
                else
                {
                    Input1 = StringToNum(CalcDisplay.Text);
                }
            }
            else
            {
                CalcDisplay.Text = $"{CalcDisplay.Text}{button.Text}";
                Input1 = StringToNum(CalcDisplay.Text);
            }
        }

        /// <summary>
        /// Equals Key click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equals_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (ParenthesisOpen > 0)
            {
                while (ParenthesisOpen > 0)
                {
                    BtnClose.PerformClick();
                }
            }

            Expression_Compute();
            CalcOppsDisplay.Text = button.Text;
        }

        /// <summary>
        /// Evaluates the Expressions provided by the Calculator
        /// </summary>
        private void Expression_Compute()
        {
            #region Double Input Opps Calcs
            if (IsOppPerformed == true && IsNewInput == true && IsSingleInput == false)
            {
                CalcOppsDisplay.Text = "";
                Input2 = Input1;
                switch (OppPerformed)
                {
                    case "+":
                        ResultTrue = AddCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "-":
                        ResultTrue = SubtractCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "×":
                        ResultTrue = MultiplyCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "÷":
                        ResultTrue = DevideCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "y^x":
                        ResultTrue = PowerCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    default:
                        ResultTrue = Input2;
                        break;
                }
                IsOppPerformed = false;
                IsNewInput = false;
                IsOppRepeated = false;
                IsSingleInput = false;
            }
            #endregion
            #region Single Input Opps Calcs
            else if (IsOppPerformed == true && IsNewInput == true && IsSingleInput == true)
            {
                CalcOppsDisplay.Text = "";
                Input2 = StringToNum(CalcDisplay.Text);
                switch (OppPerformed)
                {
                    case "SQRT":
                        ResultTrue = SqrtCompt(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "x^2":
                        ResultTrue = SquareCompt(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "1/x":
                        ResultTrue = OneOverCompt(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "e^x":
                        ResultTrue = ECompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "LN":
                        ResultTrue = NaturalLogCompt(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "LOG":
                        ResultTrue = LogCompt(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "X!":
                        ResultTrue = (Input2.Factorial_Recursion());
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "SIN":
                        ResultTrue = SinCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "COS":
                        ResultTrue = CosCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "TAN":
                        ResultTrue = TanCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "ASIN":
                        ResultTrue = AsinCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "ACOS":
                        ResultTrue = AcosCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    case "ATAN":
                        ResultTrue = AtanCompute(Input2);
                        Result = ResultTrue;
                        CalcDisplay.Text = NumToStringFormated(Result, Format);
                        break;
                    default:
                        ResultTrue = Input2;
                        break;
                }
                IsOppPerformed = false;
                IsNewInput = false;
                IsOppRepeated = false;
            }
            #endregion
            else
            {
                Input2 = StringToNum(CalcDisplay.Text);
                CalcDisplay.Text = NumToStringFormated(Input2, Format);
                ResultTrue = Input2;
                IsNewInput = false;
                IsOppPerformed = false;
                IsSingleInput = false;
            }
        }

        /// <summary>
        /// Operator Key Clicks, such as +-*÷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Expression_Compute();

            if (CalcDisplay.Text != "" && IsOppRepeated == true)
            {
                OppPerformed = button.Text;
                IsOppPerformed = true;
                IsOppRepeated = true;
                IsSingleInput = false;
                CalcOppsDisplay.Text = button.Text;
            }
            if (CalcDisplay.Text != "" && IsOppRepeated == false && IsSingleInput == false)
            {
                OppPerformed = button.Text;
                IsOppPerformed = true;
                IsOppRepeated = true;
                IsSingleInput = false;
                CalcOppsDisplay.Text = button.Text;
            }
            if (CalcDisplay.Text != "" && IsOppRepeated == false && IsSingleInput == true)
            {
                IsOppPerformed = false;
                IsOppRepeated = false;
                IsSingleInput = false;
                CalcOppsDisplay.Text = button.Text;
            }
            //else do nothing....
        }

        /// <summary>
        /// Clear key, clears all mathematical values in the Calculator 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CE_Click(object sender, EventArgs e)
        {
            CalcDisplay.Text = NumToStringFormated(0, Format);
            CalcOppsDisplay.Text = BtnCEC.Text;
            ResultTrue = 0;
            Result = 0;
            Input1 = 0;
            Input2 = 0;
            OppPerformed = null;
            IsOppPerformed = false;
            IsNewInput = false;
            Cfobjt.CF0_Npv = 0;
            Cfobjt.CF0_Irr = 0;
            Cfobjt.CF0_Input = 0;
            Cfobjt.I_Npv = 0;
            Cfobjt.I_Input = 0;
            Cfobjt.IRR = 0;
            Cfobjt.NPV = 0;

            if (Operators.TryPeek(out string s) == true)
            {
                Operators.Clear();
            }
            if(Operands.TryPeek(out double r) == true)
            {
                Operands.Clear();
            }

            if (Cfobjt.CashFlows_Npv != null)
            {
                Cfobjt.CashFlows_Npv.Clear();
            }
            if (Cfobjt.Frequency_Npv != null)
            {
                Cfobjt.Frequency_Npv.Clear();
            }
            if (Cfobjt.CashFlows_Irr != null)
            {
                Cfobjt.CashFlows_Irr.Clear();
            }
            if (Cfobjt.Frequency_Irr != null)
            {
                Cfobjt.Frequency_Irr.Clear();
            }
            if (Cfobjt.Frequency_Input != null)
            {
                Cfobjt.Frequency_Input.Clear();
            }
            if (Cfobjt.CashFlows_Input != null)
            {
                Cfobjt.CashFlows_Input.Clear();
            }
        }

        /// <summary>
        /// Back Key Click, removes the string at the end of the text view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            CalcOppsDisplay.Text = BtnBack.Text;
            if (CalcDisplay.Text.Length != 0)
            {
                if (CalcDisplay.Text.Length == 1)
                {
                    CalcDisplay.Text = "0";
                }
                else
                {
                    CalcDisplay.Text = (CalcDisplay.Text.Substring(0, CalcDisplay.Text.Length - 1));
                }
            }
        }

        /// <summary>
        /// Open Parenthesis button click 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string Operator = OppPerformed;
            double Operand = StringToNum(CalcDisplay.Text);
            ParenthesisOpen++;

            if (Operator != null)
            {
                Operators.Push(Operator);
                Operands.Push(Operand);

                OppPerformed = null;
                IsOppPerformed = false;
                IsOppRepeated = false;
                IsSingleInput = false;
                CalcDisplay.Text = NumToStringFormated(0, Format);
                CalcOppsDisplay.Text = button.Text;
            }
        }

        /// <summary>
        /// Close Parenthesis button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Button_Click(object sender, EventArgs e)
        {
            if (ParenthesisOpen > 0)
            {
                Button button = (Button)sender;
                ParenthesisOpen--;

                if ((Operators.TryPeek(out string s) == false) || (Operands.TryPeek(out double r) == false))
                {
                    Expression_Compute();
                    CalcOppsDisplay.Text = button.Text;
                }
                else if ((Operators.TryPeek(out string s1) == true) && (Operands.TryPeek(out double r1) == true))
                {
                    OppPerformed = Operators.Pop();
                    ResultTrue = Operands.Pop();

                    IsOppPerformed = true;
                    IsNewInput = true;
                    IsOppRepeated = false;
                    IsSingleInput = false;

                    Input1 = StringToNum(CalcDisplay.Text);
                    Expression_Compute();
                    CalcOppsDisplay.Text = button.Text;
                }
            }
        }

        /// <summary>
        /// Allows user to input the desired number of displayed decimal places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Format_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Format fDialog = new Dialog_Format();
            fDialog.Show(transaction, "dialog Fragment");

            fDialog.mOnFormatComplete += fDialog_mOnFormatComplete;
        }

        /// <summary>
        /// Format Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fDialog_mOnFormatComplete(object sender, OnFormatEventArgs e)
        {
            Format = e.ComputedFormat;
            CalcOppsDisplay.Text = BtnFormat.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Allows user to input & round to the desired number of decimal places
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Round_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_Round rDialog = new Dialog_Round();
            rDialog.Show(transaction, "dialog Fragment");

            rDialog.mOnRoundComplete += rDialog_mOnRoundComplete;
        }

        /// <summary>
        /// Round Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rDialog_mOnRoundComplete(object sender, OnRoundEventArgs e)
        {
            int Round = e.ComputedRound;
            double result = RoundCompute(StringToNum(CalcDisplay.Text),Round);
            if (ResultTrue != 0)
            {
                ResultTrue = RoundCompute(ResultTrue, Round);
            }
            if (Result != 0)
            {
                Result = RoundCompute(Result, Round);
            }
            CalcDisplay.Text = NumToStringFormated(result, Format);

            CalcOppsDisplay.Text = BtnRound.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Generates a Random Percentage Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rand_Button_Click(object sender, EventArgs e)
        {
            Input2 = RandCompute();
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnRand.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Converts the String Input to a percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Percent_Click(object sender, EventArgs e)
        {
            Input2 = PercentCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnPercent.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Provides the inverse of the passed parameter. Note this is an example of an extension method
        /// although it is understood that a normal method would work just as well for this computation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            Input2 = (StringToNum(CalcDisplay.Text)).Plus_Minus();
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnPlusMinus.Text;
            Expression_Compute();
        }
        #endregion

        #region TVM and Secondary Operations
        #region TVM
        /// <summary>
        /// Computes N or the time in a time value of money equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void N_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_N nDialog = new Dialog_N();
            nDialog.Show(transaction, "dialog Fragment");

            nDialog.mOnNComptComplete += nDialog_mOnNComptComplete;
        }
        /// <summary>
        /// N Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nDialog_mOnNComptComplete(object sender, OnNComputeEventArgs e)
        {
            Input2 = e.ComputedN;
            CalcDisplay.Text = NumToStringFormated(e.ComputedN, Format);
            CalcOppsDisplay.Text = BtnN.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes I/Y or the interest in a time value of money equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Iy_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_I iDialog = new Dialog_I();
            iDialog.Show(transaction, "dialog Fragment");

            iDialog.mOnIComptComplete += iDialog_mOnIComptComplete;
        }

        /// <summary>
        /// I Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void iDialog_mOnIComptComplete(object sender, OnIComputeEventArgs e)
        {
            Input2 = e.ComputedI;
            CalcDisplay.Text = NumToStringFormated(e.ComputedI, Format);
            CalcOppsDisplay.Text = BtnN.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes PV or the Present Value in a time value of money equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pv_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_PV pVDialog = new Dialog_PV();
            pVDialog.Show(transaction, "dialog Fragment");

            pVDialog.mOnPvComptComplete += pVDialog_mOnPvComptComplete;

        }

        /// <summary>
        /// PV Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pVDialog_mOnPvComptComplete(object sender, OnPvComputeEventArgs e)
        {
            Input2 = e.ComputedPV;
            CalcDisplay.Text = NumToStringFormated(e.ComputedPV, Format);
            CalcOppsDisplay.Text = BtnN.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes PMT or the Payment in a time value of money equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pmt_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_PMT pMTDialog = new Dialog_PMT();
            pMTDialog.Show(transaction, "dialog Fragment");

            pMTDialog.mOnPmtComptComplete += pMTDialog_mOnPmtComptComplete;
        }

        /// <summary>
        /// PMT Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pMTDialog_mOnPmtComptComplete(object sender, OnPmtComputeEventArgs e)
        {
            Input2 = e.ComputedPMT;
            CalcDisplay.Text = NumToStringFormated(e.ComputedPMT, Format);
            CalcOppsDisplay.Text = BtnN.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes FV or the Future Value in a time value of money equation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fv_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_FV fVDialog = new Dialog_FV();
            fVDialog.Show(transaction, "dialog Fragment");

            fVDialog.mOnFvComptComplete += fVDialog_mOnFvComptComplete;
        }

        /// <summary>
        /// FV Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fVDialog_mOnFvComptComplete(object sender, OnFvComputeEventArgs e)
        {
            Input2 = e.ComputedFV;
            CalcDisplay.Text = NumToStringFormated(e.ComputedFV, Format);
            CalcOppsDisplay.Text = BtnN.Text;
            Expression_Compute();
        }
        #endregion

        /// <summary>
        /// Allows user to input and set values for a Cash Flow Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cf_Button_Click(object sender, EventArgs e)
        {
            Cfobjt.CF0_Npv = 0;
            Cfobjt.CF0_Irr = 0;
            Cfobjt.CF0_Input = 0;
            Cfobjt.I_Npv = 0;
            Cfobjt.I_Input = 0;
            Cfobjt.IRR = 0;
            Cfobjt.NPV = 0;

            if (Cfobjt.CashFlows_Npv == null)
            {
                Cfobjt.CashFlows_Npv = new List<double>();
            }
            if (Cfobjt.Frequency_Npv == null)
            {
                Cfobjt.Frequency_Npv = new List<double>();
            }
            if (Cfobjt.CashFlows_Irr == null)
            {
                Cfobjt.CashFlows_Irr = new List<double>();
            }
            if (Cfobjt.Frequency_Irr == null)
            {
                Cfobjt.Frequency_Irr = new List<double>();
            }
            if (Cfobjt.Frequency_Input == null)
            {
                Cfobjt.Frequency_Input = new List<double>();
            }
            if (Cfobjt.CashFlows_Input == null)
            {
                Cfobjt.CashFlows_Input = new List<double>();
            }

            Cfobjt.CashFlows_Npv.Clear();
            Cfobjt.Frequency_Npv.Clear();
            Cfobjt.CashFlows_Irr.Clear();
            Cfobjt.Frequency_Irr.Clear();
            Cfobjt.Frequency_Input.Clear();
            Cfobjt.CashFlows_Input.Clear();

            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_CF cFDialog = new Dialog_CF();
            cFDialog.Show(transaction, "dialog Fragment");

            cFDialog.mOnCFAddComplete += cFDialog_mOnCFAddComplete;
        }

        /// <summary>
        /// CF Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cFDialog_mOnCFAddComplete(object sender, OnCFAddEventArgs e)
        {
            Cfobjt.CF0_Npv = e.CF0;
            Cfobjt.CF0_Irr = e.CF0;
            Cfobjt.CF0_Input = e.CF0;
            Cfobjt.I_Npv = 0;
            Cfobjt.I_Input = 0;
            Cfobjt.IRR = 0;
            Cfobjt.NPV = 0;
            Cfobjt.CashFlows_Npv.Add(e.CF);
            Cfobjt.Frequency_Npv.Add(e.FREQ);
            Cfobjt.CashFlows_Irr.Add(e.CF);
            Cfobjt.Frequency_Irr.Add(e.FREQ);
            Cfobjt.CashFlows_Input.Add(e.CF);
            Cfobjt.Frequency_Input.Add(e.FREQ);
            CalcOppsDisplay.Text = BtnCf.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes the Net Present Value of a set of Cash Flows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Npv_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_NPV nPvDialog = new Dialog_NPV();
            nPvDialog.Show(transaction, "dialog Fragment");

            nPvDialog.mOnNPVComputeComplete += nPvDialog_mOnNPVComputeComplete;
        }

        /// <summary>
        /// NPV Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nPvDialog_mOnNPVComputeComplete(object sender, OnNPVComputeEventArgs e)
        {
            Input2 = e.I;
            Cfobjt.I_Npv = Input2;

            if (Cfobjt.Frequency_Npv != null || Cfobjt.CashFlows_Npv != null)
            {
                Input2 = CfNPVMethod(Cfobjt);
                CalcDisplay.Text = NumToStringFormated(Input2, Format);
                CalcOppsDisplay.Text = BtnNpv.Text;
                Expression_Compute();

                Cfobjt.Frequency_Npv.Clear();
                Cfobjt.CashFlows_Npv.Clear();
                Cfobjt.Frequency_Npv.AddRange(Cfobjt.Frequency_Input); // Reset Inputs
                Cfobjt.CashFlows_Npv.AddRange(Cfobjt.CashFlows_Input);
                Cfobjt.CF0_Npv = Cfobjt.CF0_Input;
            }
            // else do nothing.
        }

        /// <summary>
        /// Computes the Internal Rate of Return of a set of Cash Flows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Irr_Button_Click(object sender, EventArgs e)
        {
            if (Cfobjt.Frequency_Irr != null || Cfobjt.CashFlows_Irr != null)
            {
                Input2 = CfIRRMethod(Cfobjt);
                CalcDisplay.Text = NumToStringFormated(Input2, Format);
                CalcOppsDisplay.Text = BtnIrr.Text;
                Expression_Compute();

                Cfobjt.Frequency_Irr.Clear();
                Cfobjt.CashFlows_Irr.Clear();
                Cfobjt.Frequency_Irr.AddRange(Cfobjt.Frequency_Input); // Reset Inputs
                Cfobjt.CashFlows_Irr.AddRange(Cfobjt.CashFlows_Input);
                Cfobjt.CF0_Irr = Cfobjt.CF0_Input;
            }
            // else do nothing.
        }

        /// <summary>
        /// Computes the Amortization of a Time Value of Money and Amort Object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Amort_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_AMORT amortDialog = new Dialog_AMORT();
            amortDialog.Show(transaction, "dialog Fragment");

            amortDialog.mOnAmortComptComplete += AmortDialog_mOnAmortComptComplete;
        }

        /// <summary>
        /// Amort Compute Button Click On Complete Event, Displays the Results of the Computation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AmortDialog_mOnAmortComptComplete(object sender, OnAmortComputeEventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_AMORTOUTPUT amortOutDialog = new Dialog_AMORTOUTPUT(e.AmortObj);
            amortOutDialog.Show(transaction, "dialog Fragment");
        }

        /// <summary>
        /// Takes the Square Root of a Number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sqrt_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);

            /*
            Input2 = SqrtCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnSqrt.Text;
            Expression_Compute(); */
        }

        /// <summary>
        /// Squares the parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Squared_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = SquareCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnSquared.Text;
            Expression_Compute(); */
        }

        /// <summary>
        /// Places One Over the Parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneOver_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = OneOverCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnOneOver.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Calculates Euler's Number raised to a specified power
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void E_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = ECompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnE.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Natural log or Log base "e" of a parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ln_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = NaturalLogCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnLn.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Log or the Log base "10" of a Parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = LogCompt(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnLog.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes a permutation of two inputs 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Npr_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_NPR nPrDialog = new Dialog_NPR();
            nPrDialog.Show(transaction, "dialog Fragment");

            nPrDialog.mOnNPRComptComplete += nPrDialog_mOnNPRComptComplete;
        }

        /// <summary>
        /// nPr Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nPrDialog_mOnNPRComptComplete(object sender, OnNPRComputeEventArgs e)
        {
            Input2 = e.ComputedNPR;
            CalcDisplay.Text = NumToStringFormated(e.ComputedNPR, Format);
            CalcOppsDisplay.Text = BtnNpr.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes a combination of two inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ncr_Button_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_NCR nCrDialog = new Dialog_NCR();
            nCrDialog.Show(transaction, "dialog Fragment");

            nCrDialog.mOnNCRComptComplete += nCrDialog_mOnNCRComptComplete;
        }

        /// <summary>
        /// nCPr Compute Button Click On Complete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nCrDialog_mOnNCRComptComplete(object sender, OnNCRComputeEventArgs e)
        {
            Input2 = e.ComputedNCR;
            CalcDisplay.Text = NumToStringFormated(e.ComputedNCR, Format);
            CalcOppsDisplay.Text = BtnNcr.Text;
            Expression_Compute();
        }

        /// <summary>
        /// Computes the factorial recursion of a parameter. Note, this is an example of an
        /// extension method. It is understood that a normal method would work just as well for this computation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Factorial_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = StringToNum(CalcDisplay.Text).Factorial_Recursion();
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnFactorial.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Sin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sin_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = SinCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnSin.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the CoSin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cos_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = CosCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnCos.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Tangent of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tan_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = TanCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnTan.Text;
            Expression_Compute(); */
        }

        /// <summary>
        /// Computes the Asin or Inverse Sin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Asin_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = AsinCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnAsin.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Acos or inverse CoSin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acos_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = AcosCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnAcos.Text;
            Expression_Compute();*/
        }

        /// <summary>
        /// Computes the Atan or inverse Tangent of a Parameter  in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Atan_Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IsSingleInput = true;
            IsOppPerformed = true;
            IsOppRepeated = false;
            IsNewInput = true;
            OppPerformed = button.Text;
            Operator_Click(sender, e);
            /*Input2 = AtanCompute(StringToNum(CalcDisplay.Text));
            CalcDisplay.Text = NumToStringFormated(Input2, Format);
            CalcOppsDisplay.Text = BtnAtan.Text;
            Expression_Compute();*/
        }
        #endregion

    }
}

