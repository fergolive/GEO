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
    public partial class FrmFiltroEstudios : Form
    {
        List<String> ListaDeConsultas = new List<String>();
        String consulta = "";
        string consulta1 = "";

        public FrmFiltroEstudios()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


        public string ValorRetorno { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            ValorRetorno = CrearConsultaBD();
            DialogResult = DialogResult.OK;
            this.Close();
        }


        //INICIAR CONSULTAS, SELECCION DEL TIPO DE ESTUDIO-------------------------


        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from Tomografia inner join .... ";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from Tomografia ";
            GroupDatos.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from NemoDocViewer ";
            GroupDatos.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from Modelo ";
            GroupDatos.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from Fotografia ";
            GroupDatos.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            consulta = "Select * from Oxi ";
            GroupDatos.Enabled = true;
        }


        //HABILITAR CAMPOS---------------------------------------------------------


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

        private void chkFechaRealiz_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " FechaRealizada=" + "'" + Convert.ToString(txtFechaRealiz.Value) + "'";


            if (chkFechaRealiz.Checked)
            {
                AgregarItem(consulta1);
            }
            if (chkFechaRealiz.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void chkFechaProm_CheckedChanged(object sender, EventArgs e)
        {
            consulta1 = " FechaPrometida=" + "'" + Convert.ToString(txtFechaProm.Value) + "'";


            if (chkFechaProm.Checked)
            {
                AgregarItem(consulta1);
            }
            if (chkFechaProm.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }

        private void chkCerradoPor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCerradoPor.Checked)
            { txtCerradoPor.Enabled = true; }
            else { txtCerradoPor.Enabled = false; }
        }


        //-----------------------------

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

            for (int i = indice; i <= ListaDeConsultas.Count - 3; i++)
            {
                ListaDeConsultas[i] = ListaDeConsultas[i + 2];
                ListaDeConsultas[i + 2] = null;


            }

            ListaDeConsultas.Remove(ListaDeConsultas[ListaDeConsultas.Count - 1]);
            ListaDeConsultas.Remove(ListaDeConsultas[ListaDeConsultas.Count - 1]);


        }

        private String CrearConsultaBD()
        {

            
            foreach (String consul in ListaDeConsultas)
            {

                consulta += consul;

            }


            consulta = consulta.Remove(consulta.Length - 4);
            return consulta;
        }

        private void chkCerrado_CheckedChanged(object sender, EventArgs e)
        {

          

            if (chkCerrado.Checked)
            {
                consulta1 = " Cerrado=" + "'" + 1 + "'";
                AgregarItem(consulta1);
            }
            if (chkCerrado.Checked == false)
            {
                consulta1 = " Cerrado=" + "'" + 0 + "'";
                BorrarItem(consulta1);
            }

            
        }

        private void chkCerradoPor_CheckedChanged_1(object sender, EventArgs e)
        {
            consulta1 = " CerradoPor=" + "'" + Convert.ToString(txtCerradoPor.Text) + "'";


            if (chkCerradoPor.Checked)
            {
                AgregarItem(consulta1);
            }
            if (chkCerradoPor.Checked == false)
            {
                BorrarItem(consulta1);
            }
        }
       

       
    }
}
