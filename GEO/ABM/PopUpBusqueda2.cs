using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEO.ABM
{
    public partial class UserControlBusquedaPac : Form
    {
        public UserControlBusquedaPac()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /////String id = UserControlBusquedaOdo.SeleccionarPacienteDesdeGrid2();
            //ValorRetorno = id;

            DialogResult = DialogResult.OK; //cierra el formulario
            this.Close();

            //MessageBox.Show(id);
            /* escribir una logica de negocios aqui*/
            //ValorRetorno = textBox1.Text; //Actualiza la propiedad
            
        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

    
    }
}
