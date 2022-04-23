using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Estudio
    {
        private int id;
        private DateTime fechaRealizado;
        private DateTime fechaPrometida;
        private bool cerrada;
        private Empleado cerradaPor;
        private Carpeta carpeta;
 
        public Estudio()
        {

         id = 0;
         fechaRealizado=DateTime.Now;
         fechaRealizado = (DateTime.Now).AddDays(2);
         cerrada = false;
         cerradaPor = new Empleado();
         carpeta = new Carpeta();

        }

        public Estudio(int _id,DateTime fecRealiz,DateTime fechaProm, bool _cerrada,Empleado cerrada_Por,Carpeta carp)
        {
            id = _id;
            fechaRealizado = fecRealiz;
            fechaPrometida=fechaProm;
            cerrada = _cerrada;
            cerradaPor = cerrada_Por;
            carpeta = carp;
        }

       

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime FechaRealizado
        {
            get { return fechaRealizado; }
            set { fechaRealizado = value; }
        }

        public DateTime FechaPrometida
        {
            get { return fechaPrometida;}
            set { fechaPrometida=value;}
        }

        public bool Cerrada
        {
            get { return cerrada; }
            set { cerrada = value; }
        }

        public Empleado CerradaPor
        {
            get { return cerradaPor; }
            set { cerradaPor = value; }
        }

        public Carpeta Carpeta
        {
            get { return carpeta; }
            set { carpeta = value; }
        }

       
    }
}
