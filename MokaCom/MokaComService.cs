using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Printing;
using System.Runtime.InteropServices;
using System.Text;

namespace MokaCom
{
    public enum Company
    {
        Moordtgat = 1,
        AStevendokken= 2
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class MokaComService : IMokaComService
    {
        #region Private Fields
        private eu.europa.ec.checkVatService ViesChecker;
        private Dictionary<string, string> validMemberStates;
        #endregion
        #region Constructor
        public MokaComService()
        {
            validMemberStates = GetMemberstates();
            ViesChecker = new eu.europa.ec.checkVatService();
        }
        #endregion
        #region Public Methods
        [ComVisible(true)]
        public VatCheckResult CheckVat(string MemberState, string VatNumber)
        {
            VatCheckResult retvalue = new VatCheckResult();
            try
            {
                ViesChecker.checkVat(ref MemberState, ref VatNumber, out bool euIsValid, out string euName, out string euAdress);
                retvalue.IsValid = euIsValid;
                if (euIsValid)
                {
                    retvalue.Message = "BTW nummer is correct.";
                    retvalue.Name = euName;
                    retvalue.Address = euAdress;
                }
                else
                {
                    retvalue.Message = "BTW nummer is NIET correct.";
                }
            }
            catch (Exception ex)
            {
                retvalue.IsValid = false;
                switch (ex.Message.ToUpper())
                {
                    case "INVALID_INPUT":
                        if (validMemberStates.ContainsKey(MemberState))
                            retvalue.Message = "Foutief BTW nummer.";
                        else
                            retvalue.Message = String.Format("BTW nummer van {0} kan niet on-line gecontroleerd worden.", MemberState);
                        break;
                    case "SERVICE_UNAVAILABLE":
                        retvalue.Message = "De on-line controle is niet beschikbaar.";
                        break;
                    case "MS_UNAVAILABLE":
                        retvalue.Message = string.Format("De on-line controle voor {0} is niet beschikbaar.", MemberState);
                        break;
                    case "TIMEOUT":
                        retvalue.Message = string.Format("De on-line controle voor {0} geeft geen anywoord binnen de tijdslimiet.", MemberState);
                        break;
                    case "SERVER_BUSY":
                        retvalue.Message = "De on-line controle is te druk bezet.";
                        break;
                    default:
                        retvalue.Message = ex.Message;
                        break;
                }
            }
            return retvalue;
        }

        [ComVisible(true)]
        public string DisplayOGM(string OGM)
        {
            StringBuilder DisplayString = new StringBuilder();
            if (OGM.StartsWith("RF"))   // SEPA RF Number
            {
                int GroupCount = OGM.Length / 4;
                int LastGroupLength = OGM.Length - (GroupCount * 4);

                for (int i = 0; i <= GroupCount - 1; i++)
                {
                    DisplayString.Append(OGM.Substring((i * 4), 4) + " ");
                }
                if (LastGroupLength > 0)
                {
                    DisplayString.Append(OGM.Substring(OGM.Length - LastGroupLength, LastGroupLength));
                }
            }
            else    // Belgian OGM number
            {
                DisplayString.Append("+++");
                DisplayString.Append(OGM.Substring(0, 3));
                DisplayString.Append("/");
                DisplayString.Append(OGM.Substring(3, 4));
                DisplayString.Append("/");
                DisplayString.Append(OGM.Substring(7, 5));
                DisplayString.Append("+++");
            }
            return DisplayString.ToString().Trim();
        }

        [ComVisible(true)]
        public string MakeOGM(Company company, string nummer)
        {
            string BaseString = GetBase(company, nummer, false);
            long BaseValue = Convert.ToInt64(BaseString);
            long ControlValue = BaseValue % 97;
            if (ControlValue == 0) ControlValue = 97;
            return BaseString + ControlValue.ToString("00");
        }

        [ComVisible(true)]
        public string MakeOGMSepa(Company company, string nummer)
        {
            string BaseString = GetBase(company, nummer, true);
            long BaseValue = Convert.ToInt64(BaseString);
            long ControlValue = BaseValue % 97;
            return "RF" + (98 - ControlValue).ToString("00") + BaseString.Substring(0, BaseString.Length - 4);
        }

        [ComVisible(true)]
        public MokaServer GetServer()
        {
            MokaServer srv = new MokaServer();
            SelectServerForm frm = new SelectServerForm();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                srv.Server = frm.SelectedServer;
                srv.Database = frm.SelectedDatabase;
            }
            else
            {
                srv.Server = string.Empty;
                srv.Database = string.Empty;
            }
            frm.Dispose();
            return srv;
        }

