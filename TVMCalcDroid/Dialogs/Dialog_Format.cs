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
    /// Compute Format Click Event
    /// </summary>
    public class OnFormatEventArgs : EventArgs
    {
        private int mComputedFormat;

        public int ComputedFormat
        {
            get { return mComputedFormat; }
            set { mComputedFormat = value; }
        }

        public OnFormatEventArgs(int computedFormat) : base()
        {
            ComputedFormat = computedFormat;
        }
    }

    /// <summary>
    /// Inflates a view for Computing Format;
    /// </summary>
    public class Dialog_Format : DialogFragment
    {
        private EditText mNumber;
        private Button mBtnFormatSet;

        public event EventHandler<OnFormatEventArgs> mOnFormatComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_format, container, false);

            mNumber = view.FindViewById<EditText>(Resource.Id.txt_format);

            mBtnFormatSet = view.FindViewById<Button>(Resource.Id.btnFormatCompute);

            mBtnFormatSet.Click += mBtnFormatSet_Click;

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
        /// User has clicked the Format Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnFormatSet_Click(object sender, EventArgs e)
        {
            int Format;
            double Formated;
            if (double.TryParse(mNumber.Text, out double result) == false)
                Formated = 0;
            else
                Formated = double.Parse(mNumber.Text);

            if (Formated < 0)
                Formated = 0;

                Format = Convert.ToInt32((Math.Round(Formated, 0)));
                mOnFormatComplete.Invoke(this, new OnFormatEventArgs(Format));
                this.Dismiss();
        }
    }
}