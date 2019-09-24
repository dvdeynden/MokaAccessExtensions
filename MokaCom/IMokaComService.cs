namespace MokaCom
{
    interface IMokaComService
    {
        VatCheckResult CheckVat(string MemberState, string VatNumber);
        string MakeOGM(Company Company, string Nummer);
        string MakeOGMSepa(Company Company, string Nummer);
        string DisplayOGM(string OGM);
        MokaServer GetServer();
        string[] GetPrinters();
        MokaPrinter GetPrinterCapabilities(string PrinterName);
    }
}
