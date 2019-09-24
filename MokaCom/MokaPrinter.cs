using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Printing;
using System.Text;
using System.Threading.Tasks;

namespace MokaCom
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class MokaPrinter
    {
        public string Name { get; set; }
        public string OrientationCapabilities { get; set; }
        public string CollationCapabilities { get; set; }
        public string DuplexingCapabilities { get; set; } 
        public string InputBinCapabilities { get; set; } 
        public string OutputColorCapabilities { get; set; }
        public string OutputQualityCapabilities { get; set; } 
        public string StaplingCapabilities { get; set; } 

        public MokaPrinter()
        {
           
        }
    }

}
