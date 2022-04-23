using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioOxi
    {
        private Persistencia.IPersistenciaOxi  unaPersistencia;

        public ServicioOxi()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPOxi();
        }

        public void AgregarOxi(EntidadesCompartidas.OptParaImplante oxi)
        {
            unaPersistencia.AgregarOptParaImplante(oxi);
        }

        public void EliminarOxi(EntidadesCompartidas.OptParaImplante oxi)
        {
            unaPersistencia.EliminarOptParaImplante(oxi);
        }

        public void ModificarOxi(EntidadesCompartidas.OptParaImplante oxi)
        {
            unaPersistencia.ModificarOptParaImplante(oxi);
        }

        public List<EntidadesCompartidas.OptParaImplante> ListarOxisPendientes()
        {
            return unaPersistencia.ListarOxisPendientes();
        }

        public EntidadesCompartidas.OptParaImplante BuscarOptParaImplante(String factura)
        {
            return unaPersistencia.BuscarOptParaImplante(factura);
        }

        public EntidadesCompartidas.OptParaImplante BuscarOptParaImplantePorId(int id)
        {
            return unaPersistencia.BuscarOptParaImplantePorId(id);
        }

        
    }
}
