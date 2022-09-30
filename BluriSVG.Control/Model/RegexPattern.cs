using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluriSVG.Control.Model
{
    public static class RegexPattern
    {
        public static string ViewBox = "viewBox?\\=\\\"[\\s\\S]+?\\\"";

        public static string SvgMain = "<svg[\\w\\W]+?<\\/svg>";
    }
}
