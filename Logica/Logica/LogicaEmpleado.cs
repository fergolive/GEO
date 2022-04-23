using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;


namespace Logica
{
    internal class LogicaEmpleado : ILogicaEmpleado
    {
        private static LogicaEmpleado instance = null;
        private LogicaEmpleado() { }
        public static LogicaEmpleado getLogica()
        {
            if (instance == null)
                instance = new LogicaEmpleado();
            return instance;
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            objServicioE.Agregar(empleado);
        }

        public void EliminarEmpleado(Empleado empleado)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            objServicioE.Eliminar(empleado);
        }

        public void ModificarEmpleado(Empleado empleado)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            objServicioE.Modificar(empleado);
        }

        public Empleado BuscarEmpleado(string username,string contraseña)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            return (objServicioE.BuscarEmpleado(username,contraseña));
        }

        public Empleado BuscarEmpleadoPorId(int id)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            return (objServicioE.BuscarEmpleadoPorId(id));
        }

        public List<Empleado> BuscarEmpleados(String tipo)
        {
            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            return (objServicioE.BuscarEmpleados(tipo));
        }

        public List<Empleado> BuscarEmpleadosPorNombre(String nombre)
        {

            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            return (objServicioE.BuscarEmpleadosPorNombre(nombre));
        }

        public List<Empleado> BuscarEmpleadosPorApellido(String apellido) 
        {

            ServicioRemoting.ServicioEmpleado objServicioE = new ServicioRemoting.ServicioEmpleado();
            return (objServicioE.BuscarEmpleadosPorApellido(apellido));
        }

        
       
        
    }
}
