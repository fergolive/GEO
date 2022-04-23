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
    public partial class ModificarEnviosyRetiros : Form
    {
        String tipo = "";
        String entregado = "";
        String entregadoOtro = "";
        Empleado empleadoLogueado = null;
        List<Carpeta> listaDeEnvios=null;

        public ModificarEnviosyRetiros(Empleado empleadolog)
        {
            InitializeComponent();
            empleadoLogueado = empleadolog;
        }

        private void ModificarEnviosyRetiros_Load(object sender, EventArgs e)
        {

         
            gridEstudios.AutoGenerateColumns = false;
            txtEntregadaOtro.Enabled = false;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.Document = new PrintDocument();
            PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
            printDialog1.Document = printDocument1;

            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                printDocument1.Print();
                
            }
        }

       
        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            
            int i = 0;
            //////////////////////////////////////

            // La fuente que vamos a usar para imprimir.
            
            float topMargin = e.MarginBounds.Top;
            //float yPos = 0;
            float linesPerPage = 0;
            int count = 0;
            
            DataGridViewRow row;

            // Calculamos el número de líneas que caben en cada página.
            linesPerPage = e.MarginBounds.Height / gridEstudios.Font.GetHeight(e.Graphics);
            
            Pen pen = new Pen(Color.Black, 1/2);
            int y = 100;
            int x = 50;
            int col = 0;
            
            //muestro datos de empresa y emplado
            String fecha="Fecha de envios: " + Convert.ToString(DateTime.Now.Date.ToShortDateString()) + "\n" + "Empresa de envios: Area" + "\n"+"Planilla impresa por: "+empleadoLogueado.Apellido +" "+empleadoLogueado.Nombre;
            
            
            e.Graphics.DrawString("Odonto Radiologia Integral - Envios", new Font("Arial",9), Brushes.Black, 100, 40);
            e.Graphics.DrawString(fecha, new Font(gridEstudios.Font.Name,7), Brushes.Gray, 110 , 55);

            //recorrer e imprimir cabezal
            foreach (DataGridViewCell celda in gridEstudios.Rows[0].Cells)
            {
                if (celda.ColumnIndex == 0)
                {
                    e.Graphics.DrawRectangle(pen, x, y, celda.Size.Width-30, celda.Size.Height - 5);
                    e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(x, y, celda.Size.Width-20, celda.Size.Height - 5));
                    e.Graphics.DrawString(gridEstudios.Columns[col].HeaderText, new Font(gridEstudios.Font.Name, 10), Brushes.Black, x, y);

                    x += celda.Size.Width-30;
                }
                else
                {
                    e.Graphics.DrawRectangle(pen, x, y, celda.Size.Width, celda.Size.Height - 5);
                    e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(x, y, celda.Size.Width, celda.Size.Height - 5));
                    e.Graphics.DrawString(gridEstudios.Columns[col].HeaderText, new Font(gridEstudios.Font.Name, 10), Brushes.Black, x, y);

                    x += celda.Size.Width;
                }
               
                col++;
            }

            
            y = 115;
            // Recorremos las filas del DataGridView hasta que llegemos
            // a las líneas que nos caben en cada página o al final del grid.
            while (count < linesPerPage && i < this.gridEstudios.Rows.Count)
            {
                row = gridEstudios.Rows[i];
               
                // Calculamos la posición en la que se escribe la línea
                //yPos = topMargin + (count * gridEstudios.Font.GetHeight(e.Graphics));

                // Create pen.
                x = 50;

                //imprimo filas del grid view
                foreach (DataGridViewCell celda in row.Cells)
                {
                    if(celda.ColumnIndex==0)
                    {
                        e.Graphics.DrawRectangle(pen, x, y, celda.Size.Width-30, celda.Size.Height-5);
                        e.Graphics.DrawString(celda.Value.ToString(), new Font(gridEstudios.Font.Name,9), Brushes.Black, x, y+2);

                        x += celda.Size.Width-30;
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(pen, x, y, celda.Size.Width, celda.Size.Height - 5);
                        e.Graphics.DrawString(celda.Value.ToString(), new Font(gridEstudios.Font.Name, 9), Brushes.Black, x, y+2);

                        x += celda.Size.Width;
                        
                    }
                    
                    
                }

                count++;
                y += gridEstudios.Rows[i].Height-5;
                i++;
                
            }
            

            // Una vez fuera del bucle comprobamos si nos quedan más filas 
            // por imprimir, si quedan saldrán en la siguente página
            if (i < this.gridEstudios.Rows.Count)
                e.HasMorePages = true;
            else
            {
                // si llegamos al final, se establece HasMorePages a 
                // false para que se acabe la impresión
                e.HasMorePages = false;

                // Es necesario poner el contador a 0 porque, por ejemplo si se hace 
                // una impresión desde PrintPreviewDialog, se vuelve disparar este 
                // evento como si fuese la primera vez, y si i está con el valor de la
                // última fila del grid no se imprime nada
                i = 0;
            }
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
                lblError2.Text = "No se pudo habiliatr el campo otro";
            }
        }


   

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            String mensaje = "Debe ingresar: ";
            tipo = "";
            entregado = "";
            entregadoOtro = "";

            try
            {
                foreach (Control control in Tipo.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radio = control as RadioButton;

                        if (radio.Checked)
                        {
                            tipo = radio.Text;
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
                   
                    listaDeEnvios = Logica.FabricaLogica.getLogicaCarpeta().ListarEnviosPendientes(tipo, entregado);
                    if (listaDeEnvios == null)
                    {
                        gridEstudios.DataSource = null;
                        lblError2.Text = "No hay resultados";
                    }
                    else
                    {
                       
                        gridEstudios.DataSource = null;
                        gridEstudios.DataSource = listaDeEnvios;

                    }
                }
                else
                {
                    lblError2.Text = mensaje;
                }
            }
            catch (Exception es)
            {
                lblError2.Text = es.Message;
            }
        }



        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona el tipo y destino del estudio en la lista de la izquierda, luego presiones buscar");
        }


        List<Carpeta> listaModificadas=null;

      
           

        private void gridEstudios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {
                bool retirada = false;
                bool enviada = false;

                if (gridEstudios.CurrentRow.Cells[2].Value.ToString() == "True")//enviada
                { enviada = true; }


                if (gridEstudios.CurrentRow.Cells[3].Value.ToString() == "True")//retirada
                { retirada = true; }


                int indiceFila = gridEstudios.CurrentRow.Index; //guardo indiece de la fila

                if (gridEstudios.CurrentRow.Cells[4].Value.ToString() != "")
                {
                    lblError2.Text = "";
                    gridEstudios.CurrentRow.Cells[4].Style.BackColor = System.Drawing.Color.White;


                    String factura = gridEstudios.CurrentRow.Cells[0].Value.ToString();
                    String paciente = gridEstudios.CurrentRow.Cells[1].Value.ToString();
                    String direopers = gridEstudios.CurrentRow.Cells[4].Value.ToString();


                    for (int i = 0; i < listaDeEnvios.Count; i++)
                    {
                        if (listaDeEnvios[i].NumDeFactura == factura) //controlo factura y paciente
                        {
                            if (retirada == true) { listaDeEnvios[i].Retirada = true; }
                            if (enviada == true) { listaDeEnvios[i].Enviada = true; }

                            listaDeEnvios[i].Direccion_Persona_EnvRet = direopers;

                            Logica.FabricaLogica.getLogicaCarpeta().ModificarEnviasRetiras(listaDeEnvios[i]);
                            listaDeEnvios.RemoveAt(indiceFila);
                            gridEstudios.Refresh();
                            i = listaDeEnvios.Count + 1;
                        }
                    }


                }
                else
                {
                    gridEstudios.CurrentRow.Cells[4].Style.BackColor = System.Drawing.Color.LightSalmon;
                    lblError2.Text = "Falta ingresr la direccion de envio o persona que lo recibe";
                }
            }
        }

  
        
       
        
    }
}
