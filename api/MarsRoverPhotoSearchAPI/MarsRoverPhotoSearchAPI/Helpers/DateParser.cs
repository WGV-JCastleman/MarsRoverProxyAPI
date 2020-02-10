using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRoverPhotoSearchAPI.Helpers
{
    public static class DateParser
    {
        
        public static bool TryParseAsNasaDates(this string[] inStrArr, out string[] res)
        {
            res = null;
            var resList = new List<string>();
            foreach(var inStr in inStrArr)
            {
                var success = DateTime.TryParse(inStr, out DateTime dt);
                if (success)
                {
                    var parseDate = String.Format("{0}-{1}-{2}", dt.Year, dt.Month, dt.Day);
                    resList.Add(parseDate);
                }
            }

            if (resList.Count > 0)
            {
                res = resList.ToArray();
            }
            return res.Length > 0;
        }
    }
}
