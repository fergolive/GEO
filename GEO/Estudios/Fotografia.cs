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
    public partial class Fotografia : Form
    {
        public Fotografia(Empleado EmpleadoLogueado)
        {
            InitializeComponent();
            empleadoLog = EmpleadoLogueado;
        }

        List<Empleado> listaDeEmpleados = null;
        String factura = "";
        List<DataGridViewImageColumn> listaParaMostrar = new List<DataGridViewImageColumn>();
        List<Foto> listaDeFotosParaGuardar = new List<Foto>();
       
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        Carpeta carpeta = null;
       
        EntidadesCompartidas.Fotografia EstFotografiaEncontrada = null;
        Empleado cerradoPor = null;
        Empleado empleadoLog = null;
        Empleado limpiadoPor = null;
        Empleado emplantilladoPor = null;
        Empleado impresoPor = null;

        public static byte[] convertiraBytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
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

      


        public static Image convertiraImage(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }

       

      

       

        public AutoCompleteStringCollection AutocompleteEmpleados() //odontologos
        {

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();

            foreach (Empleado odo in listaDeEmpleados)
            {
                coleccion.Add(odo.ToString());
            }

            return coleccion;
        }

        private void Fotografia_Load(object sender, EventArgs e)
        {
            try
            {
                btnModificar.Enabled = false;
                btnEliminar1.Enabled = false;
               
               
            }
            catch
            {
                lblError.Text="Error al cargar botones";
            }
        }


        private void btnAgregrar_Click(object sender, EventArgs e)
        {
            try
            {
                String factura = "";
                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometida = DateTime.Now;

                bool frentePerfilSonrisa = false;
                bool intrabucal = false;
                bool Overs = false;
                bool submenton = false;
                bool cerrado = false;

                
                if ((txtImpresoPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtImpresoPor.Text == ""))
                {
                    impresoPor = new Empleado();
                    impresoPor.Id = 1;
                }
                if ((txtLimpiadorPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtLimpiadorPor.Text == ""))
                {
                     limpiadoPor = new Empleado();
                    limpiadoPor.Id = 1;
                }
                if ((txtEmpantilladoPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtEmpantilladoPor.Text == ""))
                {
                     emplantilladoPor = new Empleado();
                    emplantilladoPor.Id = 1;
                }
             
                factura = txtFactura.Text;

                if (factura == "")
                {
                    lblError.Text = "No ha ingresado la factura";
                }

                fechaPrometida = dtFechaProm.Value;
                fechaRealizado = dtFechaRealiz.Value;

                if (chkFPS.Checked)
                {
                    frentePerfilSonrisa = true;
                }
                if (chkIntrabucal.Checked)
                {
                    intrabucal = true;
                }
                if (chkOvers.Checked)
                {
                    Overs = true;
                }

                if (chkSubmenton.Checked)
                {
                    submenton = true;
                }


                if (chkCerrado.Checked)
                {
                    cerrado = true;
                    cerradoPor = empleadoLog;
                }
                else
                {
                    Empleado sinEmpleado = new Empleado();
                    sinEmpleado.Id = 1;
                    cerradoPor = sinEmpleado;
                    cerrado = false;
                }


                EntidadesCompartidas.Fotografia nuevaFotografia = new EntidadesCompartidas.Fotografia(frentePerfilSonrisa, intrabucal, Overs, submenton, limpiadoPor, emplantilladoPor, impresoPor, 0, fechaRealizado, fechaPrometida, cerrado, cerradoPor, carpeta);

                Logica.FabricaLogica.getLogicaFotografia().AgregarFotografia(nuevaFotografia);

                
                LimpiarDatos();

                lblError.Text = "Se agrego correctamente el estudio de " +factura;
                txtFactura.Text = "";
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                String factura = "";
                DateTime fechaRealizado = DateTime.Now;
                DateTime fechaPrometida = DateTime.Now;

                bool frentePerfilSonrisa = false;
                bool intrabucal = false;
                bool Overs = false;
                bool submenton = false;
               
                bool cerrado = false;
                

                String mensaje = "Debe ingresar: ";

                if ((txtImpresoPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtImpresoPor.Text == ""))
                {
                    impresoPor = new Empleado();
                    impresoPor.Id = 1;
                }
                if ((txtLimpiadorPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtLimpiadorPor.Text == ""))
                {
                    limpiadoPor = new Empleado();
                    limpiadoPor.Id = 1;
                }
                if ((txtEmpantilladoPor.Text == "Busque un Empleado haciendo click en la lupa") || (txtEmpantilladoPor.Text == ""))
                {
                    emplantilladoPor = new Empleado();
                    emplantilladoPor.Id = 1;
                }

                factura = txtFactura.Text;
                if (factura == "")
                {
                    mensaje += "No ha ingresado la factura";
                }

                fechaPrometida = dtFechaProm.Value;
                fechaRealizado = dtFechaRealiz.Value;

                if (chkFPS.Checked)
                {
                    frentePerfilSonrisa = true;
                }
                if (chkIntrabucal.Checked)
                {
                    intrabucal = true;
                }
                if (chkOvers.Checked)
                {
                    Overs = true;
                }

                if (chkSubmenton.Checked)
                {
                    submenton = true;
                }

              
                if (chkCerrado.Checked)
                {
                    cerrado = true;
                    cerradoPor = empleadoLog;
                }
                else
                {
                    Empleado sinEmpleado = new Empleado();
                    sinEmpleado.Id = 1;
                    cerradoPor = sinEmpleado;
                    cerrado = false;
                }


                    if (mensaje == "Debe ingresar: ")
                    {
                        EntidadesCompartidas.Fotografia nuevaFotografia = new EntidadesCompartidas.Fotografia(frentePerfilSonrisa, intrabucal, Overs, submenton,EstFotografiaEncontrada.LimpiadoPor, EstFotografiaEncontrada.EmplantilladoPor,EstFotografiaEncontrada.ImpresoPor, EstFotografiaEncontrada.Id, fechaRealizado, fechaPrometida, cerrado, cerradoPor, carpeta);

                        Logica.FabricaLogica.getLogicaFotografia().ModificarFotografia(nuevaFotografia);


                        LimpiarDatos();

                        lblError.Text = "Se modifico correctamente el estudio de" + factura;

                    }
                    else
                    { lblError.Text = mensaje; }

            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            try
            {
                Logica.FabricaLogica.getLogicaFotografia().EliminarFotografia(EstFotografiaEncontrada);

                LimpiarDatos();
                lblError.Text = "Se ha eliminado correctamente el estudio";
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();

            factura = txtFactura.Text;
            if (factura == "")
            {
                lblError.Text = "Debe ingresar el numero de factura";
            }

            try
            {
                carpeta = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpeta(factura);

                if (carpeta == null)
                {

                    LimpiarDatos();
                    btnAgregrar.Enabled = false;
                    lblError.Text = "No existe una carpeta con ese numero de factura";

                }
                else
                {
                    EstFotografiaEncontrada = Logica.FabricaLogica.getLogicaFotografia().BuscarFotografia(factura);

                    if (EstFotografiaEncontrada == null)
                    {
                        lblError.Text = "No existe el estudio, puede ingrese uno";
                        btnEliminar1.Enabled = false;
                        btnModificar.Enabled = false;
                        btnAgregrar.Enabled = true;
                        
                        

                    }
                    else
                    {
                        LimpiarDatos();
                        btnEliminar1.Enabled = true;
                        btnModificar.Enabled = true;
                      
                        lblError.Text = "Estudio encontrado!!!";

                        //muestro los datos
                        dtFechaProm.Value = EstFotografiaEncontrada.FechaPrometida;
                        dtFechaRealiz.Value = EstFotografiaEncontrada.FechaRealizado;


                        if (EstFotografiaEncontrada.Cerrada == true)
                        {
                            chkCerrado.Checked = true;
                        }

                        if (EstFotografiaEncontrada.Intrabucal == true)
                        {
                            chkIntrabucal.Checked = true;
                        }

                        if (EstFotografiaEncontrada.OverJet_y_OverBite == true)
                        {
                            chkOvers.Checked = true;
                        }

                        if (EstFotografiaEncontrada.Submenton == true)
                        {
                            chkSubmenton.Checked = true;
                        }


                        if (EstFotografiaEncontrada.FrentePerfilSonrisa == true)
                        {
                            chkFPS.Checked = true;
                        }

                        txtImpresoPor.Text = EstFotografiaEncontrada.ImpresoPor.Datos;
                        txtLimpiadorPor.Text = EstFotografiaEncontrada.LimpiadoPor.Datos;
                        txtEmpantilladoPor.Text = EstFotografiaEncontrada.EmplantilladoPor.Datos;

                    }
                }


            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }

        private void LimpiarDatos()
        {

            dtFechaProm.Value = DateTime.Now;
            dtFechaRealiz.Value = DateTime.Now;
            
      
            chkCerrado.Checked = false;
            chkFPS.Checked = false;
            chkIntrabucal.Checked = false;
            chkOvers.Checked = false;
            chkSubmenton.Checked = false;

            btnModificar.Enabled = false;
            btnEliminar1.Enabled = false;

            txtEmpantilladoPor.Text = "Busque un Empleado haciendo click en la lupa";
            txtLimpiadorPor.Text = "Busque un Empleado haciendo click en la lupa";
            txtImpresoPor.Text = "Busque un Empleado haciendo click en la lupa";


            lblError.Text = "";
         
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

        private void button3_Click(object sender, EventArgs e)
        {
            GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
            if (form.ShowDialog() == DialogResult.OK)
            {

                //retorno valores del paciente seleccionado
                String idDeEmpleado = form.ValorRetorno;

                Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                txtLimpiadorPor.Text = empleadoEncontrado.Datos.ToString();
                limpiadoPor = empleadoEncontrado;

                if (EstFotografiaEncontrada != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                {
                    EstFotografiaEncontrada.LimpiadoPor = empleadoEncontrado;
                }

                txtLimpiadorPor.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
            if (form.ShowDialog() == DialogResult.OK)
            {

                //retorno valores del paciente seleccionado
                String idDeEmpleado = form.ValorRetorno;

                Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                txtEmpantilladoPor.Text = empleadoEncontrado.Datos.ToString();
                emplantilladoPor = empleadoEncontrado;

                if (EstFotografiaEncontrada != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                {
                    EstFotografiaEncontrada.EmplantilladoPor = empleadoEncontrado;
                }

                txtEmpantilladoPor.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GEO.Busqueda.frmBusquedaEmpleados form = new GEO.Busqueda.frmBusquedaEmpleados();
            if (form.ShowDialog() == DialogResult.OK)
            {

                //retorno valores del paciente seleccionado
                String idDeEmpleado = form.ValorRetorno;

                Empleado empleadoEncontrado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleadoPorId(Convert.ToInt32(idDeEmpleado));
                txtImpresoPor.Text = empleadoEncontrado.Datos.ToString();
                impresoPor = empleadoEncontrado;

                if (EstFotografiaEncontrada != null)//si encontro la carpeta en la busqueda.... (ya que para modificar se usa la carp encontrada)
                {
                    EstFotografiaEncontrada.ImpresoPor = empleadoEncontrado;
                }

                txtImpresoPor.ForeColor = System.Drawing.Color.Black;
            }
        }

        

        



    }
}
