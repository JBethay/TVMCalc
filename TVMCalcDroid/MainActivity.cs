using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Content.PM;
using static TVMCalcDroid.Helper.HelperCalc;
using static TVMCalc.Operations.Methods.PrimaryOppsMethods;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;
using System.Linq;

namespace TVMCalcDroid
{
    [Activity(Label = "TVMCalcDroid", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    ScreenOrientation = ScreenOrientation.Portrait)] // Locking screen orientation to Portrait.
    public class MainActivity : Activity
    {
        #region UI Buttons & TextViews
        Button BtnOpen, BtnClose, BtnBack, BtnDevide, Btn7, Btn8, Btn9, BtnMultiply;
        Button Btn4, Btn5, Btn6, BtnMinus, Btn1, Btn2, Btn3, BtnPlus, BtnCEC, Btn0, BtnDot, BtnEquals;
        Button BtnClr, BtnFormat, BtnRound, BtnPercent, BtnPlusMinus;
        Button BtnN, BtnIy, BtnPv, BtnPmt, BtnFv, BtnCf, BtnNpv, BtnIrr, BtnAmort;
        Button BtnPower, BtnSqrt, BtnSquared, BtnOneOver, BtnRand, BtnLn;
        Button BtnLog, BtnNpr, BtnNcr, BtnFactorial, BtnSin, BtnCos, BtnTan;
        Button BtnAsin, BtnAcos, BtnAtan;
        TextView CalcDispaly, CalcOppsDisplay;

        #endregion

        #region Properties Used for Button Clicks
        private bool IsOppPreformed { get; set; }
        private bool IsNewInput { get; set; }
        private int Format = 2;
        private double Input1 { get; set; }
        private double Input2 { get; set; }
        //public string Input3 { get; set; }
        private double Result = 0;
        private double ResultTrue = 0;
        private string OppPreformed { get; set; }
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            

            // Set the view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            ActionBar.Hide(); // Hides the action Bar

            #region Keys & Text Views
            CalcDispaly = FindViewById<TextView>(Resource.Id.Calculator_text_view);
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
            BtnRand = FindViewById<Button>(Resource.Id.RandCompt_Key);
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
            BtnEquals.Click += Equals_Click;
            BtnClr.Click += CE_Click;
            BtnBack.Click += Back_Click;

            BtnFormat.Click += Format_Click;
            BtnRound.Click += Round_Click;
            BtnPercent.Click += Percent_Click;
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

            BtnPower.Click += Power_Button_Click;
            BtnSqrt.Click += Sqrt_Button_Click;
            BtnSquared.Click += Squared_Button_Click;
            BtnOneOver.Click += OneOver_Button_Click;
            BtnRand.Click += Rand_Button_Click;
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
            if (IsNewInput == false && CalcDispaly.Text != "")
            {
                if ((IsOppPreformed == true) || (StringToNum(CalcDispaly.Text) == 0))
                {
                    CalcDispaly.Text = "";
                }
            }
            Button button = (Button)sender;
            IsNewInput = true;
            if (button.Text == ".")
            {
                if (!CalcDispaly.Text.Contains("."))
                {
                    if (CalcDispaly.Text == "")
                    {
                        CalcDispaly.Text = "0.";
                    }
                    else
                    {
                        CalcDispaly.Text = $"{CalcDispaly.Text}{button.Text}";
                        Input1 = StringToNum(CalcDispaly.Text);
                    }
                }
            }
            else
            {
                CalcDispaly.Text = $"{CalcDispaly.Text}{button.Text}";
                Input1 = StringToNum(CalcDispaly.Text);
            }
        }

