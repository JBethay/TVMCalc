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
    /// Compute IY Click Event
    /// </summary>
    public class OnIComputeEventArgs : EventArgs
    {
        private double mComputedI;

        public double ComputedI
        {
            get { return mComputedI; }
            set { mComputedI = value; }
        }

        public OnIComputeEventArgs(double computedI) : base()
        {
            ComputedI = computedI;
        }
    }

    /// <summary>
    /// Inflates a view for Computing IY;
    /// </summary>
    public class Dialog_I : DialogFragment
    {
        private EditText mN;
        private EditText mPV;
        private EditText mPMT;
        private EditText mFV;
        private TextView mComputeMode;
        private Switch mMode;
        private Button mBtnICompute;
        private bool IsBegMode= false;
        private bool IsToggled = false;

        public event EventHandler<OnIComputeEventArgs> mOnIComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_i, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_i_N);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_i_PV);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_i_PMT);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_i_FV);
            mMode = view.FindViewById<Switch>(Resource.Id.ComputeModeI);
            mComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_iview);

            mBtnICompute = view.FindViewById<Button>(Resource.Id.btnICompute);


            mMode.CheckedChange += mMode_Toggled;

            mBtnICompute.Click += mBtnICompute_Click;

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
        /// User has clicked the IY compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnICompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            double I;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double w)) == false)
            {
                mN.Text = "";
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double x)) == false)
            {
                mPV.Text = "";
                mPV.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPMT.Text, out double y)) == false)
            {
                mPMT.Text = "";
                mPMT.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mFV.Text, out double z)) == false)
            {
                mFV.Text = "";
                mFV.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                O.N = double.Parse(mN.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Fv = double.Parse(mFV.Text);

                if (this.IsBegMode == true)
                {
                    I = IAdCompute(O);
                }
                else
                {
                    I = ICompute(O);
                }

                mOnIComptComplete.Invoke(this, new OnIComputeEventArgs(I));
                this.Dismiss();
            }
        }
    }
}