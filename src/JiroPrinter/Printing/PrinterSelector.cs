using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.radykal.JiroPrinter.Printing
{
    class PrinterSelector
    {
        private string printerName = "";

        public PrinterSelector()
        {
            printerName = loadPrinterNameFromConfig();
            while (String.IsNullOrEmpty(printerName) || (! isValidPrinterName(printerName)))
            {
                printerName = selectPrinter();
            }
            savePrinterNameToConfig();
        }

        private string loadPrinterNameFromConfig()
        {
            return Properties.Settings.Default.PrinterName;
        }

        private void savePrinterNameToConfig()
        {
            Properties.Settings.Default.PrinterName = printerName;
            Properties.Settings.Default.Save();
        }

        private bool isValidPrinterName(string printerName)
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                if (printer == printerName)
                {
                    return true;
                }
            }
            return false;
        }

        private string selectPrinter()
        {
            printerName = "";
            while (String.IsNullOrEmpty(printerName))
            {
                PrintDialog printDialog = new PrintDialog();
                if (DialogResult.OK == printDialog.ShowDialog())
                {
                    printerName = printDialog.PrinterSettings.PrinterName;
                }
            }
            return printerName;
        }

        public string getPrinterName()
        {
            return printerName;
        }
    }
}