        /// <summary>
        /// Equals Key click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equals_Click(object sender, EventArgs e)
        {
            if (IsOppPreformed == true && IsNewInput == true)
            {
                Input2 = Input1;
                switch (OppPreformed)
                {
                    case "+":
                        ResultTrue = AddCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToStringFormated(Result, Format);
                        break;
                    case "-":
                        ResultTrue = SubtractCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToStringFormated(Result, Format);
                        break;
                    case "×":
                        ResultTrue = MultiplyCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToStringFormated(Result, Format);
                        break;
                    case "÷":
                        ResultTrue = DevideCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToStringFormated(Result, Format);
                        break;
                    default:
                        ResultTrue = Input2;
                        break;
                }
                //Input2 = StringToNum(CalcDispaly.Text);
                //Result = ResultTrue;
                IsOppPreformed = false;
                IsNewInput = false;
            }
            else
            {
                Input2 = StringToNum(CalcDispaly.Text);
                CalcDispaly.Text = NumToStringFormated(Input2, Format);
                ResultTrue = Input2;
                IsNewInput = false;
                IsOppPreformed = false;
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

            if (IsOppPreformed == false)
            {
                if (CalcDispaly.Text != "")
                { 
                BtnEquals.PerformClick();
                OppPreformed = button.Text;
                IsOppPreformed = true;
                //HOW TO SHOW WHAT OPP IS BEING USED?
                }
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
            CalcDispaly.Text = NumToStringFormated(0, Format);
            ResultTrue = 0;
            Result = 0;
            Input1 = 0;
            Input2 = 0;
            IsOppPreformed = false;
            IsNewInput = false;
        }

        /// <summary>
        /// Back Key Click, removes the string at the end of the text view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            if (CalcDispaly.Text.Length != 0)
            {
                if (CalcDispaly.Text.Length == 1)
                {
                    CalcDispaly.Text = "0";
                }
                else
                {
                    CalcDispaly.Text = (CalcDispaly.Text.Substring(0, CalcDispaly.Text.Length - 1));
                }
            }
        }

        //TODO
        private void Open_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Close_Button_Click(object sender, EventArgs e)
        {

        }

        // TODO
        private void Format_Click(object sender, EventArgs e)
        {
            // Fragment Transaction.
        }

        // TODO
        private void Round_Click(object sender, EventArgs e)
        {
            // Fragment Transaction.
        }

        /// <summary>
        /// Converts the String Input to a percentage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Percent_Click(object sender, EventArgs e)
        {
            Input2 = PercentCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
            BtnEquals.PerformClick();
        }

        /// <summary>
        /// Provides the inverse of the passed parameter. Note this is an example of an extension method
        /// although it is understood that a normal method would work just as well for this computation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlusMinus_Click(object sender, EventArgs e)
        {
            Input2 = (StringToNum(CalcDispaly.Text)).Plus_Minus();
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
            BtnEquals.PerformClick();
        }
        #endregion

        #region TVM and Secondary Operations
        //TODO
        private void N_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Iy_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Pv_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Pmt_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Fv_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Cf_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Npv_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Irr_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Amort_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Power_Button_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Takes the Square Root of a Number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sqrt_Button_Click(object sender, EventArgs e)
        {
            Input2 = SqrtCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Squares the parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Squared_Button_Click(object sender, EventArgs e)
        {
            Input2 = SquareCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Places One Over the Parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OneOver_Button_Click(object sender, EventArgs e)
        {
            Input2 = OneOverCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);

        }

        /// <summary>
        /// Generates a Random Percentage Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rand_Button_Click(object sender, EventArgs e)
        {
            Input2 = RandCompute();
            CalcDispaly.Text = NumToStringFormated(Input2,Format);
        }

        /// <summary>
        /// Computes the Natural log or Log base "e" of a parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ln_Button_Click(object sender, EventArgs e)
        {
            Input2 = NaturalLogCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Log or the Log base "10" of a Parameter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Log_Button_Click(object sender, EventArgs e)
        {
            Input2 = LogCompt(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        //TODO
        private void Npr_Button_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void Ncr_Button_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Computes the factorial recursion of a parameter. Note, this is an example of an
        /// extension method. It is understood that a normal method would work just as well for this computation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Factorial_Button_Click(object sender, EventArgs e)
        {
            Input2 = StringToNum(CalcDispaly.Text).Factorial_Recursion();
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Sin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sin_Button_Click(object sender, EventArgs e)
        {
            Input2 = SinCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the CoSin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cos_Button_Click(object sender, EventArgs e)
        {
            Input2 = CosCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Tangent of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tan_Button_Click(object sender, EventArgs e)
        {
            Input2 = TanCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Asin or Inverse Sin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Asin_Button_Click(object sender, EventArgs e)
        {
            Input2 = AsinCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Acos or inverse CoSin of a Parameter in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Acos_Button_Click(object sender, EventArgs e)
        {
            Input2 = AcosCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }

        /// <summary>
        /// Computes the Atan or inverse Tangent of a Parameter  in degrees
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Atan_Button_Click(object sender, EventArgs e)
        {
            Input2 = AtanCompute(StringToNum(CalcDispaly.Text));
            CalcDispaly.Text = NumToStringFormated(Input2, Format);
        }
        #endregion


        /*
        private void Btn2ND_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_2nd createAccountDialog = new Dialog_2nd();
            createAccountDialog.Show(transaction, "dialog Fragment");
        }
        */
    }
}

