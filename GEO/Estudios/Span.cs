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
    public partial class Span : Form
    {
        
        Carpeta carpeta = null;
        Empleado empleadoLogueado = null;
        Empleado cerradaPor = null;
        EntidadesCompartidas.Span spanEncontrado = null;
        String factura = "";

        public Span(Empleado empleadolog)
        {
            InitializeComponent();
            empleadoLogueado = empleadolog;
        }

       

        private void Span_Load(object sender, EventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;

                if (spanEncontrado == null)
                {
                    btnModificar.Enabled = false;
                }
                else
                    btnModificar.Enabled = true;

                cmbIdentikit.Items.Add(" ");
                cmbIdentikit.Items.Add("Sin Cargo");
                cmbIdentikit.Items.Add("Con Over");
                cmbIdentikit.Items.Add("Sin Over");
                cmbIdentikit.Items.Add("Over y Submenton");
                cmbIdentikit.Items.Add("S/Over con submenton");
                cmbIdentikit.Items.Add("Intrabucales");
            }
            catch
            {
                lblError.Text = "No se pudo cargar Identikit coment.";
            }

            try
            {
                cmbTipoDeFotos.Items.Add(" ");
                cmbTipoDeFotos.Items.Add("Cara");
                cmbTipoDeFotos.Items.Add("1 Hoja");
                cmbTipoDeFotos.Items.Add("3 Hojas");
            }
            catch
            {
                lblError.Text = "No se pudo cargar Tipo de fotos";
            }
        }

        internal void txtFactura_Validating(object sender, CancelEventArgs e)
        {
            factura = txtFactura.Text;
            try
            {
                carpeta = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);

                if (carpeta == null)
                {
                    limpiarDatos();
                    lblError.Text = "No existe el numero de factura: " + factura; ;
                    
                }
                else
                {
                    spanEncontrado = Logica.FabricaLogica.getLogicaSpam().BuscarSpan(factura);

                    if (spanEncontrado == null)
                    {
                        limpiarDatos();
                        txtFactura.Text = factura;
                        lblError.Text = "No existe el Span, ingrese uno nuevo";
                        btnAgregar.Enabled = true;
                          
                    }
                    else
                    {
                        btnEliminar.Enabled = true;
                        btnModificar.Enabled = true;

                        //muestro los datos
                        if (spanEncontrado.Bj == true)
                        {
                            chkBbj.Checked = true;
                        }

                        if (spanEncontrado.SinOpt == true)
                        {
                            chkSinOpt.Checked = true;
                        }

                        if (spanEncontrado.Cd == true)
                        {
                            chkCd.Checked = true;
                        }

                        
                        if (spanEncontrado.Mc == true)
                        {
                            chkMc.Checked = true;
                        }

                        if (spanEncontrado.Oli == true)
                        {
                            chkOli.Checked = true;
                        }

                        if (spanEncontrado.Pow == true)
                        {
                            chkPow.Checked = true;
                        }

                        if (spanEncontrado.Quir == true)
                        {
                            chkQuir.Checked = true;
                        }

                    
                        if (spanEncontrado.Rb == true)
                        {
                            chkRb.Checked = true;
                        }

                        if (spanEncontrado.Rick == true)
                        {
                            chkRick.Checked = true;
                        }

                        if (spanEncontrado.Sch == true)
                        {
                            chkSch.Checked = true;
                        }

                        if (spanEncontrado.Harv == true)
                        {
                            chkHarv.Checked = true;
                        }

                        if (spanEncontrado.Hold == true)
                        {
                            chkHold.Checked = true;
                        }

                        if (spanEncontrado.Trevisi == true)
                        {
                            chkTrevisi.Checked = true;
                        }

                        if (spanEncontrado.FotoDigital == true)
                        {
                            chkFotoDig.Checked = true;
                        }

                        if (spanEncontrado.Cerrada == true)
                        {
                            chkCerrada.Checked = true;
                        }

                        dtFechaProm.Value = spanEncontrado.FechaPrometida;
                        dtFechaRealiz.Value = spanEncontrado.FechaRealizado;

                        cmbIdentikit.SelectedItem = spanEncontrado.IdentikitComentarios;
                        cmbTipoDeFotos.SelectedItem = spanEncontrado.TipoDeFotoDigital;


                    }
                }


            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void limpiarDatos()
        {
            chkBbj.Checked = false;
            chkCd.Checked = false;
            chkCerrada.Checked = false;
            chkFotoDig.Checked = false;
            chkHarv.Checked = false;
            chkHold.Checked = false;
            chkMc.Checked = false;
            chkOli.Checked = false;
            chkPow.Checked = false;
            chkQuir.Checked = false;
            chkRb.Checked = false;
            chkRick.Checked = false;
            chkSch.Checked = false;
            chkSinOpt.Checked = false;
            chkTrevisi.Checked = false;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            lblError.Text = "";
            dtFechaRealiz.Value=DateTime.Now;
            dtFechaProm.Value = (DateTime.Now).AddDays(5);
            
        }


   

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometido = (DateTime.Now).AddDays(5);

                bool sinOpt = false;
                bool rb = false;
                bool mc = false;
                bool oli = false;
                bool bj = false;
                bool pow = false;
                bool quir = false;
                bool trevisi = false;
                bool hold = false;
                bool harv = false;
                bool sch = false;
                bool rick = false;
                bool fotodig = false;
                bool cd = false;

                String tipoDeFoto = "";
                String identikit = "";
                bool cerrada = false;

                factura = txtFactura.Text;


                fechaRealizado = dtFechaRealiz.Value;
                fechaPrometido = dtFechaProm.Value;

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




                if (chkRb.Checked)
                {
                    rb = true;
                }

                if (chkMc.Checked)
                {
                    mc = true;
                }

                if (chkOli.Checked)
                {

                    oli = true;
                }

                if (chkBbj.Checked)
                {
                    bj = true;
                }

                if (chkPow.Checked)
                {

                    pow = true;
                }

                if (chkQuir.Checked)
                {
                    quir = true;
                }

                if (chkTrevisi.Checked)
                {
                    trevisi = true;
                }

                if (chkHold.Checked)
                {
                    hold = true;
                }

                if (chkHarv.Checked)
                {
                    harv = true;
                }

                if (chkSch.Checked)
                {
                    sch = true;
                }

                if (chkRick.Checked)
                {
                    rick = true;
                }

                if (chkFotoDig.Checked)
                {
                    fotodig = true;
                }

                if (chkCd.Checked)
                {
                    cd = true;
                }

                if (chkSinOpt.Checked)
                {
                    sinOpt = true;
                }


                tipoDeFoto = cmbTipoDeFotos.SelectedItem.ToString();
                identikit = cmbIdentikit.SelectedItem.ToString();

                EntidadesCompartidas.Span nuevoSpan = new EntidadesCompartidas.Span(sinOpt, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotodig, tipoDeFoto, identikit, cd, 0, fechaRealizado, fechaPrometido, cerrada, cerradaPor, carpeta);

                Logica.FabricaLogica.getLogicaSpam().ModificarSpan(nuevoSpan);

                limpiarDatos();

                lblError.Text = "Se modifico correctamente el estudio en: " + factura;
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.FabricaLogica.getLogicaSpam().EliminarSpan(spanEncontrado);

                limpiarDatos();

                lblError.Text = "Span de" + factura + " eliminado";
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometido = (DateTime.Now).AddDays(5);

                bool sinOpt = false;
                bool rb = false;
                bool mc = false;
                bool oli = false;
                bool bj = false;
                bool pow = false;
                bool quir = false;
                bool trevisi = false;
                bool hold = false;
                bool harv = false;
                bool sch = false;
                bool rick = false;
                bool fotodig = false;
                bool cd = false;

                String tipoDeFoto = "";
                String identikit = "";
                bool cerrada = false;

                factura = txtFactura.Text;


                fechaRealizado = dtFechaRealiz.Value;
                fechaPrometido = dtFechaProm.Value;

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




                if (chkRb.Checked)
                {
                    rb = true;
                }

                if (chkMc.Checked)
                {
                    mc = true;
                }

                if (chkOli.Checked)
                {

                    oli = true;
                }

                if (chkBbj.Checked)
                {
                    bj = true;
                }

                if (chkPow.Checked)
                {

                    pow = true;
                }

                if (chkQuir.Checked)
                {
                    quir = true;
                }

                if (chkTrevisi.Checked)
                {
                    trevisi = true;
                }

                if (chkHold.Checked)
                {
                    hold = true;
                }

                if (chkHarv.Checked)
                {
                    harv = true;
                }

                if (chkSch.Checked)
                {
                    sch = true;
                }

                if (chkRick.Checked)
                {
                    rick = true;
                }

                if (chkFotoDig.Checked)
                {
                    fotodig = true;
                }

                if (chkCd.Checked)
                {
                    cd = true;
                }

                if (chkSinOpt.Checked)
                {
                    sinOpt = true;
                }


                tipoDeFoto = cmbTipoDeFotos.SelectedItem.ToString();
                identikit = cmbIdentikit.SelectedItem.ToString();

                EntidadesCompartidas.Span nuevoSpan = new EntidadesCompartidas.Span(sinOpt, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotodig, tipoDeFoto, identikit, cd, 0, fechaRealizado, fechaPrometido, cerrada, cerradaPor, carpeta);

                Logica.FabricaLogica.getLogicaSpam().AgregarSpan(nuevoSpan);

                limpiarDatos();
                lblError.Text = "Span agregado correctamente a: " + factura;
            }
            catch (Exception es)
            {

                lblError.Text = es.Message;
            }
        }


        int contfac = 0;
        private void txtFactura_Click(object sender, EventArgs e)
        {
            if (contfac == 0)
            {
                txtFactura.Text = "";
            }

            txtFactura.ForeColor = System.Drawing.Color.Black;
            contfac += 1;
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
