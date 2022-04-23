using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

namespace OriTrabajos
{
    public partial class formMenu : Form
    {
        Empleado empleadoLogueado = null;

        public formMenu(Empleado empleadoLog)
        {
            empleadoLogueado = empleadoLog;
            InitializeComponent();
            userIcon.Text = empleadoLogueado.Apellido.ToString() + " " + empleadoLogueado.Nombre.ToString();
        }

        private void formMenu_Load(object sender, EventArgs e)
        {
            //solamente para administradores
            itemEmpleados.Enabled = false;
            itemEmpleados.Visible = false;
            itemExpOdo.Enabled = false;
            itemExpOdo.Visible = false;
            

            if (empleadoLogueado.Tipo == "r")
            {
                itemEstudios.Enabled = false;
                itemEstudios.Visible = false;
            
            }

            if (empleadoLogueado.Tipo == "admin")
            {
                itemEmpleados.Enabled = true;
                itemEmpleados.Visible = true;
                itemExpOdo.Enabled = true;
                itemExpOdo.Visible = true;

            }
        }

        

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            empleadoLogueado = null;
            Logueo nuevoForm = new Logueo();
            nuevoForm.ShowDialog();
            this.Close();

        }

        private void carpetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ABM.abmCarpeta nuevaCarpeta = new ABM.abmCarpeta(empleadoLogueado);
            nuevaCarpeta.MdiParent = this;
            nuevaCarpeta.Show();
            
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void odontologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.abmOdontologo nuevoOdontologo = new ABM.abmOdontologo();
            nuevoOdontologo.MdiParent = this;
            nuevoOdontologo.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.abmEmpledo nuevoEmpleado = new ABM.abmEmpledo();
            nuevoEmpleado.MdiParent = this;
            nuevoEmpleado.Show();
        }

        private void pacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABM.abmPaciente nuevoPaciente = new ABM.abmPaciente();
            nuevoPaciente.MdiParent = this;
            nuevoPaciente.Show();
        }

        private void optParaImplantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTUDIOS.OptParaImplante nuevaOxi = new ESTUDIOS.OptParaImplante(empleadoLogueado);
            nuevaOxi.MdiParent = this;
            nuevaOxi.Show();
        }

        private void tomografiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTUDIOS.Tomografia nuevaTomo = new ESTUDIOS.Tomografia(empleadoLogueado);
            nuevaTomo.MdiParent = this;
            nuevaTomo.Show();
        }

        private void spanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTUDIOS.Span nuevoSpan = new ESTUDIOS.Span(empleadoLogueado);
            nuevoSpan.MdiParent = this;
            nuevoSpan.Show();
        }

        private void nemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTUDIOS.NemoDocViewer nuevoNemo = new ESTUDIOS.NemoDocViewer(empleadoLogueado);
            nuevoNemo.MdiParent = this;
            nuevoNemo.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTUDIOS.Modelo nuevoModelo = new ESTUDIOS.Modelo(empleadoLogueado);
            nuevoModelo.MdiParent = this;
            nuevoModelo.Show();
        }

      

        private void estudiosToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            LISTAS.ListarEstudiosPendientes nuevalista = new LISTAS.ListarEstudiosPendientes(empleadoLogueado);
            nuevalista.MdiParent = this;
            nuevalista.Show();
        }

        private void estudiosPorCarpetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LISTAS.EnviosyRetirosDiarios envios = new LISTAS.EnviosyRetirosDiarios(empleadoLogueado);
            envios.MdiParent = this;
            envios.Show();
        }

       

        private void exportarUltimoPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ABM.TransfPaciente tr = new ABM.TransfPaciente();
            //tr.ShowDialog();

            ABM.ExportarPecientesFacturados exp = new ABM.ExportarPecientesFacturados(empleadoLogueado);
            exp.MdiParent = this;
            exp.Show();
            
        }

        private void exportarOdontologosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void chequearEnviadasRetiradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LISTAS.ModificarEnviosyRetiros modEnvRet = new LISTAS.ModificarEnviosyRetiros(empleadoLogueado);
            modEnvRet.MdiParent = this;
            
            modEnvRet.Show();
        }

        private void estudiosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    

        private void fotografiasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ESTUDIOS.Fotografia nuevaFoto = new ESTUDIOS.Fotografia(empleadoLogueado);
            nuevaFoto.MdiParent = this;
            nuevaFoto.Show();
        }

        private void frmListadoDeEnviadosyRetiradoscsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEO.Listas.FrmListadoDeEnviadosyRetirados nuevo=new GEO.Listas.FrmListadoDeEnviadosyRetirados();
            nuevo.MdiParent = this;
            nuevo.Show();
        }

        private void exportarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEO.ExportarOdontologos ex = new GEO.ExportarOdontologos();
            ex.MdiParent = this;
            ex.Show();
        }

        private void exportarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEO.ABM.ExportarBaseDeDatos ex = new GEO.ABM.ExportarBaseDeDatos();
            ex.MdiParent = this;
            ex.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            ABM.abmCarpeta nuevaCarpeta = new ABM.abmCarpeta(empleadoLogueado);
            nuevaCarpeta.MdiParent = this;
            nuevaCarpeta.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LISTAS.ListarEstudiosPendientes nuevalista = new LISTAS.ListarEstudiosPendientes(empleadoLogueado);
            nuevalista.MdiParent = this;
            nuevalista.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ABM.abmOdontologo nuevoOdontologo = new ABM.abmOdontologo();
            nuevoOdontologo.MdiParent = this;
            nuevoOdontologo.Show();
        }

        private void graficoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GEO.Estadisticas.FrmGraficoVentas nuevoGrafico = new GEO.Estadisticas.FrmGraficoVentas();
            nuevoGrafico.MdiParent = this;
            nuevoGrafico.Show();
        }

       
    }
}
