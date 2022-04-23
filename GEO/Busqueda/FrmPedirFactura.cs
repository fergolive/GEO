using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEO.Busqueda
{
    public partial class FrmPedirFactura : Form
    {
        public FrmPedirFactura()
        {
            InitializeComponent();
        }

        public string ValorRetorno { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            String fac = txtFactura.Text;
            ValorRetorno = fac;

            DialogResult = DialogResult.OK; //cierra el formulario
            this.Close();
        }
    }
}
