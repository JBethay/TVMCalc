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
        private TextView mComputeMode;
        private Switch mMode;
        private Button mBtnNCompute;
        private bool IsBegMode= false;
        private bool IsToggled = false;

        public event EventHandler<OnNComputeEventArgs> mOnNComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_n, container, false);

            mIY = view.FindViewById<EditText>(Resource.Id.txt_n_IY);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_n_PV);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_n_PMT);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_n_FV);
            mMode = view.FindViewById<Switch>(Resource.Id.ComputeModeN);
            mComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_nview);

            mBtnNCompute = view.FindViewById<Button>(Resource.Id.btnNCompute);


            mMode.CheckedChange += mMode_Toggled;

            mBtnNCompute.Click += mBtnNCompute_Click;

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
        /// set the Compute mode for the calc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mMode_Toggled(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (IsToggled == false)
            {
                IsBegMode = true;
                IsToggled = true;
                mComputeMode.Text = "Annuity Due";
            }
            else
            {
                IsBegMode = false;
                IsToggled = false;
                mComputeMode.Text = "Regular Annuity";
            }
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
                mIY.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double x)) == false)
            {
                mPV.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPMT.Text, out double y)) == false)
            {
                mPMT.Hint = "Invalid Input";
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
                O.I = double.Parse(mIY.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Fv = double.Parse(mFV.Text);

                if (this.IsBegMode == true)
                {
                    N = NAdCompute(O);
                }
                else
                {
                    N = NCompute(O);
                }

                mOnNComptComplete.Invoke(this, new OnNComputeEventArgs(N));
                this.Dismiss();
            }
        }
    }
}