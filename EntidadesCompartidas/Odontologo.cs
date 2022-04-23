using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EntidadesCompartidas;



namespace EntidadesCompartidas
{
    [Serializable]
    public class Odontologo:Usuario
    {
        private String datos;
        private List<String> direcciones;
        private String horario;
        private String email;
        private String ciudad;
        

        public Odontologo() 
            :base()
        {
            datos = "";
            direcciones = new List<String>();
            horario = "";
            email ="";
            ciudad="";
            
        }

        public Odontologo(int _id,List<String> dir,String hor,String mail,String ciud,String nom,String ape,String tel,int cel,bool activ) //singleton
            : base(_id,nom,ape,tel,cel,activ)
        {
            datos = Apellido +" " + Nombre;
            direcciones = dir;
            horario = hor;
            
            email = mail;
            ciudad = ciud;

        }

        public String Datos
        {
            get{return datos;}
            set { datos = value; }
        }

        public List<String> Direcciones
        {
            get { return direcciones; }
            set { direcciones=value; }
        }

        public String Horario
        {
            get { return horario; }
            set { horario = value; }
        }

     
        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public override string ToString()
        {
            return Apellido + " " + Nombre;
        }
       
    }
}
