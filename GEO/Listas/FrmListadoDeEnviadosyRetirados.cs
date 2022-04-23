using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

namespace GEO.Listas
{
    public partial class FrmListadoDeEnviadosyRetirados : Form
    {

        List<EntidadesCompartidas.Carpeta> listaDeCarpetas = null;


        public FrmListadoDeEnviadosyRetirados()
        {
            InitializeComponent();
        }

        private void FrmListadoDeEnviadosyRetirados_Load(object sender, EventArgs e)
        {

            BuscarCarpetas();
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            BuscarCarpetas();
            
        }

        private void BuscarCarpetas()
        {
            try
            {

                GEO.Busqueda.FrmFiltroEnviados filtro = new GEO.Busqueda.FrmFiltroEnviados();
                if (filtro.ShowDialog() == DialogResult.OK)
                {
                   String consulta = filtro.ValorRetorno;
                    listaDeCarpetas = Logica.FabricaLogica.getLogicaCarpeta().BuscarCarpetas(consulta);

                   lblResultados.Text = listaDeCarpetas.Count + " Resultados";
                   gridEnviados.DataSource = listaDeCarpetas;

                   gridEnviados.Columns[0].ReadOnly = true;
                   gridEnviados.Columns[1].ReadOnly = true;
                   gridEnviados.Columns[2].ReadOnly = true;
                   gridEnviados.Columns[3].ReadOnly = true;
                   gridEnviados.Columns[4].ReadOnly = true;
                   gridEnviados.Columns[5].ReadOnly = true;
                   gridEnviados.Columns[6].ReadOnly = true;
                   gridEnviados.Columns[7].ReadOnly = true;
                   gridEnviados.Columns[8].ReadOnly = true;
                   gridEnviados.Columns[9].ReadOnly = true;
                   gridEnviados.Columns[10].ReadOnly = true;
                   gridEnviados.Columns[11].ReadOnly = true;
                }

            }
            catch(Exception es) 
            {
                MessageBox.Show("Error al realizar la busqueda: " + es.Message);
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("haz click en Filtrar para buscar carpetas por nro de factura, fecha, tipo, etc..");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool enviado=false;
            bool retirado=false;

            try
            {
                for (int i = 0; i < gridEnviados.Rows.Count; i++)
                {

                    if (gridEnviados.Rows[i].Cells[12].Value.ToString() == "True" || gridEnviados.Rows[i].Cells[12].Value.ToString() == "True") //enviado
                    {
                        if(gridEnviados.Rows[i].Cells[12].Value.ToString() == "True"){enviado=true;}
                        

                        if (gridEnviados.Rows[i].Cells[14].Value.ToString() != "") //direccion o persona
                        {
                            gridEnviados.Rows[i].Cells[14].Style.BackColor = System.Drawing.Color.White;
                            gridEnviados.Rows[i].Cells[13].Style.BackColor = System.Drawing.Color.White;
                            lblError.Text = "";

                            String factura = gridEnviados.Rows[i].Cells[0].Value.ToString();
                            String paciente = gridEnviados.Rows[i].Cells[9].Value.ToString();
                            String direopers = gridEnviados.Rows[i].Cells[14].Value.ToString();

                            foreach (Carpeta carpeta in listaDeCarpetas)
                            {
                                if (carpeta.NumDeFactura == factura) //controlo factura y paciente
                                {
                                    carpeta.Direccion_Persona_EnvRet = direopers;

                                    if (enviado == true)
                                    { carpeta.Enviada = true; }
                                    else
                                    { carpeta.Retirada = true; }
                                }
                            }
                        }
                        else
                        {
                            gridEnviados.Rows[i].Cells[14].Style.BackColor = System.Drawing.Color.Red;
                            lblError.Text = "falta/n algun/os campos por llenar";
                        }
                    }
                }

                if (lblError.Text == "")
                {
                    foreach (Carpeta carpet in listaDeCarpetas)
                    {
                        Logica.FabricaLogica.getLogicaCarpeta().ModificarEnviasRetiras(carpet);
                    }
                }
            }
            catch
            {
            }
        }


           

                
      

      

    }
}
