using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EntidadesCompartidas;

namespace OriTrabajos.LISTAS
{
    public partial class ListarEstudiosPendientes : Form
    {
        Empleado EmpleadoLogueado=null;
       


        public ListarEstudiosPendientes(Empleado empleadoLog)
        {
            InitializeComponent();
            EmpleadoLogueado = empleadoLog;
        }

      

       





        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Selecciona el tipo y destino del estudio en la lista de la izquierda, luego presiones buscar");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (rbtnNemo.Checked) //NEMO
            {
                ESTUDIOS.NemoDocViewer nemo = new ESTUDIOS.NemoDocViewer(EmpleadoLogueado);
                nemo.ShowDialog();
            }
            else if (rbtnOxi.Checked) //OXI
            {
                ESTUDIOS.OptParaImplante oxi = new ESTUDIOS.OptParaImplante(EmpleadoLogueado);
                oxi.ShowDialog();
            }
            else if (rbtnTomo.Checked) //TOMO
            {
                ESTUDIOS.Tomografia nueva = new ESTUDIOS.Tomografia(EmpleadoLogueado);
                nueva.ShowDialog();
            }
            else if (rdbFoto.Checked) //FOTOGRAFIA
            {
                ESTUDIOS.Fotografia nueva = new ESTUDIOS.Fotografia(EmpleadoLogueado);
                nueva.ShowDialog();
            }
            else if (rdbModelo.Checked) //MODELO
            {
                ESTUDIOS.Modelo nuevo = new ESTUDIOS.Modelo(EmpleadoLogueado);
                nuevo.ShowDialog();
            }
            else
            { lblerror.Text = "Debe seleccionar un estudio"; }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (rbtnTomo.Checked) //TOMO
            {
                try
                {

                    int indiceFila = gridEstudios.CurrentCell.RowIndex;
                    String fac = gridEstudios.Rows[indiceFila].Cells["Factura"].Value.ToString();

                    ESTUDIOS.Tomografia tm = new ESTUDIOS.Tomografia(EmpleadoLogueado);

                    for (int i = 0; i < tm.Controls.Count; i++)
                    {
                        if (tm.Controls[i].Name == "txtFactura")
                        {
                            tm.Controls[i].Text = fac;
                            tm.Controls[i].Enabled = false;

                        }

                    }

                    CancelEventArgs ce = new CancelEventArgs();

                    tm.Show();
                    //tm.txtFactura_Validating(sender, ce);
                    tm.Controls["btnModificar"].Enabled = true;



                }
                catch
                {
                    lblerror.Text = "No se pudo mostrar el formulario de edicion";
                }
            }
            else if (rbtnOxi.Checked) //OXI
            {
                try
                {

                    int indiceFila = gridEstudios.CurrentCell.RowIndex;
                    String fac = gridEstudios.Rows[indiceFila].Cells["Factura"].Value.ToString();

                    ESTUDIOS.OptParaImplante tm = new ESTUDIOS.OptParaImplante(EmpleadoLogueado);

                    for (int i = 0; i < tm.Controls.Count; i++)
                    {
                        if (tm.Controls[i].Name == "txtFactura")
                        {
                            tm.Controls[i].Text = fac;
                            tm.Controls[i].Enabled = false;

                        }

                    }

                    CancelEventArgs ce = new CancelEventArgs();
                    tm.Show();
                    //tm.txtFactura_Validating(sender, ce);
                    tm.Controls["btnModificar"].Enabled = true;

                }
                catch
                {
                    lblerror.Text = "No se pudo mostrar el formulario de edicion";
                }
            }
            else if (rbtnNemo.Checked)
            {
                try
                {

                    int indiceFila = gridEstudios.CurrentCell.RowIndex;
                    String fac = gridEstudios.Rows[indiceFila].Cells["Factura"].Value.ToString();

                    ESTUDIOS.NemoDocViewer tm = new ESTUDIOS.NemoDocViewer(EmpleadoLogueado);

                    for (int i = 0; i < tm.Controls.Count; i++)
                    {
                        if (tm.Controls[i].Name == "txtfactura")
                        {
                            tm.Controls[i].Text = fac;
                            tm.Controls[i].Enabled = false;

                        }

                    }

                    CancelEventArgs ce = new CancelEventArgs();
                    tm.Show();
                    //tm.txtfactura_Validating(sender, ce);
                    tm.Controls["btnModificar"].Enabled = true;
                }
                catch
                {
                    lblerror.Text = "No se pudo mostrar el formulario de edicion";
                }
            }
            else
            {
                lblerror.Text = "Debe Seleccionar un estudio";
            }
        }

        List<Estudio> listaDeEstudios=null;
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             GEO.Busqueda.FrmFiltroEstudios filtro = new GEO.Busqueda.FrmFiltroEstudios();
                if (filtro.ShowDialog() == DialogResult.OK)
                {
                   String consulta = filtro.ValorRetorno;
                   listaDeEstudios = Logica.FabricaLogica.getLogicaCarpeta().BuscarEstudios(consulta);

                   lblResultados.Text = listaDeEstudios.Count + " Resultados";
                   gridEnviados.DataSource = listaDeEstudios;
        }


 

      
    }
}
