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
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

namespace TVMCalcDroid.Dialogs
{
    /// <summary>
    /// Compute nCr Click Event
    /// </summary>
    public class OnNCRComputeEventArgs : EventArgs
    {
        private double mComputedNCR;

        public double ComputedNCR
        {
            get { return mComputedNCR; }
            set { mComputedNCR = value; }
        }

        public OnNCRComputeEventArgs(double computedNCR) : base()
        {
            ComputedNCR = computedNCR;
        }
    }

    /// <summary>
    /// Inflates a view for Computing nCr;
    /// </summary>
    public class Dialog_NCR : DialogFragment
    {
        private EditText mN;
        private EditText mR;
        private Button mBtnNCRCompute;

        public event EventHandler<OnNCRComputeEventArgs> mOnNCRComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_ncr, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_ncr_N);
            mR = view.FindViewById<EditText>(Resource.Id.txt_ncr_R);

            mBtnNCRCompute = view.FindViewById<Button>(Resource.Id.btnNCRCompute);

            mBtnNCRCompute.Click += mBtnNCRCompute_Click;

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
        /// User has clicked the nCr compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnNCRCompute_Click(object sender, EventArgs e)
        {
            double NCR;
            double N;
            double R;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double w)) == false)
            {
                mN.Text = "";
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mR.Text, out double x)) == false)
            {
                mR.Text = "";
                mR.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                N = double.Parse(mN.Text);
                R = double.Parse(mR.Text);

                NCR = NcrCompute(N, R);

                mOnNCRComptComplete.Invoke(this, new OnNCRComputeEventArgs(NCR));
                this.Dismiss();
            }
        }
    }
}