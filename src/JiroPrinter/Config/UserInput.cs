using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.radykal.JiroPrinter.Config
{
    class UserInput
    {
        private string code = "";
        private string internalCode = "";
        private int copies = 0;

        public UserInput(string code, string internalCode, int copies)
        {
            this.code = code;
            this.internalCode = internalCode;
            this.copies = copies;
        }

        public string getCode()
        {
            return code;
        }

        public string getInternalCode()
        {
            return internalCode;
        }

        public int getCopies()
        {
            return copies;
        }

    }
}
