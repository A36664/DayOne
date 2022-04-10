using System.Collections.Generic;
using System.Linq;

namespace BookStore.Helpers
{
    public static class Extension
    {
        public static string ListToString(this List<string> list)
        {
           return list.Aggregate((a, b) => a + ", " + b);
        }
    }
}
