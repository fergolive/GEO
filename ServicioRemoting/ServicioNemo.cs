using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioNemo
    {
        private Persistencia.IPersistenciaNemo unaPersistencia;

        public ServicioNemo()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPNemoDoc();
        }

        public void AgregarNemo(EntidadesCompartidas.NemoDocViewer nemo)
        {
            unaPersistencia.AgregarNemo(nemo);
        }

        public void EliminarNemo(EntidadesCompartidas.NemoDocViewer nemo)
        {
            unaPersistencia.EliminarNemo(nemo);
        }

        public void ModificarNemo(EntidadesCompartidas.NemoDocViewer nemo)
        {
            unaPersistencia.ModificarNemo(nemo);
        }

        public EntidadesCompartidas.NemoDocViewer BuscarNemo(String factura)
        {
            return (unaPersistencia.BuscarNemo(factura));
        }

        public List<EntidadesCompartidas.NemoDocViewer> ListarNemosPendientes()
        {
            return (unaPersistencia.ListarNemosPendientes());
        }

    }
}
