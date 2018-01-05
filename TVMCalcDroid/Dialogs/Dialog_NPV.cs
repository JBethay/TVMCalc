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
    /// Compute NPV Click Event
    /// </summary>
    public class OnNPVComputeEventArgs : EventArgs
    {
        private double mI;

        public double I
        {
            get { return mI; }
            set { mI = value; }
        }

        public OnNPVComputeEventArgs(double i) : base()
        {
            I = i;
        }
    }

    /// <summary>
    /// Inflates a view for NPV Compute;
    /// </summary>
    public class Dialog_NPV : DialogFragment
    {
        private EditText mI;
        private Button mBtnNpvCompute;

        public event EventHandler<OnNPVComputeEventArgs> mOnNPVComputeComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_npv, container, false);

            mI = view.FindViewById<EditText>(Resource.Id.txt_npv_I);

            mBtnNpvCompute = view.FindViewById<Button>(Resource.Id.btnNpvCompute);

            mBtnNpvCompute.Click += mBtnNpvCompute_Click;

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
        /// User has clicked the Compute NPV Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnNpvCompute_Click(object sender, EventArgs e)
        {
            double I;
            bool Valid = true;

            #region Verify Format
            if ((double.TryParse(mI.Text, out double w)) == false)
            {
                mI.Text = "Invalid Input";
                Valid = false;
            }
            #endregion

            if (Valid == true)
            {
                I = double.Parse(mI.Text);

                mOnNPVComputeComplete.Invoke(this, new OnNPVComputeEventArgs(I));
                this.Dismiss();

            }
        }
    }
}