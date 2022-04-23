namespace GEO.Busqueda
{
    partial class FrmFiltroEstudios
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
            this.chkFechaRealiz = new System.Windows.Forms.CheckBox();
            this.chkFac = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkCerrado = new System.Windows.Forms.CheckBox();
            this.chkCerradoPor = new System.Windows.Forms.CheckBox();
            this.chkFechaProm = new System.Windows.Forms.CheckBox();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtCerradoPor = new System.Windows.Forms.TextBox();
            this.txtFechaRealiz = new System.Windows.Forms.DateTimePicker();
            this.txtFechaProm = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.GroupDatos = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.GroupDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkFechaRealiz
            // 
            this.chkFechaRealiz.AutoSize = true;
            this.chkFechaRealiz.Location = new System.Drawing.Point(35, 43);
            this.chkFechaRealiz.Margin = new System.Windows.Forms.Padding(2);
            this.chkFechaRealiz.Name = "chkFechaRealiz";
            this.chkFechaRealiz.Size = new System.Drawing.Size(101, 17);
            this.chkFechaRealiz.TabIndex = 226;
            this.chkFechaRealiz.Text = "Fecha realizado";
            this.chkFechaRealiz.UseVisualStyleBackColor = true;
            this.chkFechaRealiz.CheckedChanged += new System.EventHandler(this.chkFechaRealiz_CheckedChanged);
            // 
            // chkFac
            // 
            this.chkFac.AutoSize = true;
            this.chkFac.Location = new System.Drawing.Point(35, 21);
            this.chkFac.Margin = new System.Windows.Forms.Padding(2);
            this.chkFac.Name = "chkFac";
            this.chkFac.Size = new System.Drawing.Size(62, 17);
            this.chkFac.TabIndex = 225;
            this.chkFac.Text = "Factura";
            this.chkFac.UseVisualStyleBackColor = true;
            this.chkFac.CheckedChanged += new System.EventHandler(this.chkFac_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 229;
            this.label1.Text = "Filtrar Estudios";
            // 
            // btnAyuda
            // 
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Location = new System.Drawing.Point(441, 5);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(2);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(56, 31);
            this.btnAyuda.TabIndex = 246;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(347, 229);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 30);
            this.button2.TabIndex = 248;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(100, 229);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 30);
            this.button1.TabIndex = 247;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkCerrado
            // 
            this.chkCerrado.AutoSize = true;
            this.chkCerrado.Location = new System.Drawing.Point(34, 86);
            this.chkCerrado.Margin = new System.Windows.Forms.Padding(2);
            this.chkCerrado.Name = "chkCerrado";
            this.chkCerrado.Size = new System.Drawing.Size(63, 17);
            this.chkCerrado.TabIndex = 254;
            this.chkCerrado.Text = "Cerrado";
            this.chkCerrado.UseVisualStyleBackColor = true;
            this.chkCerrado.CheckedChanged += new System.EventHandler(this.chkCerrado_CheckedChanged);
            // 
            // chkCerradoPor
            // 
            this.chkCerradoPor.AutoSize = true;
            this.chkCerradoPor.Location = new System.Drawing.Point(34, 108);
            this.chkCerradoPor.Margin = new System.Windows.Forms.Padding(2);
            this.chkCerradoPor.Name = "chkCerradoPor";
            this.chkCerradoPor.Size = new System.Drawing.Size(82, 17);
            this.chkCerradoPor.TabIndex = 255;
            this.chkCerradoPor.Text = "Cerrado Por";
            this.chkCerradoPor.UseVisualStyleBackColor = true;
            this.chkCerradoPor.CheckedChanged += new System.EventHandler(this.chkCerradoPor_CheckedChanged_1);
            // 
            // chkFechaProm
            // 
            this.chkFechaProm.AutoSize = true;
            this.chkFechaProm.Location = new System.Drawing.Point(35, 65);
            this.chkFechaProm.Margin = new System.Windows.Forms.Padding(2);
            this.chkFechaProm.Name = "chkFechaProm";
            this.chkFechaProm.Size = new System.Drawing.Size(105, 17);
            this.chkFechaProm.TabIndex = 256;
            this.chkFechaProm.Text = "Fecha prometido";
            this.chkFechaProm.UseVisualStyleBackColor = true;
            this.chkFechaProm.CheckedChanged += new System.EventHandler(this.chkFechaProm_CheckedChanged);
            // 
            // txtFactura
            // 
            this.txtFactura.Enabled = false;
            this.txtFactura.Location = new System.Drawing.Point(145, 18);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(145, 20);
            this.txtFactura.TabIndex = 257;
            // 
            // txtCerradoPor
            // 
            this.txtCerradoPor.Enabled = false;
            this.txtCerradoPor.Location = new System.Drawing.Point(144, 105);
            this.txtCerradoPor.Name = "txtCerradoPor";
            this.txtCerradoPor.Size = new System.Drawing.Size(167, 20);
            this.txtCerradoPor.TabIndex = 258;
            // 
            // txtFechaRealiz
            // 
            this.txtFechaRealiz.Enabled = false;
            this.txtFechaRealiz.Location = new System.Drawing.Point(145, 41);
            this.txtFechaRealiz.Name = "txtFechaRealiz";
            this.txtFechaRealiz.Size = new System.Drawing.Size(217, 20);
            this.txtFechaRealiz.TabIndex = 259;
            // 
            // txtFechaProm
            // 
            this.txtFechaProm.Enabled = false;
            this.txtFechaProm.Location = new System.Drawing.Point(145, 64);
            this.txtFechaProm.Name = "txtFechaProm";
            this.txtFechaProm.Size = new System.Drawing.Size(217, 20);
            this.txtFechaProm.TabIndex = 260;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 45);
            this.groupBox1.TabIndex = 261;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(32, 16);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(55, 17);
            this.radioButton6.TabIndex = 5;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Todos";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(416, 16);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(40, 17);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Oxi";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(337, 16);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(72, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Fotografia";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(270, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(60, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Modelo";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(153, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "est. Cefalometrico";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(95, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tomo";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // GroupDatos
            // 
            this.GroupDatos.Controls.Add(this.chkFac);
            this.GroupDatos.Controls.Add(this.chkFechaRealiz);
            this.GroupDatos.Controls.Add(this.txtFechaProm);
            this.GroupDatos.Controls.Add(this.chkCerrado);
            this.GroupDatos.Controls.Add(this.txtFechaRealiz);
            this.GroupDatos.Controls.Add(this.chkCerradoPor);
            this.GroupDatos.Controls.Add(this.txtCerradoPor);
            this.GroupDatos.Controls.Add(this.chkFechaProm);
            this.GroupDatos.Controls.Add(this.txtFactura);
            this.GroupDatos.Enabled = false;
            this.GroupDatos.Location = new System.Drawing.Point(16, 88);
            this.GroupDatos.Name = "GroupDatos";
            this.GroupDatos.Size = new System.Drawing.Size(481, 134);
            this.GroupDatos.TabIndex = 262;
            this.GroupDatos.TabStop = false;
            this.GroupDatos.Text = "Datos";
            // 
            // FrmFiltroEstudios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 269);
            this.Controls.Add(this.GroupDatos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFiltroEstudios";
            this.Text = "FrmFiltroEstudios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.GroupDatos.ResumeLayout(false);
            this.GroupDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkFechaRealiz;
        private System.Windows.Forms.CheckBox chkFac;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkCerrado;
        private System.Windows.Forms.CheckBox chkCerradoPor;
        private System.Windows.Forms.CheckBox chkFechaProm;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtCerradoPor;
        private System.Windows.Forms.DateTimePicker txtFechaRealiz;
        private System.Windows.Forms.DateTimePicker txtFechaProm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.GroupBox GroupDatos;
    }
}