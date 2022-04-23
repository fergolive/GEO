using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;


namespace Logica
{
    internal class LogicaSpan :ILogicaSpan
    {
        private static LogicaSpan instance = null;
        private LogicaSpan() { }
        public static LogicaSpan getLogica()
        {
            if (instance == null)
                instance = new LogicaSpan();
            return instance;
        }

        public void AgregarSpan(Span span)
        {
            ServicioRemoting.ServicioSpan objServicioC = new ServicioRemoting.ServicioSpan();
            objServicioC.AgregarSpan(span);
        }

        public void EliminarSpan(Span span)
        {
            ServicioRemoting.ServicioSpan objServicioC = new ServicioRemoting.ServicioSpan();
            objServicioC.EliminarSpan(span);
        }

        public void ModificarSpan(Span span)
        {
            ServicioRemoting.ServicioSpan objServicioC = new ServicioRemoting.ServicioSpan();
            objServicioC.ModificarSpan(span);

        }

        public Span BuscarSpan(String factura)
        {
            ServicioRemoting.ServicioSpan objServicioC = new ServicioRemoting.ServicioSpan();
            return (objServicioC.Buscarspan(factura));

        }

        public List<Span> ListarSpamPendientes()
        {
            ServicioRemoting.ServicioSpan objServicioC = new ServicioRemoting.ServicioSpan();
            return objServicioC.ListarSpamPendientes();

        }

      
    }
}
