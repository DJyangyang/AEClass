using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMS
{
    static class Program
    {
        /// <Summary>
        /// 应用程序的主入口点。
        /// </Summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
