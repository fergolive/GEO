using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioSpan
    {
        private Persistencia.IPersistenciaSpan unaPersistencia;

        public ServicioSpan()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPSpan();
        }

        public void AgregarSpan(EntidadesCompartidas.Span span)
        {
            unaPersistencia.AgregarSpan(span);
        }

        public void EliminarSpan(EntidadesCompartidas.Span span)
        {
            unaPersistencia.EliminarSpan(span);
        }

        public void ModificarSpan(EntidadesCompartidas.Span span)
        {
            unaPersistencia.ModificarSpan(span);
        }

        public EntidadesCompartidas.Span Buscarspan(String factura)
        {
            return (unaPersistencia.BuscarSpan(factura));
        }

        public List<EntidadesCompartidas.Span> ListarSpamPendientes()
        {
            return (unaPersistencia.ListarSpamPendientes());
        }

        


    }
}
