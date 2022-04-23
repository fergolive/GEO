using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OriTrabajos.LISTAS
{
    public partial class AmpliarFoto : Form
    {
        Image Foto = null;
        public AmpliarFoto(Image img)
        {
            InitializeComponent();
            Foto = img;
        }

        private void AmpliarFoto_Load(object sender, EventArgs e)
        {
            picImg.Image = Foto;


            System.Drawing.Size s = new System.Drawing.Size(Screen.PrimaryScreen.WorkingArea.Size.Width-20, Screen.PrimaryScreen.WorkingArea.Size.Height-20);
            System.Drawing.Point p = new System.Drawing.Point(0, 0);
           
            this.Location = p;
            this.Size = s;
            this.AutoScroll = true;

            System.Drawing.Size spicture = new System.Drawing.Size(Foto.Width, Foto.Height);
            System.Drawing.Point p2 = new System.Drawing.Point(0, 0);

            picImg.Size = spicture;
            picImg.Location = p;


            System.Drawing.Size ipicture = new System.Drawing.Size(Foto.Width, Foto.Height);
           
            panelImg.Size = Foto.Size;
            panelImg.Location = p;
           
        }
    }
}
