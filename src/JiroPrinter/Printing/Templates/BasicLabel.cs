using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.SharpZebra;
using Com.SharpZebra.Commands;
using Com.SharpZebra.Printing;

namespace com.radykal.JiroPrinter.Printing.Templates
{
    class BasicLabel  : ITemplate
    {
        private List<byte> printData = new List<byte>();
        private PrinterSettings printerSettings;

        public BasicLabel(string code, string internalCode, PrinterSettings printerSettings)
        {
            this.printerSettings = printerSettings;
            printInternalCode(internalCode);
            printCodeBarcode(code);
        }

        private void printInternalCode(string internalCode)
        {
            int left = 65;
            int top = 5;
            int horizontalMult = 2;
            int verticalMult = 2;
            printData.AddRange(EPLCommands.TextWrite(left, top, ElementDrawRotation.NO_ROTATION, ZebraFont.STANDARD_NORMAL, horizontalMult, verticalMult, false, internalCode, printerSettings));
        }

        private void printCodeBarcode(string code)
        {
            int left = 45;
            int top = 40;
            int height = 60;
            printData.AddRange(EPLCommands.BarCodeWrite(left, top, height, ElementDrawRotation.NO_ROTATION, getCode128Barcode(), true, code, printerSettings));
        }

        private Barcode getCode128Barcode()
        {
            Barcode barcode = new Barcode();
            barcode.Type = BarcodeType.CODE128_B;
            barcode.BarWidthNarrow = 2;
            return barcode;
        }

        public List<byte> getPrintData()
        {
            return printData;
        }
    }
}
