using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
namespace Persistencia
{
    public interface IPersistenciaSpan
    {
        Span BuscarSpan(String factura);
        void AgregarSpan(Span span);
        void ModificarSpan(Span span);
        void EliminarSpan(Span span);
        List<Span> ListarSpamPendientes();
    }
}
