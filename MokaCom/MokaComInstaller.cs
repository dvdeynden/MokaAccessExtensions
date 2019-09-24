using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration.Install;

namespace MokaCom
{
    [RunInstaller(true)]
    public partial class MokaComInstaller : Installer
    {
        public MokaComInstaller()
        {
            InitializeComponent();
        }

        public MokaComInstaller(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public override void Commit(System.Collections.IDictionary savedState)
        {
            // Get the location of regasm
            string regasmPath = System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory() + @"regasm.exe";
            // Get the location of our DLL
            string componentPath = typeof(MokaComService).Assembly.Location;
            // Execute regasm
            System.Diagnostics.Process.Start(regasmPath, "/codebase \"" + componentPath + "\"");
        }

    }
}
