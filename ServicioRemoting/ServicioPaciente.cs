using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServicioRemoting
{
    public class ServicioPaciente
    {
        private Persistencia.IPersistenciaPaciente unaPersistencia;

        public ServicioPaciente()
        {
            Servicio.CreoServicio();

            unaPersistencia = (new Persistencia.FabricaPersistencia()).getPPaciente();
        }

        public void AgregarPaciente(EntidadesCompartidas.Paciente paciente)
        {
            unaPersistencia.AgregarPaciente(paciente);
        }

        public void EliminarPaciente(EntidadesCompartidas.Paciente paciente)
        {
            unaPersistencia.EliminarPaciente(paciente);
        }

        public void ModificarPaciente(EntidadesCompartidas.Paciente paciente)
        {
            unaPersistencia.ModificarPaciente(paciente);
        }

        public List<EntidadesCompartidas.Paciente> Buscar20Pacientes()
        {
            return (unaPersistencia.Buscar20Pacientes());
        }

        public List<EntidadesCompartidas.Paciente> Buscar60Pacientes()
        {
            return (unaPersistencia.Buscar60Pacientes());
        }

        public EntidadesCompartidas.Paciente BuscarPacientePorFactura(String factura)
        {
            return (unaPersistencia.BuscarPacientePorFactura(factura));
        }

        public EntidadesCompartidas.Paciente BuscarPacientePorId(int id)
        {
            return (unaPersistencia.BuscarPacientePorId(id));
        }

        public EntidadesCompartidas.Paciente BuscarUltimoPacienteAccess()
        {
            return (unaPersistencia.BuscarUltimoPacienteAccess());
        }

        public EntidadesCompartidas.Paciente BuscarUltimoPacienteSql()
        {
            return (unaPersistencia.BuscarUltimoPacienteSql());
        }

       

        public List<EntidadesCompartidas.Paciente> ListarPacientes()
        {
            return (unaPersistencia.ListarPacientes());
        }

        public EntidadesCompartidas.Paciente BuscarPacientePorNombre(String nombre, String apellido, DateTime fechaDeNac)
        {
            
             return (unaPersistencia.BuscarPacientePorNombre(nombre,apellido,fechaDeNac));
            
        }

        public List<EntidadesCompartidas.Paciente> BuscarPacientesPorFecha(DateTime fecha)
        {
            return (unaPersistencia.BuscarPacientesPorFecha(fecha));
        }
        public List<EntidadesCompartidas.Paciente> BuscarPacientesPorNombre(String nombre)
        {
            return (unaPersistencia.BuscarPacientesPorNombre(nombre));
        }
        public List<EntidadesCompartidas.Paciente> BuscarPacientesPorApellido(String apellido)
        {
            return (unaPersistencia.BuscarPacientesPorApellido(apellido));
        }
        

       
        

    }
}
