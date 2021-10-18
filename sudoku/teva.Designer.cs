namespace sudoku
{
    partial class teva
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LNivhar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(64, 64);
            this.panel1.TabIndex = 2;
            this.panel1.Enter += new System.EventHandler(this.teva_Enter);
            this.panel1.Leave += new System.EventHandler(this.teva_Leave);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // LNivhar
            // 
            this.LNivhar.Font = new System.Drawing.Font("Arial", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LNivhar.Location = new System.Drawing.Point(0, 0);
            this.LNivhar.Name = "LNivhar";
            this.LNivhar.Size = new System.Drawing.Size(70, 70);
            this.LNivhar.TabIndex = 1;
            this.LNivhar.Text = "9";
            this.LNivhar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LNivhar.Enter += new System.EventHandler(this.teva_Enter);
            this.LNivhar.Leave += new System.EventHandler(this.teva_Leave);
            this.LNivhar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // teva
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LNivhar);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "teva";
            this.Size = new System.Drawing.Size(70, 70);
            this.Enter += new System.EventHandler(this.teva_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teva_KeyDown);
            this.Leave += new System.EventHandler(this.teva_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LNivhar;

    }
}
