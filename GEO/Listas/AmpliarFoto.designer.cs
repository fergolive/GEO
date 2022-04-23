namespace OriTrabajos.LISTAS
{
    partial class AmpliarFoto
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
            this.panelImg = new System.Windows.Forms.Panel();
            this.picImg = new System.Windows.Forms.PictureBox();
            this.panelImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panelImg
            // 
            this.panelImg.Controls.Add(this.picImg);
            this.panelImg.Location = new System.Drawing.Point(12, 12);
            this.panelImg.Name = "panelImg";
            this.panelImg.Size = new System.Drawing.Size(416, 448);
            this.panelImg.TabIndex = 0;
            // 
            // picImg
            // 
            this.picImg.Location = new System.Drawing.Point(25, 23);
            this.picImg.Name = "picImg";
            this.picImg.Size = new System.Drawing.Size(368, 399);
            this.picImg.TabIndex = 0;
            this.picImg.TabStop = false;
            // 
            // AmpliarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 472);
            this.Controls.Add(this.panelImg);
            this.Name = "AmpliarFoto";
            this.Text = "AmpliarFoto";
            this.Load += new System.EventHandler(this.AmpliarFoto_Load);
            this.panelImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelImg;
        private System.Windows.Forms.PictureBox picImg;
    }
}