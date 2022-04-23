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
    public partial class Tomografia : Form
    {
        

        String factura = "";
     
        
        Empleado tomadaPor = null;
        Empleado informadaPor = null;
        Empleado chequeadaPor = null;
        Empleado empleadoLogueado = null;
        Carpeta carpeta = null;
        EntidadesCompartidas.Tomografia tomo = null;

        public Tomografia(Empleado empleadoL)
        {
            
            InitializeComponent();
            empleadoLogueado = empleadoL;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                
                DateTime fechaRealizada = DateTime.Now;
                DateTime fechaPrometida = DateTime.Now;
               
                String orden = "";
                bool sinInforme = false;
                bool informe = false;
                int cantDeImpresiones = 0;
                int cantCds = 0;
                String patologia = "";
                
                bool cs3d = false;
                bool implant = false;
                bool invivo = false;
                String otroSoft = "";
                bool cerrada = false;
                String mens = "Debe ingresar: ";

                factura = txtFactura.Text;
                if (factura == "")
                {
                    mens = mens + " factura, ";
                }

 

                if (chkInforme.Checked)
                {

                    informe = true;

                }

                if (chkSinInforme.Checked)
                {
                    txtFecPrometida.Value = txtfecRealizada.Value;
                    sinInforme = true;
                    txtCantImpresiones.Text = "0";
                }
                else
                {
                    sinInforme = false;
                }

                fechaRealizada = txtfecRealizada.Value;
                fechaPrometida = txtFecPrometida.Value;
                orden = txtOrden.Text;

                if (orden == "")
                {
                    mens = mens + " orden, ";
                }

                try
                {
                    cantCds = Convert.ToInt32(txtCantCds.Text);
                    cantDeImpresiones = Convert.ToInt32(txtCantImpresiones.Text);
                }
                catch
                {
                    mens = mens + " cant de impresiones y/o cds, ";
                }

                if (chkPato.Checked)
                {
                    patologia = "Sin patologia";

                }
                else
                {
                    patologia = txtPatologias.Text;
                    if (patologia == "")
                    {
                        mens = mens + " patologia/s, ";
                    }
                }
                //falta tomada por y informada

                if (chkCs3d.Checked)
                {
                    cs3d = true;
                }
                else
                {
                    cs3d = false;
                }

                if (chkImplant.Checked)
                {
                    implant = true;
                }
                else
                {
                    implant = false;
                }

                if (chkinvivo.Checked)
                {
                    invivo = true;
                }
                else
                {
                    invivo = false;
                }

                otroSoft = txtOtroSoft.Text;

                Empleado cerradaPor = null;

                if (chkCerrada.Checked)
                {
                    cerrada = true;
                    cerradaPor = empleadoLogueado;
                }
                else
                {
                    cerrada = false;
                    cerradaPor = new Empleado();
                    cerradaPor.Id = 1;
                    cerradaPor.Apellido = " ";
                    cerradaPor.Nombre = " ";
                    
                }

                if (informadaPor == null)
                {
                    informadaPor = new Empleado();
                    informadaPor.Id=1;
                
                }
                if (chequeadaPor == null)
                {
                    chequeadaPor = new Empleado();
                    chequeadaPor.Id = 1;

                }
                if (tomadaPor == null)
                {
                    tomadaPor = new Empleado();
                    tomadaPor.Id = 1;

                }

                if (mens != "Debe ingresar: ")
                {
                    lblError.Text = mens;
                }
                else
                {
                    try
                    {
                        EntidadesCompartidas.Tomografia tomo = new EntidadesCompartidas.Tomografia(orden, cantDeImpresiones, informe, sinInforme, cantCds, patologia, tomadaPor, informadaPor,chequeadaPor, 0, fechaRealizada, fechaPrometida, cerrada, cerradaPor, carpeta, cs3d, implant, invivo, otroSoft);

                        Logica.FabricaLogica.getLogicaTomografia().AgregarTomografia(tomo);

                        limpiarDatos();
                        lblError.Text = "Tomo agregada correctamente a: " + tomo.Factura;
                        btnAgregar.Enabled = false;
                    }
                    catch(Exception es)
                    {
                        lblError.Text = "Error: " + es.Message; ;
                    }
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }

      

        private void Tomografia_Load(object sender, EventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;

                if (tomo != null)
                {
                    btnModificar.Enabled = true;
                }
                else
                {
                    btnModificar.Enabled = false;
                }
                btnEliminar.Enabled = false;


                List<String> listaTratamientos=new List<String>();

                listaTratamientos.Add("Implantes");
                listaTratamientos.Add("Cirugia");
                listaTratamientos.Add("Fractura");
                listaTratamientos.Add("Fisura");
                listaTratamientos.Add("Endodoncia");
                listaTratamientos.Add("Ortodoncia");
                listaTratamientos.Add("3eros molares");
                listaTratamientos.Add("3eros molares posicionamiento y/relacion con el canal mandibular");
                listaTratamientos.Add("Retenidos");
                listaTratamientos.Add("Evaluacion Injerto osea");

                foreach (String s in listaTratamientos)
                {
                    Button b = new Button();
                    b.AutoSize = true;
                    b.FlatStyle = FlatStyle.Flat;
                    b.Text = s;
                    b.Font = new Font("Microsoft Sans Serif", 7);
                    b.Click+=new EventHandler(b_Click);
                    flowLayoutPanel1.Controls.Add(b);
                
                }

                txtfecRealizada.Value = DateTime.Now;
                txtFecPrometida.Value = (DateTime.Now).AddDays(2);
            }
            catch
            {
                lblError.Text = "Error al listar Empleados y/o Odontologos";
            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            txtOrden.Text += ((Button)sender).Text;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.FabricaLogica.getLogicaTomografia().EliminarTomografia(tomo);

                limpiarDatos();
                lblError.Text = "Tomografia de " + tomo.Factura + " eliminada correctamente";
            }
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }

       

        private void UserControlSelectorDePiezas_Validating(object sender, CancelEventArgs e)
        {
            List<int> listaDePiezas = null;
            String seleccionMaxilares = "";
            String Piezas = "";

            try
            {
                seleccionMaxilares = UserControlSelectorDePiezas.SeleccionMaxilares();


                if (seleccionMaxilares != "")
                {
                    txtOrden.Text = seleccionMaxilares;
                }
                else
                {
                    listaDePiezas = UserControlSelectorDePiezas.SeleccionDePiezas();

                    foreach (int i in listaDePiezas)
                    {
                        Piezas = Piezas + i + ", ";

                        //GEO.Estudios.UCetiqueta etiq = new GEO.Estudios.UCetiqueta();
                        //etiq.CambiarEtiqueta(Convert.ToString(i));
                        //flow.Controls.Add(etiq);

                    }

                    txtOrden.Text = "Piezas :" + Piezas;
                   
                }

            }
            catch
            {
                lblError.Text = "Problemas para mostrar las piezas seleccionadas";
            }
        }

       

        private void btnModificar_Click(object sender, EventArgs e)
        {

            try
            {

                DateTime fechaRealizada = DateTime.Now;
                DateTime fechaPrometida = DateTime.Now;

                String orden = "";
                bool sinInforme = false;
                bool informe = false;
                int cantDeImpresiones = 0;
                int cantCds = 0;
                String patologia = "";

                bool cs3d = false;
                bool implant = false;
                bool invivo = false;
                String otroSoft = "";
                bool cerrada = false;
                String mens = "Debe ingresar: ";

                factura = txtFactura.Text;
                if (factura == "")
                {
                    mens = mens + " factura, ";
                }



                if (chkInforme.Checked)
                {

                    informe = true;

                }

                if (chkSinInforme.Checked)
                {
                    txtFecPrometida.Value = txtfecRealizada.Value;
                    sinInforme = true;
                    txtCantImpresiones.Text = "0";
                }
                else
                {
                    sinInforme = false;
                }

                fechaRealizada = txtfecRealizada.Value;
                fechaPrometida = txtFecPrometida.Value;
                orden = txtOrden.Text;

                if (orden == "")
                {
                    mens = mens + " orden, ";
                }

                try
                {
                    cantCds = Convert.ToInt32(txtCantCds.Text);
                    cantDeImpresiones = Convert.ToInt32(txtCantImpresiones.Text);
                }
                catch
                {
                    mens = mens + " cant de impresiones y/o cds, ";
                }

                if (chkPato.Checked)
                {
                    patologia = "Sin patologia";

                }
                else
                {
                    patologia = txtPatologias.Text;
                    if (patologia == "")
                    {
                        mens = mens + " patologia/s, ";
                    }
                }
                //falta tomada por y informada

                if (chkCs3d.Checked)
                {
                    cs3d = true;
                }
                else
                {
                    cs3d = false;
                }

                if (chkImplant.Checked)
                {
                    implant = true;
                }
                else
                {
                    implant = false;
                }

                if (chkinvivo.Checked)
                {
                    invivo = true;
                }
                else
                {
                    invivo = false;
                }

                otroSoft = txtOtroSoft.Text;

                Empleado cerradaPor = null;

                if (chkCerrada.Checked)
                {
                    cerrada = true;
                    cerradaPor = empleadoLogueado;
                }
                else
                {
                    cerrada = false;
                    cerradaPor = new Empleado();
                    cerradaPor.Id = 1;
                    cerradaPor.Apellido = " ";
                    cerradaPor.Nombre = " ";

                }

                if (informadaPor == null)
                {
                    informadaPor = new Empleado();
                    informadaPor.Id = 1;

                }
                if (chequeadaPor == null)
                {
                    chequeadaPor = new Empleado();
                    chequeadaPor.Id = 1;

                }
                if (tomadaPor == null)
                {
                    tomadaPor = new Empleado();
                    tomadaPor.Id = 1;

                }

                if (mens != "Debe ingresar: ")
                {
                    lblError.Text = mens;
                }
                else
                {
                    try
                    {
                        EntidadesCompartidas.Tomografia tomo1 = new EntidadesCompartidas.Tomografia(orden, cantDeImpresiones, informe, sinInforme, cantCds, patologia,tomo.TomadaPor, tomo.InformadaPor, tomo.ChequeadaPor,tomo.Id, fechaRealizada, fechaPrometida, cerrada, cerradaPor, carpeta, cs3d, implant, invivo, otroSoft);

                        Logica.FabricaLogica.getLogicaTomografia().ModificarTomografia(tomo1);

                        limpiarDatos();
                        lblError.Text = "Tomo modificada correctamente a: " + tomo.Factura;
                        btnAgregar.Enabled = false;
                    }
                    catch (Exception es)
                    {
                        lblError.Text = "Error: " + es.Message; ;
                    }
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
        }


        private void chkSinInforme_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCerrada.Checked)
            {
                txtFecPrometida.Value = DateTime.Now;
            }
            else
            {
                txtFecPrometida.Value = (DateTime.Now).AddDays(2);
            }
        }

        private void limpiarDatos()
        {
          
            txtOrden.Text = "";
            txtPatologias.Text = "";
            txtTomadaPor.Text = "";
            txtInformadaPor.Text = "";
            txtChequeadaPor.Text = "";
            txtCantCds.Text = "0";
            txtCantImpresiones.Text = "0";
            chkInforme.Checked = false;
            chkPato.Checked = false;
            chkCs3d.Checked = false;
            chkImplant.Checked = false;
            chkinvivo.Checked = false;
            chkCerrada.Checked = false;
            chkSinInforme.Checked = false;
            txtOtroSoft.Text = "";
            lblError.Text = "";


        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                factura = txtFactura.Text;

                if (factura == "")
                {
                    lblError.Text = "Debe ingresar el numero de factura";
                }
                else
                {
                    carpeta = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);
                    if (carpeta == null)
                    {
                        limpiarDatos();
                        lblError.Text = "No existe el numero de factura, puede ingresar uno nuevo";
                        
                        btnAgregar.Enabled = true;
                        btnModificar.Enabled = false;
                        btnEliminar.Enabled = false;
                    }
                    else
                    {
                        tomo = Logica.FabricaLogica.getLogicaTomografia().BuscarTomografia(factura);

                        if (tomo == null)
                        {
                            limpiarDatos();
                            lblError.Text = "No existe la tomo, puede ingresar una";

                            txtFactura.Text = factura;
                            btnAgregar.Enabled = true;
                            btnModificar.Enabled = false;
                            btnEliminar.Enabled = false;
                        }
                        else
                        {
                            limpiarDatos();
                            txtFactura.Text = factura;
                            btnAgregar.Enabled = false;
                            btnModificar.Enabled = true;
                            btnEliminar.Enabled = true;

                            //mostrar datos encontrados
                            txtfecRealizada.Value = tomo.FechaRealizado;
                            txtFecPrometida.Value = tomo.FechaPrometida;
                            txtOrden.Text = tomo.Orden.ToString();
                            if (tomo.Informe == true)
                            {
                                chkInforme.Checked = true;
                            }

                            if (tomo.SinInforme == true)
                            {
                                chkSinInforme.Checked = true;
                            }

                            txtCantImpresiones.Text = tomo.Impresiones.ToString();
                            txtCantCds.Text = tomo.Cds.ToString();

                            if (tomo.Patologia == "Sin patologia")
                            {
                                chkPato.Checked = true;
                                txtPatologias.Text = "Sin patologia";
                            }
                            else
                            {
                                txtPatologias.Text = tomo.Patologia.ToString();
                            }

                            txtTomadaPor.Text = tomo.TomadaPor.Datos;
                            txtTomadaPor.ForeColor = System.Drawing.Color.Black;
                            txtInformadaPor.Text = tomo.InformadaPor.Datos;
                            txtInformadaPor.ForeColor = System.Drawing.Color.Black;
                            txtChequeadaPor.Text = tomo.ChequeadaPor.Datos;
                            txtChequeadaPor.ForeColor = System.Drawing.Color.Black;


                            if (tomo.Cs3dImagingSoft == true)
                            {
                                chkCs3d.Checked = true;
                            }
                            else
                            {
                                chkCs3d.Checked = false;
                            }

                            if (tomo.ImplantViewerSoft == true)
                            {
                                chkImplant.Checked = true;
                            }
                            else
                            {
                                chkImplant.Checked = false;
                            }

                            if (tomo.InVivoSoft == true)
                            {
                                chkinvivo.Checked = true;
                            }
                            else
                            {
                                chkinvivo.Checked = false;
                            }

                            txtOtroSoft.Text = tomo.OtroSoft.ToString();

                            if (tomo.Cerrada == true)
                            {
                                chkCerrada.Checked = true;
                            }
                        }
                    }
                }
            }
            catch
            {
                lblError.Text = "No es posible buscar la tomografia";
            }
        }

        int contfac = 0;
        private void txt_Click(object sender, EventArgs e)
        {
            if (contfac == 0)
            {
                txtFactura.Text = "";
            }

            txtFactura.ForeColor = System.Drawing.Color.Black;
            contfac += 1;
        }

        private void btnTomada_Click(object sender, EventArgs e)
        {
            try
            {
                

                GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeEmpleado = form.ValorRetorno;

                    Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                    txtTomadaPor.Text = empleadoEncontrado.Datos.ToString();
                    tomadaPor =  empleadoEncontrado;

                    if (tomo!= null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                    {
                        tomo.TomadaPor = empleadoEncontrado;
                    }
                    txtTomadaPor.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
        }

        private void btnInformada_Click(object sender, EventArgs e)
        {
            try
            {
              

                GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeEmpleado = form.ValorRetorno;

                    Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                    txtInformadaPor.Text = empleadoEncontrado.Datos.ToString();
                    informadaPor = empleadoEncontrado;

                    if (tomo != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                    {
                        tomo.InformadaPor = empleadoEncontrado;
                    }

                    txtInformadaPor.ForeColor = System.Drawing.Color.Black;

                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
        }

        private void btnCheq_Click(object sender, EventArgs e)
        {
            try
            {
                

                GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
                if (form.ShowDialog() == DialogResult.OK)
                {

                    //retorno valores del paciente seleccionado
                    String idDeEmpleado = form.ValorRetorno;

                    Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                    txtChequeadaPor.Text = empleadoEncontrado.Datos.ToString();
                    chequeadaPor = empleadoEncontrado;

                    if (tomo != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                    {
                        tomo.ChequeadaPor=empleadoEncontrado;
                    }

                    txtChequeadaPor.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception es)
            { MessageBox.Show(es.Message); }
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
