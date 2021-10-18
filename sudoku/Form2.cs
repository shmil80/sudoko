using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sudoku
{
    public partial class Form2 : Form
    {
        public static Form2 Sform2 ;
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            set_efsharuyot();
        }
        public bool hatseg_efsharuyot { get; private set; }
        public bool mehikat_efsharouyot { get; private set; }
        public bool hishuv { get; private set; }
        public bool ktov_rak_1 { get; private set; }
        public int mispar_yeduim { get; private set; }
        public int godel_teva { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            int rankold = Sudoku.rank, godelOld = godel_teva;
            if (!set_efsharuyot())
                return;
            Visible = false;
            FMain.SForm1.raanen(rankold != Sudoku.rank?0:godelOld != godel_teva?2:0);
        }
        bool set_efsharuyot()
        {
            //System.Diagnostics.Process myProc = new System.Diagnostics.Process();
            //myProc .StartInfo.FileName = @"C:\dvarim sheli\tohnot\moon\moon.exe";  //Attempting to start a non-existing executable
            //myProc.Start(); 
            Sudoku.ranksquare = comboBox1.SelectedIndex + 2;
            hatseg_efsharuyot = checkBox2.Checked;
            mehikat_efsharouyot = checkBox1.Checked;
            hishuv = checkBox3.Checked;
            ktov_rak_1 = checkBox4.Checked;
            int temp;
            if (int.TryParse(textBox1.Text, out temp))
                mispar_yeduim = temp;
            else
            {
                MessageBox.Show("טעות במספר המשבצות");
                return false;
            }
            if (int.TryParse(textBox2.Text, out temp))
                godel_teva = temp;
            else
            {
                MessageBox.Show("טעות בגודל המשבצת");
                return false;
            }
            return true;

        }
    }
}
