using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSMTilesDownloader.Helper
{
    public class Console
    {
        private Form1 form1;

        public Console(Form1 form1)
        {
            this.form1 = form1;
        }

        internal void WriteLine(string message)
        {
            form1.LogPanel = message;
        }
    }
}
