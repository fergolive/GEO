using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEO.Busqueda
{
    public partial class FrmFiltroEnviados : Form
    {
        public FrmFiltroEnviados()
        {
            InitializeComponent();
        }

        List<String> ListaDeConsultas = new List<String>();
        String consulta = "";
        String consulta1;
        String consulta2="";
   

       

        private void FrmFiltroEnviados_Load(object sender, EventArgs e)
        {

            consulta = "Select * from Carpeta where";
            
        }


        private void chkFac_CheckedChanged(object sender, EventArgs e)
        {
            
            consulta1 = " Factura= " + "'" + txtFactura.Text + "'";

            if (chkFac.Checked == false)
            {
                BorrarItem(consulta1);
            }
            if (chkFac.Checked)
            {                  
               AgregarItem(consulta1);
            }
            
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {

            consulta1 = " FechaRealizada=" + "'" + Convert.ToString(dtFecha.Value) + "'";


            if (chkFecha.Checked)
            {
                AgregarItem(consulta1);
            }
            if (chkFecha.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void chkdir_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " DireccionDeEnvio=" + "'" + txtDireccion.Text + "'";

            if (chkdir.Checked)
            {
                
                AgregarItem(consulta1);
            }
            if (chkdir.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " EntregadoA=" + "'" + txtEntregado.Text + "'";

            if (chkEntregado.Checked)
            {
                
                AgregarItem(consulta1);
            }
            if (chkEntregado.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void chkCerradaPor_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " Carpeta.CerradaPor=" + "'" + txtCerradaPor.Text + "'";
            if (chkCerradaPor.Checked)
            {
                
                AgregarItem(consulta1);
            }
            if (chkCerradaPor.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void chkClinica_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " Carpeta.Clinica=" + "'" + txtClinica.Text + "'";
            if (chkClinica.Checked)
            {
                
                AgregarItem(consulta1);
            }
            if (chkClinica.Checked==false)
            {
                BorrarItem(consulta1);
            }
        }

        private void rbtCordon_CheckedChanged(object sender, EventArgs e)
        {
            consulta2 = " Carpeta.Tipo=" + "'" + "Retira Cordon" + "'";

            if (rbtCordon.Checked)
            {
                BorrarItem(consulta2);
            }
            if (rbtCordon.Checked == false)
            {
                AgregarItem(consulta2);
            }
        }

        private void rbtPocitos_CheckedChanged(object sender, EventArgs e)
        {
            consulta2 = " Carpeta.Tipo=" + "'" + "Retira Pocitos" + "'";


            if (rbtPocitos.Checked == false)
            {
                BorrarItem(consulta2);
            }
            if (rbtPocitos.Checked)
            {

                AgregarItem(consulta2);
            }
        }

        private void rbtEnvia_CheckedChanged(object sender, EventArgs e)
        {
            consulta2 = " Carpeta.Tipo=" + "'" + "Envia" + "'";

            if (rbtEnvia.Checked)
            {
                AgregarItem(consulta2);

            }
            if (rbtEnvia.Checked == false)
            {
                BorrarItem(consulta2);
            }
        }

        private void rbtnInt_CheckedChanged(object sender, EventArgs e)
        {

            consulta2 = " Carpeta.Tipo=" + "'" + "Interior" + "'";


            if (rbtnInt.Checked == false)
            {
                BorrarItem(consulta2);
            }
            if (rbtnInt.Checked)
            {
                AgregarItem(consulta2);
            }
        }

        private void chkCerrada_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " Carpeta.Cerrada=1";
            if (chkCerrada.Checked)
            {
                
                AgregarItem(consulta1);
            }
            if (chkCerrada.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        public string ValorRetorno { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
           ValorRetorno=CrearConsultaBD();
           DialogResult = DialogResult.OK;
           this.Close();
        }

       

        

        private void AgregarItem(String consultaN)
        {

           ListaDeConsultas.Add(consultaN);
           ListaDeConsultas.Add(" and ");
                                      
        }

        private void BorrarItem(String consultaN)
        {
            
                //obtengo el indice
                int indice = ListaDeConsultas.IndexOf(consultaN);
                //borro el elemento
                ListaDeConsultas[indice + 1] = null;
                ListaDeConsultas[indice] = null;

                for (int i = indice; i <= ListaDeConsultas.Count-3; i++)
                {
                    ListaDeConsultas[i] = ListaDeConsultas[i + 2];
                    ListaDeConsultas[i + 2] = null;

                    
                }

                ListaDeConsultas.Remove(ListaDeConsultas[ListaDeConsultas.Count - 1]);
                ListaDeConsultas.Remove(ListaDeConsultas[ListaDeConsultas.Count - 1]);
             
        
        }

        private String CrearConsultaBD()
        {
            
            consulta = "Select * from Carpeta where";
           

            foreach (String consul in ListaDeConsultas)
            {

                consulta += consul;
            
            }


            consulta = consulta.Remove(consulta.Length - 4);
            return consulta;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1) rellenar los campos de texto de los datos que queremos usar para la busqueda \n\n2) chequear a la izquiera los datos que vamos a usarluego de ser rellenados \n\nEn tipo de carpeta si queremos podemos indicar si es retira o envia y finalizada es para carpetas que ya estan terminadas y al final presionamos aceptar para realizar la busqueda o la cancelamos \n\n En caso de que hayamos indicado retira o envia y quieramos desmarcar la opcion debemos cerrar  y abrir nuevamente la ventana");
        }

        

       
            

      
    }
}
