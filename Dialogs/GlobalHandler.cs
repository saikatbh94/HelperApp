using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelperApp
{
    [Serializable]
    public class GlobalHandler
    {
        public static int flag = 0;
        public string GetRandomString(List<string> stringList)
        {
            Random random = new Random();
            int idx = random.Next(0, 1000) % stringList.Count;
            return stringList[idx];
        }
    }
}