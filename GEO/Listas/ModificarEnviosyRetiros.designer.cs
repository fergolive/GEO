namespace OriTrabajos.LISTAS
{
    partial class ModificarEnviosyRetiros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModificarEnviosyRetiros));
            this.gridEstudios = new System.Windows.Forms.DataGridView();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pacient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Retirada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Direccion_Persona_EnvRet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblerror = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.Tipo = new System.Windows.Forms.GroupBox();
            this.rbtEnvia = new System.Windows.Forms.RadioButton();
            this.rbtPocitos = new System.Windows.Forms.RadioButton();
            this.rbtCordon = new System.Windows.Forms.RadioButton();
            this.txtEntregadaOtro = new System.Windows.Forms.TextBox();
            this.groupEntregada = new System.Windows.Forms.GroupBox();
            this.rbtOtro = new System.Windows.Forms.RadioButton();
            this.rbtArea = new System.Windows.Forms.RadioButton();
            this.rbtRecepcion = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblError2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).BeginInit();
            this.Tipo.SuspendLayout();
            this.groupEntregada.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridEstudios
            // 
            this.gridEstudios.AllowUserToAddRows = false;
            this.gridEstudios.AllowUserToDeleteRows = false;
            this.gridEstudios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gridEstudios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridEstudios.BackgroundColor = System.Drawing.Color.DarkCyan;
            this.gridEstudios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridEstudios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstudios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Factura,
            this.Pacient,
            this.Paciente,
            this.Retirada,
            this.Direccion_Persona_EnvRet,
            this.Column1});
            this.gridEstudios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEstudios.GridColor = System.Drawing.Color.PowderBlue;
            this.gridEstudios.Location = new System.Drawing.Point(0, 0);
            this.gridEstudios.Margin = new System.Windows.Forms.Padding(2);
            this.gridEstudios.MultiSelect = false;
            this.gridEstudios.Name = "gridEstudios";
            this.gridEstudios.RowTemplate.Height = 24;
            this.gridEstudios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridEstudios.ShowCellErrors = false;
            this.gridEstudios.ShowCellToolTips = false;
            this.gridEstudios.ShowEditingIcon = false;
            this.gridEstudios.ShowRowErrors = false;
            this.gridEstudios.Size = new System.Drawing.Size(649, 511);
            this.gridEstudios.TabIndex = 173;
            this.gridEstudios.VirtualMode = true;
            this.gridEstudios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEstudios_CellClick);
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "NumDeFactura";
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            this.Factura.Width = 68;
            // 
            // Pacient
            // 
            this.Pacient.DataPropertyName = "Paciente";
            this.Pacient.HeaderText = "Paciente";
            this.Pacient.Name = "Pacient";
            this.Pacient.Width = 74;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Enviada";
            this.Paciente.HeaderText = "Enviada";
            this.Paciente.Name = "Paciente";
            this.Paciente.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Paciente.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Paciente.Width = 71;
            // 
            // Retirada
            // 
            this.Retirada.DataPropertyName = "Retirada";
            this.Retirada.HeaderText = "Retirada";
            this.Retirada.Name = "Retirada";
            this.Retirada.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Retirada.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Retirada.Width = 72;
            // 
            // Direccion_Persona_EnvRet
            // 
            this.Direccion_Persona_EnvRet.DataPropertyName = "Direccion_Persona_EnvRet";
            this.Direccion_Persona_EnvRet.HeaderText = "Direccion_Y/o_Persona";
            this.Direccion_Persona_EnvRet.Name = "Direccion_Persona_EnvRet";
            this.Direccion_Persona_EnvRet.Width = 146;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Image = global::GEO.Properties.Resources.IconSave;
            this.Column1.Name = "Column1";
            this.Column1.Width = 5;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(16, 514);
            this.lblerror.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 13);
            this.lblerror.TabIndex = 176;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // Tipo
            // 
            this.Tipo.Controls.Add(this.rbtEnvia);
            this.Tipo.Controls.Add(this.rbtPocitos);
            this.Tipo.Controls.Add(this.rbtCordon);
            this.Tipo.ForeColor = System.Drawing.Color.White;
            this.Tipo.Location = new System.Drawing.Point(3, 3);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(145, 107);
            this.Tipo.TabIndex = 183;
            this.Tipo.TabStop = false;
            this.Tipo.Text = "Tipo";
            // 
            // rbtEnvia
            // 
            this.rbtEnvia.AutoSize = true;
            this.rbtEnvia.Location = new System.Drawing.Point(20, 71);
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
            this.rbtPocitos.Location = new System.Drawing.Point(20, 48);
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
            this.rbtCordon.Location = new System.Drawing.Point(20, 25);
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
            this.txtEntregadaOtro.Location = new System.Drawing.Point(9, 95);
            this.txtEntregadaOtro.Name = "txtEntregadaOtro";
            this.txtEntregadaOtro.Size = new System.Drawing.Size(130, 19);
            this.txtEntregadaOtro.TabIndex = 185;
            // 
            // groupEntregada
            // 
            this.groupEntregada.Controls.Add(this.rbtOtro);
            this.groupEntregada.Controls.Add(this.rbtArea);
            this.groupEntregada.Controls.Add(this.txtEntregadaOtro);
            this.groupEntregada.Controls.Add(this.rbtRecepcion);
            this.groupEntregada.ForeColor = System.Drawing.Color.White;
            this.groupEntregada.Location = new System.Drawing.Point(3, 116);
            this.groupEntregada.Name = "groupEntregada";
            this.groupEntregada.Size = new System.Drawing.Size(145, 130);
            this.groupEntregada.TabIndex = 184;
            this.groupEntregada.TabStop = false;
            this.groupEntregada.Text = "Destino";
            // 
            // rbtOtro
            // 
            this.rbtOtro.AutoSize = true;
            this.rbtOtro.Location = new System.Drawing.Point(20, 72);
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
            this.rbtArea.Location = new System.Drawing.Point(20, 49);
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
            this.rbtRecepcion.Location = new System.Drawing.Point(20, 26);
            this.rbtRecepcion.Name = "rbtRecepcion";
            this.rbtRecepcion.Size = new System.Drawing.Size(77, 17);
            this.rbtRecepcion.TabIndex = 0;
            this.rbtRecepcion.TabStop = true;
            this.rbtRecepcion.Text = "Recepcion";
            this.rbtRecepcion.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.DarkCyan;
            this.flowLayoutPanel1.Controls.Add(this.Tipo);
            this.flowLayoutPanel1.Controls.Add(this.groupEntregada);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(157, 511);
            this.flowLayoutPanel1.TabIndex = 188;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblError2);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 252);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(145, 142);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensajes";
            // 
            // lblError2
            // 
            this.lblError2.BackColor = System.Drawing.Color.DarkCyan;
            this.lblError2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblError2.ForeColor = System.Drawing.Color.White;
            this.lblError2.Location = new System.Drawing.Point(7, 20);
            this.lblError2.Multiline = true;
            this.lblError2.Name = "lblError2";
            this.lblError2.Size = new System.Drawing.Size(132, 101);
            this.lblError2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridEstudios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(157, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 511);
            this.panel1.TabIndex = 189;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(806, 25);
            this.toolStrip1.TabIndex = 190;
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
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(45, 22);
            this.toolStripButton3.Text = "Ayuda";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 511);
            this.panel2.TabIndex = 191;
            // 
            // ModificarEnviosyRetiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 536);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblerror);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ModificarEnviosyRetiros";
            this.Text = "MODIFICAR ESTADO DE CARPETAS (Enviadas/Retiradas)";
            this.Load += new System.EventHandler(this.ModificarEnviosyRetiros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).EndInit();
            this.Tipo.ResumeLayout(false);
            this.Tipo.PerformLayout();
            this.groupEntregada.ResumeLayout(false);
            this.groupEntregada.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEstudios;
        private System.Windows.Forms.Label lblerror;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.GroupBox Tipo;
        private System.Windows.Forms.RadioButton rbtEnvia;
        private System.Windows.Forms.RadioButton rbtPocitos;
        private System.Windows.Forms.RadioButton rbtCordon;
        private System.Windows.Forms.TextBox txtEntregadaOtro;
        private System.Windows.Forms.GroupBox groupEntregada;
        private System.Windows.Forms.RadioButton rbtOtro;
        private System.Windows.Forms.RadioButton rbtArea;
        private System.Windows.Forms.RadioButton rbtRecepcion;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox lblError2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pacient;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Retirada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion_Persona_EnvRet;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
    }
}