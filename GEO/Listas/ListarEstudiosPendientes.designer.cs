namespace OriTrabajos.LISTAS
{
    partial class ListarEstudiosPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListarEstudiosPendientes));
            this.groupImpresion = new System.Windows.Forms.GroupBox();
            this.rdbModelo = new System.Windows.Forms.RadioButton();
            this.rdbFoto = new System.Windows.Forms.RadioButton();
            this.rbtnNemo = new System.Windows.Forms.RadioButton();
            this.rbtnOxi = new System.Windows.Forms.RadioButton();
            this.rbtnTomo = new System.Windows.Forms.RadioButton();
            this.gridEstudios = new System.Windows.Forms.DataGridView();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Informada_Por = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tomada_Por = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblerror = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lblResultados = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.groupImpresion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupImpresion
            // 
            this.groupImpresion.Controls.Add(this.rdbModelo);
            this.groupImpresion.Controls.Add(this.rdbFoto);
            this.groupImpresion.Controls.Add(this.rbtnNemo);
            this.groupImpresion.Controls.Add(this.rbtnOxi);
            this.groupImpresion.Controls.Add(this.rbtnTomo);
            this.groupImpresion.ForeColor = System.Drawing.Color.White;
            this.groupImpresion.Location = new System.Drawing.Point(3, 3);
            this.groupImpresion.Name = "groupImpresion";
            this.groupImpresion.Size = new System.Drawing.Size(147, 150);
            this.groupImpresion.TabIndex = 168;
            this.groupImpresion.TabStop = false;
            this.groupImpresion.Text = "Tipo de estudio";
            // 
            // rdbModelo
            // 
            this.rdbModelo.AutoSize = true;
            this.rdbModelo.Location = new System.Drawing.Point(25, 117);
            this.rdbModelo.Name = "rdbModelo";
            this.rdbModelo.Size = new System.Drawing.Size(60, 17);
            this.rdbModelo.TabIndex = 167;
            this.rdbModelo.TabStop = true;
            this.rdbModelo.Text = "Modelo";
            this.rdbModelo.UseVisualStyleBackColor = true;
            // 
            // rdbFoto
            // 
            this.rdbFoto.AutoSize = true;
            this.rdbFoto.Location = new System.Drawing.Point(25, 94);
            this.rdbFoto.Name = "rdbFoto";
            this.rdbFoto.Size = new System.Drawing.Size(72, 17);
            this.rdbFoto.TabIndex = 166;
            this.rdbFoto.TabStop = true;
            this.rdbFoto.Text = "Fotografia";
            this.rdbFoto.UseVisualStyleBackColor = true;
            // 
            // rbtnNemo
            // 
            this.rbtnNemo.AutoSize = true;
            this.rbtnNemo.Location = new System.Drawing.Point(25, 71);
            this.rbtnNemo.Name = "rbtnNemo";
            this.rbtnNemo.Size = new System.Drawing.Size(112, 17);
            this.rbtnNemo.TabIndex = 165;
            this.rbtnNemo.TabStop = true;
            this.rbtnNemo.Text = "Est Cefalometricos";
            this.rbtnNemo.UseVisualStyleBackColor = true;
            // 
            // rbtnOxi
            // 
            this.rbtnOxi.AutoSize = true;
            this.rbtnOxi.Location = new System.Drawing.Point(25, 48);
            this.rbtnOxi.Name = "rbtnOxi";
            this.rbtnOxi.Size = new System.Drawing.Size(40, 17);
            this.rbtnOxi.TabIndex = 164;
            this.rbtnOxi.TabStop = true;
            this.rbtnOxi.Text = "Oxi";
            this.rbtnOxi.UseVisualStyleBackColor = true;
            // 
            // rbtnTomo
            // 
            this.rbtnTomo.AutoSize = true;
            this.rbtnTomo.Location = new System.Drawing.Point(25, 27);
            this.rbtnTomo.Name = "rbtnTomo";
            this.rbtnTomo.Size = new System.Drawing.Size(52, 17);
            this.rbtnTomo.TabIndex = 163;
            this.rbtnTomo.TabStop = true;
            this.rbtnTomo.Text = "Tomo";
            this.rbtnTomo.UseVisualStyleBackColor = true;
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
            this.Paciente,
            this.Informada_Por,
            this.Tomada_Por});
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
            this.gridEstudios.Size = new System.Drawing.Size(572, 424);
            this.gridEstudios.TabIndex = 0;
            this.gridEstudios.VirtualMode = true;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            this.Factura.ReadOnly = true;
            this.Factura.Width = 68;
            // 
            // Paciente
            // 
            this.Paciente.DataPropertyName = "Paciente";
            this.Paciente.HeaderText = "Paciente";
            this.Paciente.Name = "Paciente";
            this.Paciente.ReadOnly = true;
            this.Paciente.Width = 74;
            // 
            // Informada_Por
            // 
            this.Informada_Por.DataPropertyName = "InformadaPorNombre";
            this.Informada_Por.HeaderText = "Informada_Por";
            this.Informada_Por.Name = "Informada_Por";
            this.Informada_Por.ReadOnly = true;
            this.Informada_Por.Width = 101;
            // 
            // Tomada_Por
            // 
            this.Tomada_Por.DataPropertyName = "TomadaPorNombre";
            this.Tomada_Por.HeaderText = "Tomada_Por";
            this.Tomada_Por.Name = "Tomada_Por";
            this.Tomada_Por.ReadOnly = true;
            this.Tomada_Por.Width = 93;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(11, 72);
            this.lblerror.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 13);
            this.lblerror.TabIndex = 171;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.btnAgregar,
            this.toolStripSeparator2,
            this.btnEditar,
            this.toolStripSeparator3,
            this.lblResultados,
            this.toolStripSeparator5,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(728, 25);
            this.toolStrip1.TabIndex = 174;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::GEO.Properties.Resources.IconListar;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton1.Text = "Listar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::GEO.Properties.Resources.IconAdd;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(69, 22);
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::GEO.Properties.Resources.IconEdit2;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(57, 22);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            this.panel1.Size = new System.Drawing.Size(728, 424);
            this.panel1.TabIndex = 175;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridEstudios);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(156, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 424);
            this.panel2.TabIndex = 170;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupImpresion);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(156, 424);
            this.flowLayoutPanel1.TabIndex = 169;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(147, 139);
            this.groupBox1.TabIndex = 169;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mensajes";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.DarkCyan;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 114);
            this.textBox1.TabIndex = 0;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::GEO.Properties.Resources.IconSearch1;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(57, 22);
            this.toolStripButton2.Text = "Filtrar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lblResultados
            // 
            this.lblResultados.Name = "lblResultados";
            this.lblResultados.Size = new System.Drawing.Size(64, 22);
            this.lblResultados.Text = "Resultados";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // ListarEstudiosPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkCyan;
            this.ClientSize = new System.Drawing.Size(728, 449);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblerror);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ListarEstudiosPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListarEstudiosPendientes";
            this.groupImpresion.ResumeLayout(false);
            this.groupImpresion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstudios)).EndInit();
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

        private System.Windows.Forms.GroupBox groupImpresion;
        private System.Windows.Forms.RadioButton rbtnOxi;
        private System.Windows.Forms.RadioButton rbtnTomo;
        private System.Windows.Forms.RadioButton rbtnNemo;
        private System.Windows.Forms.DataGridView gridEstudios;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Paciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Informada_Por;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tomada_Por;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.RadioButton rdbModelo;
        private System.Windows.Forms.RadioButton rdbFoto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lblResultados;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}