using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.radykal.JiroPrinter.Config;

namespace com.radykal.JiroPrinter.Cli
{
    class Arguments
    {
        public UserInput promptUser()
        {
            string code = this.promptForCode();
            string internalCode = this.promptForInternalCode();
            int copies = this.promptForCopies();
            return new UserInput(code, internalCode, copies);
        }

        private string promptForCode()
        {
            return this.promptFromConsole("Código de barras: ");
        }

        private string promptForInternalCode()
        {
            return this.promptFromConsole("Código interno: ");
        }

        private int promptForCopies()
        {
            string copies = this.promptFromConsole("Copias: ");
            return int.Parse(copies);
        }

        private string promptFromConsole(string caption)
        {
            Console.Write(caption);
            string input = Console.ReadLine();
            return input;
        }
    }
}
