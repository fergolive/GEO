using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

using Logica;



namespace OriTrabajos.ABM
{
    public partial class abmCarpeta : Form
    {
        Empleado empleadoLogueado = null;
        Paciente pacienteSelec=null;
        Odontologo odontologoSelec=null;
        
        //FabricaPersistencia fp = new FabricaPersistencia();
        Carpeta carpetaEncontrada = null;
        
        

        public abmCarpeta(Empleado empleadolog)
        {
            InitializeComponent();
            empleadoLogueado = empleadolog;
 
        }

        private void abmCarpeta_Load(object sender, EventArgs e)
        {
            try
            {
             

                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
                btnBusquedaOdontologo.Enabled = false;
                btnBusquedaPaciente.Enabled = false;

                this.Text = "ABM Carpeta" + " " + "Loguedo como: " + empleadoLogueado.Apellido.ToString() + empleadoLogueado.Nombre.ToString();

                groupOdontologo.Enabled = false;
            
                
                txtdireccion.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtdireccion.AutoCompleteSource = AutoCompleteSource.CustomSource;

                             
                cmbClinica.Items.Add("Pocitos");
                cmbClinica.Items.Add("Cordon");
               
           
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        public AutoCompleteStringCollection Autocomplete() //direcciones de Odontologos
        {

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (String dir in odontologoSelec.Direcciones)
            {
                coleccion.Add(dir);
            }

            return coleccion;
        }

  
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                FabricaLogica.getLogicaCarpeta().EliminarCarpeta(carpetaEncontrada);
                

                //groupTipos.Controls.Clear();
                
                cmbClinica.SelectedItem = carpetaEncontrada.Clinica.ToString();
                txtObservaciones.Text = "";
                chkCerrada.Checked = false;
                
                groupEntregada.Controls.Clear();
                txtEntregadaOtro.Text = "";
               
                txtdireccion.Text = "";

            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txtEntregadaOtro.Enabled = true;
            txtEntregadaOtro.Text = "Escriba aqui";
        }

        private void txtEntregadaOtro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEntregadaOtro_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtEntregadaOtro.Text == "escriba aqui")
            {
                txtEntregadaOtro.Text = "";
            }
        }

        private void txtchequeadaPor_TextChanged(object sender, EventArgs e)
        {
            if (txtEntregadaOtro.Text == "escriba aqui")
            {
                txtEntregadaOtro.Text = "";
            }
        }


        private void reiniciarControles()
        {
            dtFechaPrometida.Value = DateTime.Now;
            dtfechaRealizado.Value = DateTime.Now;
            rbtCordon.Checked = false;
            rbtEnvia.Checked = false;
            rbtPocitos.Checked = false;
            cmbClinica.Text = "Clinica";
           
            rbtRecepcion.Checked = false;
            rbtOtro.Checked = false;
            txtEntregadaOtro.Enabled = false;
            txtEntregadaOtro.Text = "";
            groupOdontologo.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }

        

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            txtEntregadaOtro.Enabled = true;

