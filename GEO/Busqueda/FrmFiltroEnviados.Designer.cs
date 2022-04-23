namespace GEO.Busqueda
{
    partial class FrmFiltroEnviados
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
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.chkFac = new System.Windows.Forms.CheckBox();
            this.chkFecha = new System.Windows.Forms.CheckBox();
            this.chkdir = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chkEntregado = new System.Windows.Forms.CheckBox();
            this.txtEntregado = new System.Windows.Forms.TextBox();
            this.chkCerradaPor = new System.Windows.Forms.CheckBox();
            this.txtCerradaPor = new System.Windows.Forms.TextBox();
            this.chkClinica = new System.Windows.Forms.CheckBox();
            this.txtClinica = new System.Windows.Forms.TextBox();
            this.chkCerrada = new System.Windows.Forms.CheckBox();
            this.rbtCordon = new System.Windows.Forms.RadioButton();
            this.rbtPocitos = new System.Windows.Forms.RadioButton();
            this.rbtEnvia = new System.Windows.Forms.RadioButton();
            this.rbtnInt = new System.Windows.Forms.RadioButton();
            this.groupTipos = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.groupTipos.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtFecha
            // 
            this.dtFecha.Location = new System.Drawing.Point(135, 60);
            this.dtFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(229, 20);
            this.dtFecha.TabIndex = 217;
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(135, 37);
            this.txtFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(107, 20);
            this.txtFactura.TabIndex = 216;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(135, 83);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(229, 20);
            this.txtDireccion.TabIndex = 215;
            // 
            // chkFac
            // 
            this.chkFac.AutoSize = true;
            this.chkFac.Location = new System.Drawing.Point(20, 39);
            this.chkFac.Margin = new System.Windows.Forms.Padding(2);
            this.chkFac.Name = "chkFac";
            this.chkFac.Size = new System.Drawing.Size(62, 17);
            this.chkFac.TabIndex = 223;
            this.chkFac.Text = "Factura";
            this.chkFac.UseVisualStyleBackColor = true;
            this.chkFac.CheckedChanged += new System.EventHandler(this.chkFac_CheckedChanged);
            // 
            // chkFecha
            // 
            this.chkFecha.AutoSize = true;
            this.chkFecha.Location = new System.Drawing.Point(20, 61);
            this.chkFecha.Margin = new System.Windows.Forms.Padding(2);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(56, 17);
            this.chkFecha.TabIndex = 224;
            this.chkFecha.Text = "Fecha";
            this.chkFecha.UseVisualStyleBackColor = true;
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // chkdir
            // 
            this.chkdir.AutoSize = true;
            this.chkdir.Location = new System.Drawing.Point(20, 83);
            this.chkdir.Margin = new System.Windows.Forms.Padding(2);
            this.chkdir.Name = "chkdir";
            this.chkdir.Size = new System.Drawing.Size(115, 17);
            this.chkdir.TabIndex = 225;
            this.chkdir.Text = "Direccion de envio";
            this.chkdir.UseVisualStyleBackColor = true;
            this.chkdir.CheckedChanged += new System.EventHandler(this.chkdir_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(112, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 228;
            this.label1.Text = "Filtrar Carpetas";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(20, 262);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 30);
            this.button1.TabIndex = 229;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(302, 262);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 30);
            this.button2.TabIndex = 230;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkEntregado
            // 
            this.chkEntregado.AutoSize = true;
            this.chkEntregado.Location = new System.Drawing.Point(20, 106);
            this.chkEntregado.Margin = new System.Windows.Forms.Padding(2);
            this.chkEntregado.Name = "chkEntregado";
            this.chkEntregado.Size = new System.Drawing.Size(85, 17);
            this.chkEntregado.TabIndex = 233;
            this.chkEntregado.Text = "Entregado A";
            this.chkEntregado.UseVisualStyleBackColor = true;
            this.chkEntregado.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtEntregado
            // 
            this.txtEntregado.Location = new System.Drawing.Point(135, 106);
            this.txtEntregado.Margin = new System.Windows.Forms.Padding(2);
            this.txtEntregado.Name = "txtEntregado";
            this.txtEntregado.Size = new System.Drawing.Size(229, 20);
            this.txtEntregado.TabIndex = 232;
            // 
            // chkCerradaPor
            // 
            this.chkCerradaPor.AutoSize = true;
            this.chkCerradaPor.Location = new System.Drawing.Point(20, 128);
            this.chkCerradaPor.Margin = new System.Windows.Forms.Padding(2);
            this.chkCerradaPor.Name = "chkCerradaPor";
            this.chkCerradaPor.Size = new System.Drawing.Size(82, 17);
            this.chkCerradaPor.TabIndex = 235;
            this.chkCerradaPor.Text = "Cerrada Por";
            this.chkCerradaPor.UseVisualStyleBackColor = true;
            this.chkCerradaPor.CheckedChanged += new System.EventHandler(this.chkCerradaPor_CheckedChanged);
            // 
            // txtCerradaPor
            // 
            this.txtCerradaPor.Location = new System.Drawing.Point(135, 128);
            this.txtCerradaPor.Margin = new System.Windows.Forms.Padding(2);
            this.txtCerradaPor.Name = "txtCerradaPor";
            this.txtCerradaPor.Size = new System.Drawing.Size(229, 20);
            this.txtCerradaPor.TabIndex = 234;
            // 
            // chkClinica
            // 
            this.chkClinica.AutoSize = true;
            this.chkClinica.Location = new System.Drawing.Point(20, 151);
            this.chkClinica.Margin = new System.Windows.Forms.Padding(2);
            this.chkClinica.Name = "chkClinica";
            this.chkClinica.Size = new System.Drawing.Size(57, 17);
            this.chkClinica.TabIndex = 237;
            this.chkClinica.Text = "Clinica";
            this.chkClinica.UseVisualStyleBackColor = true;
            this.chkClinica.CheckedChanged += new System.EventHandler(this.chkClinica_CheckedChanged);
            // 
            // txtClinica
            // 
            this.txtClinica.Location = new System.Drawing.Point(135, 151);
            this.txtClinica.Margin = new System.Windows.Forms.Padding(2);
            this.txtClinica.Name = "txtClinica";
            this.txtClinica.Size = new System.Drawing.Size(144, 20);
            this.txtClinica.TabIndex = 236;
            // 
            // chkCerrada
            // 
            this.chkCerrada.AutoSize = true;
            this.chkCerrada.Location = new System.Drawing.Point(20, 232);
            this.chkCerrada.Margin = new System.Windows.Forms.Padding(2);
            this.chkCerrada.Name = "chkCerrada";
            this.chkCerrada.Size = new System.Drawing.Size(73, 17);
            this.chkCerrada.TabIndex = 238;
            this.chkCerrada.Text = "Finalizada";
            this.chkCerrada.UseVisualStyleBackColor = true;
            this.chkCerrada.CheckedChanged += new System.EventHandler(this.chkCerrada_CheckedChanged);
            // 
            // rbtCordon
            // 
            this.rbtCordon.AutoSize = true;
            this.rbtCordon.Location = new System.Drawing.Point(5, 10);
            this.rbtCordon.Name = "rbtCordon";
            this.rbtCordon.Size = new System.Drawing.Size(90, 17);
            this.rbtCordon.TabIndex = 0;
            this.rbtCordon.TabStop = true;
            this.rbtCordon.Text = "Retira Cordon";
            this.rbtCordon.UseVisualStyleBackColor = true;
            this.rbtCordon.CheckedChanged += new System.EventHandler(this.rbtCordon_CheckedChanged);
            // 
            // rbtPocitos
            // 
            this.rbtPocitos.AutoSize = true;
            this.rbtPocitos.Location = new System.Drawing.Point(113, 11);
            this.rbtPocitos.Name = "rbtPocitos";
            this.rbtPocitos.Size = new System.Drawing.Size(91, 17);
            this.rbtPocitos.TabIndex = 1;
            this.rbtPocitos.TabStop = true;
            this.rbtPocitos.Text = "Retira Pocitos";
            this.rbtPocitos.UseVisualStyleBackColor = true;
            this.rbtPocitos.CheckedChanged += new System.EventHandler(this.rbtPocitos_CheckedChanged);
            // 
            // rbtEnvia
            // 
            this.rbtEnvia.AutoSize = true;
            this.rbtEnvia.Location = new System.Drawing.Point(220, 11);
            this.rbtEnvia.Name = "rbtEnvia";
            this.rbtEnvia.Size = new System.Drawing.Size(52, 17);
            this.rbtEnvia.TabIndex = 158;
            this.rbtEnvia.TabStop = true;
            this.rbtEnvia.Text = "Envia";
            this.rbtEnvia.UseVisualStyleBackColor = true;
            this.rbtEnvia.CheckedChanged += new System.EventHandler(this.rbtEnvia_CheckedChanged);
            // 
            // rbtnInt
            // 
            this.rbtnInt.AutoSize = true;
            this.rbtnInt.Location = new System.Drawing.Point(284, 11);
            this.rbtnInt.Name = "rbtnInt";
            this.rbtnInt.Size = new System.Drawing.Size(57, 17);
            this.rbtnInt.TabIndex = 159;
            this.rbtnInt.TabStop = true;
            this.rbtnInt.Text = "Interior";
            this.rbtnInt.UseVisualStyleBackColor = true;
            this.rbtnInt.CheckedChanged += new System.EventHandler(this.rbtnInt_CheckedChanged);
            // 
            // groupTipos
            // 
            this.groupTipos.Controls.Add(this.rbtnInt);
            this.groupTipos.Controls.Add(this.rbtEnvia);
            this.groupTipos.Controls.Add(this.rbtPocitos);
            this.groupTipos.Controls.Add(this.rbtCordon);
            this.groupTipos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.groupTipos.Location = new System.Drawing.Point(18, 192);
            this.groupTipos.Name = "groupTipos";
            this.groupTipos.Size = new System.Drawing.Size(345, 32);
            this.groupTipos.TabIndex = 241;
            this.groupTipos.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(20, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 244;
            this.label4.Text = "tipo de carpeta";
            // 
            // btnAyuda
            // 
            this.btnAyuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyuda.Location = new System.Drawing.Point(315, 2);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(2);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(56, 31);
            this.btnAyuda.TabIndex = 245;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // FrmFiltroEnviados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 305);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupTipos);
            this.Controls.Add(this.chkCerrada);
            this.Controls.Add(this.chkClinica);
            this.Controls.Add(this.txtClinica);
            this.Controls.Add(this.chkCerradaPor);
            this.Controls.Add(this.txtCerradaPor);
            this.Controls.Add(this.chkEntregado);
            this.Controls.Add(this.txtEntregado);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkdir);
            this.Controls.Add(this.chkFecha);
            this.Controls.Add(this.chkFac);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.txtFactura);
            this.Controls.Add(this.txtDireccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmFiltroEnviados";
            this.Load += new System.EventHandler(this.FrmFiltroEnviados_Load);
            this.groupTipos.ResumeLayout(false);
            this.groupTipos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.CheckBox chkFac;
        private System.Windows.Forms.CheckBox chkFecha;
        private System.Windows.Forms.CheckBox chkdir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkEntregado;
        private System.Windows.Forms.TextBox txtEntregado;
        private System.Windows.Forms.CheckBox chkCerradaPor;
        private System.Windows.Forms.TextBox txtCerradaPor;
        private System.Windows.Forms.CheckBox chkClinica;
        private System.Windows.Forms.TextBox txtClinica;
        private System.Windows.Forms.CheckBox chkCerrada;
        private System.Windows.Forms.RadioButton rbtCordon;
        private System.Windows.Forms.RadioButton rbtPocitos;
        private System.Windows.Forms.RadioButton rbtEnvia;
        private System.Windows.Forms.RadioButton rbtnInt;
        private System.Windows.Forms.GroupBox groupTipos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAyuda;
    }
}