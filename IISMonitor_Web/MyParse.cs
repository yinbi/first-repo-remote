using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IISMonitor_Web
{
    public class MyParse
    {
        public static int ParseInt(string snum, int def)
        {
            int num;
            return int.TryParse(snum, out num) ? num : def;
        }

        public static long ParseLong(string snum, long def)
        {
            long num;
            return long.TryParse(snum, out num) ? num : def;
        }

        public static float Parsefloat(string snum, float def)
        {
            float num;
            return float.TryParse(snum, out num) ? num : def;
        }

        public static decimal ParseDecimal(string snum, decimal def)
        {
            decimal num;
            return decimal.TryParse(snum, out num) ? num : def;
        }

        public static bool ParseBool(string snum, bool def)
        {
            bool num;
            return bool.TryParse(snum, out num) ? num : def;
        }

        public static DateTime ParseTime(string sTime)
        {
            DateTime time;
            return DateTime.TryParse(sTime, out time) ? time : DateTime.Now;
        }
    }
}
