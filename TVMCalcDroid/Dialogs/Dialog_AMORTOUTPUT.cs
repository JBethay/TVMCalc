using System;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using TVMCalc.Operations.ObjctTemps;
using static TVMCalc.Operations.Methods.TVMMethods;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

namespace TVMCalcDroid.Dialogs
{


    /// <summary>
    /// Inflates a view for AmortOutPut;
    /// </summary>
    public class Dialog_AMORTOUTPUT : DialogFragment
    {
        private TextView mBal;
        private TextView mPrin;
        private TextView mInt;
        private Button mBtnAmortDone;
        private AmortObject O;

        /// <summary>
        /// Constructor that requires a AmrotObj Param
        /// </summary>
        /// <param name="parameterIn"></param>
        public Dialog_AMORTOUTPUT(AmortObject parameterIn)
        {
            O = parameterIn;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.dialog_amortoutput, container, false);

            mBal = view.FindViewById<TextView>(Resource.Id.Amort_Bal_view);
            mPrin = view.FindViewById<TextView>(Resource.Id.Amort_Prin_view);
            mInt = view.FindViewById<TextView>(Resource.Id.Amort_Int_view);

            mBal.Text = $"Balance: {Math.Round(O.EndBal,2).ToString("N")}";
            mPrin.Text = $"Principle Paid: {Math.Round(O.PrnPaid, 2).ToString("N")}";
            mInt.Text = $"Interest Paid: {Math.Round(O.IntPaid, 2).ToString("N")}";

            mBtnAmortDone = view.FindViewById<Button>(Resource.Id.btnAmortDone);

            mBtnAmortDone.Click += mBtnAmortDone_Click;

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
        /// User has clicked the Amort Done Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mBtnAmortDone_Click(object sender, EventArgs e)
        {
            this.Dismiss();
        }

    }
}