using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
     public class Empleado : Usuario
     {
         
         
        private String username;
        private String password;
        private String datos;
        private String tipo;

        public Empleado(int _id,String user,String pass,String nom,String ape,String tel,int cel,String tip,bool activ)
            :base(_id,nom,ape,tel,cel,activ)
        {
            datos = Apellido + " " + Nombre; 
            username = user;
            password = pass;
            tipo = tip;
        }

        public Empleado():base()  // singleton
        {
            username = "";
            password = "";
            datos = "";
            tipo = "";
        }

        public String Username
        {
            get { return username; }
            set { username=value; }
        }

        public String Password
        {
            get { return password; }
            set { password=value; }
        }

        public String Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        

       
    }
}
