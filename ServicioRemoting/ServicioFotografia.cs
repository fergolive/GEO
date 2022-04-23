using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;

namespace ServicioRemoting
{
    public class ServicioFotografia
    {

        private Persistencia.IPersistenciaFotografia unaPersistencia;

        public ServicioFotografia()
        {
            
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPFotografia();
        }

        public void AgregarFotografia(EntidadesCompartidas.Fotografia fotografia)
        {
            unaPersistencia.AgregarFotografia(fotografia);
        }

        public void EliminarFotografia(EntidadesCompartidas.Fotografia fotografia)
        {
            unaPersistencia.EliminarFotografia(fotografia);
        }

        public void EliminarFotos(int id)
        {
            unaPersistencia.EliminarFotos(id);
        }

        public EntidadesCompartidas.Fotografia BuscarFotografia(String factura)
        {
            return unaPersistencia.BuscarFotografia(factura);
        }

        public List<EntidadesCompartidas.Foto> BuscarFotografiasPorId(int id)
        {
            return unaPersistencia.BuscarFotografiasPorId(id);
        }

        public void AgregarImagen(EntidadesCompartidas.Foto foto) 
        {
            unaPersistencia.AgregarImagen(foto);
        }

        public void AgregarImagenConId(int id,EntidadesCompartidas.Foto foto)
        {
            unaPersistencia.AgregarImagenConId(id, foto);
        }

        public void ModificarFotografia(EntidadesCompartidas.Fotografia fotografia)
        {
            unaPersistencia.ModificarFotografia(fotografia);
        }
       

    }
}
