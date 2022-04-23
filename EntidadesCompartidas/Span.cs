using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Span:Estudio
    {
        private bool sinOpt;
        private bool rb;
        private bool mc;
        private bool oli;
        private bool bj;
        private bool pow;
        private bool quir;
        private bool trevisi;
        private bool hold;
        private bool harv;
        private bool sch;
        private bool rick;
        private bool fotoDigital;
        private String tipoDeFotoDig;
        private String identikitComentarios;
        private bool cd;

        public Span():base()
        {
            sinOpt=false;
            rb = false;
            mc = false;
            oli = false;
            bj = false;
            pow = false;
            quir = false;
            trevisi = false;
            hold = false;
            harv = false;
            sch = false;
            rick = false;
            fotoDigital = false;
            tipoDeFotoDig = "";
            identikitComentarios = "";
            cd = false;
        }

        public Span(bool sOpt, bool _rb, bool _mc, bool _oli, bool _bj, bool _pow, bool _quir, bool _trevisi, bool _hold, bool _harv, bool _sch, bool _rick, bool _fotodigital, String tipoDeFotoD, String identikit, bool _cd, int _id, DateTime fecRealiz, DateTime fechaProm,bool cerrad,Empleado cerradP,Carpeta carpeta )
            : base(_id, fecRealiz, fechaProm, cerrad,cerradP,carpeta)
        {
            sinOpt = sOpt;
            rb = _rb;
            mc = _mc;
            oli = _oli;
            bj = _bj;
            pow = _pow;
            quir = _quir;
            trevisi = _trevisi;
            hold = _hold;
            harv = _harv;
            sch = _sch;
            rick = _rick;
            fotoDigital = _fotodigital;
            tipoDeFotoDig = tipoDeFotoD;
            identikitComentarios = identikit;
            cd = _cd;
        }

        public bool SinOpt
        {
            get { return sinOpt;}
            set { sinOpt=value;}
        }

        public bool Rb
        {
            get { return rb; }
            set { rb = value; }
        }

        public bool Mc
        {
            get { return mc; }
            set { mc = value; }
        }

        public bool Oli
        {
            get { return oli; }
            set { oli = value; }
        }

        public bool Bj
        {
            get { return bj; }
            set { bj = value; }
        }

        public bool Pow
        {
            get { return pow; }
            set { pow = value; }
        }

        public bool Quir
        {
            get { return quir; }
            set { quir = value; }
        }

        public bool Trevisi
        {
            get { return trevisi; }
            set { trevisi = value; }
        }

        public bool Hold
        {
            get { return hold; }
            set { hold = value; }
        }

        public bool Harv
        {
            get { return harv; }
            set { harv = value; }
        }

        public bool Sch
        {
            get { return sch; }
            set { sch = value; }
        }

        public bool Rick
        {
            get { return rick; }
            set { rick = value; }
        }

        public bool FotoDigital
        {
            get { return fotoDigital; }
            set { fotoDigital = value; }
        }

        public String TipoDeFotoDigital
        {
            get { return tipoDeFotoDig; }
            set { tipoDeFotoDig = value; }
        }

        public String IdentikitComentarios
        {
            get { return identikitComentarios; }
            set { identikitComentarios = value; }
        }

        public bool Cd
        {
            get { return cd; }
            set { cd = value; }
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
