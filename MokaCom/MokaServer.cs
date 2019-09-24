using System.Runtime.InteropServices;

namespace MokaCom
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class MokaServer
    {
        public string Server { get; set; }
        public string Database { get; set; }
    }
}
