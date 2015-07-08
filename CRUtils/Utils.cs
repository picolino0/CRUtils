using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUtils
{
    public static class Utils
    {
        public static bool ContainsIgnoreCase(this List<String> input, String check)
        {
            foreach (String st in input)
            {
                if (st.ToLower() == check.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
