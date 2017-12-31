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
using System.Linq;

namespace TVMCalcDroid
{
    [Activity(Label = "TVMCalcDroid", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    ScreenOrientation = ScreenOrientation.Portrait)] // Locking screen orientation to Portrait.
    public class MainActivity : Activity
    {
        Button BtnOpen, BtnClose, BtnBack, BtnDevide, Btn7, Btn8, Btn9, BtnMultiply;
        Button Btn4, Btn5, Btn6, BtnMinus, Btn1, Btn2, Btn3, BtnPlus, BtnCEC, Btn0, BtnDot, BtnEquals;
        Button BtnClr;
        TextView CalcDispaly;

        private bool IsOppPreformed { get; set; }
        private bool IsNewInput { get; set; }
        private int Format = 2;
        private double Input1 { get; set; }
        private double Input2 { get; set; }
        private double Result = 0;
        private double ResultTrue = 0;
        private string OppPreformed { get; set; }

    protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            CalcDispaly = FindViewById<TextView>(Resource.Id.Calculator_text_view);

            #region Keys           
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

            #endregion

            #region Button_Clicks
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

            BtnPlus.Click += Operator_Click;
            BtnMinus.Click += Operator_Click;
            BtnDevide.Click += Operator_Click;
            BtnMultiply.Click += Operator_Click;
            BtnEquals.Click += Equals_Click;
            BtnClr.Click += CE_Click;
            BtnBack.Click += Back_Click;
            #endregion

        }

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
                        CalcDispaly.Text = NumToString(0.00,Format); // plus formated number of zeros. 
                    }
                    else
                    {
                        CalcDispaly.Text = StringToFormatedString($"{CalcDispaly.Text}{button.Text}",Format);
                        Input1 = StringToNum(CalcDispaly.Text);
                    }
                }
            }
            else
            {
                CalcDispaly.Text = StringToFormatedString($"{CalcDispaly.Text}{button.Text}", Format);
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
                        CalcDispaly.Text = NumToString(Result, Format);
                        break;
                    case "-":
                        ResultTrue = SubtractCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToString(Result, Format);
                        break;
                    case "×":
                        ResultTrue = MultiplyCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToString(Result, Format);
                        break;
                    case "÷":
                        ResultTrue = DevideCompt(ResultTrue, Input2);
                        Result = ResultTrue;
                        CalcDispaly.Text = NumToString(Result, Format);
                        break;
                    default:
                        ResultTrue = Input2;
                        break;
                }
                Input2 = StringToNum(CalcDispaly.Text);
                Result = ResultTrue;
                IsOppPreformed = false;
                IsNewInput = false;
            }
            else
            {
                Input2 = StringToNum(CalcDispaly.Text);
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
                BtnEquals.PerformClick();
                OppPreformed = button.Text;
                IsOppPreformed = true;
                //HOW TO SHOW WHAT OPP IS BEING USED?
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
            CalcDispaly.Text = NumToString(0,Format);
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
        private void Back_Click(object sender, EventArgs e) //back click
        {
            if (CalcDispaly.Text.Length != 0)
            {
                CalcDispaly.Text = (CalcDispaly.Text.Substring(0, CalcDispaly.Text.Length - 1));
            }

        }

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

