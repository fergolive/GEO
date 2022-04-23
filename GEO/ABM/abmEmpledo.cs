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
    public partial class abmEmpledo : Form
    {
       
        Empleado empEncontrado = null;

        public abmEmpledo()
        {
            InitializeComponent();
            btnModificar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            String telefono = "";
            int celular = 0;
            String contraseña = "";
            String usuario = "";
            String apellido = "";
            String nombre = "";
            String mensaje = "Debe ingresar: ";


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

            String tipo = "";

            if (rbdCont.Checked)
            {
                tipo = "c";
            }
            if (rbdOdontologo.Checked)
            {
                tipo = "d";
            }
            if (rbdProduccion.Checked)
            {
                tipo = "p";
            }
            if (rbdRecep.Checked)
            {
                tipo = "r";
            }
            if (rbdTomos.Checked)
            {
                tipo = "t";
            }
            if (rbdAdmin.Checked)
            {
                tipo = "a";
            }

            if (tipo == "")
            {
                mensaje = mensaje + "Sector";
            }

            contraseña = txtContraseña.Text;
            if (contraseña == "")
            {

                mensaje = mensaje + "Contraseña, ";
            }


            usuario = txtUsuario.Text;
            if (usuario == "")
            {
                mensaje = mensaje + "Usuario, ";
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
                Empleado nuevoEmp = new Empleado(0, usuario, contraseña, nombre, apellido, telefono, celular, tipo, true);
                try
                {
                    Logica.FabricaLogica.getLogicaEmpleado().AgregarEmpleado(nuevoEmp);

                    txtTelefono.Text = "";
                    txtCelular.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    lblError.Text = "Empleado agregardo correctamente";
                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }
            }
            else
            {
                lblError.Text = mensaje;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            try
            {
                Logica.FabricaLogica.getLogicaEmpleado().EliminarEmpleado(empEncontrado);

                txtApellido.Text = "";
                txtCelular.Text = "";
                txtContraseña.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtUsuario.Text = "";

                lblError.Text = "Empleado eliminado correctamente";
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String telefono = "";
            int celular = 0;
            String contraseña = "";
            String usuario = "";
            String apellido = "";
            String nombre = "";
            String mensaje = "Debe ingresar: ";
            String tipo = "";

            telefono = (String)txtTelefono.Text;
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

            try
            {
                contraseña = txtContraseña.Text;
            }
            catch
            {
                mensaje = mensaje + "Contraseña, ";
            }

            try
            {
                usuario = txtUsuario.Text;
            }
            catch
            {
                mensaje = mensaje + "Usuario, ";
            }

            try
            {
                apellido = txtApellido.Text;
            }
            catch
            {
                mensaje = mensaje + "Apellido, ";
            }

            try
            {
                nombre = txtNombre.Text;
            }
            catch
            {
                mensaje = mensaje + "Nombre, ";
            }



            if (rbdCont.Checked)
            {
                tipo = "c";
            }
            if (rbdOdontologo.Checked)
            {
                tipo = "d";
            }
            if (rbdProduccion.Checked)
            {
                tipo = "p";
            }
            if (rbdRecep.Checked)
            {
                tipo = "r";
            }
            if (rbdTomos.Checked)
            {
                tipo = "t";
            }
            if (tipo == "")
            {
                mensaje = mensaje + "Tipo, ";
            }

            if (mensaje != "")
            {
                Empleado nuevoEmp = new Empleado(0, usuario, contraseña, nombre, apellido, telefono, celular, tipo, true);
                try
                {
                    Logica.FabricaLogica.getLogicaEmpleado().ModificarEmpleado(nuevoEmp);
                    txtTelefono.Text = "";
                    txtCelular.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    lblError.Text = "Empleado modificado correctamente";
                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }
            }
            else
            {
                lblError.Text = mensaje;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeEmpleado = form.ValorRetorno;

                    Empleado EmpleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));


                    if(EmpleadoEncontrado!=null) 
                    {

                        empEncontrado = EmpleadoEncontrado;
                    //mostrar datos
                        txtNombre.Text = EmpleadoEncontrado.Nombre;
                        txtApellido.Text = EmpleadoEncontrado.Apellido;
                        txtCelular.Text = Convert.ToString(EmpleadoEncontrado.Celular);
                        txtContraseña.Text = EmpleadoEncontrado.Password;
                        txtTelefono.Text = EmpleadoEncontrado.Telefono;
                        txtUsuario.Text = EmpleadoEncontrado.Username;
                        btnModificar.Enabled = true;
                        btnEliminar.Enabled = true;

                        if (EmpleadoEncontrado.Tipo == "d")
                        {
                            rbdOdontologo.Checked = true;
                        }

                        if (EmpleadoEncontrado.Tipo == "t")
                        {
                            rbdTomos.Checked = true;
                        }

                        if (EmpleadoEncontrado.Tipo == "r")
                        {
                            rbdRecep.Checked=true;
                        }

                        if (EmpleadoEncontrado.Tipo == "p")
                        {
                            rbdProduccion.Checked = true;
                        }

                        if (EmpleadoEncontrado.Tipo == "c")
                        {
                            rbdCont.Checked = true;
                        }

                        if (EmpleadoEncontrado.Tipo == "a")
                        {
                            rbdAdmin.Checked = true;
                        }
                    }

                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
        
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {

            String telefono = "";
            int celular = 0;
            String contraseña = "";
            String usuario = "";
            String apellido = "";
            String nombre = "";
            String mensaje = "Debe ingresar: ";


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

            String tipo = "";

            if (rbdCont.Checked)
            {
                tipo = "c";
            }
            if (rbdOdontologo.Checked)
            {
                tipo = "d";
            }
            if (rbdProduccion.Checked)
            {
                tipo = "p";
            }
            if (rbdRecep.Checked)
            {
                tipo = "r";
            }
            if (rbdTomos.Checked)
            {
                tipo = "t";
            }
            if (rbdAdmin.Checked)
            {
                tipo = "a";
            }

            if (tipo == "")
            {
                mensaje = mensaje + "Sector";
            }

            contraseña = txtContraseña.Text;
            if (contraseña == "")
            {

                mensaje = mensaje + "Contraseña, ";
            }


            usuario = txtUsuario.Text;
            if (usuario == "")
            {
                mensaje = mensaje + "Usuario, ";
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
                Empleado nuevoEmp = new Empleado(empEncontrado.Id, usuario, contraseña, nombre, apellido, telefono, celular, tipo, true);
                try
                {
                    Logica.FabricaLogica.getLogicaEmpleado().ModificarEmpleado(nuevoEmp);

                    txtTelefono.Text = "";
                    txtCelular.Text = "";
                    txtContraseña.Text = "";
                    txtUsuario.Text = "";
                    txtApellido.Text = "";
                    txtNombre.Text = "";
                    lblError.Text = "Empleado modificado correctamente";
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }
            }
            else
            {
                lblError.Text = mensaje;
            }
        }

        private void abmEmpledo_Load(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
        }

    

       
        
    }
}
