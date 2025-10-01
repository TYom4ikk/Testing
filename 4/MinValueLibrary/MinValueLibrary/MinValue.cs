using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinValueLibrary
{
    public class MinValue
    {
        public static int MinInt(int a, int b, int c)
        {
            int min = a;
            if (min > b) min = b;
            if (min > c) min = c;
            return min;
        }
        public static float MinFloat(float a, float b, float c)
        {
            float min = a;
            if (min > b) min = b;
            if (min > c) min = c;
            return min;
        }
    }
}