            if (rbtOtro.Checked == true)
            {
                chkCerrada.Checked = true;
            }
            else
            {
                chkCerrada.Checked = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txtEntregadaOtro.Enabled = false;

            if (rbtArea.Checked == true)
            {
                chkCerrada.Checked = true;
            }
            else
            {
                chkCerrada.Checked = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txtEntregadaOtro.Enabled = false;

            if(rbtRecepcion.Checked==true)
            {
                chkCerrada.Checked = true;
            }   
            else
            {
                chkCerrada.Checked=false;
            }
        }
   
        private void Envia_CheckedChanged(object sender, EventArgs e)
        {
            groupOdontologo.Enabled = true;
       

            
        }

        private void btnCambiarDir_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtOdontologo.Text == ""))
                {
                    lblError.Text = "Debe seleccionar un Odotologo";
                }
                else if (txtNuevaDir.Text == "")
                {
                    lblError.Text = "Debe introducir una nueva direccion";
                }
                else if(txtNuevaDir.Text.Length>40)
                {
                    lblError.Text = "direccion muy larga";
                }
                else
                {
                   
                            //obtengo nueva direccion
                            String direccion = txtNuevaDir.Text;
     
                            //agrego la direccion a la BD
                            Logica.FabricaLogica.getLogicaOdontologo().AgregarDireccion(odontologoSelec, direccion);

                            //agrego la dir al odontologo seleccionado
                            
                            odontologoSelec.Direcciones.Add(txtNuevaDir.Text);

                            //muestro mensaje de que se agrego correctamente la direccion
                            lblError.Text = "Direccion agregada correctamente";

                    
                            txtdireccion.Text = txtNuevaDir.Text;
                            txtNuevaDir.Text = "";

                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }


        private void rbtnInt_CheckedChanged(object sender, EventArgs e)
        { 
            groupOdontologo.Enabled = true;
   
        }

      

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                String factura = "";
                factura = txtFac.Text;
                if (factura == "")
                {
                    lblError.Text = "Debe ingresar el numero de factura";
                    reiniciarControles();
                }
                else
                {
                    carpetaEncontrada = FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);


                    if (carpetaEncontrada == null)
                    {
                        lblError.Text = "No existe la carpeta, puede ingresar una";
                        reiniciarControles();
                        BorrarDatos();
                        btnAgregar.Enabled = true;
                        btnBusquedaPaciente.Enabled = true;
                        btnBusquedaOdontologo.Enabled = true;
                    }
                    else
                    {
                        //Muestro los datos de la carpeta encontrada
                        btnAgregar.Enabled = false;
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;
                        btnBusquedaPaciente.Enabled = true;

                        btnBusquedaOdontologo.Enabled = true;

                        //Tipo
                        if (carpetaEncontrada.Tipo == "Retira Cordon")
                        {
                            rbtCordon.Checked = true;
                        }
                        else if (carpetaEncontrada.Tipo == "Retira Pocitos")
                        {
                            rbtPocitos.Checked = true;
                        }
                        else if (carpetaEncontrada.Tipo == "Envia")
                        {
                            rbtEnvia.Checked = true;
                            txtdireccion.Text = carpetaEncontrada.DireccionDeEnvio.ToString();
                        }
                        else if (carpetaEncontrada.Tipo == "Interior")
                        {
                            rbtnInt.Checked = true;
                            txtdireccion.Text = carpetaEncontrada.DireccionDeEnvio.ToString();

                        }

                        //fecha prom
                        dtFechaPrometida.Value = Convert.ToDateTime(carpetaEncontrada.FechaPrometida);
                        dtfechaRealizado.Value = Convert.ToDateTime(carpetaEncontrada.FechaRealizada);

                        //clinica
                        cmbClinica.Text = carpetaEncontrada.Clinica.ToString();

                        //observaciones
                        txtObservaciones.Text = carpetaEncontrada.Observaciones.ToString();

                        //entregada a..
                        if (carpetaEncontrada.EntregadaA == "Recepcion")
                        {
                            rbtRecepcion.Checked = true;
                        }
                        else if (carpetaEncontrada.EntregadaA == "Area")
                        {
                            rbtArea.Checked = true;
                        }
                        else
                        {
                            rbtOtro.Checked = true;
                            txtEntregadaOtro.Text = carpetaEncontrada.EntregadaA.ToString();
                        }

                        //mostrar Odontologo

                        txtOdontologo.Text = carpetaEncontrada.Odontologo.Datos;

                        txtPaciente.Text = carpetaEncontrada.Paciente.Datos;

                        lblError.Text = "Paciente encontrado: " + carpetaEncontrada.Paciente.Nombre.ToString();
                        lblError.Text += ", fecha de nac: " + carpetaEncontrada.Paciente.FechaDeNac.ToString();
                    }

                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void BorrarDatos()
        {
            
            btnAgregar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;

            dtFechaPrometida.Value = DateTime.Now;
            dtfechaRealizado.Value = DateTime.Now;

            rbtCordon.Checked = false;
            rbtPocitos.Checked = false;
            rbtEnvia.Checked = false;
            rbtnInt.Checked = false;

            cmbClinica.SelectedValue = "Clinica";
            txtObservaciones.Text = "";

            rbtRecepcion.Checked = false;
            rbtArea.Checked = false;
            rbtOtro.Checked = false;

            txtEntregadaOtro.Text = "";

            groupOdontologo.Enabled = false;
            txtdireccion.Text = "";
            txtNuevaDir.Text = "";

           
            txtOdontologo.Text = "Busque un odontologo haciendo click en la lupa";
            txtOdontologo.ForeColor = System.Drawing.Color.DarkTurquoise;
            txtPaciente.Text = "Busque un paciente haciendo click en la lupa";
            txtPaciente.ForeColor = System.Drawing.Color.DarkTurquoise;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //agregar
        {
            String factura = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            String clinica = "";
            String Obs = "";
            bool cerrada = false;
            Empleado cerradaPor =null;
            String entregadaA = "";
            String direccionDeEnvio = "";
            String mensaje = "Debe ingresar: ";

            factura = txtFac.Text;

            if (factura == "")
            {
                mensaje = mensaje + "factura, ";
            }

            bool unoChequeado = false;
            foreach (Control control in groupTipos.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        unoChequeado = true;
                        tipo = radio.Text;
                    }
                }
            }
            if(unoChequeado==false)
            {

                mensaje = mensaje + "tipo, ";
            }

            if (tipo == "Retira Cordon")
            {

                direccionDeEnvio = "Retira Cordon";
            }

            if (tipo == "Retira Pocitos")
            {
                direccionDeEnvio = "Retira Pocitos";
            }

            fechaProm = dtFechaPrometida.Value;
            fechaReal = dtfechaRealizado.Value;

            clinica = (String)cmbClinica.SelectedItem;

            if (clinica == "")
            {
                mensaje = mensaje + "clinica, ";
            }


            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradaPor = empleadoLogueado;
            }
            else
            {
                cerradaPor = new Empleado();
                cerradaPor.Id = 1;
                cerrada = false;
            }


            Obs = txtObservaciones.Text;


            bool entregada = false;
            foreach (Control control in groupEntregada.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        entregada = true;
                        entregadaA = radio.Text;
                    }
                }
            }

            if (entregadaA == "Otro")
            {
                entregadaA = txtEntregadaOtro.Text;
                if (entregadaA == "")
                {
                    mensaje = mensaje + "Entregada a, ";
                }
            }


            if ((txtPaciente.Text == "") || (txtPaciente.Text == "Busque un paciente haciendo click en la lupa"))
            {
                mensaje = mensaje + "paciente, ";
            }

            if ((txtOdontologo.Text == "") || (txtOdontologo .Text == "Busque un odontologo haciendo click en la lupa"))
            {
                mensaje = mensaje + "odontologo, ";
            }


            if ((rbtEnvia.Checked)||(rbtnInt.Checked))
            {
                direccionDeEnvio = txtdireccion.Text;
                if (direccionDeEnvio == "")
                {
                    mensaje = mensaje + "direccion de envio, ";
                }
            }

            if (chkCerrada.Checked == true)
            {
                if (entregada == false)
                {
                    mensaje += "entregada a, ";
                }
            }

            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    Carpeta nuevaCarpeta = new Carpeta(factura, tipo, fechaProm, fechaReal, clinica, Obs, cerrada, cerradaPor, entregadaA, pacienteSelec, odontologoSelec, direccionDeEnvio, false, false, "");

                   
                    FabricaLogica.getLogicaCarpeta().AgregarCarpeta(nuevaCarpeta);
                    lblError.Text = "Carpeta agregada correctamente";
                    //borrar datos

                    BorrarDatos();

                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }
            }
            else { lblError.Text = mensaje; }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               

                GEO.Busqueda.frmBusquedaPaciente form = new GEO.Busqueda.frmBusquedaPaciente();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDePaciente = form.ValorRetorno;

                    Paciente pacienteEncontrado = Logica.FabricaLogica.getLogicaPaciente().BuscarPacientePorId(Convert.ToInt32(idDePaciente));
                    txtPaciente.Text = pacienteEncontrado.Datos.ToString();
                    pacienteSelec = pacienteEncontrado;

                    if (carpetaEncontrada != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                    {
                        carpetaEncontrada.Paciente = pacienteEncontrado;
                    }

                    txtPaciente.ForeColor = System.Drawing.Color.Black;

                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
        }

        

        private void txtFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {

                e.Handled = true;
                SendKeys.Send("{TAB}");
                SendKeys.Send("{ENTER}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String factura = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            String clinica = "";
            String Obs = "";
            bool cerrada = false;
            Empleado cerradaPor =null;
            String entregadaA = "";
            String direccionDeEnvio = "";
            String mensaje = "Debe ingresar: ";

            factura = txtFac.Text;

            if (factura == "")
            {
                mensaje = mensaje + "factura, ";
            }

            foreach (Control control in groupTipos.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        tipo = radio.Text;
                    }
                }
            }

            if (tipo == "")
            {
                mensaje = mensaje + "tipo, ";
            }

            if (tipo == "Retira Cordon")
            {

                direccionDeEnvio = "Retira Cordon";
            }

            if (tipo == "Retira Pocitos")
            {
                direccionDeEnvio = "Retira Pocitos";
            }


            fechaProm = dtFechaPrometida.Value;
            fechaReal = dtfechaRealizado.Value;

            clinica = (String)cmbClinica.SelectedItem;

            if (clinica == "")
            {
                mensaje = mensaje + "clinica, ";
            }


            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradaPor = empleadoLogueado;
            }
            else
            {
                cerradaPor = new Empleado();
                cerradaPor.Id = 0;

                cerrada = false;
            }


            Obs = txtObservaciones.Text;



            foreach (Control control in groupEntregada.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;

                    if (radio.Checked)
                    {
                        entregadaA = radio.Text;
                    }
                }
            }
            if (entregadaA == "Otro")
            {
                entregadaA = txtEntregadaOtro.Text;
            }

            if ((entregadaA == "Otro") && (entregadaA == ""))
            {
                mensaje = mensaje + "entregadaA, ";
            }

            
            if (txtPaciente.Text=="")
            {
                mensaje = mensaje + "paciente, ";
            }

            if (txtOdontologo.Text=="")
            {
                mensaje = mensaje + "odontologo, ";
            }


            if (rbtEnvia.Checked)
            {
                direccionDeEnvio = txtdireccion.Text;
                if (direccionDeEnvio == "")
                {
                    mensaje = mensaje + "direccion, ";
                }
            }



            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    Carpeta nuevaCarpeta = new Carpeta(factura, tipo, fechaProm, fechaReal, clinica, Obs, cerrada, cerradaPor, entregadaA, carpetaEncontrada.Paciente, carpetaEncontrada.Odontologo, direccionDeEnvio, false, false, "");

                    FabricaLogica.getLogicaCarpeta().ModificarCarpeta(nuevaCarpeta);
                    lblError.Text = "Carpeta modificada correctamente";
                    //borrar datos

                    BorrarDatos();

                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }
            }
            else lblError.Text = mensaje;
        
        }

        private void button1_Click_1(object sender, EventArgs e) //busqueda de odontologo
        {
            try
            {
               

                GEO.Busqueda.busquedaOdontologo form = new GEO.Busqueda.busquedaOdontologo();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeOdontologo = form.ValorRetorno;

                    Odontologo OdontologoEncontrado = Logica.FabricaLogica.getLogicaOdontologo().BuscarOdontologoPorId(Convert.ToInt32(idDeOdontologo));
                    txtOdontologo.Text = OdontologoEncontrado.Datos.ToString();
                    odontologoSelec = OdontologoEncontrado;

                    if (odontologoSelec.Direcciones.Count==0)
                    {
                        throw new Exception("Si desea realizar un envio \n debe agregar una direccion");
                    }
                    else
                    {
                        txtdireccion.Text = odontologoSelec.Direcciones[0].ToString();
                    }


                    if (carpetaEncontrada != null)
                    {
                        carpetaEncontrada.Odontologo = OdontologoEncontrado;
                    }

                    txtOdontologo.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch(Exception es)
            { MessageBox.Show(es.Message); }
        }

        
     

        //esto es para q el texto desaparezca cuando hacemos click
        int contfac = 0;
        private void txtFac_Click(object sender, EventArgs e)
        {
            if (contfac == 0)
            {
                txtFac.Text = "";
            }

            txtFac.ForeColor = System.Drawing.Color.Black;
            contfac += 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (carpetaEncontrada != null)
                {
                    Logica.FabricaLogica.getLogicaCarpeta().EliminarCarpeta(carpetaEncontrada);
                    BorrarDatos();
                    lblError.Text = "Carpeta "+ carpetaEncontrada.NumDeFactura +" eliminada correctamente";

                }
            }
            catch (Exception es) { lblError.Text = "No se ha podido eliminar la carpeta: \n" + es.Message; }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            rbtArea.Checked = false;
            rbtArea.Checked = false;
            rbtOtro.Checked = false;
            txtEntregadaOtro.Text = "";
            chkCerrada.Checked = false;
        }

        private void rbtCordon_CheckedChanged(object sender, EventArgs e)
        {
            groupOdontologo.Enabled = false;
        }

        private void rbtPocitos_CheckedChanged(object sender, EventArgs e)
        {
            groupOdontologo.Enabled = false;
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Cree un carpeta con un numero de factura, para luego crear sus estudios asociados al mismo numero de factura. Primero rellene el formulario(no es preciso que rellene todos los campos, en ese caso la carpeta estaria pendiente) Mientras no se indique que los estudios de esta carpeta estan finalizados la carpeta seguira pendiente, si esta carpeta tiene algun estudio pendiente no se podra finalizar ");
        }

  



     

       


      

       

       

        

       

      

       

    }
}

        






    
    
