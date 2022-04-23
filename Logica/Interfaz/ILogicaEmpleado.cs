using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaEmpleado
    {
        Empleado BuscarEmpleado(String nombre,String apellido);
        Empleado BuscarEmpleadoPorId(int id);
        List<Empleado> BuscarEmpleadosPorNombre(String nombre);
        List<Empleado> BuscarEmpleadosPorApellido(String apellido);
        List<Empleado> BuscarEmpleados(String tipo);
        void AgregarEmpleado(Empleado empleado);
        void ModificarEmpleado(Empleado empleado);
        void EliminarEmpleado(Empleado empleado);
    }
}
