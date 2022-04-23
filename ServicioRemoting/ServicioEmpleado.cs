using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioEmpleado
    {

        private Persistencia.IPersistenciaEmpleado unaPersistencia;

        public ServicioEmpleado()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPEMpleado();
        }

        
        public void Agregar(EntidadesCompartidas.Empleado empleado)
        {
            unaPersistencia.AgregarEmpleado(empleado);
        }

        public void Eliminar(EntidadesCompartidas.Empleado empleado)
        {
            unaPersistencia.EliminarEmpleado(empleado);
        }

        public void Modificar(EntidadesCompartidas.Empleado empleado)
        {
            unaPersistencia.ModificarEmpleado(empleado);
        }

        public EntidadesCompartidas.Empleado BuscarEmpleado(String username, String contraseña)
        {
            return (unaPersistencia.BuscarEmpleado(username, contraseña));
        }

        public EntidadesCompartidas.Empleado BuscarEmpleadoPorId(int idempleado)
        {
            return (unaPersistencia.BuscarEmpleadoPorId(idempleado));
        }

        public List<EntidadesCompartidas.Empleado> BuscarEmpleados(String tipo)
        {
            return (unaPersistencia.BuscarEmpleados(tipo));
        }

        public List<EntidadesCompartidas.Empleado> BuscarEmpleadosPorNombre(String nombre)
        { 
            
            return (unaPersistencia.BuscarEmpleadosPorNombre(nombre)); 
        
        }

        public List<EntidadesCompartidas.Empleado> BuscarEmpleadosPorApellido(String apellido)
        {
            return (unaPersistencia.BuscarEmpleadosPorApellido(apellido));
        
        }
    }
}
