using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Collections;


namespace Logica
{
    internal class LogicaOdontologo :ILogicaOdontologo
    {
        private static LogicaOdontologo instance = null;
        private LogicaOdontologo() { }
        public static LogicaOdontologo getLogica()
        {
            if (instance == null)
                instance = new LogicaOdontologo();
            return instance;
        }

        public void AgregarOdontologo(Odontologo odontologo)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            objServicioO.AgregarOdontologo(odontologo);
        }

        public void EliminarOdontologo(Odontologo odontologo)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            objServicioO.Eliminar(odontologo);
        }

        public void ModificarOdontologo(Odontologo odontologo)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            objServicioO.ModificarOdontologo(odontologo);
        }

        public Odontologo BuscarOdontologo(String nombre,String apellido)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologo(nombre,apellido));
        }

        public Odontologo BuscarOdontologoPorFactura(String factura)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologoPorFactura(factura));
        }

        public Odontologo BuscarOdontologoPorId(int id)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologoPorId(id));
        }

        public List<Odontologo> BuscarOdontologos()
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologos());
        }

        public List<String> BuscarDirecciones(int id)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarDirecciones(id));
        }

        public void AgregarDireccion(Odontologo odontologo,String direccion)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            objServicioO.AgregarDireccion(odontologo,direccion);
        }

        public void AgregarDireccionAccess(Odontologo odontologo, String direccion)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            objServicioO.AgregarDireccionAccess(odontologo, direccion);
        }

        public List<Odontologo> BuscarOdontologosAccess(String ruta)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologosAccess(ruta));
        }

        public List<Odontologo> BuscarOdontologosPorNombre(String nombre)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologosPorNombre(nombre));
        
        }
        public List<Odontologo> BuscarOdontologosPorApellido(String apellido)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologosPorApellido(apellido));
        }
        public List<Odontologo> BuscarOdontologosPorTelefono(int telefono)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologosPorTelefono(telefono));
        }
        public List<Odontologo> BuscarOdontologosPorCelular(int celular)
        {
            ServicioRemoting.ServicioOdontologo objServicioO = new ServicioRemoting.ServicioOdontologo();
            return (objServicioO.BuscarOdontologosPorCelular(celular));
        }
     

       

    }
}
