using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;


namespace Logica
{
    internal class LogicaOxi : ILogicaOxi
    {
        private static LogicaOxi instance = null;
        private LogicaOxi() { }
        public static LogicaOxi getLogica()
        {
            if (instance == null)
                instance = new LogicaOxi();
            return instance;
        }

        public void AgregarOptParaImplante(OptParaImplante optParaImplante)
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            objServicioS.AgregarOxi(optParaImplante);
        }

        public void EliminarOptParaImplante(OptParaImplante optParaImplante)
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            objServicioS.EliminarOxi(optParaImplante);
        }


        public void ModificarOptParaImplante(OptParaImplante optParaImplante)
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            objServicioS.ModificarOxi(optParaImplante);
        }

        public List<OptParaImplante> ListarOxisPendientes()
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            return objServicioS.ListarOxisPendientes();
        }

        public OptParaImplante BuscarOptParaImplante(String factura)
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            return objServicioS.BuscarOptParaImplante(factura);
        }

        public OptParaImplante BuscarOptParaImplantePorId(int id)
        {
            ServicioRemoting.ServicioOxi objServicioS = new ServicioRemoting.ServicioOxi();
            return objServicioS.BuscarOptParaImplantePorId(id);
        }

        
    }
}
