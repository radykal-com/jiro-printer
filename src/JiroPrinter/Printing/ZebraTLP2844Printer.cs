using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.SharpZebra;
using Com.SharpZebra.Printing;
using Com.SharpZebra.Commands;
using com.radykal.JiroPrinter.Printing.Templates;


namespace com.radykal.JiroPrinter.Printing
{
    class ZebraTLP2844Printer : AbstractPrinter, IPrinter
    {
        private const int DPI = 203;

        public ZebraTLP2844Printer(string printerName, float labelWidthInInches, float labelLengthInInches) : base(printerName, DPI, labelWidthInInches, labelLengthInInches) { }

        override protected void configurePrinter()
        {
            printerSettings = new PrinterSettings();
            printerSettings.PrinterName = printerName;
            printerSettings.AlignLeft = 10;
            printerSettings.AlignTop = 0;
            printerSettings.AlignTearOff = 0;
            printerSettings.Width = (int)Math.Round(printerDPI * labelWidthInInches, 0); // width in dots
            printerSettings.Length = (int)Math.Round(printerDPI * labelLengthInInches, 0); // length in dots
            printerSettings.Darkness = 30;
        }


        public void print(ITemplate template, int copies)
        {
            List<byte> printData = new List<byte>();
            printData.AddRange(EPLCommands.ClearPrinter(printerSettings));
            printData.AddRange(template.getPrintData());
            printData.AddRange(EPLCommands.PrintBuffer(copies));
            new SpoolPrinter(printerSettings).Print(printData.ToArray());
        }
    }
}
