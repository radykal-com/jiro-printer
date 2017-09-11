using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.SharpZebra.Printing;
using com.radykal.JiroPrinter.Printing.Templates;

namespace com.radykal.JiroPrinter.Printing
{
    public interface IPrinter
    {
        PrinterSettings getPrinterSettings();

        void print(ITemplate template, int copies);
    }
}
