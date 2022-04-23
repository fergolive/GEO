using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

using System.Collections;

namespace Logica
{
    internal class LogicaNemo :ILogicaNemo
    {
        private static LogicaNemo instance = null;
        private LogicaNemo() { }
        public static LogicaNemo getLogica()
        {
            if (instance == null)
                instance = new LogicaNemo();
            return instance;
        }

        public void AgregarNemo(NemoDocViewer nemo)
        {
            ServicioRemoting.ServicioNemo objServicioN = new ServicioRemoting.ServicioNemo();
            objServicioN.AgregarNemo(nemo);
        }

        public void EliminarNemo(NemoDocViewer nemo)
        {
            ServicioRemoting.ServicioNemo objServicioN = new ServicioRemoting.ServicioNemo();
            objServicioN.EliminarNemo(nemo);
        }

        public void ModificarNemo(NemoDocViewer nemo)
        {
            ServicioRemoting.ServicioNemo objServicioN = new ServicioRemoting.ServicioNemo();
            objServicioN.ModificarNemo(nemo);
        }

        public NemoDocViewer BuscarNemo(String factura)
        {
            ServicioRemoting.ServicioNemo objServicioN = new ServicioRemoting.ServicioNemo();
            return objServicioN.BuscarNemo(factura);
        }

        public List<NemoDocViewer> ListarNemosPendientes()
        {
            ServicioRemoting.ServicioNemo objServicioN = new ServicioRemoting.ServicioNemo();
            return objServicioN.ListarNemosPendientes();
        }

        
       
    }
}
