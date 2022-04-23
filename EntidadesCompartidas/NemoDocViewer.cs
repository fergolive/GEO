using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class NemoDocViewer:Estudio
    {
        
        
        private bool nemo;
        private bool docViewer;
        private bool roth;
        private bool ayala;
        private bool pConTrat;
        private bool pSinTrat;
        private bool visEst;
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
        private bool rickFront;
        private bool modelo;
        private bool sinOpt;
        private String software;
        private String observaciones;
        

        public NemoDocViewer():base()
        {
          
            nemo=false;
            docViewer=false;
            roth=false;
            ayala=false;
            pConTrat=false;
            pSinTrat=false;
            visEst=false;

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
            rickFront = false;
            modelo = false;
            sinOpt = false;
            software = "";
            observaciones = "";
            
        }

        public NemoDocViewer(bool _nemo,bool _docViewer,bool _roth,bool _ayala,bool _pConTrat,bool _pSinTrat,bool _visEst, bool _rb, bool _mc, bool _oli, bool _bj, bool _pow, bool _quir, bool _trevisi, bool _hold, bool _harv, bool _sch, bool _rick, bool _fotodigital, String tipoDeFotoD, String identikit, bool _cd,bool rf,bool model,bool Sp,String soft,String Obs,int id_,DateTime fecRealiz, DateTime fechaProm,bool cerrad,Empleado cerradaP,Carpeta carpeta )
            : base(id_,fecRealiz, fechaProm, cerrad,cerradaP,carpeta)
        {
            nemo=_nemo;
            docViewer=_docViewer;
            roth=_roth;
            ayala=_ayala;
            pConTrat=_pConTrat;
            pSinTrat=_pSinTrat;
            visEst=_visEst;
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
            rickFront = rf;
            modelo = model;
            sinOpt = Sp;
            software = soft;
            observaciones = Obs;
            
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

        public bool Nemo
        {
            get { return nemo;}
            set { nemo=value;}
        }

        public bool DocViewer
        {
            get { return docViewer; }
            set { docViewer = value; }
        }

        public bool Ayala
        {
            get { return ayala; }
            set { ayala = value; }
        }

        public bool Roth
        {
            get { return roth; }
            set { roth = value; }
        }

        public bool VisEst
        {
            get { return visEst; }
            set { visEst = value; }
        }

        public bool PConTrat
        {
            get { return pConTrat; }
            set { pConTrat = value; }
        }

        public bool PSinTrat
        {
            get { return pSinTrat; }
            set { pConTrat = value; }
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

        public bool RickFront
        {
            get { return rickFront; }
            set { rickFront = value; }
        }

        public bool Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        public bool SinOpt
        {
            get { return sinOpt; }
            set { sinOpt = value; }
        }

        public String Software
        {
            get { return software; }
            set { software = value; }
        }

        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        
    }
}
