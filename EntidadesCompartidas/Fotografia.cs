using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Fotografia:Estudio
    {
        
        private bool frentePerfilSonrisa;
        private bool intrabucal;
        private bool overJet_y_OverBite;
        private bool submenton;
      
       
        private Empleado limpioPor;
        private Empleado emplantilladoPor;
        private Empleado impresoPor;
      
        

        public Fotografia():base()
        {
            
            frentePerfilSonrisa=false;
            intrabucal=false;
            overJet_y_OverBite=false;
            submenton=false;
            
           
            limpioPor = null; ;
            emplantilladoPor=null;
            impresoPor = null ;
            
            

        }

        public Fotografia(bool frentePS, bool intrabuc, bool overs, bool smenton, Empleado limpiadoPor, Empleado emplantilladop, Empleado impresoP, int _id, DateTime fecRealiz, DateTime fechaProm, bool cerrad, Empleado cerradoP, Carpeta carpeta)
            : base(_id, fecRealiz, fechaProm,cerrad,cerradoP,carpeta)
        {
           
            frentePerfilSonrisa = frentePS;
            intrabucal = intrabuc;
            overJet_y_OverBite = overs;
            submenton = smenton;
           
           
            limpioPor = limpiadoPor; ;
            emplantilladoPor =emplantilladop ;
            impresoPor = impresoP;

            
        }

        public bool FrentePerfilSonrisa
        {
            get { return frentePerfilSonrisa; }
            set { frentePerfilSonrisa = value; }
        }

        public bool Intrabucal
        {
            get { return intrabucal; }
            set { intrabucal = value; }
        }

        public bool OverJet_y_OverBite
        {
            get { return overJet_y_OverBite; }
            set { overJet_y_OverBite = value; }
        }

        public bool Submenton
        {
            get { return submenton; }
            set { submenton = value; }
        }

    

        public Empleado LimpiadoPor
        {
            get{return limpioPor;}
            set{limpioPor=value;}
        }
    
        public Empleado EmplantilladoPor
        {
            get{return emplantilladoPor;}
            set{emplantilladoPor=value;}
        }
         
        public Empleado ImpresoPor
        {
            get{return impresoPor;}
            set{impresoPor=value;}
        }

     

    }
}
