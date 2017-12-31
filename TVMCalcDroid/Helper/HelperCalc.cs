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
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

namespace TVMCalcDroid.Helper
{
    public static  class HelperCalc
    {
        //bool Check_Error = false;

        public static bool IsNum(char c)
        {
            if (Char.IsDigit(c))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Rounds String for formating purposes. Note that a second variable will need to keep track of physical values....
        /// </summary>
        /// <param name="num"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string NumToString(double num, int format)
        {
            RoundCompute(num, format);
            return num.ToString();
        }

        public static double StringToNum(string s)
        {
            return double.Parse(s);
        }

        /// <summary>
        /// Formats a returns string to a selected number of decimal places
        /// </summary>
        /// <param name="num"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string StringToFormatedString(string num, int format)
        {
            return NumToString(StringToNum(num), format);
        }



    }
}