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
    /// Add CF Click Event
    /// </summary>
    public class OnCFAddEventArgs : EventArgs
    {
        private double mCF0;
        private double mCF;
        private double mFREQ;

        public double CF0
        {
            get { return mCF0; }
            set { mCF0 = value; }
        }
        public double CF
        {
            get { return mCF; }
            set { mCF = value; }
        }
        public double FREQ
        {
            get { return mFREQ; }
            set { mFREQ = value; }
        }

        public OnCFAddEventArgs(double cF0, double cF, double fREQ) : base()
        {
            CF0 = cF0;
            CF = cF;
            FREQ = fREQ;
        }
    }

    /// <summary>
    /// Inflates a view for adding cash flows;
    /// </summary>
    public class Dialog_CF : DialogFragment
    {
        private EditText mCF0;
        private EditText mCF;
        private EditText mFREQ;
        private TextView mCFComputeMode;
        private Button mBtnCFAdd;
        private Button mBtnCFDone;

        public event EventHandler<OnCFAddEventArgs> mOnCFAddComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_cf, container, false);

            mCF0 = view.FindViewById<EditText>(Resource.Id.txt_cf_CF0);
            mCF = view.FindViewById<EditText>(Resource.Id.txt_cf_CF);
            mFREQ = view.FindViewById<EditText>(Resource.Id.txt_cf_FREQ);

            mCFComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_cfview);

            mBtnCFAdd = view.FindViewById<Button>(Resource.Id.btnCFAdd);
            mBtnCFDone = view.FindViewById<Button>(Resource.Id.btnCFDone);

            mBtnCFAdd.Click += mBtnCFAdd_Click;
            mBtnCFDone.Click += MBtnCFDone_CLick;

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
        /// User has clicked the Add CF Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnCFAdd_Click(object sender, EventArgs e)
        {
            double CF0;
            double CF;
            double Freq;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mCF0.Text, out double w)) == false)
            {
                mCF0.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mCF.Text, out double x)) == false)
            {
                mCF.Hint = "Invalid Input";
                Valid = false;
            }
            if ((double.TryParse(mFREQ.Text, out double y)) == false)
            {
                mFREQ.Hint = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                CF0 = double.Parse(mCF0.Text);
                CF = double.Parse(mCF.Text);
                Freq = double.Parse(mFREQ.Text);

                mCFComputeMode.Text = $"CF{(int.Parse(mCFComputeMode.Text.Remove(0, 2)) + 1)}";

                mCF.Text = "";
                mFREQ.Text = "";
                mOnCFAddComplete.Invoke(this, new OnCFAddEventArgs(CF0,CF,Freq));
            }
        }

        /// <summary>
        /// User has clicked the Done Cf Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MBtnCFDone_CLick(object sender, EventArgs e)
        {
            this.Dismiss();
        }
    }
}