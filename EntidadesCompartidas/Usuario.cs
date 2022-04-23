using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Usuario
    {
        private int id;
        private String nombre;
        private String apellido;
        private String telefono;
        private int celular;
        private bool activo;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre=value; }
        }

        public String Apellido
        {
            get { return apellido; }
            set { apellido=value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono=value; }
        }

        public int Celular
        {
            get { return celular; }
            set { celular=value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo=value; }
        }

        public Usuario(int _id,String nom,String ape,String tel,int cel,bool act)
        {
            id = _id;
            nombre = nom;
            apellido = ape;
            telefono = tel;
            celular = cel;
            activo = act;
        }

        public Usuario() // singleton
        {
            id = 0;
            nombre = "<sin nombre>";
            apellido = "<sin apellido>";
            telefono = "";
            celular = 0;
            activo = true;
        }

       

       
    }
}
