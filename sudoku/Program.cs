using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace sudoku
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form2.Sform2 = new Form2();
            FMain.SForm1 = new FMain();
            Application.Run(FMain.SForm1);
        }
    }
}
