using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BluriSVG.Control.Model
{
    public class SvgData
    {
        public string Path
        {
            get;set;
        }
        public Brush Fill
        {
            get;set;
        }
        public Geometry Geometry
        {
            get;set;
        }
    }
}
