using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.Content.PM;

namespace TVMCalcDroid
{
    [Activity(Label = "TVMCalcDroid", MainLauncher = true,ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
    ScreenOrientation = ScreenOrientation.Portrait)] // Locking screen orientaiton to Portrait.
    public class MainActivity : Activity
    {
        Button BtnOpen, BtnClose, BtnPlusMinus, BtnDevide, Btn7, Btn8, Btn9, BtnMultiply;
        Button Btn4, Btn5, Btn6, BtnMinus, Btn1, Btn2, Btn3, BtnPlus, BtnCEC, Btn0, BtnDot, BtnEquals;
        Button BtnCpt, BtnEnter, BtnUp, BtnDown, BtnBegEnd, Btn2ND;
        Button BtnN, BtnIY, BtnPv, BtnPmt, BtnFv, BtnClrTvm;
        Button BtnAmort, BtnNpv, BtnIrr, BtnCf, BtnPercent, BtnPower;
        Button BtnNpr, BtnNcr, BtnSin, BtnCos, BtnTan, BtnAsin, BtnAcos, BtnAtan;
        Button BtnSqrt, BtnSquare, BtnOneOver, BtnLn, BtnLog, BtnRound, BtnFactorial;

        TextView CalcDispaly;

        public List<Button> Operation_Keys = new List<Button> {};
        public List<Button> Num_Keys = new List<Button> {};

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //View rootInLandscapeLayout = this.LayoutInflater.Inflate(Resource.Layout.MainL, null);
            //View rootIn2NDLayout = this.LayoutInflater.Inflate(Resource.Layout.dialog_2nd, null);
            /*
            CalcDispaly = FindViewById<TextView>(Resource.Id.Calculator_text_view);

            #region Portrait View Keys           
            BtnOpen = FindViewById<Button>(Resource.Id.Parenthesie_Open_Key);
            BtnClose = FindViewById<Button>(Resource.Id.Parenthesie_Closed_Key);
            BtnPlusMinus = FindViewById<Button>(Resource.Id.Plus_Minus_Key);
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
            #endregion
            
            #region Landscape View Keys
            BtnCpt = FindViewById<Button>(Resource.Id.CPT_Key);
            BtnEnter = FindViewById<Button>(Resource.Id.ENTER_Key);
            BtnUp = FindViewById<Button>(Resource.Id.Up_Key);
            BtnDown = FindViewById<Button>(Resource.Id.Down_Key);
            BtnBegEnd = FindViewById<Button>(Resource.Id.BGN_Key);
            Btn2ND = FindViewById<Button>(Resource.Id.Second_Key);
            BtnN = FindViewById<Button>(Resource.Id.N_Key);
            BtnIY = FindViewById<Button>(Resource.Id.IY_Key);
            BtnPv = FindViewById<Button>(Resource.Id.PV_Key);
            BtnPmt = FindViewById<Button>(Resource.Id.PMT_Key);
            BtnFv = FindViewById<Button>(Resource.Id.FV_Key);
            BtnClrTvm = FindViewById<Button>(Resource.Id.ClrTvm_Key);
            BtnAmort = FindViewById<Button>(Resource.Id.Amort_Key);
            BtnNpv = FindViewById<Button>(Resource.Id.NPR_Key);
            BtnIrr = FindViewById<Button>(Resource.Id.IRR_Key);
            BtnCf = FindViewById<Button>(Resource.Id.CF_Key);
            BtnPercent = FindViewById<Button>(Resource.Id.Percent_Key);
            BtnPower = FindViewById<Button>(Resource.Id.Power_Key);
            #endregion

            #region 2nd view Keys
            BtnNpr = FindViewById<Button>(Resource.Id.NPR_Key);
            BtnNcr = FindViewById<Button>(Resource.Id.NCR_Key);
            BtnSin = FindViewById<Button>(Resource.Id.Sin_Key);
            BtnCos = FindViewById<Button>(Resource.Id.Cos_Key);
            BtnTan = FindViewById<Button>(Resource.Id.Tan_Key);
            BtnAsin = FindViewById<Button>(Resource.Id.Asin_Key);
            BtnAcos = FindViewById<Button>(Resource.Id.Acos_Key);
            BtnAtan = FindViewById<Button>(Resource.Id.Atan_Key);
            BtnSqrt = FindViewById<Button>(Resource.Id.Sqrt_Key);
            BtnSquare = FindViewById<Button>(Resource.Id.Square_Key);
            BtnOneOver = FindViewById<Button>(Resource.Id.OneOver_Key);
            BtnLn = FindViewById<Button>(Resource.Id.NaturalLog_Key);
            BtnLog = FindViewById<Button>(Resource.Id.Log_Key);
            BtnRound = FindViewById<Button>(Resource.Id.Round_Key);
            BtnFactorial = FindViewById<Button>(Resource.Id.Factorial_Key);
            #endregion
            */
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

