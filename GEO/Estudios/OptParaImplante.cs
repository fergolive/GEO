using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

namespace OriTrabajos.ESTUDIOS
{
    public partial class OptParaImplante : Form
    {
       
        EntidadesCompartidas.OptParaImplante oxiEncontrada = null;
        Carpeta carpeta = null;
        Empleado empleadoLogueado = null;

        public OptParaImplante(Empleado empleadoLog)
        {

            InitializeComponent();
            empleadoLogueado = empleadoLog;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String factura;
            int id=0;
            DateTime fechaRealizado = DateTime.Now;
            DateTime fechaPrometida = (DateTime.Now).AddDays(1);
            Empleado cerradaPor=null; 
            bool opt=false;
            bool impresion=false;
            bool informe=false;
            bool cd=false;
            bool cerrada = false;
            String mensaje = "Debe ingresar: ";

            factura = txtFactura.Text;
            if (factura == "")
            {
                mensaje = mensaje + "factura";
            }


            fechaRealizado = dtfechas.Value;
            fechaPrometida = dtFechaPrometida.Value;

            if (chkOpt.Checked)
            {
                opt = true;
            }

            if (chkImpresion.Checked)
            {
                impresion = true;
            }

            if(chkInforme.Checked)
            {
                informe = true;
            }

            if (chkCd.Checked)
            {
                cd = true;
            }

            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradaPor = empleadoLogueado;
            }
            else
            {
                cerrada=false;
                Empleado sinEmpleado = new Empleado();
                sinEmpleado.Id = 1;
                cerradaPor = sinEmpleado;
            }

            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    EntidadesCompartidas.OptParaImplante nuevaOxi = new EntidadesCompartidas.OptParaImplante(impresion,informe,cd,opt,id,fechaRealizado,fechaPrometida,cerrada,empleadoLogueado,carpeta);
                    Logica.FabricaLogica.getLogicaOxi().AgregarOptParaImplante(nuevaOxi);

                    limpiarDatos();
                    lblError.Text = "Oxi Agregarda correctamente al nro: "+nuevaOxi.Factura.ToString();
     
                }
                catch(Exception es)
                {
                    lblError.Text = es.Message;
                }
            }

        }
        internal void limpiarDatos()
        {
            txtFactura.Text = "";
            chkOpt.Checked = false;
            chkImpresion.Checked = false;
            chkInforme.Checked = false;
            chkCd.Checked = false;
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            lblError.Text = "";
            
        }
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.FabricaLogica.getLogicaOxi().EliminarOptParaImplante(oxiEncontrada);

                limpiarDatos();
                lblError.Text = "Se ha eliminado la oxi de "+oxiEncontrada.Factura.ToString();
            }
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String factura;
            int id = 0;
            DateTime fechaRealizado = DateTime.Now;
            DateTime fechaPrometida = (DateTime.Now).AddDays(1);
            Empleado cerradaPor = null;
            bool opt = false;
            bool impresion = false;
            bool informe = false;
            bool cd = false;
            bool cerrada = false;
            String mensaje = "Debe ingresar: ";

            factura = txtFactura.Text;
            if (factura == "")
            {
                mensaje = mensaje + "factura";
            }


            fechaRealizado = dtfechas.Value;
            fechaPrometida = dtFechaPrometida.Value;

            if (chkOpt.Checked)
            {
                opt = true;
            }

            if (chkImpresion.Checked)
            {
                impresion = true;
            }

            if (chkInforme.Checked)
            {
                informe = true;
            }

            if (chkCd.Checked)
            {
                cd = true;
            }

            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradaPor = empleadoLogueado;
            }
            else
            {
                cerrada = false;
                Empleado sinEmpleado = new Empleado();
                sinEmpleado.Id = 1;
                cerradaPor = sinEmpleado;
            }

            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    EntidadesCompartidas.OptParaImplante nuevaOxi = new EntidadesCompartidas.OptParaImplante(impresion, informe, cd, opt, id, fechaRealizado, fechaPrometida, cerrada, empleadoLogueado, carpeta);
                    Logica.FabricaLogica.getLogicaOxi().ModificarOptParaImplante(nuevaOxi);

                    chkOpt.Checked = false;
                    chkImpresion.Checked = false;
                    chkInforme.Checked = false;
                    chkCd.Checked = false;
                    btnAgregar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;
                    chkCerrada.Checked = false;

                    lblError.Text = "Se ha modificado correctamente la oxi";

                }
                catch (Exception es)
                {
                    lblError.Text = es.Message;
                }

            }
        }
        private void dtfechas_ValueChanged(object sender, EventArgs e)
        {
            dtFechaPrometida.Value = (dtfechas.Value).AddDays(1);
        }

        private void OptParaImplante_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;

            if (oxiEncontrada != null)
            {
                btnModificar.Enabled = true;
            }
            else
            {
                btnModificar.Enabled = false;
            }

        }

        int contfac = 0;

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            if (contfac == 0)
            {
                txtFactura.Text = "";
            }

            txtFactura.ForeColor = System.Drawing.Color.Black;
            contfac += 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                String factura = txtFactura.Text;
                carpeta = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);


                if (carpeta == null)
                {
                    limpiarDatos();

                    lblError.Text = "Numero de factura:" + factura + " no encontrado";

                }
                else
                {
                    oxiEncontrada = Logica.FabricaLogica.getLogicaOxi().BuscarOptParaImplante(factura);
                    if (oxiEncontrada == null)
                    {


                        lblError.Text = "No se encontro una oxi, puede agregarla";

                        btnAgregar.Enabled = true;
                        btnEliminar.Enabled = false;
                        btnModificar.Enabled = false;

                        dtfechas.Value = DateTime.Now;
                        dtFechaPrometida.Value = DateTime.Now.AddDays(1);
                    }
                    else
                    {
                        lblError.Text = "";
                        btnAgregar.Enabled = false;
                        btnEliminar.Enabled = false;
                        btnModificar.Enabled = true;

                        //mostrar datos
                        dtFechaPrometida.Value = oxiEncontrada.FechaPrometida;
                        dtfechas.Value = oxiEncontrada.FechaRealizado;
                        if (oxiEncontrada.Cerrada == true)
                        {
                            chkCerrada.Checked = true;
                        }

                        if (oxiEncontrada.Impresion == true)
                        {
                            chkImpresion.Checked = true;
                        }

                        if (oxiEncontrada.Opt == true)
                        {
                            chkOpt.Checked = true;
                        }

                        if (oxiEncontrada.Informe == true)
                        {
                            chkInforme.Checked = true;
                        }

                        if (oxiEncontrada.Cd == true)
                        {
                            chkCd.Checked = true;
                        }

                        btnAgregar.Enabled = false;
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;
                    }
                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {

                e.Handled = true;
                SendKeys.Send("{TAB}");
                SendKeys.Send("{ENTER}");
            }
        }

       
    }
}
