using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TVMCalc.Operations.ObjctTemps;
using static TVMCalc.Operations.Methods.TVMMethods;

namespace TVMCalcDroid.Dialogs
{
    /// <summary>
    /// Compute N Click Event
    /// </summary>
    public class OnNComputeEventArgs : EventArgs
    {
        private double mComputedN;

        public double ComputedN
        {
            get { return mComputedN; }
            set { mComputedN = value; }
        }

        public OnNComputeEventArgs(double computedN) : base()
        {
            ComputedN = computedN;
        }
    }

    /// <summary>
    /// Inflates a view for Computing N;
    /// </summary>
    public class Dialog_N : DialogFragment
    {
        private EditText mIY;
        private EditText mPV;
        private EditText mPMT;
        private EditText mFV;
        private Button mBtnNCompute;        

        public event EventHandler<OnNComputeEventArgs> mOnNComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_n, container, false);

            mIY = view.FindViewById<EditText>(Resource.Id.txt_n_IY);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_n_PV);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_n_PMT);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_n_FV);

            mBtnNCompute = view.FindViewById<Button>(Resource.Id.btnNCompute);

            mBtnNCompute.Click += mBtnNCompute_Click;

            return view;
        }

        /// <summary>
        /// User has clicked the N compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnNCompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            double N;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mIY.Text, out double w)) == false)
            {
                mIY.Text = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double x)) == false)
            {
                mPV.Text = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPMT.Text, out double y)) == false)
            {
                mPMT.Text = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mFV.Text, out double z)) == false)
            {
                mFV.Text = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                O.I = double.Parse(mIY.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Fv = double.Parse(mFV.Text);

                N = NCompute(O);

                mOnNComptComplete.Invoke(this, new OnNComputeEventArgs(N));
                this.Dismiss();
            }
        }
    }
}