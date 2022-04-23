using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioOdontologo
    {

         private Persistencia.IPersistenciaOdontologo unaPersistencia;

        public ServicioOdontologo()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPOdontologo();
        }

        public void AgregarOdontologo(EntidadesCompartidas.Odontologo odontologo)
        {
            unaPersistencia.AgregarOdontologo(odontologo);
        }

        public void Eliminar(EntidadesCompartidas.Odontologo odontologo)
        {
            unaPersistencia.EliminarOdontologo(odontologo);
        }

        public void ModificarOdontologo(EntidadesCompartidas.Odontologo odontologo)
        {
            unaPersistencia.ModificarOdontologo(odontologo);
        }

        public EntidadesCompartidas.Odontologo BuscarOdontologo(String nombre,String apellido)
        {
            return (unaPersistencia.BuscarOdontologo(nombre,apellido));
        }

        public EntidadesCompartidas.Odontologo BuscarOdontologoPorFactura(String factura)
        {
            return (unaPersistencia.BuscarOdontologoPorFactura(factura));
        }

        public EntidadesCompartidas.Odontologo BuscarOdontologoPorId(int id)
        {
            return (unaPersistencia.BuscarOdontologoPorId(id));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologos()
        {
            return (unaPersistencia.BuscarOdontologos());
        }

        public void AgregarDireccion(EntidadesCompartidas.Odontologo odontologo,String direccion)
        {
            unaPersistencia.AgregarDireccion(odontologo,direccion);
        }

        public void AgregarDireccionAccess(EntidadesCompartidas.Odontologo odontologo, String direccion)
        {
            unaPersistencia.AgregarDireccionAccess(odontologo, direccion);
        }

        public List<String> BuscarDirecciones(int id)
        {
            return (unaPersistencia.BuscarDirecciones(id));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologosAccess(String ruta)
        {
            return (unaPersistencia.BuscarOdontologosAccess(ruta));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologosPorCelular(int celular)
        {
            return (unaPersistencia.BuscarOdontologosPorCelular(celular));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologosPorTelefono(int telefono)
        {
            return (unaPersistencia.BuscarOdontologosPorTelefono(telefono));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologosPorNombre(String nombre)
        {
            return (unaPersistencia.BuscarOdontologosPorNombre(nombre));
        }

        public List<EntidadesCompartidas.Odontologo> BuscarOdontologosPorApellido(String apellido)
        {
            return (unaPersistencia.BuscarOdontologosPorApellido(apellido));
        }


      

    
        
    }
}
