using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{

    internal class LogicaCarpeta : ILogicaCarpeta
    {
        private static LogicaCarpeta instance = null;
        private LogicaCarpeta() { }
        public static LogicaCarpeta getLogica()
        {
            if (instance == null)
                instance = new LogicaCarpeta();
            return instance;
        }

        public void AgregarCarpeta(Carpeta carpeta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            objServicioN.AgregarCarpeta(carpeta);
        }

        public void AgregarCarpeta2(Carpeta carpeta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            objServicioN.AgregarCarpeta2(carpeta);
        }

        public void EliminarCarpeta(Carpeta carpeta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            objServicioN.EliminarCarpeta(carpeta);
        }

        public void ModificarCarpeta(Carpeta carpeta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            objServicioN.ModificarCarpeta(carpeta);
        }

        public Carpeta BuscarCarpeta(String factura)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.BuscarCarpeta(factura);
        }

        public List<Carpeta> BuscarCarpetas(String consulta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.BuscarCarpetas(consulta);
        }
        public List<Carpeta> ListarEnviosPendientes(String tipo,String entregada)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
                return objServicioN.ListarEnviosPendientes(tipo,entregada);
        }

        public List<String> ListarUltimos5FacturasPacientesAccess(String ruta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.ListarUltimos5FacturasPacientesAccess(ruta);
        }

        public Carpeta BuscarCarpetaPorFacturaAccess(String factura,String ruta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.BuscarCarpetaPorFacturaAccess(factura,ruta);
        }

        public Odontologo BuscarOdotologoPorIdAccess(int idOdontologo)
        {

            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.BuscarOdotologoPorIdAccess(idOdontologo);
        }

        public int ModificarEnviasRetiras(Carpeta carpeta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.ModificarEnviasRetiras(carpeta);
        }

        public void GuardarRuta(String ruta, int tipo)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            objServicioN.GuardarRuta(ruta,tipo);
        }

        public String ObtenerRuta(int tipo)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
           return  objServicioN.ObtenerRuta(tipo);
        }

        public List<Carpeta> BuscarCarpetasAccess(String ruta)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.BuscarCarpetasAccess(ruta);
        
        }

        public int ContarCarpetasXAnioMes(int anio, int mes)
        {
            ServicioRemoting.ServicioCarpeta objServicioN = new ServicioRemoting.ServicioCarpeta();
            return objServicioN.ContarCarpetasXAnioMes(anio, mes);
        }

    }
}
