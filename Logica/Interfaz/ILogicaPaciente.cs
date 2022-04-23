using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaPaciente
    {   

        Paciente BuscarUltimoPacienteAccess();
        Paciente BuscarUltimoPacienteSql();
        List<Paciente> Buscar20Pacientes();
        Paciente BuscarPacientePorNombre(String nombre, String apellido, DateTime fechaDeNac);
        List<Paciente> Buscar60Pacientes();
        Paciente BuscarPacientePorId(int id);
        Paciente BuscarPacientePorFactura(String factura);
        void AgregarPaciente(Paciente paciente);
        void ModificarPaciente(Paciente paciente);
        void EliminarPaciente(Paciente paciente);
        List<Paciente> ListarPacientes();
        List<Paciente> BuscarPacientesPorFecha(DateTime fecha);
        List<Paciente> BuscarPacientesPorNombre(String nombre);
        List<Paciente> BuscarPacientesPorApellido(String apellido);
    
    }
}
