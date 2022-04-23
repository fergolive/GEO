using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaCarpeta
    {
        Carpeta BuscarCarpeta(String factura);
        List<Carpeta> BuscarCarpetas(String consulta);
        void AgregarCarpeta(Carpeta carpeta);
        void AgregarCarpeta2(Carpeta carpeta);
        void ModificarCarpeta(Carpeta carpeta);
        void EliminarCarpeta(Carpeta carpeta);
        List<Carpeta> ListarEnviosPendientes(String tipo,String entrgada);
        //access
       
        List<String> ListarUltimos5FacturasPacientesAccess(String ruta);
        Carpeta BuscarCarpetaPorFacturaAccess(String factura,String ruta);
        Odontologo BuscarOdotologoPorIdAccess(int idOdontologo);
        int ModificarEnviasRetiras(Carpeta carpeta);

        void GuardarRuta(String ruta, int tipo);
        String ObtenerRuta(int tipo);
        List<Carpeta> BuscarCarpetasAccess(String ruta);
        int ContarCarpetasXAnioMes(int anio, int mes);

    }
}
