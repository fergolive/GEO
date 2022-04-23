using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Persistencia.FabricaPersistencia d = new Persistencia.FabricaPersistencia();
            //EntidadesCompartidas.Odontologo nuevo= d.getPCarpeta().BuscarOdotologoPorIdAccess(1729);

            EntidadesCompartidas.Carpeta nueva = d.getPCarpeta().BuscarCarpetaPorFacturaAccess("c223332");
            
            
        }
    }
}
