using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class OptParaImplante : Estudio
    {
        
        private bool impresion;
        private bool informe;
        private bool cd;
        private bool opt;

        public OptParaImplante() : base()
        {
            impresion=true;
            informe=true;
            cd=true;
            opt = true;
        }

        public OptParaImplante(bool impre, bool inf, bool _cd,bool _opt, int _id, DateTime fecRealiz,DateTime fechaProm,bool cerrad,Empleado cerradoP,Carpeta carp)
            : base(_id, fecRealiz, fechaProm, cerrad,cerradoP,carp)
        {
            
            impresion = impre;
            informe = inf;
            cd = _cd; ;
            opt = _opt;
        }

        public bool Impresion
        {
            get { return impresion; }
            set { impresion = value; }
        }

        public bool Informe
        {
            get { return informe; }
            set { informe = value; }
        }

        public bool Cd
        {
            get { return cd; }
            set { cd = value; }
        }

        public bool Opt
        {
            get { return opt; }
            set { opt = value; }
        }

        public String Factura
        {
            get { return Carpeta.NumDeFactura; }
            set { Carpeta.NumDeFactura = value; }
        }

        public String Paciente
        {
            get { return Carpeta.Paciente.Apellido + " " + Carpeta.Paciente.Nombre; }
        }
    }
}
