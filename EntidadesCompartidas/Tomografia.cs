using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Tomografia : Estudio
    {
        
        private String orden;
        private int impresiones;
        private bool informe;
        private bool sinInforme;
        private int cds;
        private String patologia;
        private Empleado tomadaPor;
        private Empleado chequeadaPor;
        private Empleado informadaPor;
        private bool cs3dImagingSoft;
        private bool implantViewerSoft;
        private bool inVivoSoft;
        private String otroSoft;


        public Tomografia()
            : base()
        {
           
            orden = "";
            impresiones = 0;
            informe = false;
            sinInforme = false;
            cds = 0;
            patologia = "";
            tomadaPor = new Empleado();
            informadaPor = new Empleado();
            chequeadaPor = new Empleado();
            cs3dImagingSoft=false;
            implantViewerSoft=false;
            inVivoSoft=false;
            otroSoft="";
        }

        public Tomografia(String ord, int impres, bool inf,bool sinInf, int Cd, String patolog,Empleado tomadaP, Empleado informadaP,Empleado chequeadap, int _id, DateTime fecRealiz,DateTime fechaProm,bool cerrad,Empleado cerradoP,Carpeta carp,bool cs3dImagingSof,bool implantV,bool inViv,String otro)
            : base(_id, fecRealiz, fechaProm,cerrad,cerradoP,carp)
        {

            orden = ord;
            impresiones = impres;
            informe = inf;
            sinInforme = sinInf;
            cds = Cd;
            patologia = patolog;
            tomadaPor = tomadaP;
            informadaPor = informadaP;
            chequeadaPor = chequeadap;
            cs3dImagingSoft = cs3dImagingSof;
            implantViewerSoft = implantV;
            inVivoSoft = inViv;
            otroSoft = otro;
        }


        public String Orden
        {
            get { return orden; }
            set { orden = value; }
        }

        public int Impresiones
        {
            get { return impresiones; }
            set { impresiones = value; }
        }

        public bool Informe
        {
            get { return informe; }
            set { informe = value; }
        }

        public bool SinInforme
        {
            get { return sinInforme; }
            set { sinInforme = value; }
        }


        public int Cds
        {
            get { return cds; }
            set { cds = value; }

        }

        public String Patologia
        {
            get { return patologia; }
            set { patologia = value; }
        }

        public Empleado InformadaPor
        {
            get { return informadaPor; }
            set { informadaPor = value; }

        }

        public Empleado TomadaPor
        {
            get { return tomadaPor; }
            set { tomadaPor = value; }

        }

        public Empleado ChequeadaPor
        {
            get { return chequeadaPor; }
            set { chequeadaPor = value; }

        }

        public bool Cs3dImagingSoft
        {
            get { return cs3dImagingSoft; }
            set { cs3dImagingSoft = value; }
        }

        public bool ImplantViewerSoft
        {
            get { return implantViewerSoft; }
            set { implantViewerSoft = value; }
        }

        public bool InVivoSoft
        {
            get { return inVivoSoft; }
            set { inVivoSoft = value; }
        }

        public String OtroSoft
        {
            get { return otroSoft; }
            set { otroSoft = value; }
        }


        //propiedades para mostrar en una grilla

        public String Factura
        {
            get { return Carpeta.NumDeFactura; }
            set { Carpeta.NumDeFactura = value; }
        }

        public String Paciente
        {
            get { return Carpeta.Paciente.Apellido+" "+Carpeta.Paciente.Nombre; }
        }

        public String InformadaPorNombre
        {
            get { return informadaPor.Apellido + " " + informadaPor.Nombre; }
        }

        public String TomadaPorNombre
        {
            get { return tomadaPor.Apellido + " " + tomadaPor.Nombre; }
        }
    
       
       
    }
}
