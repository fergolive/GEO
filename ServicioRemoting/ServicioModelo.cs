using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioModelo
    {
        private Persistencia.IPersistenciaModelo unaPersistencia;

        public ServicioModelo()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPModelo();
        }

        public void AgregarModelo(EntidadesCompartidas.Modelo modelo)
        {
            unaPersistencia.AgregarModelo(modelo);
        }

        public void EliminarModelo(EntidadesCompartidas.Modelo modelo)
        {
            unaPersistencia.EliminarModelo(modelo);
        }

        public void ModificarModelo(EntidadesCompartidas.Modelo modelo)
        {
            unaPersistencia.ModificarModelo(modelo);
        }

        public List<EntidadesCompartidas.Modelo> ListarModelosPendientes()
        {
            return (unaPersistencia.ListarModelosPendientes());
        }

        public EntidadesCompartidas.Modelo BuscarModelo(String factura)
        {
            return (unaPersistencia.BuscarModelo(factura));
        }

        public List<EntidadesCompartidas.Foto> BuscarFotografiasModPorId(int id)
        {
            return (unaPersistencia.BuscarFotografiasModPorId(id));
        }
    }
}
