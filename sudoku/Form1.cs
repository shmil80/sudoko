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
    public partial class FMain : Form
    {
        public static FMain SForm1 ;
        #region member
        teva[] tevot;
        Sudoku sudoku_sheli;
        List<Misparpashut[]> shmira_lebitul = new List<Misparpashut[]>();
        #endregion
        
        #region constructor
        public FMain()
        {
            InitializeComponent();
            bne();
        }
        void bne()
        {
            tevot = new teva[Sudoku.rank2];
            this.SuspendLayout();
            for (int x = 0; x < Sudoku.rank; x++)
                for (int y = 0; y < Sudoku.rank; y++)
                    tevot[x + y * Sudoku.rank] = new teva(this, x + y * Sudoku.rank);
            hatemGodel();
            //panel1.Size = clientpanelratsuy;
            foreach (teva t in tevot)

            {
                t.Parent = panel1;
                t.BackColor = teva.DefaultBackColor;
            }
            new_game();
            tevot[0].Focus();
            this.ResumeLayout(false);
        }
        void hatemGodel()
        {
            int Margin = 2, marginX = -Margin, baseMarginY = 0 - Margin, marginY = baseMarginY;
            for (int x = 0; x < Sudoku.rank; x++)
            {
                if (x % Sudoku.ranksquare == 0)
                    marginX += Margin;
                marginY = baseMarginY;
                for (int y = 0; y < Sudoku.rank; y++)
                {
                    if (y % Sudoku.ranksquare == 0)
                        marginY += Margin;
                    teva new_teva = tevot[x + y * Sudoku.rank];
                    new_teva.Location = new Point(marginX + x * new_teva.Width, marginY + y * new_teva.Height);
                    Color Cold = new_teva.BackColor;
                }
            }
            Size clientpanelratsuy = new Size(marginX + Sudoku.rank * tevot[0].Width, marginY + Sudoku.rank * tevot[0].Height);
            Size clientformratsuy = clientpanelratsuy;
            panel1.Top = menuStrip1.Size.Height;
            clientformratsuy.Height += panel1.Top;
            this.ClientSize = clientformratsuy;
            panel1.Size = clientpanelratsuy;

            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            if (this.Height > r.Height)
            {
                this.Height = r.Height;
                if (panel1.Height > this.ClientSize.Height - panel1.Top)
                {
                    clientpanelratsuy.Height = this.ClientSize.Height - panel1.Top;
                    int SCROLL = 17;
                    clientpanelratsuy.Width += SCROLL;
                    this.Width += SCROLL;
                    panel1.Size = clientpanelratsuy;
                }
            }
            if (this.Width > r.Width)
                this.Width = r.Width;
            this.Location = new Point(r.Width / 2 - this.Width / 2, r.Height / 2 - this.Height / 2);

        }
        #endregion

        
        #region focus
        
        #endregion
        
        public void refresh(bool shmirat_bitul,bool tsva_adom)
        {
            for (int i = 0; i < Sudoku.rank2; i++)
                tevot[i].mutsag = sudoku_sheli[i];

            foreach (teva t in tevot)
                t.shane_trseva_reka(teva.DefaultBackColor);

            if (tsva_adom || sudoku_sheli.mushlam)
            {
                foreach (Mispar t in sudoku_sheli.Taouyot())
                    tevot[t.X + t.Y * Sudoku.rank].shane_trseva_reka(Color.Red);
                if(!sudoku_sheli.Taouyot().Any()&&!tevot.Any(t=>t.menuhash))
                    foreach (Mispar t in sudoku_sheli)
                        tevot[t.X + t.Y * Sudoku.rank].shane_trseva_reka(Color.Gold);
            }
            if (shmirat_bitul)
            {
                for(int i=0;i<index_bitul;i++)
                    shmira_lebitul.RemoveAt(0);
                shmira_lebitul.Insert(index_bitul = 0, sudoku_sheli.yeduim_ahshav);
                חזורToolStripMenuItem.Enabled = false;
                ביטולToolStripMenuItem.Enabled = shmira_lebitul.Count>1;
            }
            
        }

        private void אפשרויותToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.Sform2.ShowDialog();
        }

        #region new game
        private void משחקחדשToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_game();
        }

        private void new_game()
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            SuspendLayout();
            Mispar Null = new Mispar(null, 0, 0) { Value = null };
            foreach(teva t in tevot)
            {
                t.isReadOnly = false;
                t.mutsag = Null;
                t.resetForeColor();
            }
            SudokuMuhrah muhrah = new SudokuMuhrah(Sudoku.rank2 - Form2.Sform2.mispar_yeduim);
            foreach (Misparpashut m in muhrah.yeduim_ahshav)
                tevot[m.index].isReadOnly = true;
            new_mishak(muhrah.ToArray());
            
            //Text = (muhrah.yeduim_ahshav.Count().ToString());
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }
        #endregion

        #region bniyat rek
        private void משחקריקToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_empty();
        }

        private void new_empty()
        {
            SuspendLayout();
            Mispar Null = new Mispar(null, 0, 0) { Value = null };
            foreach (teva t in tevot)
            {
                t.isReadOnly = false;
                t.mutsag = Null;
                t.resetForeColor();
            }
            new_mishak(null);
        }
        #endregion

        public void raanen(int New)
        {
            SuspendLayout();
            switch (New)
            {
                case 0: 
                panel1.Dispose();
                panel1 = new Panel();
                panel1.Parent = this;
                panel1.BackColor = Color.Black;
                panel1.AutoScroll = true;
                bne();
                    break;
                case 1:new_mishak(sudoku_sheli.ToArray());
                    break;
                case 2:
                    foreach (teva t in tevot)
                        t.raanenSize();
                    hatemGodel();
                    hatemGodel(); 
                    
                    break;
            }
            ResumeLayout();
        }
        #region nihush
        private void השלםToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_nihush(sender == השלםToolStripMenuItem);
        }

        private void new_nihush(bool nihush)
        {
            if (sudoku_sheli.Taouyot().Any())
            { taout(); return; }
            SuspendLayout();
            Mispar Null = new Mispar(null, 0, 0) { Value = null };
            List<Mispar> list = new List<Mispar>();
            for (int i = 0; i < Sudoku.rank2; i++)
                if (sudoku_sheli[i].Value == null)
                    tevot[i].menuhash = true;
                else
                    list.Add(sudoku_sheli[i]);
            Sudoku mushlam;
            mushlam = nihush ?
                new SudokuMushlam(list.ToArray()) :
                new Sudoku(list.ToArray(), true, true);
            if (mushlam.Taouyot().Any())
             taout(); 
                else
            new_mishak(mushlam.yeduim_ahshav);
            for (int i = 0; i < Sudoku.rank2; i++)
                if (sudoku_sheli[i].Value == null)
                    tevot[i].menuhash = false;

        }

        void taout()
        {

            refresh(false, true);
            MessageBox.Show("יש טעויות במה שכבר נבחר\nולכן א\"א להשלים את השאר");
        }
        private void מחקהשלמהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (teva t in tevot)
                t.menuhash = false;
            new_mishak(sudoku_sheli.ToArray());
            // sudoku_sheli.bdika_mehadash();
            //refresh(false, false);
        }
        #endregion
        void new_mishak(Misparpashut[] yeduim)
        {
            shmira_lebitul.Clear();
            index_bitul = 0;
            new_suduko(yeduim);
            refresh(true,false);
            ResumeLayout();
        }
        void new_suduko(Misparpashut[] yeduim)
        {
            sudoku_sheli = new Sudoku(yeduim, Form2.Sform2.hishuv, Form2.Sform2.ktov_rak_1);
            foreach (teva t in tevot)
                t.kasher(sudoku_sheli);

        }
        internal void focus(int index)
        {
            tevot[(index + Sudoku.rank2) % Sudoku.rank2].Focus();
        }

        int index_bitul;
        private void ביטולToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (shmira_lebitul.Count > index_bitul + 1)
            {
                new_suduko(shmira_lebitul[++index_bitul]);
                refresh(false,false);
                חזורToolStripMenuItem.Enabled = true;
                ביטולToolStripMenuItem.Enabled = shmira_lebitul.Count > 1 + index_bitul;
            }
        }

        private void חזורToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index_bitul >0)
            {
                new_suduko(shmira_lebitul[--index_bitul]);
                refresh(false,false);
                חזורToolStripMenuItem.Enabled = index_bitul > 0;
                ביטולToolStripMenuItem.Enabled = shmira_lebitul.Count > 1 + index_bitul;
            }

        }
        public void shane(int index,int? shinuy)
        {
            if ((int?)sudoku_sheli[index].Value == shinuy)
                return;
            sudoku_sheli.Pshane(index, shinuy, true);
            tevot[index].shane_tseva_mispar(Color.Black);
            refresh(true,false);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            menuStrip1.Width = ClientSize.Width;
            //panel1.Width = ClientSize.Width;
            //panel1.Height = ClientSize.Height + menuStrip1.Height;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sudoku.ranksquare = 5;
            SudokuMushlam s = new SudokuMushlam(null);
            System.IO.File.WriteAllText("data.txt", s.ToString());
        }

        private void שמירהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save =new SaveFileDialog();
            save.Filter = "קבצי sdk|*.sdk";
            if(save.ShowDialog()!=DialogResult.OK)
                return;
            System.IO.File.WriteAllText(save.FileName, sudoku_sheli.ToString() + save_readOnlys);
        }
        private string save_readOnlys
        {
            get
            {
                StringBuilder result = new StringBuilder("\n");
                foreach (teva t in tevot)
                    result.Append("\t"+t.isReadOnly);
                result.Remove(1, 1);
                return result.ToString();
            }
        }

        private void פתיחהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "קבצי sdk|*.sdk";
            if (open.ShowDialog() != DialogResult.OK)
                return;

            string[]result=System.IO.File.ReadAllLines(open.FileName);
            Sudoku.rank = result.Length-1;
            Sudoku.rank2 = Sudoku.rank * Sudoku.rank;
            string[][] netunim = new string[result.Length][];
            for (int i = 0; i < Sudoku.rank; i++)
                netunim[i] = result[i].Split('\t');
            List<Mispar> list = new List<Mispar>();
            for (int i = 0; i < Sudoku.rank; i++)
                for (int j = 0; j < Sudoku.rank; j++)
                    if (netunim[i][j] != " ")
                        list.Add(new Mispar(null, j, i) { Value = int.Parse(netunim[i][j]) });
            string[] read_only=result[Sudoku.rank].Split('\t');
            for (int i = 0; i < tevot.Length; i++)
                tevot[i].isReadOnly = bool.Parse(read_only[i]);
            new_mishak(list.ToArray());
            
        }



        void docToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs ev)
        {
            Rectangle paper = ev.MarginBounds;
            float yPos = 0,xPos=0;
            float lineWidth = 3;
            float gridwidth = 1;
            float heightRow = Math.Min(paper.Width / Sudoku.rank,paper.Height / Sudoku.rank);// printFont.GetHeight(ev.Graphics) + gridwidth;
            float widthColumn = heightRow;

            float margingridwidth = gridwidth / 2;
            float marginligne = lineWidth / 2 + margingridwidth;
            Font printFont = null;
            int size = 45;
            do
            {
                if (size < 0)
                {
                    MessageBox.Show("הדף קטן מדי");
                    return;
                } 
                printFont = new System.Drawing.Font("Arial", size--, FontStyle.Regular);
            }
            while (printFont.GetHeight(ev.Graphics) + gridwidth > heightRow);
            Pen printPen = new Pen(Color.Black, lineWidth + gridwidth);
            Pen gridPen = new Pen(Color.Black, gridwidth);
            //printPen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            //gridPen.Alignment = printPen.Alignment;

            float leftMargin = paper.Left;
            float topMargin = paper.Top;


            
            string[] line = sudoku_sheli.ToString().Split('\n');
            string[][] numbers = new string[Sudoku.rank][];
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = line[i].Split('\t');

            // Print each line of the file.
            if(true)for (int i = 0; i <= numbers.Length; i++)
            {
                ev.Graphics.DrawLine(gridPen, leftMargin + lineWidth * (i / Sudoku.ranksquare + 1) + widthColumn * i - margingridwidth,
                    topMargin,
                    leftMargin + lineWidth * (i / Sudoku.ranksquare + 1) + widthColumn * i - margingridwidth,
                    topMargin + lineWidth * (numbers.Length / Sudoku.ranksquare + 1) + heightRow * numbers.Length);
                ev.Graphics.DrawLine(gridPen, leftMargin,
                    topMargin + lineWidth * (i / Sudoku.ranksquare + 1) + heightRow * i - margingridwidth,
                    leftMargin + lineWidth * (numbers.Length / Sudoku.ranksquare + 1) + widthColumn * numbers.Length,
                    topMargin + lineWidth * (i / Sudoku.ranksquare + 1) + heightRow * i - margingridwidth);
            }
            for (int y = 0; y <= numbers.Length; y++)
            {
                yPos = topMargin + lineWidth * (y / Sudoku.ranksquare + 1) + y * heightRow;
                if (y % Sudoku.ranksquare == 0)
                    ev.Graphics.DrawLine(printPen, leftMargin, yPos - marginligne, leftMargin +
                        widthColumn * numbers.Length + lineWidth * (numbers.Length / Sudoku.ranksquare+1),
                        yPos - marginligne);
                if (y == numbers.Length) break;
                for (int x = 0; x <= numbers[y].Length; x++)
                {
                    xPos = leftMargin + lineWidth * (x / Sudoku.ranksquare + 1) + x * widthColumn;
                    if (y == 0 && x % Sudoku.ranksquare == 0)
                        ev.Graphics.DrawLine(printPen, xPos - marginligne, topMargin,
                            xPos - marginligne, topMargin +
                            heightRow * numbers.Length + lineWidth * (numbers.Length / Sudoku.ranksquare+1));
                    if (x == numbers[y].Length) break;
                    ev.Graphics.DrawString(numbers[y][x], printFont, tevot[y*Sudoku.rank+ x].isReadOnly?Brushes.Blue: Brushes.Black,
                       xPos + widthColumn/2-TextRenderer.MeasureText(numbers[y][x],printFont).Width/2,
                       yPos + heightRow / 2 - printFont.GetHeight(ev.Graphics) / 2
                       , new StringFormat());

                }
            }
            // If more lines exist, print another page.
                ev.HasMorePages = false;
        }

        private void הדפסהToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog print = new PrintDialog();
            if (print.ShowDialog() != DialogResult.OK)
                return;
            System.Drawing.Printing.PrintDocument docToPrint =
            new System.Drawing.Printing.PrintDocument();
            docToPrint.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(docToPrint_PrintPage);
            docToPrint.PrinterSettings = print.PrinterSettings;
            print.Document = docToPrint;

            docToPrint.Print();

        }
        public static void hatem_font_godel(Control sender,int margin,string text)
        {
            Font result=(Font)sender.Font.Clone();
            int iSize = 45;
            Size godel;
            do
            {
                if (iSize < 0)
                {
                    MessageBox.Show("הדף קטן מדי");
                    return;
                }
                result = new System.Drawing.Font("Arial", iSize--, FontStyle.Regular);
                godel = TextRenderer.MeasureText(text, result);
            }
            while (godel.Width > sender.ClientSize.Width - margin ||
                godel.Height > sender.ClientSize.Height - margin);
            sender.Font = result;

        }
    }
}
