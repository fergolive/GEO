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
    public partial class TransfPaciente : Form
    {
        public TransfPaciente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {   
                Carpeta carpetaEncontrada=null;
                String factura="";
                String ruta="";
                ruta=txtRuta.Text;
                factura=lstNumeros.SelectedItem.ToString();
                if (factura == "")
                {
                    lblError.Text = "seleccione una factura";
                }
                else if (ruta == "")
                {   lblError.Text = "ingrese la ruta de la base de datos"; }
                else
                {
                    carpetaEncontrada = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpetaPorFacturaAccess(factura,ruta);
                    if (carpetaEncontrada == null)
                    {
                        lblError.Text = "No se encontro la carpeta";
                    }
                    else
                    {
                        if (carpetaEncontrada.Odontologo.Id != 1)
                        {
                            Odontologo odontologoEncontrado = null;

                            odontologoEncontrado = Logica.FabricaLogica.getLogicaOdontologo().BuscarOdontologo(carpetaEncontrada.Odontologo.Nombre, carpetaEncontrada.Odontologo.Apellido);

                            if (odontologoEncontrado != null)
                            {
                                carpetaEncontrada.Odontologo = null;
                                carpetaEncontrada.Odontologo = odontologoEncontrado;
                            }
                            else
                            {
                                Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(carpetaEncontrada.Odontologo);
                            }
                        }

                        Paciente pacEncontrado = null;
                        if (carpetaEncontrada.Paciente.Id != 1)
                        {
                            pacEncontrado = Logica.FabricaLogica.getLogicaPaciente().BuscarPacientePorNombre(carpetaEncontrada.Paciente.Nombre, carpetaEncontrada.Paciente.Apellido, carpetaEncontrada.Paciente.FechaDeNac);
                            if (pacEncontrado != null)
                            {
                                carpetaEncontrada.Paciente = null;
                                carpetaEncontrada.Paciente = pacEncontrado;
                            }
                            else
                            {
                                Logica.FabricaLogica.getLogicaPaciente().AgregarPaciente(carpetaEncontrada.Paciente);
                            }
                        }


                        Logica.FabricaLogica.getLogicaCarpeta().AgregarCarpeta(carpetaEncontrada);

                        label1.Text = "se exporto exitosamente:" + carpetaEncontrada.NumDeFactura;


                    }

                }
               

            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String ruta="";
                List<String> listaDeNumeros = Logica.FabricaLogica.getLogicaCarpeta().ListarUltimos5FacturasPacientesAccess(ruta);
                lstNumeros.DataSource = listaDeNumeros;
            }
            catch   
            {
                lblError.Text="No se pudo listar las facturas";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { String ruta = txtRuta.Text;

                if (ruta == "")
                {
                    lblError.Text="Debe ingresar la ruta del archivo de la base de datos(ACCESS)";
            
                }
                 Logica.FabricaLogica.getLogicaCarpeta().GuardarRuta(ruta,1); //1 cordon

            }
            catch (Exception es) { lblError.Text = es.Message; }
        }
    }
}
