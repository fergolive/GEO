using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;
using EntidadesCompartidas;

namespace GEO.Estudios
{
    public partial class UserControl2 : UserControl
    {
        

        public UserControl2()
        {
            InitializeComponent();
        }
        List<Paciente> listaDePacientes = null;

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            //buscar
            if (chkNombre.Checked)
            {
                //deshabilito apellido y fecha
                txtApellido.Enabled = false;
                dtfechas.Enabled = false;
                txtApellido.Enabled = true;

                String nombre = txtNombre.Text;
                if (nombre == "")
                {
                    lblError.Text = "Debe ingresar el nombre";
                }
                else
                listaDePacientes= FabricaLogica.getLogicaPaciente().BuscarPacientesPorNombre(nombre);
            }
            if (chkApellido.Checked)
            {
               //deshabilito nombre y fecha
                txtNombre.Enabled = false;
                dtfechas.Enabled = false;
                txtApellido.Enabled = true;

                String apellido = txtApellido.Text;
                if (apellido == "")
                {
                    lblError.Text = "Debe ingresar el apellido";
                }
                else
                    listaDePacientes = FabricaLogica.getLogicaPaciente().BuscarPacientesPorApellido(apellido);
            
            }

            if (chkFecha.Checked)
            {
                //deshabilito apellido y nombre
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                dtfechas.Enabled = true;

                DateTime fecha = dtfechas.Value; //no controlo la fecha porque siempre tiene una seleccionada
                listaDePacientes = FabricaLogica.getLogicaPaciente().BuscarPacientesPorFecha(fecha);
            
            }

            if (listaDePacientes != null)
            {
                gridResultado.DataSource = listaDePacientes;

                gridResultado.Columns["Activo"].Visible = false;
                gridResultado.Columns["Id"].Visible = false;
                gridResultado.Columns["Telefono"].Visible = false;
                gridResultado.Columns["Datos"].Visible = false;
                gridResultado.Columns["Celular"].Visible = false;
            }
            else lblError.Text = "No se han encontrado pacientes";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            txtApellido.Enabled = false;
            txtNombre.Enabled = false;
            dtfechas.Enabled = false;
        }

        

        
        

        private void chkNombre_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkNombre.Checked)
            {
                txtNombre.Enabled = true;
            }
            else
            {
                txtNombre.Enabled = false;
            }
        }

        private void chkApellido_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkApellido.Checked)
            {
                txtApellido.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
            }
        }

        private void chkFecha_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkFecha.Checked)
            {
                dtfechas.Enabled = true;
            }
            else
            {
                dtfechas.Enabled = false;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        public String SeleccionarPacienteDesdeGrid()
        {
            int indicefila = gridResultado.CurrentCell.RowIndex;
            String idseleccionado= gridResultado.Rows[indicefila].Cells["Id"].Value.ToString();
            return idseleccionado;

            
        }
    }
}
