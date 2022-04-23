using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaOdontologo
    {
        void AgregarDireccion(Odontologo odontologo,String direccion);
        void AgregarDireccionAccess(Odontologo odontologo, String direccion);
        List<String> BuscarDirecciones(int id);
        List<Odontologo> BuscarOdontologos();
        Odontologo BuscarOdontologo(String nombre,String apellido);
        Odontologo BuscarOdontologoPorId(int id);
        Odontologo BuscarOdontologoPorFactura(String factura);
        void AgregarOdontologo(Odontologo odontologo);
        void ModificarOdontologo(Odontologo odontologo);
        void EliminarOdontologo(Odontologo odontologo);
        List<Odontologo> BuscarOdontologosAccess(String ruta);
        List<Odontologo> BuscarOdontologosPorNombre(String nombre);
        List<Odontologo> BuscarOdontologosPorCelular(int celular);
        List<Odontologo> BuscarOdontologosPorApellido(String apellido);
        List<Odontologo> BuscarOdontologosPorTelefono(int telefono);
    
    }
}
