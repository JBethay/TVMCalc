﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace TVMCalcDroid
{
    [Activity(Label = "TVMCalcDroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button mButtonSecond;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            mButtonSecond = FindViewById<Button>(Resource.Id.Second_Key);

            mButtonSecond.Click += MButtonSecond_Click;
        }

        private void MButtonSecond_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_2nd createAccountDialog = new Dialog_2nd();
            createAccountDialog.Show(transaction, "dialog Fragment");
        }
    }
}
