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
    /// Compute nPr Click Event
    /// </summary>
    public class OnNPRComputeEventArgs : EventArgs
    {
        private double mComputedNPR;

        public double ComputedNPR
        {
            get { return mComputedNPR; }
            set { mComputedNPR = value; }
        }

        public OnNPRComputeEventArgs(double computedNPR) : base()
        {
            ComputedNPR = computedNPR;
        }
    }

    /// <summary>
    /// Inflates a view for Computing nPr;
    /// </summary>
    public class Dialog_NPR : DialogFragment
    {
        private EditText mN;
        private EditText mR;
        private Button mBtnNPRCompute;

        public event EventHandler<OnNPRComputeEventArgs> mOnNPRComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_npr, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_npr_N);
            mR = view.FindViewById<EditText>(Resource.Id.txt_npr_R);

            mBtnNPRCompute = view.FindViewById<Button>(Resource.Id.btnNPRCompute);

            mBtnNPRCompute.Click += mBtnNPRCompute_Click;

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
        /// User has clicked the nPr compute Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnNPRCompute_Click(object sender, EventArgs e)
        {
            double NPR;
            double N;
            double R;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mN.Text, out double w)) == false)
            {
                mN.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mR.Text, out double x)) == false)
            {
                mR.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                N = double.Parse(mN.Text);
                R = double.Parse(mR.Text);

                NPR = NprCompute(N, R);

                mOnNPRComptComplete.Invoke(this, new OnNPRComputeEventArgs(NPR));
                this.Dismiss();
            }
        }
    }
}