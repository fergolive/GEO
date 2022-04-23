using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using EntidadesCompartidas;

namespace PruebaPersistenvia
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Tomografia t = new Tomografia();
                FabricaPersistencia fb = new FabricaPersistencia();
                t.FechaPrometida = DateTime.Now;
                t.Factura = "fdfdffddffdf";
          fb.getPTomografia().AgregarTomografia(t);
                
         
            }
            catch(Exception es)
            {
                Console.Write(es.Message);
                Console.Read();
            }

        }
    }
}
