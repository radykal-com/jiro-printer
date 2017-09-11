using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.SharpZebra.Printing;

namespace com.radykal.JiroPrinter.Printing
{
    abstract class AbstractPrinter
    {
        protected PrinterSettings printerSettings;
        protected string printerName;
        protected int printerDPI;
        protected float labelWidthInInches;
        protected float labelLengthInInches;

        public AbstractPrinter(string printerName, int printerDPI, float labelWidthInInches, float labelLengthInInches)
        {
            this.printerName = printerName;
            this.printerDPI = printerDPI;
            this.labelWidthInInches = labelWidthInInches;
            this.labelLengthInInches = labelLengthInInches;
            configurePrinter();
        }

        abstract protected void configurePrinter();

        public PrinterSettings getPrinterSettings()
        {
            return printerSettings;
        }
    }
}
