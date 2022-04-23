using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;



namespace OriTrabajos.ABM
{
    public partial class abmPaciente : Form
    {
        Paciente pacienteEncontrado = null;
        public abmPaciente()
        {
            InitializeComponent();
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            String telefono = "";
            int celular = 0;
            String nombre = "";
            String apellido = "";
            DateTime fechaDeNac = DateTime.Now;

            String mensaje = "Debe ingresar: ";

            fechaDeNac = dtfechas.Value;

            telefono = txtTelefono.Text;

            if (telefono == "")
            {
                mensaje = mensaje + "Telefono, ";
            }

            try
            {
                celular = Convert.ToInt32(txtCelular.Text);
            }
            catch
            {
                mensaje = mensaje + "Celular, ";
            }


            apellido = txtApellido.Text;
            if (apellido == "")
            {
                mensaje = mensaje + "Apellido, ";
            }

            nombre = txtNombre.Text;
            if (nombre == "")
            {
                mensaje = mensaje + "Nombre, ";
            }


            if (mensaje != "")
            {
                Paciente nuevoPac = new Paciente(0, fechaDeNac, nombre, apellido, telefono, celular, true);
                try
                {
                    Logica.FabricaLogica.getLogicaPaciente().AgregarPaciente(nuevoPac);
                    txtApellido.Text = "";
                    txtCelular.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";

                    MessageBox.Show("Paciente agregado correctamente");
                    lblError.Text = "Paciente agregado correctamente";
                }
                catch (Exception es)
                {
                    MessageBox.Show("No se ha podido ingresar el paciente!! \n intente nuevamente");
                    lblError.Text = es.Message;
                }
            }
            else
            {
                lblError.Text = mensaje;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try {

                GEO.Busqueda.frmBusquedaPaciente nuevaBusquedaPac = new GEO.Busqueda.frmBusquedaPaciente();
                if (nuevaBusquedaPac.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDePaciente = nuevaBusquedaPac.ValorRetorno;

                    pacienteEncontrado = Logica.FabricaLogica.getLogicaPaciente().BuscarPacientePorId(Convert.ToInt32(idDePaciente));

                    //muestro los datos encontrados
                    txtNombre.Text = pacienteEncontrado.Nombre;
                    txtApellido.Text = pacienteEncontrado.Apellido;
                    txtCelular.Text = pacienteEncontrado.Celular.ToString();
                    txtTelefono.Text = pacienteEncontrado.Telefono;

                    lblError.Text = "si modificaa datos guarde los cambios";

                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }

            
            }
            catch (Exception es) { lblError.Text = es.Message;
            MessageBox.Show("No se pudo realizar la busqueda");
            }
        }

        private void abmPaciente_Load(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String telefono = "";
            int celular = 0;
            String nombre = "";
            String apellido = "";
            DateTime fechaDeNac = DateTime.Now;

            String mensaje = "Debe ingresar: ";

            fechaDeNac = dtfechas.Value;

            telefono = txtTelefono.Text;

            if (telefono == "")
            {
                mensaje = mensaje + "Telefono, ";
            }

            try
            {
                celular = Convert.ToInt32(txtCelular.Text);
            }
            catch
            {
                mensaje = mensaje + "Celular, ";
            }


            apellido = txtApellido.Text;
            if (apellido == "")
            {
                mensaje = mensaje + "Apellido, ";
            }

            nombre = txtNombre.Text;
            if (nombre == "")
            {
                mensaje = mensaje + "Nombre, ";
            }


            if (mensaje != "")
            {
                Paciente PacModificado = new Paciente(pacienteEncontrado.Id, fechaDeNac, nombre, apellido, telefono, celular, true);
                try
                {
                    Logica.FabricaLogica.getLogicaPaciente().ModificarPaciente(PacModificado);
                    txtApellido.Text = "";
                    txtCelular.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";

                    MessageBox.Show("Paciente modificado correctamente");
                    lblError.Text = "Paciente modificado correctamente";
                }
                catch (Exception es)
                {
                    MessageBox.Show("No se ha podido modificar el paciente!! \n intente nuevamente");
                    lblError.Text = es.Message;
                }
            }
            else
            {
                lblError.Text = mensaje;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try { 
                
             GEO.PreguntaConfirmacion formPregunta = new  GEO.PreguntaConfirmacion("Seguro que desea eliminar al paciente: \n"+pacienteEncontrado.Nombre + " "+pacienteEncontrado.Apellido);
             if (formPregunta.ShowDialog() == DialogResult.OK)
             {

                 Logica.FabricaLogica.getLogicaPaciente().EliminarPaciente(pacienteEncontrado);
                 BorrarDatos();
                 lblError.Text = "Paciente "+ pacienteEncontrado.Nombre+" "+pacienteEncontrado.Apellido+" \n se elimino correctamente";
             }
                
            
            }
            catch (Exception es) { lblError.Text = es.Message; MessageBox.Show("No fue posible eliminar al paciente"); }
        }

        private void BorrarDatos()
        {
            txtApellido.Text = "";
            txtCelular.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }


       
    }
}
