using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.radykal.JiroPrinter.Cli;
using com.radykal.JiroPrinter.Config;
using com.radykal.JiroPrinter.Printing;
using com.radykal.JiroPrinter.Printing.Templates;

namespace com.radykal.JiroPrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments arguments = new Arguments();
            PrinterSelector printerSelector = new PrinterSelector();
            IPrinter printer = new ZebraTLP2844Printer(printerSelector.getPrinterName(), 2.244f, 0.748f);
            while (true)
            {
                UserInput config = arguments.promptUser();
                string internalCode = config.getInternalCode();
                if (String.IsNullOrWhiteSpace(internalCode))
                {
                    internalCode = config.getCode();
                }
                BasicLabel label = new BasicLabel(config.getCode(), internalCode, printer.getPrinterSettings());
                printer.print(label, config.getCopies());
                Console.WriteLine("Imprimiendo {0} copias", config.getCopies());
                Console.WriteLine("");
            }
        }
    }
}
