using System;
using System.Collections.Generic;
using System.Linq;

namespace Alph.Data
{
    public static class HelperData
    {
        public static List<string> AbbreviatedTitles;
        public static List<string> Articles;

        static HelperData()
        {
            string someAbbreviatedTitles = "DJ,MC";
            string someArticles = "A,An,The,Los";
            AbbreviatedTitles = someAbbreviatedTitles.Split(',').ToList();
            Articles = someArticles.Split(',').ToList();
        }
    }
}
