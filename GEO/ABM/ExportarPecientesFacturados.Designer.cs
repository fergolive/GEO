namespace OriTrabajos.ABM
{
    partial class ExportarPecientesFacturados
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportarPecientesFacturados));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtPacientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GrdRutaBD = new System.Windows.Forms.GroupBox();
            this.btnGuardarRuta = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.TextBox();
            this.btnActivar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.GrdRutaBD.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnActivar,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolStripButton2,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(671, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Rockwell Extra Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(6, 86);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(70, 19);
            this.lblMensaje.TabIndex = 2;
            this.lblMensaje.Text = "label1";
            // 
            // txtPacientes
            // 
            this.txtPacientes.Location = new System.Drawing.Point(9, 205);
            this.txtPacientes.Margin = new System.Windows.Forms.Padding(2);
            this.txtPacientes.Multiline = true;
            this.txtPacientes.Name = "txtPacientes";
            this.txtPacientes.Size = new System.Drawing.Size(654, 270);
            this.txtPacientes.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pacientes exportados hoy";
            // 
            // GrdRutaBD
            // 
            this.GrdRutaBD.Controls.Add(this.btnGuardarRuta);
            this.GrdRutaBD.Controls.Add(this.txtRuta);
            this.GrdRutaBD.Enabled = false;
            this.GrdRutaBD.ForeColor = System.Drawing.Color.White;
            this.GrdRutaBD.Location = new System.Drawing.Point(282, 94);
            this.GrdRutaBD.Margin = new System.Windows.Forms.Padding(2);
            this.GrdRutaBD.Name = "GrdRutaBD";
            this.GrdRutaBD.Padding = new System.Windows.Forms.Padding(2);
            this.GrdRutaBD.Size = new System.Drawing.Size(379, 65);
            this.GrdRutaBD.TabIndex = 5;
            this.GrdRutaBD.TabStop = false;
            this.GrdRutaBD.Text = "Ruta de Base de datos";
            // 
            // btnGuardarRuta
            // 
            this.btnGuardarRuta.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarRuta.Image = global::GEO.Properties.Resources.favicon__3_;
            this.btnGuardarRuta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarRuta.Location = new System.Drawing.Point(301, 20);
            this.btnGuardarRuta.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardarRuta.Name = "btnGuardarRuta";
            this.btnGuardarRuta.Size = new System.Drawing.Size(74, 31);
            this.btnGuardarRuta.TabIndex = 1;
            this.btnGuardarRuta.Text = "Guardar";
            this.btnGuardarRuta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarRuta.UseVisualStyleBackColor = true;
            this.btnGuardarRuta.Click += new System.EventHandler(this.btnGuardarRuta_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(30, 26);
            this.txtRuta.Margin = new System.Windows.Forms.Padding(2);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(268, 20);
            this.txtRuta.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.DarkCyan;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblError.ForeColor = System.Drawing.Color.White;
            this.lblError.Location = new System.Drawing.Point(12, 30);
            this.lblError.Multiline = true;
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(647, 43);
            this.lblError.TabIndex = 2;
            // 
            // btnActivar
            // 
            this.btnActivar.Image = global::GEO.Properties.Resources.IconTimer;
            this.btnActivar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(97, 22);
            this.btnActivar.Text = "Activar Timer";
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton1.Text = "Desactivar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(44, 22);
            this.toolStripButton2.Text = "Ayuda";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // ExportarPecientesFacturados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(671, 484);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.GrdRutaBD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPacientes);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ExportarPecientesFacturados";
            this.Text = "EXPORTAR PACIENTES FACTURADOS";
            this.Load += new System.EventHandler(this.ExportarPecientesFacturados_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.GrdRutaBD.ResumeLayout(false);
            this.GrdRutaBD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnActivar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.TextBox txtPacientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.GroupBox GrdRutaBD;
        private System.Windows.Forms.Button btnGuardarRuta;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox lblError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}