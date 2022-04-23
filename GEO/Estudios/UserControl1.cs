using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriTrabajos.ESTUDIOS
{
    public partial class UserControl1 : UserControl
    {
        List<int> listaDePiezas = new List<int>();
        String SeleccionMaxilar = "";

        public UserControl1()
        {
            InitializeComponent();
        }

        
        private void lbl18_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl18, 18);
                
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl17_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl17, 17);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl16_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl16, 16);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl15_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl15,15);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl14_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl14,14);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
                
        }

        private void lbl38_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl38,38);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl37_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl37,37);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl36_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl36,36);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl35_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl35,35);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl34_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl34,34);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl33_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl33, 33);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl32_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl32,32);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl31_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl31,31);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl41_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl41, 41);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl42_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl42, 42);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl43_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl43,43);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl44_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl44,44);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl45_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl45,45);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl46_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl46,46);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl47_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl47,47);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl48_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl48,48);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl28_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl28, 28);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl27_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl27, 27);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl26_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl26, 26);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl25_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl25, 25);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl24_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl24, 24);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl23_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl23,23);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl22_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl22, 22);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl21_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl21, 21);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl11_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl11, 11);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void lbl12_Click(object sender, EventArgs e)
        {
           try
            {
                CambiarColor((Label)this.lbl12, 12);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
           
        }

        private void lbl13_Click(object sender, EventArgs e)
        {
            try
            {
                CambiarColor((Label)this.lbl13, 13);
            }
            catch
            {
                throw new Exception("No se pudo seleccionar una pieza");
            }
        }

        private void CambiarColor(Label lbl, int num)
        {
            DeschequearRbtns();

            if (lbl.BackColor == System.Drawing.Color.White)
            {
                lbl.BackColor = System.Drawing.Color.SteelBlue; //fondo azul
                lbl.ForeColor = System.Drawing.Color.White; //letra blanca
                listaDePiezas.Add(num);
            }
            else if (lbl.BackColor == System.Drawing.Color.SteelBlue)
            {
                lbl.BackColor = System.Drawing.Color.White; //fondo azure
                lbl.ForeColor = System.Drawing.Color.LightSlateGray; //letra gris
                listaDePiezas.Remove(num);
            }

            this.OnValidating(null);
        }

        public List<int> SeleccionDePiezas()
        {

            return listaDePiezas;

       
        }

        private void DeschequearRbtns()
        {
            rbtnBimaxilar.Checked = false;
            rbtnMaxInf.Checked = false;
            rbtnMaxSup.Checked = false;
        }

        public String SeleccionMaxilares()
        {

            try
            {
                if (rbtnBimaxilar.Checked)
                {
                    SeleccionMaxilar = "Bimaxilar; ";
                }
                else if (rbtnMaxInf.Checked)
                {
                    SeleccionMaxilar = "Maxilar Inferior; ";
                }
                else if (rbtnMaxSup.Checked)
                {
                    SeleccionMaxilar = "Maxilar Superior; ";
                }
                else
                {
                    SeleccionMaxilar = "";
                }


                return SeleccionMaxilar;
            }
            catch
            {
                throw new Exception("Problemas para seleccionar el o los maxilares");
            }
        }

        private void rbtnMaxSup_CheckedChanged(object sender, EventArgs e)
        {
            this.OnValidating(null);
        }

        private void rbtnMaxInf_CheckedChanged(object sender, EventArgs e)
        {
            this.OnValidating(null);
        }

        private void rbtnBimaxilar_CheckedChanged(object sender, EventArgs e)
        {
            this.OnValidating(null);
        }

        

        

       

       

        

        



      

      

        


        

       

    }
}
