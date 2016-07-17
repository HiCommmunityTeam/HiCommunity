using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiCommunityCacheAccessor
{
    public class CacheConstDefine
    {
        public static DateTime TimeSeed = new DateTime(2016, 08, 1);

        public static double TotalSecondsTenYear = DateTime.Now.AddYears(10).Subtract(CacheConstDefine.TimeSeed).TotalSeconds;
    }
}
