using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using EntidadesCompartidas;



namespace EntidadesCompartidas
{
    [Serializable]
    public class Paciente:Usuario
    {
        private String datos;
        private DateTime fechaDeNac;
        

        public Paciente() 
            :base()
        {
            fechaDeNac = DateTime.Now;
            
        }

        public Paciente(int _id,DateTime fDeNac,String nom,String ape,String tel,int cel,bool activ) 
            : base(_id,nom,ape,tel,cel,activ)
        {
            datos = ape + " " + nom + " " + fDeNac +" "+ cel;
            fechaDeNac = fDeNac;
        }

        public String Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        public DateTime FechaDeNac
        {
            get { return fechaDeNac; }
            set { fechaDeNac=value; }
        }


        
        public override String ToString()
        {
            
            return Nombre +" "+ Apellido +" f.n:"+ FechaDeNac.ToShortDateString();
        }
       
    }
}
