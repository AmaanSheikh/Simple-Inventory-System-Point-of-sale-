namespace POS
{
    partial class frmDashBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnItems = new System.Windows.Forms.Button();
            this.btnPurchase = new System.Windows.Forms.Button();
            this.Sale = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnItems
            // 
            this.btnItems.Location = new System.Drawing.Point(86, 84);
            this.btnItems.Name = "btnItems";
            this.btnItems.Size = new System.Drawing.Size(107, 26);
            this.btnItems.TabIndex = 0;
            this.btnItems.Text = "Items";
            this.btnItems.UseVisualStyleBackColor = true;
            this.btnItems.Click += new System.EventHandler(this.btnItems_Click);
            // 
            // btnPurchase
            // 
            this.btnPurchase.Location = new System.Drawing.Point(86, 144);
            this.btnPurchase.Name = "btnPurchase";
            this.btnPurchase.Size = new System.Drawing.Size(107, 23);
            this.btnPurchase.TabIndex = 1;
            this.btnPurchase.Text = "Purchase Register";
            this.btnPurchase.UseVisualStyleBackColor = true;
            this.btnPurchase.Click += new System.EventHandler(this.btnPurchase_Click);
            // 
            // Sale
            // 
            this.Sale.Location = new System.Drawing.Point(86, 199);
            this.Sale.Name = "Sale";
            this.Sale.Size = new System.Drawing.Size(107, 23);
            this.Sale.TabIndex = 2;
            this.Sale.Text = "Sale";
            this.Sale.UseVisualStyleBackColor = true;
            // 
            // frmDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 536);
            this.Controls.Add(this.Sale);
            this.Controls.Add(this.btnPurchase);
            this.Controls.Add(this.btnItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnItems;
        private System.Windows.Forms.Button btnPurchase;
        private System.Windows.Forms.Button Sale;

    }
}