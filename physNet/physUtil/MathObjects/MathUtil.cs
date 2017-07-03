using System;
using System.Collections.Generic;
using System.Text;

namespace physNet.physUtil.MathObjects
{
    public class MathUtil
    {
        public static bool Compare(double a, double b, double epsilon)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}
