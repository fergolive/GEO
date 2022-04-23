using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioTomografia
    {
         private Persistencia.IPersistenciaTomografia unaPersistencia;

        public ServicioTomografia()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPTomografia();
        }

        public void AgregarTomografia(EntidadesCompartidas.Tomografia tomografia)
        {
            unaPersistencia.AgregarTomografia(tomografia);
        }

        public void EliminarTomografia(EntidadesCompartidas.Tomografia tomografia)
        {
            unaPersistencia.EliminarTomografia(tomografia);
        }

        public void ModificarTomografia(EntidadesCompartidas.Tomografia tomografia)
        {
            unaPersistencia.ModificarTomografia(tomografia);
        }

        public EntidadesCompartidas.Tomografia BuscarTomografia(String factura)
        {
            return (unaPersistencia.BuscarTomografia(factura));
        }

        public List<EntidadesCompartidas.Tomografia> ListarTomografiasPendientes()
        {
            return (unaPersistencia.ListarTomografiasPendientes());
        }

       
    }
}
