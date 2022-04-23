using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
 [Serializable]
    public class Modelo:Estudio
    {
        private bool modeloYMedio;
        private bool estudioDeModelo;
        private bool placaBase;
        private bool paraArticulador;
        private String laboratorio;
        private String clinica;
        private bool tieneFotos;
        private String observaciones;
        

        public Modelo():base()
        {
            modeloYMedio = false;
            estudioDeModelo = false;
            clinica = "";
            placaBase = false;
            paraArticulador = false;
            laboratorio = "";
            tieneFotos=false;
            observaciones="";
          
        }

        public Modelo(bool modymedio, bool estmodelo, String clinic,bool placaB,bool pArticulador, String lab,int id, DateTime fecRealiz, DateTime fechaProm,bool cerrad,Empleado cerrada_Por,Carpeta carp,bool fotos,String obs)
            : base(id,fecRealiz,fechaProm,cerrad,cerrada_Por,carp)
        {
            modeloYMedio = modymedio;
            estudioDeModelo = estmodelo;
            clinica = clinic;
            placaBase = placaB;
            paraArticulador = pArticulador;
            laboratorio = lab;
            tieneFotos = fotos;
            observaciones = obs;
        }

        public bool ModeloYMedio
        {
            get { return modeloYMedio;}
            set { modeloYMedio=value;}
        }

        public bool EstudioDeModelo
        {
            get { return estudioDeModelo; }
            set { estudioDeModelo = value; }
        }

        public String Clinica
        {
            get { return clinica; }
            set { clinica = value; }
        }

        public bool PlacaBase
        {
            get { return placaBase; }
            set { placaBase = value; }
        }

        public bool ParaArticulador
        {
            get { return paraArticulador; }
            set { paraArticulador = value; }
        }

        public String Laboratorio
        {
            get { return laboratorio; }
            set { laboratorio = value; }
        }

        public bool TieneFotos
        {
            get { return tieneFotos; }
            set { tieneFotos = value; }
        }

        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }
    }
}
