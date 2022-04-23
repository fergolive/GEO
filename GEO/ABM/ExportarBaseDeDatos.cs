using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;


namespace GEO.ABM
{
    public partial class ExportarBaseDeDatos : Form
    {
        public ExportarBaseDeDatos()
        {
            InitializeComponent();
        }

        String ruta="";

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = " Archivos mdb(*.mdb)|*.mdb";
            open.Title = "Archivos de base de datos";

            if (open.ShowDialog() == DialogResult.OK)
            {
                lblRuta.Text = open.FileName;
                ruta = open.FileName;

            }
            open.Dispose();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {

                if(ruta!="")
                {
                   
                    List<Carpeta> carpetasEncontradas = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpetasAccess(ruta);

                    double cien = Convert.ToDouble(100);
                    double carpetacount = Convert.ToDouble(carpetasEncontradas.Count);
                    double cantidad = (100/carpetacount);

                    foreach(Carpeta carpe in carpetasEncontradas)
                    {
                        if (carpe.Odontologo != null)
                        {
                            if (carpe.Odontologo.Id != 0)
                            {
                                Odontologo nuevo = Logica.FabricaLogica.getLogicaCarpeta().BuscarOdotologoPorIdAccess(carpe.Odontologo.Id);
                                carpe.Odontologo = null;
                                carpe.Odontologo = nuevo;
                            }
                        } 

                        if(carpe.Odontologo!=null)
                        {
                            Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(carpe.Odontologo); //doy de alta los odontologos

                        }

                        Logica.FabricaLogica.getLogicaPaciente().AgregarPaciente(carpe.Paciente); 
                        Logica.FabricaLogica.getLogicaCarpeta().AgregarCarpeta2(carpe);

                        listBox1.Items.Add("Carpeta: " + carpe.NumDeFactura + ",   " + "Paciente: " + carpe.Paciente.Apellido + " " + carpe.Paciente.Nombre + ",   " + "Odontologo: " + carpe.Odontologo.Apellido + " " + carpe.Odontologo.Nombre + ".");
                    }

                    MessageBox.Show("Se han exportado: " + carpetasEncontradas.Count + " Carpetas");
                   
                }
                else
                {
                    MessageBox.Show("Primero debe buscar el archivo de BD");
                }
            }

            catch(Exception es)
            {
                lblError.Text = "Error:" + es.Message;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero busque la base de datos y luego presione en Exportar, exportar una base de datos puede tardar varios minutos.");
        }
    }
}
