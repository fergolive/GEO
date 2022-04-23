using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

using System.Drawing.Printing;
using System.Web;

namespace OriTrabajos.LISTAS
{
    public partial class EnviosyRetirosDiarios : Form
    {

        String titulo="";
        List<Carpeta> listaDeEnvios = null;
        Empleado empleadoLogueado = null;
        DataGridViewPrinter MyDataGridViewPrinter;


        public EnviosyRetirosDiarios(Empleado empleadolog)
        {
            InitializeComponent();
            empleadoLogueado = empleadolog;
        }

        private void EnviosyRetirosDiarios_Load(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            btnPrintPreview.Enabled = false;
            
            gridEstudios.AutoGenerateColumns = false;
            txtEntregadaOtro.Enabled = false;


            gridEstudios.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            gridEstudios.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            gridEstudios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            gridEstudios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridEstudios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridEstudios.DefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular, GraphicsUnit.Point);
            gridEstudios.DefaultCellStyle.BackColor = Color.Empty;
            gridEstudios.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            gridEstudios.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridEstudios.GridColor = SystemColors.ControlDarkDark;
            
            gridEstudios.Columns[gridEstudios.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Adjusting each column to be fit as the content of all its cells, including the header cell
            gridEstudios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }

        private void rbtOtro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtOtro.Checked)
                {
                    txtEntregadaOtro.Enabled = true;
                }
                else
                {
                    txtEntregadaOtro.Enabled = false;
                }
            }
            catch
            {
                lblerror.Text = "No se pudo habiliatr el campo otro";
            }
        }
        /////////////////////////////////////////////////////
        
        //nuevos objetos globales para imprimir el gridview

        /////////////////////////////////////////////////////

        // The printing setup function
        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = "Carpetas Pendientes"; 
            MyPrintDocument.PrinterSettings = MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);
/*
            if (MessageBox.Show("Do you want the report to be centered on the page",
                "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
*/
                gridEstudios.Columns[4].Visible = false;
         

                MyDataGridViewPrinter = new DataGridViewPrinter(gridEstudios,
                    MyPrintDocument, true, true, titulo, new Font("Tahoma", 13,
                    FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            /*
            else
                MyDataGridViewPrinter = new DataGridViewPrinter(gridEstudios,
                MyPrintDocument, false, true, "Carpetas", new Font("Tahoma", 18,
                FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            */
            return true;
        }

        



        private void MyPrintDocument_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            String mensaje = "Debe ingresar: ";
            String tipo = "";
            String entregado = "";
            String entregadoOtro = "";

            try
            {
                foreach (Control control in groupTipos.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;

                        if (radio.Checked)
                        {
                            tipo = radio.Text;
                            titulo = "Carpetas " + tipo + " pendientes, para ";

                        }
                    }
                }

                if (tipo == "")
                {
                    mensaje = mensaje + "tipo, ";
                }

                foreach (Control control in groupEntregada.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;

                        if (radio.Checked)
                        {
                            entregado = radio.Text;
                            titulo += entregado;
                        }
                    }
                }

                if (entregado == "")
                {
                    mensaje = mensaje + "tipo, ";
                }
                else if (entregado == "Otro")
                {
                    entregadoOtro = txtEntregadaOtro.Text;
                    if (entregadoOtro == "")
                    {
                        mensaje = mensaje + "Otro, ";
                    }
                    else
                    {
                        entregado = entregadoOtro;
                    }
                }

                if (mensaje == "Debe ingresar: ")
                {
                   //aca
                    listaDeEnvios = Logica.FabricaLogica.getLogicaCarpeta().ListarEnviosPendientes(tipo, entregado);

                    if (listaDeEnvios == null)
                    {
                        gridEstudios.DataSource = null;
                        btnPrint.Enabled = false;
                        btnPrintPreview.Enabled = false;
                    }
                    else
                    {
                        gridEstudios.DataSource = null;
                        gridEstudios.DataSource = listaDeEnvios;

                        btnPrint.Enabled = true;
                        btnPrintPreview.Enabled = true;
                    }
                }
                else
                {
                    lblerror.Text = mensaje;
                }
            }
            catch (Exception es)
            {
                lblerror.Text = es.Message;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = MyPrintDocument;
                MyPrintPreviewDialog.ShowDialog();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetupThePrinting())
                    MyPrintDocument.Print();

            }
            catch (Exception es)
            {
                lblerror.Text = es.Message;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona el tipo y destino del estudio en la lista de la izquierda, luego presiona Listar, Si en la lista aparecen carpetas pendientes pero no las quieres enviar, las eliminas de la lista con el icono 'tacho de bazura' de la ultima columna, esos cambios no se guardaran, solamente se veran reflejados en la impresion, si quieres obtener nuevamente los datos antiguos presiona 'Listar'. Pero si la fecha prometida ha cambiado lo mas recomendable es que vayas al formulario de carpetas y cambies la fecha prometida de la misma para que no te aparezca en pendientes.");
        }

        private void gridEstudios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 4)
                {
                    int indiceFila = gridEstudios.CurrentCell.RowIndex;
                    String fac = gridEstudios.Rows[indiceFila].Cells["Factura"].Value.ToString();


                    for (int i = 0; i < listaDeEnvios.Count; i++)
                    {

                        if (listaDeEnvios[i].NumDeFactura == fac)
                        {
                            listaDeEnvios.RemoveAt(indiceFila);
                            i = listaDeEnvios.Count + 1;//salir del foreach
                        }

                    }

                    gridEstudios.DataSource = listaDeEnvios;
                    gridEstudios.Refresh(); 
                   
                }
            }
            catch(Exception es)
            { MessageBox.Show(es.Message); }
        }

        
        
    }
}
