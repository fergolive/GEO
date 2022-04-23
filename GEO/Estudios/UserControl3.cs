using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;
using Logica;

namespace GEO.Estudios
{
    public partial class UserControl3 : UserControl
    {

        List<Odontologo> listaDeOdontologos = null;

        public UserControl3()
        {
            InitializeComponent();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                //buscar
                if (chkNombre.Checked)
                {

                    txtDatos.Enabled = true;


                    String nombre = txtDatos.Text;
                    if (nombre == "")
                    {
                        lblError.Text = "Debe ingresar el nombre";
                    }
                    else
                        listaDeOdontologos = FabricaLogica.getLogicaOdontologo().BuscarOdontologosPorNombre(nombre);
                }
                if (chkApellido.Checked)
                {


                    txtDatos.Enabled = true;

                    String apellido = txtDatos.Text;
                    if (apellido == "")
                    {
                        lblError.Text = "Debe ingresar el apellido";
                    }
                    else
                        listaDeOdontologos = FabricaLogica.getLogicaOdontologo().BuscarOdontologosPorApellido(apellido);

                }

                if (chkTelefono.Checked)
                {

                    txtDatos.Enabled = true;
                    int telefono = 0;
                    if (txtDatos.Text == "")
                    {
                        lblError.Text = "Debe ingresar el telefono";
                    }
                    else
                    {

                        try
                        {
                            telefono = Convert.ToInt32(txtDatos.Text);
                        }
                        catch
                        {
                            lblError.Text = "El telefono debe ser de tipo numerico";
                        }
                    }

                    listaDeOdontologos = FabricaLogica.getLogicaOdontologo().BuscarOdontologosPorTelefono(telefono);

                }

                if (chkCelular.Checked)
                {
                    txtDatos.Enabled = false;
                    int celular = 0;
                    if (txtDatos.Text == "")
                    {
                        lblError.Text = "Debe ingresar el celular";
                    }
                    else
                    {

                        try
                        {
                            celular = Convert.ToInt32(txtDatos.Text);
                        }
                        catch
                        {
                            lblError.Text = "El celular debe ser de tipo numerico";
                        }
                    }
                    listaDeOdontologos = FabricaLogica.getLogicaOdontologo().BuscarOdontologosPorCelular(celular);
                }


                if (listaDeOdontologos != null)
                {
                    gridResultado.DataSource = listaDeOdontologos;

                    gridResultado.Columns["Activo"].Visible = false;
                    gridResultado.Columns["Id"].Visible = false;
                    gridResultado.Columns["Cel"].Visible = false;
                    gridResultado.Columns["Horario"].Visible = false;
                    gridResultado.Columns["Email"].Visible = false;
                    gridResultado.Columns["Datos"].Visible = false;

                }
                else lblError.Text = "No se han encontrado odontologos";
            }
            catch(Exception es) {

                throw new Exception(es.Message);
            }
        }
        
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }


        private void chkNombre_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkNombre.Checked)
            {
                txtDatos.Enabled = true;
            }
            
        }

        private void chkApellido_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkApellido.Checked)
            {
                txtDatos.Enabled = true;
            }
           
        }


        public String SeleccionarPacienteDesdeGrid()
        {
            int indicefila = gridResultado.CurrentCell.RowIndex;
            String idseleccionado= gridResultado.Rows[indicefila].Cells["Id"].Value.ToString();
            return idseleccionado;
        }

        private void UserControl3_Load(object sender, EventArgs e)
        {
            txtDatos.Enabled = true;
        }

        private void chkTelefono_CheckedChanged(object sender, EventArgs e)
        {
            txtDatos.Enabled = false;
        }

        private void chkCelular_CheckedChanged(object sender, EventArgs e)
        {
            txtDatos.Enabled = false;
        }

        public String SeleccionarPacienteDesdeGrid2()
        {
            int indicefila = gridResultado.CurrentCell.RowIndex;
            String idseleccionado = gridResultado.Rows[indicefila].Cells["Id"].Value.ToString();
            return idseleccionado;


        }
    }
}
    

