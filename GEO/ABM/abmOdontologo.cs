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
    public partial class abmOdontologo : Form
    {
        List<String> listaDeDirecciones = new List<String>();
       
        private Odontologo odontologoEncontrado = null;

        public abmOdontologo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String telefono="";
            int celular=0;
            
            String ciudad="";
            String nombre="";
            String apellido="";
            String mail="";
            String Horario="";
            
            String mensaje = "Debe ingresar: ";

            
                telefono = txtTelefono.Text;
           if(telefono=="")
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

         
                ciudad = txtCiudad.Text;
            
            if(ciudad=="")
            {
                mensaje = mensaje + "Ciudad, ";
            }

           
                apellido = txtApellido.Text;
            if(apellido=="")
            {
                mensaje = mensaje + "Apellido, ";
            }

            
            nombre = txtNombre.Text;
            if(nombre=="")
            {
                mensaje = mensaje + "Nombre, ";
            }

            Horario = txtHora.Text;
            if (Horario == "")
            {
                mensaje = mensaje + "Horariol";
            }

            mail = txtMail.Text;
            if (mail == "")
            {
                mensaje = mensaje + "email, ";
            }

            if (listaDeDirecciones.Count == 0)
            {
                mensaje = mensaje + "direccion, ";
            }
            

            if (mensaje != "")
            {
                Odontologo nuevoOdonto=new Odontologo(0,listaDeDirecciones,Horario,mail,ciudad,nombre,apellido,telefono,celular,true);
                try
                {
                    Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(nuevoOdonto);

                    for (int i = 0; i < listaDeDirecciones.Count; i++)
                    {
                        Logica.FabricaLogica.getLogicaOdontologo().AgregarDireccion(nuevoOdonto, nuevoOdonto.Direcciones[i].ToString());

                    }

                        txtApellido.Text = "";
                    txtCelular.Text = "";
                    txtDireccion.Text = "";
                    txtHora.Text = "";
                    txtHora.Text = "";
                    txtCiudad.Text = "";
                    txtMail.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    
                    lblError.Text = "Odontologo agregado correctamente";
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                Logica.FabricaLogica.getLogicaOdontologo().EliminarOdontologo(odontologoEncontrado);

                txtApellido.Text = "";
                txtCelular.Text = "";
                txtDireccion.Text = "";
                txtHora.Text = "";
                txtCiudad.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";

                lblError.Text = "Odontologo eliminado correctamente";
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String telefono="";
            int celular=0;
            String direccion="";
            String ciudad="";
            String nombre="";
            String apellido="";
            String mail="";
            String Horario="";
            List<String> direcciones = new List<String>();
           
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

            
                direccion = txtDireccion.Text;
           if(direccion=="")
            {
                mensaje = mensaje + "Direccion, ";
            }

            ciudad = txtCiudad.Text;
            if (ciudad == "")
            {
                mensaje = mensaje + "Ciudad, ";
            }

            
                apellido = txtApellido.Text;
            if(apellido=="")
            {
                mensaje = mensaje + "Apellido, ";
            }

             nombre = txtNombre.Text;
            if(nombre=="")
            {
                mensaje = mensaje + "Nombre, ";
            }
            

            if (mensaje != "")
            {
                Odontologo nuevoOdonto = new Odontologo(0,direcciones, Horario, mail, ciudad,nombre, apellido, telefono, celular, true);
                try
                {
                    Logica.FabricaLogica.getLogicaOdontologo().ModificarOdontologo(nuevoOdonto);
                    txtApellido.Text = "";
                    txtCelular.Text = "";
                    txtDireccion.Text = "";
                    
                    txtHora.Text = "";
                    
                    txtMail.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";

                    lblError.Text = "Odontologo modificado correctamente";
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

        

        private void btnAddDir_Click(object sender, EventArgs e)
        {
            
            String direccionnueva="";
            try
            {
                direccionnueva = txtDireccion.Text;

                if (direccionnueva == "")
                {
                    lblError.Text = "No ha ingresado una direccion";
                }
                else 
                {


                    listaDeDirecciones.Add(direccionnueva);
                    crearlista();
                   

                   
                    txtDireccion.Text = "";
                }
            }
             catch(Exception es)
            {
                lblError.Text = "Error: " + es.Message;
            }
        }

        private void btnDeldir_Click(object sender, EventArgs e)
        {

            eliminarItem();
        }

        private void eliminarItem()
        {
            if (botonEtiquetaSeleccionado != "")
            {
                for (int i = 0; i < listaDeDirecciones.Count; i++)
                {
                    if (listaDeDirecciones[i] == botonEtiquetaSeleccionado)
                    {
                        listaDeDirecciones.Remove(listaDeDirecciones[i]);
                        crearlista();
                    }
                }
            }
        }
        private void crearlista()
        {
            flow.Controls.Clear();

            foreach(String dir in listaDeDirecciones)
            {
                Button btnEtiqueta = new Button();
                btnEtiqueta.FlatStyle = FlatStyle.Flat;
                btnEtiqueta.Text = dir;
                btnEtiqueta.Click += new EventHandler(btnEtiqueta_Click);
                btnEtiqueta.AutoSize = true;
                flow.Controls.Add(btnEtiqueta);
            }
        }

        String botonEtiquetaSeleccionado = "";
        private void btnEtiqueta_Click(object sender, EventArgs e)
        {
            botonEtiquetaSeleccionado = ((Button)sender).Text;
        }
       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
                String telefono = "";
                int celular = 0;

                String ciudad = "";
                String nombre = "";
                String apellido = "";
                String mail = "";
                String Horario = "";

                String mensaje = "Debe ingresar: ";


                telefono = txtTelefono.Text;


                try
                {
                    celular = Convert.ToInt32(txtCelular.Text);
                }
                catch
                {
                    mensaje=mensaje + "Celular, ";
                }
                ciudad = txtCiudad.Text;

                if (ciudad == "")
                {
                    mensaje = mensaje + "Ciudad, ";
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

                Horario = txtHora.Text;
                if (Horario == "")
                {
                    mensaje = mensaje + "Horario, ";
                }

                mail = txtMail.Text;
                if (mail == "")
                {
                    mensaje = mensaje + "email, ";
                }

                if (listaDeDirecciones.Count == 0)
                {
                    mensaje = mensaje + "direccion, ";
                }


                if (mensaje == "Debe ingresar: ")
                {
                    Odontologo nuevoOdonto = new Odontologo(0, listaDeDirecciones, Horario, mail, ciudad, nombre, apellido, telefono, celular, true);
                    try
                    {
                        Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(nuevoOdonto);

                        for (int i = 0; i < listaDeDirecciones.Count; i++)
                        {
                            Logica.FabricaLogica.getLogicaOdontologo().AgregarDireccion(nuevoOdonto, nuevoOdonto.Direcciones[i].ToString());

                        }

                            txtApellido.Text = "";
                            txtCelular.Text = "";
                            txtDireccion.Text = "";
                            txtHora.Text = "";
                            txtHora.Text = "";
                            txtCiudad.Text = "";
                            txtMail.Text = "";
                            txtNombre.Text = "";
                            txtTelefono.Text = "";
                            flow.Controls.Clear();

                            lblError.Text = "Odontologo agregado correctamente";
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

  

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            String telefono = "";
            int celular = 0;

            String ciudad = "";
            String nombre = "";
            String apellido = "";
            String mail = "";
            String Horario = "";

            String mensaje = "Debe ingresar: ";


            telefono = txtTelefono.Text;

            try
            {
                celular = Convert.ToInt32(txtCelular.Text);
            }
            catch { mensaje = mensaje + "Celular(numero), "; }

            ciudad = txtCiudad.Text;

            if (ciudad == "")
            {
                mensaje = mensaje + "Ciudad, ";
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

            Horario = txtHora.Text;
            if (Horario == "")
            {
                mensaje = mensaje + "Horariol";
            }

            mail = txtMail.Text;
            if (mail == "")
            {
                mensaje = mensaje + "email, ";
            }

            if (odontologoEncontrado.Direcciones.Count == 0)
            {
                mensaje = mensaje + "direccion, ";
            }


            if (mensaje == "Debe ingresar: ")
            {
                Odontologo nuevoOdonto = new Odontologo(odontologoEncontrado.Id, listaDeDirecciones, Horario, mail, ciudad, nombre, apellido, telefono, celular, true);
                try
                {
                    Logica.FabricaLogica.getLogicaOdontologo().ModificarOdontologo(nuevoOdonto);

                    for (int i = 0; i < listaDeDirecciones.Count; i++)
                    {
                        Logica.FabricaLogica.getLogicaOdontologo().AgregarDireccion(nuevoOdonto, nuevoOdonto.Direcciones[i].ToString());

                    }

                    txtApellido.Text = "";
                    txtCelular.Text = "";
                    txtDireccion.Text = "";
                    txtHora.Text = "";
                    txtHora.Text = "";
                    txtCiudad.Text = "";
                    txtMail.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    flow.Controls.Clear();

                    lblError.Text = "Odontologo modificado correctamente";
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
            try {

                GEO.Busqueda.FrmBusquedaOdontologo nuevaBusquedaOdo = new GEO.Busqueda.FrmBusquedaOdontologo();
                if (nuevaBusquedaOdo .ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeOdontologo = nuevaBusquedaOdo.ValorRetorno;

                    odontologoEncontrado = Logica.FabricaLogica.getLogicaOdontologo().BuscarOdontologoPorId(Convert.ToInt32(idDeOdontologo));

                    //muestro los datos encontrados
                    txtNombre.Text = odontologoEncontrado.Nombre;
                    txtApellido.Text = odontologoEncontrado.Apellido;
                    txtCelular.Text = odontologoEncontrado.Celular.ToString();
                    txtTelefono.Text = odontologoEncontrado.Telefono;
                    txtCiudad.Text = odontologoEncontrado.Ciudad;
                    txtMail.Text = odontologoEncontrado.Email;
                    txtHora.Text = odontologoEncontrado.Horario;

                    listaDeDirecciones = null;
                    listaDeDirecciones = odontologoEncontrado.Direcciones;
                    crearlista();
                    

                    lblError.Text = "si modifica datos guarde los cambios";

                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                }
            
            }
            catch (Exception es) { lblError.Text = es.Message; }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try {

                Logica.FabricaLogica.getLogicaOdontologo().EliminarOdontologo(odontologoEncontrado);

                txtApellido.Text = "";
                txtCelular.Text = "";
                txtDireccion.Text = "";
                txtHora.Text = "";
                txtHora.Text = "";
                txtCiudad.Text = "";
                txtMail.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = ""; 
                flow.Controls.Clear();

                lblError.Text = "Odontologo eliminado correctamente";
                
            }
            catch (Exception es) { lblError.Text = es.Message; }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Para agregar una direccion, escriba la direccion en el campo 'Direccion' y presione el boton agregar a la derecha del campo, para eliminar una direccion seleccione una direccion de la lista y presione el 'tacho de bazura' de la parte inferior");
        }






 
    }
}
