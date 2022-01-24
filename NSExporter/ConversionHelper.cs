using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSExporter
{
    public static class ConversionHelper
    {
        public static double ToMmolL(this double mgdl)
        {
            return mgdl / 18;
        } 
        
        public static double ToMgDl(this double mmol)
        {
            return mmol * 18;
        }
    }
}
