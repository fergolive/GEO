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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        List<Empleado> listaDeEmpleado = null;

        
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
                        listaDeEmpleado = FabricaLogica.getLogicaEmpleado().BuscarEmpleadosPorNombre(nombre);
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
                        listaDeEmpleado = FabricaLogica.getLogicaEmpleado().BuscarEmpleadosPorApellido(apellido);

                }

                if (listaDeEmpleado != null)
                {
                    gridResultado.DataSource = listaDeEmpleado;
                    
                    gridResultado.Columns["Id"].Visible = false;
                    gridResultado.Columns["Cel"].Visible = false;
                    gridResultado.Columns["Tel"].Visible = false;
                    gridResultado.Columns["Nombre"].Visible = false;
                    gridResultado.Columns["Apellido"].Visible = false;
                    gridResultado.Columns["Username"].Visible = false;
                    gridResultado.Columns["Password"].Visible = false;
                    
                }
                else lblError.Text = "No se han encontrado odontologos";
            }
            catch (Exception es)
            {

                throw new Exception(es.Message);
            }
        }

        public String SeleccionarPacienteDesdeGrid()
        {
            int indicefila = gridResultado.CurrentCell.RowIndex;
            String idseleccionado = gridResultado.Rows[indicefila].Cells["Id"].Value.ToString();
            return idseleccionado;


        }
    }
}
