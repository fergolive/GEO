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
    public partial class NemoDocViewer : Form
    {
       
        Empleado empleadoLogueado = null;
        Empleado cerradaPor = null;
        String factura = "";
        EntidadesCompartidas.NemoDocViewer nemoEncontrado = null;
        Carpeta carpeta = null;

        public NemoDocViewer(Empleado empleadolog)
        {
            InitializeComponent();
            empleadoLogueado = empleadolog;
        }



        private void NemoDocViewer_Load(object sender, EventArgs e)
        {
            try
            {
                
                limpiarDatos();
                btnAgregar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

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

     

        private void limpiarDatos()
        {
            
            chkCerrada.Checked = false;

            DesmarcarTodos();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

            lblError.Text = "";

            cmbIdentikit.Text = "";
            cmbTipoDeFotos.Text = "";

            txtObs.Text = "";
            rbtnSpan.Checked = false;
            rbtnOtro.Checked = false;
            rbtnNemo.Checked = false;
            rbtnDoc.Checked = false;
            txtOtro.Text = "";

        }

       

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometido = (DateTime.Now).AddDays(5);

                bool nemo = false;
                bool doc = false;
                bool roth = false;
                bool ayala = false;
                bool pcon = false;
                bool psin = false;
                bool vis = false;
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
                bool rickFront = false;
                bool modelo=false;
                bool sinOpt=false;
                String software="";
                String obs;

                String mensaje = "Debe ingresar: ";
                String tipoDeFoto = "";
                String identikit = "";
                bool cerrada = false;

                factura = txtFactura.Text;
                if (factura == "")
                {
                    mensaje = mensaje + "Factura ";
                }

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

                if (chkNemo.Checked)
                {
                    nemo = true;
                }

                if (chkDoc.Checked)
                {
                    doc = true;
                }

                if (chkRoth.Checked)
                {
                    roth = true;
                }

                if (chkayala.Checked)
                {
                    ayala = true;
                }

                if (chkpContrat.Checked)
                {
                    pcon = true;
                }

                if (chkpSinTrat.Checked)
                {
                    psin = true;
                }


                if (chkvisEst.Checked)
                {
                    vis = true;
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

                if (chkBj.Checked)
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

                if (chkFotodig.Checked)
                {
                    fotodig = true;
                }

                if (chkCd.Checked)
                {
                    cd = true;
                }

                if (chkRickF.Checked)
                {
                    rickFront = true;
                }

                if (chkModelo.Checked)
                {
                    modelo = true;
                }


                if(chkSinOpt.Checked)
                {
                 sinOpt=true;
                }

                obs=txtObs.Text;

                //software
                if(rbtnDoc.Checked)
                {
                    software="DocViewer";
                }

                if(rbtnNemo.Checked)
                {
                    software="Nemo";
                }

                if(rbtnOtro.Checked)
                {
                    software=txtOtro.Text;
                    if(txtOtro.Text=="")
                    {
                        mensaje += "Otro, ";
                    }
                }

                if(rbtnSpan.Checked)
                {
                 software="Span";
                }

                tipoDeFoto = cmbTipoDeFotos.SelectedItem.ToString();
                identikit = cmbIdentikit.SelectedItem.ToString();

                if (mensaje == "Debe ingresar: ")
                {
                    EntidadesCompartidas.NemoDocViewer nuevo = new EntidadesCompartidas.NemoDocViewer(nemo, doc, roth, ayala, pcon, psin, vis, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotodig, tipoDeFoto, identikit, cd,rickFront,modelo,sinOpt,software,obs, 0, fechaRealizado, fechaPrometido, cerrada, cerradaPor, carpeta);
                    Logica.FabricaLogica.getLogicaNemo().AgregarNemo(nuevo);

                    
                    limpiarDatos();
                    btnAgregar.Enabled = false;
                    lblError.Text = "Nemo agregado correctamente a: " + factura;
                }
                else { lblError.Text = mensaje; }
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

                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometido = (DateTime.Now).AddDays(5);

                bool nemo = false;
                bool doc = false;
                bool roth = false;
                bool ayala = false;
                bool pcon = false;
                bool psin = false;
                bool vis = false;
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
                bool rickFrontal = false;
                bool modelo = false;
                bool sinOpt = false;
                String software="";
                String obs="";

                String mensaje = "Debe ingresar: ";
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

                if (chkNemo.Checked)
                {
                    nemo = true;
                }

                if (chkDoc.Checked)
                {
                    doc = true;
                }

                if (chkRoth.Checked)
                {
                    roth = true;
                }

                if (chkayala.Checked)
                {
                    ayala = true;
                }

                if (chkpContrat.Checked)
                {
                    pcon = true;
                }

                if (chkpSinTrat.Checked)
                {
                    psin = true;
                }


                if (chkvisEst.Checked)
                {
                    vis = true;
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

                if (chkBj.Checked)
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

                if (chkFotodig.Checked)
                {
                    fotodig = true;
                }

                if (chkCd.Checked)
                {
                    cd = true;
                }

                if(chkRickF.Checked)
                {
                    rickFrontal = true;
                }

                if (chkModelo.Checked)
                {
                    modelo = true;
                }
                if (chkSinOpt.Checked)
                {
                    sinOpt = true;
                }

                //software
                if (rbtnDoc.Checked)
                {
                    software = "DocViewer";
                }

                if (rbtnNemo.Checked)
                {
                    software = "Nemo";
                }

                if (rbtnOtro.Checked)
                {
                    software = txtOtro.Text;
                    if (txtOtro.Text == "")
                    {
                        mensaje += "Otro, ";
                    }
                }

                if (rbtnSpan.Checked)
                {
                    software = "Span";
                }

                tipoDeFoto = cmbTipoDeFotos.SelectedItem.ToString();
                identikit = cmbIdentikit.SelectedItem.ToString();
                obs = txtObs.Text;

                if (mensaje == "Debe ingresar: ")
                {
                    EntidadesCompartidas.NemoDocViewer nuevo = new EntidadesCompartidas.NemoDocViewer(nemo, doc, roth, ayala, pcon, psin, vis, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotodig, tipoDeFoto, identikit, cd,rickFrontal,modelo, sinOpt, software, obs, 0, fechaRealizado, fechaPrometido, cerrada, cerradaPor, carpeta);
                    Logica.FabricaLogica.getLogicaNemo().ModificarNemo(nuevo);
            

                    limpiarDatos();

                    lblError.Text = "Nemo modificado correctamente en: " + factura;
                }
                else { lblError.Text = mensaje; }

            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                GEO.Busqueda.FrmPedirFactura form = new GEO.Busqueda.FrmPedirFactura();

                //if (form.ShowDialog() == DialogResult.OK)
                //{
                   // factura = form.ValorRetorno;

                    factura=txtFactura.Text;

                    carpeta = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);

                    if (carpeta == null)
                    {

                        limpiarDatos();
                        lblError.Text = "No existe una carpeta con ese numero de factura";
                        
                        btnEliminar.Enabled = false;
                        btnModificar.Enabled = false;
                        btnAgregar.Enabled = false;
                       
                    }
                    else
                    {
                        nemoEncontrado = Logica.FabricaLogica.getLogicaNemo().BuscarNemo(factura);

                        if (nemoEncontrado == null)
                        {
                            lblError.Text = "No existe el NemoDoc, ingrese uno nuevo";
                            btnAgregar.Enabled = true;
                            btnEliminar.Enabled = false;
                            btnModificar.Enabled = false;
                        }
                        else
                        {
                            limpiarDatos();

                            chkmarcartodos.Checked = false;
                            btnEliminar.Enabled = true;
                            btnModificar.Enabled = true;

                            //muestro los datos
                            txtFactura.Text = nemoEncontrado.Factura;
                            lblError.Text = "Estudio encontrado!!!";

                            if (nemoEncontrado.Ayala == true)
                            {
                                chkayala.Checked = true;
                            }

                            if (nemoEncontrado.Bj == true)
                            {
                                chkBj.Checked = true;
                            }

                            if (nemoEncontrado.Cd == true)
                            {
                                chkCd.Checked = true;
                            }

                            if (nemoEncontrado.DocViewer == true)
                            {
                                chkDoc.Checked = true;
                            }

                            if (nemoEncontrado.Cerrada == true)
                            {
                                chkCerrada.Checked = true;
                            }

                            if (nemoEncontrado.FotoDigital == true)
                            {
                                chkFotodig.Checked = true;
                            }

                            if (nemoEncontrado.Harv == true)
                            {
                                chkHarv.Checked = true;
                            }

                            if (nemoEncontrado.Hold == true)
                            {
                                chkHold.Checked = true;
                            }

                            if (nemoEncontrado.Mc == true)
                            {
                                chkMc.Checked = true;
                            }

                            if (nemoEncontrado.Nemo == true)
                            {
                                chkNemo.Checked = true;
                            }

                            if (nemoEncontrado.Oli == true)
                            {
                                chkOli.Checked = true;
                            }

                            if (nemoEncontrado.PConTrat == true)
                            {
                                chkpContrat.Checked = true;
                            }

                            if (nemoEncontrado.PSinTrat == true)
                            {
                                chkpSinTrat.Checked = true;
                            }

                            if (nemoEncontrado.Quir == true)
                            {
                                chkQuir.Checked = true;
                            }

                            if (nemoEncontrado.Rb == true)
                            {
                                chkRb.Checked = true;
                            }

                            if (nemoEncontrado.Rick == true)
                            {
                                chkRick.Checked = true;
                            }

                            if (nemoEncontrado.Roth == true)
                            {
                                chkRoth.Checked = true;
                            }

                            if (nemoEncontrado.Sch == true)
                            {
                                chkSch.Checked = true;
                            }

                            if (nemoEncontrado.Trevisi == true)
                            {
                                chkTrevisi.Checked = true;
                            }

                            if (nemoEncontrado.VisEst == true)
                            {
                                chkvisEst.Checked = true;
                            }

                            if (nemoEncontrado.Pow == true)
                            {
                                chkPow.Checked = true;
                            }

                            if (nemoEncontrado.SinOpt == true)
                            {
                                chkSinOpt.Checked = true;
                            }

                            if (nemoEncontrado.RickFront == true)
                            {
                                chkRickF.Checked = true;
                            }

                            if (nemoEncontrado.Modelo==true)
                            {
                                chkModelo.Checked = true;
                            }

                            //software
                            if (nemoEncontrado.Software == "Nemo")
                            { rbtnNemo.Checked = true; }
                            else if (nemoEncontrado.Software == "DocViewer")
                            { rbtnDoc.Checked = true; }  
                            else if (nemoEncontrado.Software == "Span")
                            { rbtnSpan.Checked = true; }
                            else 
                            {
                                rbtnOtro.Checked = true;
                                txtOtro.Text = nemoEncontrado.Software;
                            }

                            txtObs.Text = nemoEncontrado.Observaciones.ToString();
                            

                            dtFechaProm.Value = nemoEncontrado.FechaPrometida;
                            dtFechaRealiz.Value = nemoEncontrado.FechaRealizado;

                            //cmbIdentikit.SelectedItem = nemoEncontrado.IdentikitComentarios;
                            //cmbTipoDeFotos.SelectedItem = nemoEncontrado.TipoDeFotoDigital;

                            cmbIdentikit.Text = nemoEncontrado.IdentikitComentarios.ToString();
                            cmbTipoDeFotos.Text = nemoEncontrado.TipoDeFotoDigital.ToString();



                        }
                    }

                }
             //}
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }
        
        
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.FabricaLogica.getLogicaNemo().EliminarNemo(nemoEncontrado);

                limpiarDatos();

                lblError.Text = "Nemo " + factura + " eliminado correctamente";
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void chkOtro_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = true;
            txtOtro.Visible = true;
        }

        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = false;
            txtOtro.Visible = false;
            txtOtro.Text = "";
        }

        private void chkDockViewer_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = false;
            txtOtro.Visible = false;
            txtOtro.Text = "";
        }

        private void chkSpan_CheckedChanged(object sender, EventArgs e)
        {
            txtOtro.Enabled = false;
            txtOtro.Visible = false;
            txtOtro.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {

                if (chkmarcartodos.Checked)
                {
                    MarcarTodos();
                }
                else { DesmarcarTodos(); }
                
            }
            catch { lblError.Text = "No se pudieron marcar todos"; }
        }

        private void MarcarTodos()
        {
            chkayala.Checked = true;
            chkBj.Checked = true;
            chkCd.Checked = true;
            chkDoc.Checked = true;
            chkFotodig.Checked = true;
            chkHarv.Checked = true;
            chkHold.Checked = true;
            chkMc.Checked = true;
            chkNemo.Checked = true;
            chkOli.Checked = true;
            chkpContrat.Checked = true;
            chkPow.Checked = true;
            chkpSinTrat.Checked = true;
            chkQuir.Checked = true;
            chkRb.Checked = true;
            chkRick.Checked = true;
            chkRoth.Checked = true;
            chkSch.Checked = true;
            chkSinOpt.Checked = true;
            chkTrevisi.Checked = true;
            chkvisEst.Checked = true;
            chkModelo.Checked = true;
            chkRickF.Checked = true;
        }

        private void DesmarcarTodos()
        {
            chkayala.Checked = false;
            chkBj.Checked = false;
            chkCd.Checked = false;
            chkDoc.Checked = false;
            chkFotodig.Checked = false;
            chkHarv.Checked = false;
            chkHold.Checked = false;
            chkMc.Checked = false;
            chkNemo.Checked = false;
            chkOli.Checked = false;
            chkpContrat.Checked = false;
            chkPow.Checked = false;
            chkpSinTrat.Checked = false;
            chkQuir.Checked = false;
            chkRb.Checked = false;
            chkRick.Checked = false;
            chkRoth.Checked = false;
            chkSch.Checked = false;
            chkSinOpt.Checked = false;
            chkTrevisi.Checked = false;
            chkvisEst.Checked = false;
            chkmarcartodos.Checked = false;
            chkModelo.Checked = false;
            chkRickF.Checked = false;
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
