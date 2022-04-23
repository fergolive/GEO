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
    public partial class Logueo : Form
    {

        Empleado empleadoLogueado = null;
        

        public Logueo()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String usuario = "";
                String contraseña = "";
                String mensaje="Debe ingresar: ";

                usuario = txtUsuario.Text;
                contraseña = txtContraseña.Text;

                if (usuario == "")
                {
                    mensaje = mensaje  + "Usuario, ";
                }
                if (contraseña == "")
                {
                    mensaje = mensaje + "Contraseña ";
                }

                if (mensaje == "Debe ingresar: ")
                {
                    empleadoLogueado = Logica.FabricaLogica.getLogicaEmpleado().BuscarEmpleado(usuario,contraseña);

                    if (empleadoLogueado == null)
                    {
                        lblerror.Text = "No existe el usuario y/o contraseña";
                    }
                   
                    else  
                    {

                        this.Hide();
                        formMenu nuevoMenuOnew = new formMenu(empleadoLogueado); 
                        nuevoMenuOnew.ShowDialog();
                        this.Close();

                    }
                }
                else
                {
                    lblerror.Text = mensaje;
                }
            }
            catch(Exception es)
            {
                lblerror.Text = es.Message;
            }



        }


        

        

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            { 
            
             e.Handled = true;
             SendKeys.Send("{TAB}");
             SendKeys.Send("{ENTER}");
            }
        }

      
      


        private void Logueo_Load(object sender, EventArgs e)
        {
            txtContraseña.TextAlign = HorizontalAlignment.Center;
            txtUsuario.TextAlign = HorizontalAlignment.Center;
        }
        int contfac = 0;
        private void txtUsuario_Enter(object sender, EventArgs e)
        {

            if (contfac == 0)
            {
                txtUsuario.Text = "";
            }

            txtUsuario.ForeColor = System.Drawing.Color.Gray;
            contfac += 1;
        }

        int contfac1 = 0;
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (contfac1 == 0)
            {
                txtContraseña.Text = "";

                txtContraseña.PasswordChar = '*';
            }


            txtContraseña.ForeColor = System.Drawing.Color.Gray;
            contfac1 += 1;
        }



    

       
            
        

       
    }
}
