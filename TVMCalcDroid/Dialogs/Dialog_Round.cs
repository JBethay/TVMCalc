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
    /// Compute Round Click Event
    /// </summary>
    public class OnRoundEventArgs : EventArgs
    {
        private int mComputedRound;

        public int ComputedRound
        {
            get { return mComputedRound; }
            set { mComputedRound = value; }
        }

        public OnRoundEventArgs(int computedRound) : base()
        {
            ComputedRound = computedRound;
        }
    }

    /// <summary>
    /// Inflates a view for Rounding;
    /// </summary>
    public class Dialog_Round : DialogFragment
    {
        private EditText mNumber;
        private Button mBtnRoundSet;

        public event EventHandler<OnRoundEventArgs> mOnRoundComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_round, container, false);

            mNumber = view.FindViewById<EditText>(Resource.Id.txt_round);

            mBtnRoundSet = view.FindViewById<Button>(Resource.Id.btnRoundCompute);

            mBtnRoundSet.Click += mBtnRoundSet_Click;

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
        /// User has clicked the Round Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnRoundSet_Click(object sender, EventArgs e)
        {
            int Round;
            double Formated;
            if (double.TryParse(mNumber.Text, out double result) == false)
                Formated = 0;
            else
                Formated = double.Parse(mNumber.Text);

            if (Formated < 0)
                Formated = 0;

                Round = Convert.ToInt32((Math.Round(Formated, 0)));
                mOnRoundComplete.Invoke(this, new OnRoundEventArgs(Round));
                this.Dismiss();
        }
    }
}