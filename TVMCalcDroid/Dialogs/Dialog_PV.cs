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
    /// Compute PV Click Event
    /// </summary>
    public class OnPvComputeEventArgs : EventArgs
    {
        private double mComputedPV;

        public double ComputedPV
        {
            get { return mComputedPV; }
            set { mComputedPV = value; }
        }

        public OnPvComputeEventArgs(double computedPV) : base()
        {
            ComputedPV = computedPV;
        }
    }

    /// <summary>
    /// Inflates a view for Computing PV;
    /// </summary>
    public class Dialog_PV : DialogFragment
    {
        private EditText mN;
        private EditText mIY;
        private EditText mPMT;
        private EditText mFV;
        private TextView mComputeMode;
        private Switch mMode;
        private Button mBtnPVCompute;
        private bool IsBegMode= false;
        private bool IsToggled = false;

        public event EventHandler<OnPvComputeEventArgs> mOnPvComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_pv, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_pv_N);
            mIY = view.FindViewById<EditText>(Resource.Id.txt_pv_I);
            mPMT = view.FindViewById<EditText>(Resource.Id.txt_pv_PMT);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_pv_FV);
            mMode = view.FindViewById<Switch>(Resource.Id.ComputeModePv);
            mComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_pvview);

            mBtnPVCompute = view.FindViewById<Button>(Resource.Id.btnPVCompute);


            mMode.CheckedChange += mMode_Toggled;

            mBtnPVCompute.Click += mBtnPVCompute_Click;

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
        /// User has clicked the PV compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnPVCompute_Click(object sender, EventArgs e)
        {
            TvmObject O = new TvmObject();
            double Pv;
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
                O.N = double.Parse(mN.Text);
                O.I = double.Parse(mIY.Text);
                O.Pmt = double.Parse(mPMT.Text);
                O.Fv = double.Parse(mFV.Text);

                if (this.IsBegMode == true)
                {
                    Pv = PvAdCompute(O);
                }
                else
                {
                    Pv = PvCompute(O);
                }

                mOnPvComptComplete.Invoke(this, new OnPvComputeEventArgs(Pv));
                this.Dismiss();
            }
        }
    }
}