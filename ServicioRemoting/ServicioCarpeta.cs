using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioCarpeta
    {
        private Persistencia.IPersistenciaCarpeta unaPersistencia;

        public ServicioCarpeta()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPCarpeta();
        }

        public void AgregarCarpeta(EntidadesCompartidas.Carpeta carpeta)
        {
            unaPersistencia.AgregarCarpeta(carpeta);
        }

        public void AgregarCarpeta2(EntidadesCompartidas.Carpeta carpeta)
        {
            unaPersistencia.AgregarCarpeta2(carpeta);
        }
        public void EliminarCarpeta(EntidadesCompartidas.Carpeta carpeta)
        {
            unaPersistencia.EliminarCarpeta(carpeta);
        }

        public void ModificarCarpeta(EntidadesCompartidas.Carpeta carpeta)
        {
            unaPersistencia.ModificarCarpeta(carpeta);
        }

        public List<EntidadesCompartidas.Carpeta> ListarEnviosPendientes(String tipo,String entregada)
        {
            return unaPersistencia.ListarEnviosPendientes(tipo,entregada);
        }

        public EntidadesCompartidas.Carpeta BuscarCarpeta(String factura)
        {
            return unaPersistencia.BuscarCarpeta(factura);
        }

        public List<EntidadesCompartidas.Carpeta> BuscarCarpetas(String consulta)
        {
            return unaPersistencia.BuscarCarpetas(consulta);
        }

        public List<String> ListarUltimos5FacturasPacientesAccess(String ruta)
        {
            return unaPersistencia.ListarUltimos5FacturasPacientesAccess(ruta);
        }

        public EntidadesCompartidas.Carpeta BuscarCarpetaPorFacturaAccess(String factura,String ruta)
        {
            return unaPersistencia.BuscarCarpetaPorFacturaAccess(factura,ruta);
        }

        public EntidadesCompartidas.Odontologo BuscarOdotologoPorIdAccess(int idOdontologo)
        {
            return unaPersistencia.BuscarOdotologoPorIdAccess(idOdontologo);
        }

        public int ModificarEnviasRetiras(EntidadesCompartidas.Carpeta carpeta)
        {
           return unaPersistencia.ModificarEnviasRetiras(carpeta);
        }

        public void GuardarRuta(String ruta, int tipo)
        {
            unaPersistencia.GuardarRuta(ruta,tipo);
        }

        public String ObtenerRuta(int tipo)
        {
            return unaPersistencia.ObtenerRuta(tipo);
        }

        public List<EntidadesCompartidas.Carpeta> BuscarCarpetasAccess(String ruta)
        { 
            return unaPersistencia.BuscarCarpetasAccess(ruta);
        }

        public int ContarCarpetasXAnioMes(int anio, int mes)
        {
            return unaPersistencia.ContarCarpetasXAnioMes(anio,mes);
        }
        
    }
}
