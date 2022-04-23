namespace OriTrabajos.LISTAS
{
    partial class EnviosyRetirosDiarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnviosyRetirosDiarios));
            this.gridEstudios = new System.Windows.Forms.DataGridView();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odontologo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionDeEnvio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.groupTipos = new System.Windows.Forms.GroupBox();
            this.rbtEnvia = new System.Windows.Forms.RadioButton();
            this.rbtPocitos = new System.Windows.Forms.RadioButton();
            this.rbtCordon = new System.Windows.Forms.RadioButton();
            this.txtEntregadaOtro = new System.Windows.Forms.TextBox();
            this.groupEntregada = new System.Windows.Forms.GroupBox();
            this.rbtOtro = new System.Windows.Forms.RadioButton();
            this.rbtArea = new System.Windows.Forms.RadioButton();
            this.rbtRecepcion = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblerror = new System.Windows.Forms.TextBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).BeginInit();
            this.groupTipos.SuspendLayout();
            this.groupEntregada.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEstudios
            // 
            this.gridEstudios.AllowUserToAddRows = false;
            this.gridEstudios.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gridEstudios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridEstudios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridEstudios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridEstudios.BackgroundColor = System.Drawing.Color.DarkCyan;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEstudios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Factura,
            this.Odontologo,
            this.Paciente,
            this.DireccionDeEnvio,
            this.Column1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridEstudios.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridEstudios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEstudios.GridColor = System.Drawing.Color.PowderBlue;
            this.gridEstudios.Location = new System.Drawing.Point(0, 0);
            this.gridEstudios.Margin = new System.Windows.Forms.Padding(2);
            this.gridEstudios.MultiSelect = false;
            this.gridEstudios.Name = "gridEstudios";
            this.gridEstudios.ReadOnly = true;
            this.gridEstudios.RowTemplate.Height = 24;
            this.gridEstudios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEstudios.ShowCellErrors = false;
            this.gridEstudios.ShowCellToolTips = false;
            this.gridEstudios.ShowEditingIcon = false;
            this.gridEstudios.ShowRowErrors = false;
            this.gridEstudios.Size = new System.Drawing.Size(586, 533);
            this.gridEstudios.TabIndex = 173;
            this.gridEstudios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEstudios_CellClick);
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "NumDeFactura";
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            this.Factura.ReadOnly = true;
            this.Factura.Width = 81;
            // 
            // Odontologo
            // 
            this.Odontologo.DataPropertyName = "Odontologo";
            this.Odontologo.HeaderText = "Odontologo";
            this.Odontologo.Name = "Odontologo";
            this.Odontologo.ReadOnly = true;
            this.Odontologo.Width = 107;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Paciente";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 88;
            // 
            // DireccionDeEnvio
            // 
            this.DireccionDeEnvio.DataPropertyName = "DireccionDeEnvio";
            this.DireccionDeEnvio.HeaderText = "DireccionDeEnvio";
            this.DireccionDeEnvio.Name = "DireccionDeEnvio";
            this.DireccionDeEnvio.ReadOnly = true;
            this.DireccionDeEnvio.Width = 145;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = global::GEO.Properties.Resources.favicon__5_;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 5;
            // 
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage_1);
            // 
            // groupTipos
            // 
            this.groupTipos.Controls.Add(this.rbtEnvia);
            this.groupTipos.Controls.Add(this.rbtPocitos);
            this.groupTipos.Controls.Add(this.rbtCordon);
            this.groupTipos.ForeColor = System.Drawing.Color.White;
            this.groupTipos.Location = new System.Drawing.Point(3, 3);
            this.groupTipos.Name = "groupTipos";
            this.groupTipos.Size = new System.Drawing.Size(134, 86);
            this.groupTipos.TabIndex = 183;
            this.groupTipos.TabStop = false;
            this.groupTipos.Text = "Tipo";
            // 
            // rbtEnvia
            // 
            this.rbtEnvia.AutoSize = true;
            this.rbtEnvia.Location = new System.Drawing.Point(5, 61);
            this.rbtEnvia.Name = "rbtEnvia";
            this.rbtEnvia.Size = new System.Drawing.Size(52, 17);
            this.rbtEnvia.TabIndex = 158;
            this.rbtEnvia.TabStop = true;
            this.rbtEnvia.Text = "Envia";
            this.rbtEnvia.UseVisualStyleBackColor = true;
            // 
            // rbtPocitos
            // 
            this.rbtPocitos.AutoSize = true;
            this.rbtPocitos.Location = new System.Drawing.Point(5, 38);
            this.rbtPocitos.Name = "rbtPocitos";
            this.rbtPocitos.Size = new System.Drawing.Size(91, 17);
            this.rbtPocitos.TabIndex = 1;
            this.rbtPocitos.TabStop = true;
            this.rbtPocitos.Text = "Retira Pocitos";
            this.rbtPocitos.UseVisualStyleBackColor = true;
            // 
            // rbtCordon
            // 
            this.rbtCordon.AutoSize = true;
            this.rbtCordon.Location = new System.Drawing.Point(5, 15);
            this.rbtCordon.Name = "rbtCordon";
            this.rbtCordon.Size = new System.Drawing.Size(90, 17);
            this.rbtCordon.TabIndex = 0;
            this.rbtCordon.TabStop = true;
            this.rbtCordon.Text = "Retira Cordon";
            this.rbtCordon.UseVisualStyleBackColor = true;
            // 
            // txtEntregadaOtro
            // 
            this.txtEntregadaOtro.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntregadaOtro.Location = new System.Drawing.Point(8, 89);
            this.txtEntregadaOtro.Name = "txtEntregadaOtro";
            this.txtEntregadaOtro.Size = new System.Drawing.Size(118, 19);
            this.txtEntregadaOtro.TabIndex = 185;
            // 
            // groupEntregada
            // 
            this.groupEntregada.Controls.Add(this.rbtOtro);
            this.groupEntregada.Controls.Add(this.rbtArea);
            this.groupEntregada.Controls.Add(this.txtEntregadaOtro);
            this.groupEntregada.Controls.Add(this.rbtRecepcion);
            this.groupEntregada.ForeColor = System.Drawing.Color.White;
            this.groupEntregada.Location = new System.Drawing.Point(3, 95);
            this.groupEntregada.Name = "groupEntregada";
            this.groupEntregada.Size = new System.Drawing.Size(134, 118);
            this.groupEntregada.TabIndex = 184;
            this.groupEntregada.TabStop = false;
            this.groupEntregada.Text = "Destino";
            // 
            // rbtOtro
            // 
            this.rbtOtro.AutoSize = true;
            this.rbtOtro.Location = new System.Drawing.Point(5, 64);
            this.rbtOtro.Name = "rbtOtro";
            this.rbtOtro.Size = new System.Drawing.Size(45, 17);
            this.rbtOtro.TabIndex = 158;
            this.rbtOtro.TabStop = true;
            this.rbtOtro.Text = "Otro";
            this.rbtOtro.UseVisualStyleBackColor = true;
            this.rbtOtro.CheckedChanged += new System.EventHandler(this.rbtOtro_CheckedChanged);
            // 
            // rbtArea
            // 
            this.rbtArea.AutoSize = true;
            this.rbtArea.Location = new System.Drawing.Point(5, 41);
            this.rbtArea.Name = "rbtArea";
            this.rbtArea.Size = new System.Drawing.Size(47, 17);
            this.rbtArea.TabIndex = 1;
            this.rbtArea.TabStop = true;
            this.rbtArea.Text = "Area";
            this.rbtArea.UseVisualStyleBackColor = true;
            // 
            // rbtRecepcion
            // 
            this.rbtRecepcion.AutoSize = true;
            this.rbtRecepcion.Location = new System.Drawing.Point(5, 18);
            this.rbtRecepcion.Name = "rbtRecepcion";
            this.rbtRecepcion.Size = new System.Drawing.Size(77, 17);
            this.rbtRecepcion.TabIndex = 0;
            this.rbtRecepcion.TabStop = true;
            this.rbtRecepcion.Text = "Recepcion";
            this.rbtRecepcion.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnPrintPreview,
            this.toolStripSeparator2,
            this.btnPrint,
            this.toolStripSeparator3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(730, 25);
            this.toolStrip1.TabIndex = 187;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::GEO.Properties.Resources.IconListar;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton1.Text = "Listar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Image = global::GEO.Properties.Resources.IconVistaPrevia;
            this.btnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(87, 22);
            this.btnPrintPreview.Text = "Vista Previa";
            this.btnPrintPreview.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::GEO.Properties.Resources.IconImprimir;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(73, 22);
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton4.Text = "Ayuda";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 533);
            this.panel1.TabIndex = 188;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridEstudios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(144, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(586, 533);
            this.panel2.TabIndex = 188;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkCyan;
            this.flowLayoutPanel1.Controls.Add(this.groupTipos);
            this.flowLayoutPanel1.Controls.Add(this.groupEntregada);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(144, 533);
            this.flowLayoutPanel1.TabIndex = 186;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblerror);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 116);
            this.groupBox1.TabIndex = 185;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensajes";
            // 
            // lblerror
            // 
            this.lblerror.BackColor = System.Drawing.Color.DarkCyan;
            this.lblerror.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblerror.ForeColor = System.Drawing.Color.White;
            this.lblerror.Location = new System.Drawing.Point(7, 14);
            this.lblerror.Multiline = true;
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(119, 95);
            this.lblerror.TabIndex = 0;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Accion";
            this.dataGridViewImageColumn1.Image = global::GEO.Properties.Resources.IconDeleteWhite;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 46;
            // 
            // EnviosyRetirosDiarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 558);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "EnviosyRetirosDiarios";
            this.Text = "LISTADO DE CARPETAS PENDIENTES DE ENVIO O RETIRO";
            this.Load += new System.EventHandler(this.EnviosyRetirosDiarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).EndInit();
            this.groupTipos.ResumeLayout(false);
            this.groupTipos.PerformLayout();
            this.groupEntregada.ResumeLayout(false);
            this.groupEntregada.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEstudios;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.GroupBox groupTipos;
        private System.Windows.Forms.RadioButton rbtEnvia;
        private System.Windows.Forms.RadioButton rbtPocitos;
        private System.Windows.Forms.RadioButton rbtCordon;
        private System.Windows.Forms.TextBox txtEntregadaOtro;
        private System.Windows.Forms.GroupBox groupEntregada;
        private System.Windows.Forms.RadioButton rbtOtro;
        private System.Windows.Forms.RadioButton rbtArea;
        private System.Windows.Forms.RadioButton rbtRecepcion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnPrintPreview;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lblerror;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Odontologo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionDeEnvio;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
    }
}