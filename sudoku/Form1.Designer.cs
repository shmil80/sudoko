namespace sudoku
{
    partial class FMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.משחקToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.משחקחדשToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.משחקריקToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.רמזToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.השלםToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.השלםבלילנחשToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.מחקהשלמהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.אפשרויותToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.עריכהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ביטולToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.חזורToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.שמירהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.פתיחהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.הדפסהToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.משחקToolStripMenuItem,
            this.רמזToolStripMenuItem,
            this.toolStripMenuItem1,
            this.עריכהToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(585, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "תפריטים";
            // 
            // משחקToolStripMenuItem
            // 
            this.משחקToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.משחקחדשToolStripMenuItem,
            this.משחקריקToolStripMenuItem,
            this.שמירהToolStripMenuItem,
            this.פתיחהToolStripMenuItem,
            this.הדפסהToolStripMenuItem});
            this.משחקToolStripMenuItem.Name = "משחקToolStripMenuItem";
            this.משחקToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.משחקToolStripMenuItem.Text = "משחק";
            // 
            // משחקחדשToolStripMenuItem
            // 
            this.משחקחדשToolStripMenuItem.Name = "משחקחדשToolStripMenuItem";
            this.משחקחדשToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.משחקחדשToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.משחקחדשToolStripMenuItem.Text = "משחק חדש";
            this.משחקחדשToolStripMenuItem.Click += new System.EventHandler(this.משחקחדשToolStripMenuItem_Click);
            // 
            // משחקריקToolStripMenuItem
            // 
            this.משחקריקToolStripMenuItem.Name = "משחקריקToolStripMenuItem";
            this.משחקריקToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.משחקריקToolStripMenuItem.Text = "בנה משחק ידנית";
            this.משחקריקToolStripMenuItem.Click += new System.EventHandler(this.משחקריקToolStripMenuItem_Click);
            // 
            // רמזToolStripMenuItem
            // 
            this.רמזToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.השלםToolStripMenuItem,
            this.השלםבלילנחשToolStripMenuItem,
            this.מחקהשלמהToolStripMenuItem});
            this.רמזToolStripMenuItem.Name = "רמזToolStripMenuItem";
            this.רמזToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.רמזToolStripMenuItem.Text = "רמז";
            // 
            // השלםToolStripMenuItem
            // 
            this.השלםToolStripMenuItem.Name = "השלםToolStripMenuItem";
            this.השלםToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.השלםToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.השלםToolStripMenuItem.Text = "השלם";
            this.השלםToolStripMenuItem.Click += new System.EventHandler(this.השלםToolStripMenuItem_Click);
            // 
            // השלםבלילנחשToolStripMenuItem
            // 
            this.השלםבלילנחשToolStripMenuItem.Name = "השלםבלילנחשToolStripMenuItem";
            this.השלםבלילנחשToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.השלםבלילנחשToolStripMenuItem.Text = "השלם מוכרחים";
            this.השלםבלילנחשToolStripMenuItem.Click += new System.EventHandler(this.השלםToolStripMenuItem_Click);
            // 
            // מחקהשלמהToolStripMenuItem
            // 
            this.מחקהשלמהToolStripMenuItem.Name = "מחקהשלמהToolStripMenuItem";
            this.מחקהשלמהToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.מחקהשלמהToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.מחקהשלמהToolStripMenuItem.Text = "מחק השלמה";
            this.מחקהשלמהToolStripMenuItem.Click += new System.EventHandler(this.מחקהשלמהToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.אפשרויותToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "כלים";
            // 
            // אפשרויותToolStripMenuItem
            // 
            this.אפשרויותToolStripMenuItem.Name = "אפשרויותToolStripMenuItem";
            this.אפשרויותToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.אפשרויותToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.אפשרויותToolStripMenuItem.Text = "אפשרויות";
            this.אפשרויותToolStripMenuItem.Click += new System.EventHandler(this.אפשרויותToolStripMenuItem_Click);
            // 
            // עריכהToolStripMenuItem
            // 
            this.עריכהToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ביטולToolStripMenuItem,
            this.חזורToolStripMenuItem});
            this.עריכהToolStripMenuItem.Name = "עריכהToolStripMenuItem";
            this.עריכהToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.עריכהToolStripMenuItem.Text = "עריכה";
            // 
            // ביטולToolStripMenuItem
            // 
            this.ביטולToolStripMenuItem.Name = "ביטולToolStripMenuItem";
            this.ביטולToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.ביטולToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.ביטולToolStripMenuItem.Text = "ביטול";
            this.ביטולToolStripMenuItem.Click += new System.EventHandler(this.ביטולToolStripMenuItem_Click);
            // 
            // חזורToolStripMenuItem
            // 
            this.חזורToolStripMenuItem.Name = "חזורToolStripMenuItem";
            this.חזורToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.חזורToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.חזורToolStripMenuItem.Text = "חזור";
            this.חזורToolStripMenuItem.Click += new System.EventHandler(this.חזורToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(100, 100);
            this.panel1.TabIndex = 5;
            // 
            // שמירהToolStripMenuItem
            // 
            this.שמירהToolStripMenuItem.Name = "שמירהToolStripMenuItem";
            this.שמירהToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.שמירהToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.שמירהToolStripMenuItem.Text = "שמירה";
            this.שמירהToolStripMenuItem.Click += new System.EventHandler(this.שמירהToolStripMenuItem_Click);
            // 
            // פתיחהToolStripMenuItem
            // 
            this.פתיחהToolStripMenuItem.Name = "פתיחהToolStripMenuItem";
            this.פתיחהToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.פתיחהToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.פתיחהToolStripMenuItem.Text = "פתיחה";
            this.פתיחהToolStripMenuItem.Click += new System.EventHandler(this.פתיחהToolStripMenuItem_Click);
            // 
            // הדפסהToolStripMenuItem
            // 
            this.הדפסהToolStripMenuItem.Name = "הדפסהToolStripMenuItem";
            this.הדפסהToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.הדפסהToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.הדפסהToolStripMenuItem.Text = "הדפסה";
            this.הדפסהToolStripMenuItem.Click += new System.EventHandler(this.הדפסהToolStripMenuItem_Click);
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(585, 535);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sudoku";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem אפשרויותToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem משחקToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem משחקחדשToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem משחקריקToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem רמזToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem השלםToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem השלםבלילנחשToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem מחקהשלמהToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עריכהToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ביטולToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem חזורToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem שמירהToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem פתיחהToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem הדפסהToolStripMenuItem;


    }
}

