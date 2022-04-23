using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriTrabajos.ABM
{
    public partial class ExportarPecientesFacturados : Form
    {
        int contador = 0;
            

        public ExportarPecientesFacturados(EntidadesCompartidas.Empleado usuario)
        {
            InitializeComponent();
            if (usuario.Tipo == "admin")
            {
                GrdRutaBD.Enabled = true;
            }
            else { GrdRutaBD.Enabled = false; }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try{


                String ruta = txtRuta.Text;
                if (ruta == "")
                { lblError.Text = "Debe ingresar la ruta de la BD"; }
                else
                {
        

           

                List<String> listaDeNumeros = Logica.FabricaLogica.getLogicaCarpeta().ListarUltimos5FacturasPacientesAccess(ruta);//lista 10


                foreach (String fac in listaDeNumeros)
                {

                    //(1)busco carpeta en access
                    EntidadesCompartidas.Carpeta carpetaEncontrada = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpetaPorFacturaAccess(fac, ruta);
                    carpetaEncontrada.Clinica = "Cordon";
                    carpetaEncontrada.FechaRealizada = DateTime.Now;


                    //if (carpetaEncontrada.Odontologo.Id != 1)
                    //{
                    //    //(2)busco si existe el odontologo de recepcion en mi bd
                    //    EntidadesCompartidas.Odontologo odontologoEncontrado = null;
                    //    odontologoEncontrado = Logica.FabricaLogica.getLogicaOdontologo().BuscarOdontologo(carpetaEncontrada.Odontologo.Nombre, carpetaEncontrada.Odontologo.Apellido);

                    //    if (odontologoEncontrado != null)
                    //    {
                    //        //si lo encuentro borro lo anterior y le pongo el de mi bd que tiene todo los datos

                    //           carpetaEncontrada.Odontologo.Apellido = odontologoEncontrado.Apellido;
                    //           carpetaEncontrada.Odontologo.Nombre = odontologoEncontrado.Nombre;
                    //           carpetaEncontrada.Odontologo.Direcciones.Add(odontologoEncontrado.Direcciones[0].ToString());
                    //           carpetaEncontrada.Odontologo.Telefono = odontologoEncontrado.Telefono;
                    //           carpetaEncontrada.Odontologo.Id = odontologoEncontrado.Id;
                    //           carpetaEncontrada.Odontologo.Ciudad = odontologoEncontrado.Ciudad;
                    //           carpetaEncontrada.Odontologo.Email = odontologoEncontrado.Email;





                    //    }
                    //    else
                    //    {
                    //        //si no lo encutro lo agrego a mi bd
                    //        Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(carpetaEncontrada.Odontologo);
                    //    }
                    //}


                    //if (carpetaEncontrada.Paciente.Id != 1)
                    //{

                    //   Logica.FabricaLogica.getLogicaPaciente().AgregarPaciente(carpetaEncontrada.Paciente);

                    //}


                    Logica.FabricaLogica.getLogicaCarpeta().AgregarCarpeta2(carpetaEncontrada);

                    txtPacientes.Text += carpetaEncontrada.NumDeFactura + ", " + carpetaEncontrada.Paciente.Apellido + ", " + carpetaEncontrada.Paciente.Nombre + " - ";

                }
               }
            }
     
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                timer1.Start();
                lblMensaje.Enabled = false;
                lblMensaje.Text = "Activado!! exportando pacientes...."+"\n"+"no cierre la aplicacion.";
            }
            catch(Exception es)
            {
                lblError.Text=es.Message;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lblMensaje.Text = "Desactivado";
        }

        private void ExportarPecientesFacturados_Load(object sender, EventArgs e)
        {
            try {

                txtRuta.Text = Logica.FabricaLogica.getLogicaCarpeta().ObtenerRuta(1);
                
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            
            }
        }

        private void btnGuardarRuta_Click(object sender, EventArgs e)
        {
            try
            {
                //tipo de ruta: 1 para exportar pacientes todo el tiempo
                Logica.FabricaLogica.getLogicaCarpeta().GuardarRuta(txtRuta.Text, 1);
            }
            catch (Exception es) { lblError.Text = es.Message; }
        }
        
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero ingrese la ruta de la ubicacion del archivo de la base datos en el campo de texto y presione guardar de access donde el sistema de facturacion guarda los datos, luego presione Activar Timer, eso hara que cada cierto intervalo de tiempo el sistema chequee si hay nuevas facturas, si las hay tomara los datos y creara carpetas con pacientes y odontolos, al finalizar el dia de trabajo desactive el timer.");
        }
    }
}
