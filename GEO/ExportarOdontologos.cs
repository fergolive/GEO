using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

namespace GEO
{
    public partial class ExportarOdontologos : Form
    {
        public ExportarOdontologos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String ruta = "";
                ruta = txtRuta.Text;
                if (ruta == "")
                {
                    lblError.Text = "No ha ingresado la ruta de origen";
                }
                else
                {

                    List<EntidadesCompartidas.Odontologo> listaOdontologosAccess = null;
                    String pass = "44296766odontologos";

                    String contrañesa = "";

                    contrañesa = txtContraseña.Text;
                    if (contrañesa == "")
                    {
                        lblError.Text = "Debe ingresar la contraseña";
                    }
                    else if (contrañesa == pass)
                    {
                        listaOdontologosAccess = Logica.FabricaLogica.getLogicaOdontologo().BuscarOdontologosAccess(ruta);

                        if (listaOdontologosAccess != null)
                        {
                            foreach (Odontologo odo in listaOdontologosAccess)
                            {

                                Logica.FabricaLogica.getLogicaOdontologo().AgregarOdontologo(odo);
                                if (odo.Direcciones[0] != "")
                                {
                                    Logica.FabricaLogica.getLogicaOdontologo().AgregarDireccionAccess(odo, odo.Direcciones[0].ToString());
                                }
                            }

                            lblError.Text = "Se han exportado:" + listaOdontologosAccess.Count.ToString() + " " + "odontologos";
                        }
                        else
                        {
                            lblError.Text = "No se pudieron exportar los odontologos";
                        }
                    }
                    else if (contrañesa != pass)
                    {
                        lblError.Text = "contraseña mal";
                    }
                }
            }
            catch(Exception es)
            {
                lblError.Text = es.Message;
            }
        }
    }
}
