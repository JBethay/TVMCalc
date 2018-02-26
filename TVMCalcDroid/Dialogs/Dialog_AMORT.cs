using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TVMCalc.Operations.ObjctTemps;
using static TVMCalc.Operations.Methods.TVMMethods;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

namespace TVMCalcDroid.Dialogs
{
    /// <summary>
    /// Compute Amrot Click Event
    /// </summary>
    public class OnAmortComputeEventArgs : EventArgs
    {
        private AmortObject mAmortObj;

        public AmortObject AmortObj
        {
            get { return mAmortObj; }
            set { mAmortObj = value; }
        }

        public OnAmortComputeEventArgs(AmortObject amortObj) : base()
        {
            AmortObj = amortObj;
        }
    }

    /// <summary>
    /// Inflates a view for Computing Amort;
    /// </summary>
    public class Dialog_AMORT : DialogFragment
    {
        private EditText mN;
        private EditText mIY;
        private EditText mPV;
        private EditText mPMT;
        private EditText mFV;
        private EditText mP1;
        private EditText mP2;
        private Button mBtnPMTCompute;
        private Button mBtnAMORTCompute;

        public event EventHandler<OnAmortComputeEventArgs> mOnAmortComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_amortinput, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_amort_N);
            mIY = view.FindViewById<EditText>(Resource.Id.txt_amort_I);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_amort_PV);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_amort_PMT);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_amort_FV);
            mP1 = view.FindViewById<EditText>(Resource.Id.txt_amort_P1);
            mP2 = view.FindViewById<EditText>(Resource.Id.txt_amort_P2);

            mBtnPMTCompute = view.FindViewById<Button>(Resource.Id.btnAmortPMTCompute);
            mBtnAMORTCompute = view.FindViewById<Button>(Resource.Id.btnAmortCompute);

            mBtnPMTCompute.Click += mBtnPMTCompute_Click;
            mBtnAMORTCompute.Click += mBtnAMORTCompute_Click;

            return view;
        }

        /// <summary>
        /// Removes title bar and adds animation.
        /// </summary>
        /// <param name="savedInstanceState"></param>
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Removes the title
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim; // adds create and destroy animation
        }

        /// <summary>
        /// User has clicked the PMT compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnPMTCompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            double Pmt;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double w)) == false)
            {
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mIY.Text, out double x)) == false)
            {
                mIY.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double y)) == false)
            {
                mPV.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mFV.Text, out double z)) == false)
            {
                mFV.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                O.N = double.Parse(mN.Text);
                O.I = double.Parse(mIY.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Fv = double.Parse(mFV.Text);
                Pmt = PmtCompute(O);

                mPMT.Text = Pmt.ToString();
            }
        }

        /// <summary>
        /// Use has clicked the Amort Compute Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnAMORTCompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            AmortObject A = new AmortObject();
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double t)) == false)
            {
                mN.Text = "";
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mIY.Text, out double u)) == false)
            {
                mIY.Text = "";
                mIY.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double v)) == false)
            {
                mPV.Text = "";
                mPV.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPMT.Text, out double w)) == false)
            {
                mPMT.Text = "";
                mPMT.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mFV.Text, out double x)) == false)
            {
                mFV.Text = "";
                mFV.Hint = "Invalid Input";
                Valid = false;
            }
            if ((Int32.TryParse(mP1.Text, out int y)) == false)
            {
                mP1.Text = "";
                mP1.Hint = "Invalid Input";
                Valid = false;
            }
            if ((Int32.TryParse(mP1.Text, out int y1)) == true)
            {
                if (!(Int32.Parse(mP1.Text) >= 1))
                {
                    mP1.Text = "";
                    mP1.Hint = "P1 Must Be At Least Equal To 1";
                    Valid = false;
                }
            }
            if (((Int32.TryParse(mP1.Text, out int y2)) == true) && (Int32.TryParse(mP2.Text, out int y3)) == true)
            {
                if (!(Int32.Parse(mP1.Text) <= Int32.Parse(mP2.Text)))
                {
                    mP1.Text = "";
                    mP1.Hint = "P1 Must Be Less Than Or Equal To P2";
                    Valid = false;
                }
            }
            if ((Int32.TryParse(mP2.Text, out int z)) == false)
            {
                mP2.Text = "";
                mP2.Hint = "Invalid Input";
                Valid = false;
            }
            if ((((double.TryParse(mP1.Text, out double yz1)) == true) && (double.TryParse(mP2.Text, out double yz2)) == true) && (double.TryParse(mN.Text, out double yz3) == true))
            {
                if(!(double.Parse(mP1.Text) <= double.Parse(mN.Text)))
                {
                    mP1.Text = "";
                    mP1.Hint = "P1 Must Be Less Than Or Equal To N";
                    Valid = false;
                }
                if (!(double.Parse(mP2.Text) <= double.Parse(mN.Text)))
                {
                    mP2.Text = "";
                    mP2.Hint = "P2 Must Be Less Than Or Equal To N";
                    Valid = false;
                }
            }
            #endregion

            if (Valid == true)
            {
                O.N = double.Parse(mN.Text);
                O.I = double.Parse(mIY.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Fv = double.Parse(mFV.Text);
                A.P1 = Convert.ToInt32(mP1.Text);
                A.P2 = Convert.ToInt32(mP2.Text);

                A = AmortCompute(O, A);

                mOnAmortComptComplete.Invoke(this, new OnAmortComputeEventArgs(A));
                this.Dismiss();
            }

        }
    }
}