        [ComVisible(true)]
        public string[] GetPrinters()
        {
            List<string> thePrinters = new List<string>();
            foreach (string prt in PrinterSettings.InstalledPrinters)
            {
                thePrinters.Add(prt);
            }
            return thePrinters.ToArray();
        }

        [ComVisible(true)]
        public MokaPrinter GetPrinterCapabilities(string PrinterName)
        {
            MokaPrinter thisPrinter = new MokaPrinter();
            PrintServer thisPrintServer = new PrintServer();
            PrintQueue thisPrintQueue = new PrintQueue(thisPrintServer, PrinterName);
            PrintCapabilities theCapabilities = thisPrintQueue.GetPrintCapabilities();
            StringBuilder Caps = new StringBuilder();
            thisPrinter.Name = PrinterName;

            Caps.Clear();
            foreach (PageOrientation cap in theCapabilities.PageOrientationCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(PageOrientation), cap));
            }
            thisPrinter.OrientationCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (Collation cap in theCapabilities.CollationCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(Collation), cap));
            }
            thisPrinter.CollationCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (Duplexing cap in theCapabilities.DuplexingCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(Duplexing), cap));
            }
            thisPrinter.DuplexingCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (InputBin cap in theCapabilities.InputBinCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(InputBin), cap));
            }
            thisPrinter.InputBinCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (OutputColor cap in theCapabilities.OutputColorCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(OutputColor), cap));
            }
            thisPrinter.OutputColorCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (OutputQuality cap in theCapabilities.OutputQualityCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(OutputQuality), cap));
            }
            thisPrinter.OutputQualityCapabilities = Caps.ToString();

            Caps.Clear();
            foreach (Stapling cap in theCapabilities.StaplingCapability)
            {
                Caps.AppendFormat("{0}={1};", (int)cap, Enum.GetName(typeof(Stapling), cap));
            }
            thisPrinter.StaplingCapabilities = Caps.ToString();

            thisPrintQueue.Dispose();
            return thisPrinter;
        }
        #endregion
        #region Private methods
        private Dictionary<string, string> GetMemberstates()
        {
            Dictionary<string, string> retvalue = new Dictionary<string, string>
            {
                { "AT", "AT-Austria" },
                { "BE", "BE-Belgium" },
                { "BG", "BG-Bulgaria" },
                { "CY", "CY-Cyprus" },
                { "CZ", "CZ-Czech Republic" },
                { "DE", "DE-Germany" },
                { "DK", "DK-Denmark" },
                { "EE", "EE-Estonia" },
                { "EL", "EL-Greece" },
                { "ES", "ES-Spain" },
                { "FI", "FI-Finland" },
                { "FR", "FR-France " },
                { "GB", "GB-United Kingdom" },
                { "HR", "HR-Croatia" },
                { "HU", "HU-Hungary" },
                { "IE", "IE-Ireland" },
                { "IT", "IT-Italy" },
                { "LT", "LT-Lithuania" },
                { "LU", "LU-Luxembourg" },
                { "LV", "LV-Latvia" },
                { "MT", "MT-Malta" },
                { "NL", "NL-The Netherlands" },
                { "PL", "PL-Poland" },
                { "PT", "PT-Portugal" },
                { "RO", "RO-Romania" },
                { "SE", "SE-Sweden" },
                { "SI", "SI-Slovenia" },
                { "SK", "SK-Slovakia" }
            };
            return retvalue;
        }
        private string GetBase(Company company, string nummer, bool useSepa)
        {
            string BaseString;
            if (company ==  Company.Moordtgat)
                BaseString = "2224";
            else
                BaseString = "1028";
            if (useSepa)
                return BaseString + nummer.Replace("/", "") + "2715";
            else
                return BaseString + nummer.Replace("/", "");
        }
        #endregion
    }
}
