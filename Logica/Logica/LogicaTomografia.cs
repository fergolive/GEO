using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;


namespace Logica
{
    internal class LogicaTomografia :ILogicaTomografia
    {
        private static LogicaTomografia instance = null;
        private LogicaTomografia() { }
        public static LogicaTomografia getLogica()
        {
            if (instance == null)
                instance = new LogicaTomografia();
            return instance;
        }

        public void AgregarTomografia(Tomografia tomografia)
        {
            ServicioRemoting.ServicioTomografia objServicioT = new ServicioRemoting.ServicioTomografia();
            objServicioT.AgregarTomografia(tomografia);
        }

        public void EliminarTomografia(Tomografia tomografia)
        {
            ServicioRemoting.ServicioTomografia objServicioT = new ServicioRemoting.ServicioTomografia();
            objServicioT.EliminarTomografia(tomografia);
        }

        public void ModificarTomografia(Tomografia tomografia)
        {
            ServicioRemoting.ServicioTomografia objServicioT = new ServicioRemoting.ServicioTomografia();
            objServicioT.ModificarTomografia(tomografia);
        }

        public List<Tomografia> ListarTomografiasPendientes()
        {
            ServicioRemoting.ServicioTomografia objServicioT = new ServicioRemoting.ServicioTomografia();
            return (objServicioT.ListarTomografiasPendientes());
        }

        public Tomografia BuscarTomografia(String factura)
        {
            ServicioRemoting.ServicioTomografia objServicioT = new ServicioRemoting.ServicioTomografia();
            return (objServicioT.BuscarTomografia(factura));
        }
        
    }
}
