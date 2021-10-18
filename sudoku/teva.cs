using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sudoku
{
    public partial class teva : Panel
    {
        Color cYeholim;
        Color cNimhak = Color.GreenYellow, cNivhar1 = Color.Cyan;
        Sudoku sudoku_parent;
        bool hakpaat_focus;
        internal void kasher(Sudoku sudoku_sheli)
        {
            sudoku_parent = sudoku_sheli;
        }
        public Mispar mutsag
        {

            set
            {
                LNivhar.Text = value==null?"  ":value.ToString();
                LNivhar.Visible = value.Value != null;
                if (!(panel1.Visible =
                    value.Value == null && Form2.Sform2.hatseg_efsharuyot))
                    return;
                cYeholim = Color.Black;
                if(Form2.Sform2.mehikat_efsharouyot)
                    switch (value.shayah.Count())
                {
                    case 1: cYeholim = Color.Green; break;
                    case 2: cYeholim = Color.Red; break;
                }
                bool[] visible = new bool[Sudoku.rank];

                for (int i = 0; i < Sudoku.rank; i++)
                {
                    visible[i] = !Form2.Sform2.mehikat_efsharouyot;
                    if (yeholim[i].BackColor != cNivhar1 && yeholim[i].ForeColor != cNimhak)
                        yeholim[i].ForeColor = cYeholim;
                }
                foreach (int i in value.shayah)
                    visible[i-1] = true;
                for (int i = 0; i < Sudoku.rank; i++)
                    yeholim[i].Visible = visible[i];
            }
        }
        public int index;
        Label[] yeholim;
        FMain parent;
        public teva(FMain parent, int index)
        {
            InitializeComponent();
            this.parent = parent;
            this.Size = new Size(Form2.Sform2.godel_teva,Form2.Sform2.godel_teva);
            LNivhar.Size = this.Size;
            LNivhar.Location = new Point(0, 0);
            FMain.hatem_font_godel(LNivhar,2,Sudoku.rank.ToString());
            this.index = index;
            yeholim = new Label[Sudoku.rank];
            for (int x = 0; x < Sudoku.ranksquare; x++)
                for (int y = 0; y < Sudoku.ranksquare; y++)
                    new_yeholim(x, y);

            LNivhar.Text = null;
            panel1.Visible =  Form2.Sform2.hatseg_efsharuyot;
        }
        void new_yeholim(int x, int y)
        {
            Label newLabel = new Label();
            int Index = x + Sudoku.ranksquare * y;
            int size_yeholim = (this.ClientSize.Width - this.Margin.All) / Sudoku.ranksquare;
            newLabel.Location = new System.Drawing.Point(size_yeholim * x, size_yeholim * y);
            newLabel.Size = new System.Drawing.Size(size_yeholim, size_yeholim);
            newLabel.Text = (Index+1).ToString();
            newLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            newLabel.MouseDown += new MouseEventHandler(this.yeholim_MouseDown);
            newLabel.Enter += new System.EventHandler(this.teva_Enter);
            newLabel.Leave += new System.EventHandler(this.teva_Leave);
            FMain.hatem_font_godel(newLabel, 0, newLabel.Text);
            panel1.Controls.Remove(yeholim[x + Sudoku.ranksquare * y]);
            //yeholim[index].Dispose();
            yeholim[Index] = newLabel;
            panel1.Controls.Add(yeholim[Index]);
        }
        internal void raanenSize()
        {
            this.Size=new Size(Form2.Sform2.godel_teva,Form2.Sform2.godel_teva);
            LNivhar.Size = this.Size;
            panel1.Size = this.Size;
            FMain.hatem_font_godel(LNivhar, 0, LNivhar.Text);
            int size_yeholim = (this.ClientSize.Width - this.Margin.All) / Sudoku.ranksquare;
            Size sizeYeholim = new System.Drawing.Size(size_yeholim, size_yeholim);
            for(int x=0;x<Sudoku.ranksquare;x++)
            for(int y=0;y<Sudoku.ranksquare;y++)
            {
                Label l = yeholim[y * Sudoku.ranksquare + x];
                l.Size = sizeYeholim;
                l.Location = new System.Drawing.Point(size_yeholim * x, size_yeholim * y); ;
                FMain.hatem_font_godel(l, 0, l.Text);
            }
        }

        public void shane_tseva_mispar(Color new_color)
        {
            LNivhar.ForeColor = new_color;
        }
        Color Cbase_reka;
        public void shane_trseva_reka(Color new_color)
        {
            this.BackColor = Cbase_reka = new_color;
            if (Focused) teva_Enter(null,null);
        }


        bool Pisreadonly;
        public bool isReadOnly
        {
            set
            {
                Pisreadonly = value;
                //this.Enabled = !value;
                shane_tseva_mispar(value ? Color.Blue : Color.Black);
                
            }
            get
            {
                return Pisreadonly;
            }
        }

        private void yeholim_MouseDown(object sender, MouseEventArgs e)
        {
            Focus();
            Label Lsender = sender as Label;
            int matsav = Lsender.ForeColor == cNimhak ? 0 : Lsender.BackColor == cNivhar1 ? 1 : 2;
            int index = int.Parse(Lsender.Text) - 1,x=index%Sudoku.ranksquare,y=index/Sudoku.ranksquare;
            hakpaat_focus = true;
            new_yeholim(x, y);
            Focus();
            hakpaat_focus = false;
            Lsender = yeholim[index];
            if (Lsender.ForeColor == cNimhak)
            {
                //sudoku_parent.hahzer_shayah_mishbetset_hitsoni(sudoku_parent[index], int.Parse(Lsender.Text));
                //parent.refresh(false);
            }
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Right:
                    Lsender.ForeColor = cYeholim;
                    if(matsav != 1 )
                        Lsender.BackColor = cNivhar1;
                    break;
                default:
                    if (matsav == 0)
                        Lsender.ForeColor = cYeholim;
                    else
                    {
                        Lsender.ForeColor = cNimhak;
                        //sudoku_parent.batel_shayah_mishbetset_hitsoni(sudoku_parent[index], int.Parse(Lsender.Text));
                        //parent.refresh(false);
                    }
                   break;
            }
        }
        //private void label1_doubleClick(object sender, EventArgs e)
        //{
        //    Label Lsender = sender as Label;
        //    if (Lsender.ForeColor == cYeholim)
        //        Lsender.ForeColor = cNivhar1;
        //    else if (Lsender.ForeColor == cNivhar1)
        //        Lsender.ForeColor = cNivhar2;
        //    else if (Lsender.ForeColor == cNivhar2)
        //        Lsender.ForeColor = cYeholim;
        //}
        internal void resetForeColor()
        {
            
            foreach(Label l in yeholim)
                l.ForeColor=Label.DefaultForeColor;
        }



        Color cnihush = Color.Plum;
        public bool menuhash
        {
            set
            {
                if (value)
                    shane_tseva_mispar(cnihush);
                else if (LNivhar.ForeColor == cnihush)
                {
                    shane_tseva_mispar(Label.DefaultForeColor);
                    sudoku_parent.Pshane(index, null, false, false);
                }
            }
            get { return LNivhar.ForeColor == cnihush; }
        }
        static Color color_nivhar_reka = Color.GreenYellow,
            color_nivhar_reka_taout = Color.FromArgb(color_nivhar_reka.A/2, color_nivhar_reka);// Brown;
        private void teva_Enter(object sender, EventArgs e)
        {
            if (hakpaat_focus) return;
            BorderStyle = BorderStyle.Fixed3D;
                this.BackColor = this.BackColor == teva.DefaultBackColor ? color_nivhar_reka : color_nivhar_reka_taout;
        }

        private void teva_Leave(object sender, EventArgs e)
        {
            if (hakpaat_focus) return;
            BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Cbase_reka;
        }
        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down: return true;
                default: return base.IsInputKey(keyData);
            }
        }
        private void teva_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                parent.focus(e.Control ? index % Sudoku.rank : index - Sudoku.rank);
            if (e.KeyCode == Keys.Down)
                parent.focus(e.Control ? Sudoku.rank * (Sudoku.rank - 1) + index % Sudoku.rank : index + Sudoku.rank);
            if (e.KeyCode == Keys.Left)
                parent.focus(e.Control ? index - index % Sudoku.rank : index - 1);
            if (e.KeyCode == Keys.Right)
                parent.focus(e.Control ? index - index % Sudoku.rank + Sudoku.rank - 1 : index + 1);
            if (Pisreadonly)
                return;
            if ((e.KeyValue >= 48 && e.KeyValue < 58) || (e.KeyValue >= 96 && e.KeyValue < 106))
            {
                int value=e.KeyValue - (e.KeyValue < 80 ? 48 : 96);
                if (Sudoku.rank > 9 && sudoku_parent[index].Value == 1)
                    value+= 10;
                if (value <= Sudoku.rank && value > 0)
                    if (e.Control)
                        yeholim_MouseDown(yeholim[value-1], new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                    else if(e.Shift)
                        yeholim_MouseDown(yeholim[value-1], new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                    else
                        parent.shane(index, value);
            }
            if (e.KeyData == Keys.Delete || e.KeyData == Keys.Space || e.KeyData == Keys.Back)
                parent.shane(index, null);

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
        }



    }
}
