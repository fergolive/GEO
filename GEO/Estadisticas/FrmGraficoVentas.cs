using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GEO.Estadisticas
{
    public partial class FrmGraficoVentas : Form
    {
        public FrmGraficoVentas()
        {
            InitializeComponent();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int anioInicio=0;

            try
            {
                anioInicio = Convert.ToInt32(txtAnioInicio.Text);
            }
            catch
            {
                lblError.Text = "Debe ingresar el año de inicio";
            }

            int anioActual = Convert.ToInt32(DateTime.Now.Year);
            

             //lienzo
            Graphics g = this.CreateGraphics();

            //LAPICES Y PINCELES
            Pen lapiz0 = new Pen(Color.Black, 4);
            Pen lapiz = new Pen(Color.Green, 3);
            Pen lapiz1 = new Pen(Color.Black, 2);
            Pen lapiz2 = new Pen(Color.Black, 2);
            SolidBrush pincel = new SolidBrush(Color.White);
            
            g.FillRectangle(pincel,10,70,1000,400); //FONDO BLANCO
            g.DrawLine(lapiz1,new Point(50,90),new Point(50, 410)); //eje y
            g.DrawLine(lapiz1, new Point(40, 400), new Point(700, 400)); //eje 

            //marcas meses eje x
            g.DrawLine(lapiz2, new Point(100, 396), new Point(100, 403));
            g.DrawLine(lapiz2, new Point(150, 396), new Point(150, 403));
            g.DrawLine(lapiz2, new Point(200, 396), new Point(200, 403));
            g.DrawLine(lapiz2, new Point(250, 396), new Point(250, 403));
            g.DrawLine(lapiz2, new Point(300, 396), new Point(300, 403));
            g.DrawLine(lapiz2, new Point(350, 396), new Point(350, 403));
            g.DrawLine(lapiz2, new Point(400, 396), new Point(400, 403));
            g.DrawLine(lapiz2, new Point(450, 396), new Point(450, 403));
            g.DrawLine(lapiz2, new Point(500, 396), new Point(500, 403));
            g.DrawLine(lapiz2, new Point(550, 396), new Point(550, 403));
            g.DrawLine(lapiz2, new Point(600, 396), new Point(600, 403));
            g.DrawLine(lapiz2, new Point(650, 396), new Point(650, 403));


            //ETIQUETAS------------------------------------------------------------------
            Label ly = new Label();
            ly.Text = "AÑO";
            ly.BackColor = System.Drawing.Color.White;

            Label lx = new Label();
            lx.Text = "MESES";
            lx.BackColor = System.Drawing.Color.White;
            
          
            Label enero = new Label();
            enero.Text = "ene          feb           mar           abr            may           jun            jul            ago            sep            oct            nov          dic";
            enero.BackColor = System.Drawing.Color.White;
            enero.ForeColor = System.Drawing.Color.Blue;
            enero.AutoSize = true;
            //---------------------------------------------------------------------------


            Point puntoCero = new Point(50, 400 - 60); //PUNTO (0,0)
            List<int> cantidadesxmes = new List<int>();


            //recorrer la cantidad de años
      
            int alturaCuadradito = 50;
            for (int i = anioInicio; i < anioActual+1; i++)
            {

                //marcas meses eje y
                Pen lapiz4 = new Pen(Color.Black, 2);
                g.DrawLine(lapiz4, new Point(47, 320), new Point(53, 320));
              

                puntoCero.X = 50;
                puntoCero.Y = 360;

                Random r = new Random();

                Label etiqueta = new Label();
                etiqueta.BackColor = System.Drawing.Color.Transparent;
                etiqueta.Text = anioInicio.ToString();
                etiqueta.AutoSize = true;
                
                etiqueta.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                etiqueta.Location = new Point(820,105+alturaCuadradito);
               
                this.Controls.Add(etiqueta);

                int colorR = r.Next(0, 255);
                int colorG = r.Next(0, 255);
                int colorB = r.Next(0, 255);

                int x = 50; //desplazamiento en x
                //recorrer meses para cada anio
                Pen lapizCeleste = new Pen(Color.FromArgb(colorR, colorG, colorB), 3);
                SolidBrush pincelCuadro = new SolidBrush(Color.FromArgb(colorR, colorG, colorB));
                g.FillRectangle(pincelCuadro, 800,100+alturaCuadradito, 20, 20);

                for (int j = -1; j < 12; j++)
                {

                    int c = Logica.FabricaLogica.getLogicaCarpeta().ContarCarpetasXAnioMes(i, j + 2);  
                    
                    g.DrawLine(lapizCeleste, puntoCero, new Point(50 + x, 360 - c )); //50,400 es el punto inicial
                    g.DrawRectangle(lapiz0, new Rectangle(50 + x, 360 - c  , 2, 2));

                    puntoCero.X = 50 + x;
                    puntoCero.Y = 360 - c;
                    x += 50;           
                 }

              
               
                anioInicio += 1;
                alturaCuadradito += 30;  
            }

           /*
            //marcas para los meses
            int xx = 0;
            for (int j = 0; j < 12; j++)
            {
                g.DrawLine(lapiz1, puntoCero, new Point(50+xx,500));

                xx += 50;
            }
            */
            lx.Location = new Point(710, 400);
            ly.Location = new Point(55, 80);


            enero.Location = new Point(90, 415);
           

            this.Controls.Add(lx);
            this.Controls.Add(ly);
            this.Controls.Add(enero);
          

             }

    }
}
