using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MokaCom;


namespace TestMokaCom
{
    public partial class Form1 : Form
    {
        MokaComService MokaService;
        public Form1()
        {
            InitializeComponent();
            MokaService = new MokaComService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string thisName = string.Empty;
            string thisAddress = string.Empty;
            VatCheckResult thisresult = MokaService.CheckVat(txtCountry.Text, txtBtwNr.Text);
            if (thisresult.IsValid)
                MessageBox.Show(string.Format("{0}\n\n{1}\n\n{2}", thisresult.Message, thisresult.Name, thisresult.Address), "BTW Controle", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(thisresult.Message, "BTW Controle", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnMaakOGM_Click(object sender, EventArgs e)
        {
            if (!useSepa.Checked)
            {
                if (Company.Text == "MO") OGM.Text = MokaService.MakeOGM( MokaCom.Company.Moordtgat, FactuurNR.Text);
                else OGM.Text = MokaService.MakeOGM(MokaCom.Company.AStevendokken, FactuurNR.Text);
            }
            else
            {
                if (Company.Text == "MO") OGM.Text = MokaService.MakeOGMSepa(MokaCom.Company.Moordtgat, FactuurNR.Text);
                else OGM.Text = MokaService.MakeOGMSepa(MokaCom.Company.AStevendokken, FactuurNR.Text);
            }

            this.OGMDisplay.Text = MokaService.DisplayOGM(OGM.Text);

        }

        private void btnSelectServer_Click(object sender, EventArgs e)
        {
            MokaServer x = MokaService.GetServer();
            txtServer.Text = x.Server;
            txtDatabase.Text = x.Database;


        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            lstPrinters.Items.Clear();
            string[] PrinterList = MokaService.GetPrinters();
            lstPrinters.Items.AddRange(PrinterList);

        }

        private void lstPrinters_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MokaPrinter thisPrinter = GetThisPrinter();
            StringBuilder lstCapabilities = new StringBuilder();
            lstCapabilities.AppendLine(thisPrinter.OrientationCapabilities);
            lstCapabilities.AppendLine(thisPrinter.CollationCapabilities);
            lstCapabilities.AppendLine(thisPrinter.DuplexingCapabilities);
            lstCapabilities.AppendLine(thisPrinter.InputBinCapabilities);
            lstCapabilities.AppendLine(thisPrinter.OutputColorCapabilities);
            lstCapabilities.AppendLine(thisPrinter.OutputQualityCapabilities);

            MessageBox.Show(lstCapabilities.ToString(), string.Format("Capabilities for {0}", thisPrinter.Name));
        }

        private MokaPrinter GetThisPrinter()
        {
            return MokaService.GetPrinterCapabilities(lstPrinters.SelectedItem.ToString());
        }
    }
}
