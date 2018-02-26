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
    /// Compute FV Click Event
    /// </summary>
    public class OnFvComputeEventArgs : EventArgs
    {
        private double mComputedFV;

        public double ComputedFV
        {
            get { return mComputedFV; }
            set { mComputedFV = value; }
        }

        public OnFvComputeEventArgs(double computedFV) : base()
        {
            ComputedFV = computedFV;
        }
    }

    /// <summary>
    /// Inflates a view for Computing FV;
    /// </summary>
    public class Dialog_FV : DialogFragment
    {
        private EditText mN;
        private EditText mIY;
        private EditText mPV;
        private EditText mPMT;
        private TextView mComputeMode;
        private Switch mMode;
        private Button mBtnFVCompute;
        private bool IsBegMode= false;
        private bool IsToggled = false;

        public event EventHandler<OnFvComputeEventArgs> mOnFvComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_fv, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_fv_N);
            mIY = view.FindViewById<EditText>(Resource.Id.txt_fv_I);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_fv_PMT);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_fv_PV);
            mMode = view.FindViewById<Switch>(Resource.Id.ComputeModeFv);
            mComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_fvview);

            mBtnFVCompute = view.FindViewById<Button>(Resource.Id.btnFVCompute);


            mMode.CheckedChange += mMode_Toggled;

            mBtnFVCompute.Click += mBtnFVCompute_Click;

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
        /// User has clicked the FV compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnFVCompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            double Fv;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double w)) == false)
            {
                mN.Text = "";
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mIY.Text, out double x)) == false)
            {
                mIY.Text = "";
                mIY.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPMT.Text, out double y)) == false)
            {
                mPMT.Text = "";
                mPMT.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mPV.Text, out double z)) == false)
            {
                mPV.Text = "";
                mPV.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                O.N = double.Parse(mN.Text);
                O.I = double.Parse(mIY.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Pv = double.Parse(mPV.Text);

                if (this.IsBegMode == true)
                {
                    Fv = FvAdCompute(O);
                }
                else
                {
                    Fv = FvCompute(O);
                }

                mOnFvComptComplete.Invoke(this, new OnFvComputeEventArgs(Fv));
                this.Dismiss();
            }
        }
    }
}