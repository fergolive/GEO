using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaModelo :ILogicaModelo
    {
        private static LogicaModelo instance = null;
        private LogicaModelo() { }
        public static LogicaModelo getLogica()
        {
            if (instance == null)
                instance = new LogicaModelo();
            return instance;
        }

        public void AgregarModelo(Modelo modelo)
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            objServicioN.AgregarModelo(modelo);
        }

        public void EliminarModelo(Modelo modelo)
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            objServicioN.EliminarModelo(modelo);
        }

        public void ModificarModelo(Modelo modelo)
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            objServicioN.ModificarModelo(modelo);
        }

        public Modelo BuscarModelo(String factura)
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            return objServicioN.BuscarModelo(factura);
        }

        public List<Modelo> ListarModelosPendientes()
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            return objServicioN.ListarModelosPendientes();
        }

        public List<Foto> BuscarFotografiasModPorId(int id)
        {
            ServicioRemoting.ServicioModelo objServicioN = new ServicioRemoting.ServicioModelo();
            return objServicioN.BuscarFotografiasModPorId(id);
        }

    }
}
