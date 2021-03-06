﻿using System;
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
    /// Compute PMT Click Event
    /// </summary>
    public class OnPmtComputeEventArgs : EventArgs
    {
        private double mComputedPMT;

        public double ComputedPMT
        {
            get { return mComputedPMT; }
            set { mComputedPMT = value; }
        }

        public OnPmtComputeEventArgs(double computedPMT) : base()
        {
            ComputedPMT = computedPMT;
        }
    }

    /// <summary>
    /// Inflates a view for Computing PMT;
    /// </summary>
    public class Dialog_PMT : DialogFragment
    {
        private EditText mN;
        private EditText mIY;
        private EditText mPV;
        private EditText mFV;
        private TextView mComputeMode;
        private Switch mMode;
        private Button mBtnPMTCompute;
        private bool IsBegMode= false;
        private bool IsToggled = false;

        public event EventHandler<OnPmtComputeEventArgs> mOnPmtComptComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_pmt, container, false);

            mN = view.FindViewById<EditText>(Resource.Id.txt_pmt_N);
            mIY = view.FindViewById<EditText>(Resource.Id.txt_pmt_I);
            mPV = view.FindViewById<EditText>(Resource.Id.txt_pmt_PV);
            mFV = view.FindViewById<EditText>(Resource.Id.txt_pmt_FV);
            mMode = view.FindViewById<Switch>(Resource.Id.ComputeModePmt);
            mComputeMode = view.FindViewById<TextView>(Resource.Id.Compute_Mode_pmtview);

            mBtnPMTCompute = view.FindViewById<Button>(Resource.Id.btnPMTCompute);


            mMode.CheckedChange += mMode_Toggled;

            mBtnPMTCompute.Click += mBtnPMTCompute_Click;

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
            if ((double.TryParse(mPV.Text, out double y)) == false)
            {
                mPV.Text = "";
                mPV.Hint = "Invalid Input";
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
                O.I = double.Parse(mIY.Text);
                O.Pv = double.Parse(mPV.Text);
                O.Fv = double.Parse(mFV.Text);

                if (this.IsBegMode == true)
                {
                    Pmt = PmtAdCompute(O);
                }
                else
                {
                    Pmt = PmtCompute(O);
                }

                mOnPmtComptComplete.Invoke(this, new OnPmtComputeEventArgs(Pmt));
                this.Dismiss();
            }
        }
    }
}