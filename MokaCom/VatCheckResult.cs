using System.Runtime.InteropServices;

namespace MokaCom
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class VatCheckResult
    {
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Message { get; set; }
    }

}
