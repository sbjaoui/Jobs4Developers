using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobs4Developers.Models.Utils
{
    public static class Utils
    {
        public static List<int> ToListOfInt(this string str)
        {
            List<int> listInt = new List<int>();
            if (str != null)
            {
                string[] idsStr = str.Split(',');

                foreach (string idStr in idsStr)
                {
                    int id;
                    if (int.TryParse(idStr, out id))
                    {
                        listInt.Add(id);
                    }
                }
            }

            return listInt;
        }
    }
}