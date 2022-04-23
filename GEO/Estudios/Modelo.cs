using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace OriTrabajos.ESTUDIOS
{
    public partial class Modelo : Form
    {
        String factura = "";
        Carpeta carpetaEncontrada = null;
        Empleado empleado = null; //empleado logueado
       
        EntidadesCompartidas.Modelo modeloEncontrado = null;
        List<DataGridViewImageColumn> listaParaMostrar = new List<DataGridViewImageColumn>();
        List<Foto> listaDeFotosParaGuardar = new List<Foto>();
      //  DataGridViewImageColumn fotoSeleccionada = null;
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();

        public Modelo(Empleado empleadoLog)
        {

            InitializeComponent();
            empleado = empleadoLog;
        }

        private Image Redimensionar(Image Imagen, int Ancho, int Alto, int resolucion)
        {
            //Bitmap sera donde trabajaremos los cambios
            using (Bitmap imagenBitmap = new Bitmap(Ancho, Alto, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(resolucion, resolucion);
                //Hacemos los cambios a ImagenBitmap usando a ImagenGraphics y la Imagen Original(Imagen)
                //ImagenBitmap se comporta como un objeto de referenciado
                using (Graphics imagenGraphics = Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(Imagen, new Rectangle(0, 0, Ancho, Alto), new Rectangle(0, 0, Imagen.Width, Imagen.Height), GraphicsUnit.Pixel);
                    //todos los cambios hechos en imagenBitmap lo llevaremos un Image(Imagen) con nuevos datos a travez de un MemoryStream
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    Imagen = Image.FromStream(imagenMemoryStream);
                }
            }
            return Imagen;
        }

        private Image Redimensionar(Image image, int SizeHorizontalPercent, int SizeVerticalPercent)
        {
            //Obntenemos el ancho y el alto a partir del porcentaje de tamaño solicitado
            int anchoDestino = image.Width * SizeHorizontalPercent / 100;
            int altoDestino = image.Height * SizeVerticalPercent / 100;
            //Obtenemos la resolucion original 
            int resolucion = Convert.ToInt32(image.HorizontalResolution);

            return this.Redimensionar(image, anchoDestino, altoDestino, resolucion);
        }

        private void Modelo_Load(object sender, EventArgs e)
        {
            try
            {
                btnAgregar.Enabled = false;
                btnModificar1.Enabled = false;
                btnEliminar1.Enabled = false;
                
                DateTime result = DateTime.Today.Subtract(TimeSpan.FromDays(1));
                dtfechas.Value = result;

                cmbClinica.Items.Add("Cordon");
                cmbClinica.Items.Add("Pocitos");

                CmbLaboratorio.Items.Add("Pocitos");
                CmbLaboratorio.Items.Add("Paula");
                CmbLaboratorio.Items.Add("Otro");
                
            }
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //fp.getPModelo().EliminarModelo(modeloEncontrado);

                lblError.Text = "Se ha eliminado correctamente";
            }
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }


        private void chkMym_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMym.Checked)
            {
                CmbLaboratorio.SelectedItem = "Pocitos";
            }
        }

        private void chkEstudio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstudio.Checked)
            {
                CmbLaboratorio.SelectedItem = "Pocitos";
            }
        }

        private void chkPlaca_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlaca.Checked)
            {
                CmbLaboratorio.SelectedItem = "Pocitos";
            }
        }

        private void chkParaArticulador_CheckedChanged(object sender, EventArgs e)
        {
            if (chkParaArticulador.Checked)
            {
                CmbLaboratorio.SelectedItem = "Pocitos";
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            factura = txtFactura.Text;
            if (factura == "")
            {
                lblError.Text = "Debe ingresar el numero de factura";
            }
            try
            {
                carpetaEncontrada = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);

                if (carpetaEncontrada == null)
                {

                    LimpiarDatos();

                    lblError.Text = "No existe la carpeta con el numero de factura";
                    btnAgregar.Enabled = false;
                    btnModificar1.Enabled = false;
                    btnEliminar1.Enabled = false;
                    

                }
                else
                {
                    modeloEncontrado = Logica.FabricaLogica.getLogicaModelo().BuscarModelo(factura);

                    if (modeloEncontrado == null)
                    {
                        LimpiarDatos();
                        lblError.Text = "No existe el modelo, puede ingresar uno";
                        btnAgregar.Enabled = true;
                        btnEliminar1.Enabled = false;
                        btnModificar1.Enabled = false;


                    }
                    else
                    {
                        btnAgregar.Enabled = false;
                        btnModificar1.Enabled = true;
                        btnEliminar1.Enabled = true;


                        //muestro los datos
                        dtfechas.Value = modeloEncontrado.FechaRealizado;
                        dtFechaProm.Value = modeloEncontrado.FechaPrometida;



                        if (modeloEncontrado.ModeloYMedio == true)
                        {
                            chkMym.Checked = true;
                        }
                        else
                        {
                            chkMym.Checked = false;
                        }

                        if (modeloEncontrado.EstudioDeModelo == true)
                        {
                            chkEstudio.Checked = true;
                        }
                        else
                        {
                            chkEstudio.Checked = false;
                        }

                        if (modeloEncontrado.PlacaBase == true)
                        {
                            chkPlaca.Checked = true;
                        }
                        else
                        {
                            chkPlaca.Checked = false;
                        }

                        if (modeloEncontrado.ParaArticulador == true)
                        {
                            chkParaArticulador.Checked = true;
                        }
                        else
                        {
                            chkParaArticulador.Checked = false;
                        }

                        if (modeloEncontrado.Cerrada == true)
                        {
                            chkCerrada.Checked = true;
                        }
                        else
                        {
                            chkCerrada.Checked = false;
                        }

                        if (modeloEncontrado.TieneFotos==true)
                        {
                            chkTieneFotos.Checked = true;
                        }

                        cmbClinica.Text = modeloEncontrado.Clinica.ToString();

                        txtObservaciones.Text = modeloEncontrado.Observaciones.ToString();
                        if(modeloEncontrado.Laboratorio!="Paula" && modeloEncontrado.Laboratorio!="Pocitos")
                        {

                            CmbLaboratorio.Text = "Otro";

                            txtOtro.Enabled=true;
                           

                            txtOtro.Text = modeloEncontrado.Laboratorio.ToString();
                        }
                        
                         


                        /*
                        for (int i = 0; i < cmbClinica.Items.Count; i++)
                        {
                            if (cmbClinica.Items[i].ToString() == modeloEncontrado.Clinica.ToString())
                            {

                                cmbClinica.SelectedItem = cmbClinica.Items[i];
                            }
                        }

                        for (int i = 0; i < CmbLaboratorio.Items.Count; i++)
                        {
                            if (CmbLaboratorio.Items[i].ToString() == modeloEncontrado.Laboratorio.ToString())
                            {

                                CmbLaboratorio.SelectedItem = CmbLaboratorio.Items[i];
                            }
                        }
                        */


                    }
                }


            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            String factura = "";

            DateTime fechaRealizado = DateTime.Now;
            DateTime fechaPrometida = (DateTime.Now).AddDays(5);
            String observaciones="";
            bool tieneFotos = false; ;
            bool mym = false;
            bool estDeModelo = false;
            bool placaBase = false;
            bool paraArticulador = false;
            Empleado cerradoPor = null;

            String clinica = "";
            String laboratorio = "";

            bool cerrada = false;


            String mensaje = "Debe ingresar: ";

            factura = txtFactura.Text;
            if (factura == "")
            {
                mensaje = mensaje + "Factura; ";
            }

            fechaRealizado = dtfechas.Value;
            fechaPrometida = dtFechaProm.Value;


            if (chkMym.Checked) //modelo y medio
            {
                mym = true;
            }

            if (chkEstudio.Checked) //estudio de modelo
            {
                estDeModelo = true;
            }

            if (chkPlaca.Checked) //placa base
            {
                placaBase = true;
            }

            if (chkParaArticulador.Checked) //para articulador
            {
                paraArticulador = true;
            }

            try
            {
                clinica = cmbClinica.SelectedItem.ToString(); ;
                if (clinica == "")
                {
                    mensaje = mensaje + "Clinica; ";
                }
            }
            catch { mensaje += "Clinica; "; }

          

            try
            {
                laboratorio = CmbLaboratorio.SelectedItem.ToString();
                if (laboratorio == "")
                {
                    mensaje = mensaje + "Laboratorio; ";
                }
            }
            catch 
            {
                mensaje += "Laboratorio; ";
            }

           

            if (laboratorio == "Otro")
            {
                laboratorio = txtOtro.Text;
                if (txtOtro.Text == "")
                {
                    mensaje += "otro laboratorio; ";
                }
                
                
            }

            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradoPor = empleado;
            }
            else
            {
                Empleado sinempleado = new Empleado();
                sinempleado.Id = 1;
                cerrada = false;
                cerradoPor = sinempleado;
            }

            observaciones = txtObservaciones.Text;
            if (chkTieneFotos.Checked)
            {
                tieneFotos = true;
            }

            
            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    EntidadesCompartidas.Modelo nuevoModelo = new EntidadesCompartidas.Modelo(mym, estDeModelo, clinica, placaBase, paraArticulador, laboratorio, 1, fechaRealizado, fechaPrometida, cerrada, cerradoPor, carpetaEncontrada,tieneFotos,observaciones);

                    Logica.FabricaLogica.getLogicaModelo().AgregarModelo(nuevoModelo);

                    LimpiarDatos();

                    txtFactura.Text = "";
                    lblError.Text = "se ha ingresado correctamente el modelo a "+factura;


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

        private void LimpiarDatos()
        {
            dtFechaProm.Value = DateTime.Now;
            dtfechas.Value = DateTime.Now;

            chkCerrada.Checked = false;
            chkEstudio.Checked = false;
            chkMym.Checked = false;
            chkParaArticulador.Checked = false;
            chkPlaca.Checked = false;
            chkTieneFotos.Checked = false;

            cmbClinica.Text = "";
            CmbLaboratorio.Text = "";
            txtOtro.Enabled = false;
            lblFlecha.Text = "";

            txtObservaciones.Text = "";
        
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

        private void CmbLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbLaboratorio.Text == "Otro")
            {
                txtOtro.Enabled = true;
               

            }
            else {
                txtOtro.Enabled = false;
                lblFlecha.Text = "";
            }
        }

        private void btnModificar1_Click(object sender, EventArgs e)
        {
            String factura = "";

            DateTime fechaRealizado = DateTime.Now;
            DateTime fechaPrometida = (DateTime.Now).AddDays(5);
            String observaciones = "";
            bool tieneFotos = false; ;
            bool mym = false;
            bool estDeModelo = false;
            bool placaBase = false;
            bool paraArticulador = false;
            Empleado cerradoPor = null;

            String clinica = "";
            String laboratorio = "";

            bool cerrada = false;


            String mensaje = "Debe ingresar: ";

            factura = txtFactura.Text;
            if (factura == "")
            {
                mensaje = mensaje + "Factura; ";
            }

            fechaRealizado = dtfechas.Value;
            fechaPrometida = dtFechaProm.Value;


            if (chkMym.Checked) //modelo y medio
            {
                mym = true;
            }

            if (chkEstudio.Checked) //estudio de modelo
            {
                estDeModelo = true;
            }

            if (chkPlaca.Checked) //placa base
            {
                placaBase = true;
            }

            if (chkParaArticulador.Checked) //para articulador
            {
                paraArticulador = true;
            }

            clinica = cmbClinica.SelectedItem.ToString(); ;

            if (clinica == "")
            {
                mensaje = mensaje + "Clinica; ";
            }

            laboratorio = CmbLaboratorio.SelectedItem.ToString();

            if (laboratorio == "")
            {
                mensaje = mensaje + "Laboratorio; ";
            }

            if (laboratorio == "Otro")
            {
                laboratorio = txtOtro.Text;
                if (txtOtro.Text == "")
                {
                    mensaje += "otro laboratorio; ";
                }


            }

            if (chkCerrada.Checked)
            {
                cerrada = true;
                cerradoPor = empleado;
            }
            else
            {
                Empleado sinempleado = new Empleado();
                sinempleado.Id = 1;
                cerrada = false;
                cerradoPor = sinempleado;
            }

            observaciones = txtObservaciones.Text;
            if (chkTieneFotos.Checked)
            {
                tieneFotos = true;
            }


            if (mensaje == "Debe ingresar: ")
            {
                try
                {
                    EntidadesCompartidas.Modelo nuevoModelo = new EntidadesCompartidas.Modelo(mym, estDeModelo,clinica, placaBase, paraArticulador, laboratorio, modeloEncontrado.Id, fechaRealizado, fechaPrometida, cerrada, cerradoPor, carpetaEncontrada, tieneFotos, observaciones);

                    Logica.FabricaLogica.getLogicaModelo().ModificarModelo(nuevoModelo);

                    LimpiarDatos();

                    txtFactura.Text = "";
                    lblError.Text = "se ha modificado correctamente el modelo de" + factura;


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

    }
}
