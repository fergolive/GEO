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
    public partial class busquedaOdontologo : Form
    {
        public busquedaOdontologo()
        {
            InitializeComponent();
        }
        public string ValorRetorno { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            String id = userControlO.SeleccionarPacienteDesdeGrid();
            ValorRetorno = id;

            DialogResult = DialogResult.OK; //cierra el formulario
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
