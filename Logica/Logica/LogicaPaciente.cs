using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaPaciente :ILogicaPaciente
    {
        private static LogicaPaciente instance = null;
        private LogicaPaciente() { }
        public static LogicaPaciente getLogica()
        {
            if (instance == null)
                instance = new LogicaPaciente();
            return instance;
        }

        public void AgregarPaciente(Paciente paciente)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            objServicioA.AgregarPaciente(paciente);
        }

        public void EliminarPaciente(Paciente paciente)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            objServicioA.EliminarPaciente(paciente);
        }

        public void ModificarPaciente(Paciente paciente)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            objServicioA.ModificarPaciente(paciente);
        }

        public List<Paciente> Buscar20Pacientes()
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.Buscar20Pacientes();
        }

        public List<Paciente> Buscar60Pacientes()
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.Buscar60Pacientes();
        }

        public Paciente BuscarPacientePorNombre(String nombre,String apellido,DateTime fechaDeNac)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientePorNombre(nombre,apellido,fechaDeNac);
        }

        public Paciente BuscarPacientePorFactura(String factura)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientePorFactura(factura);
        }

        public Paciente BuscarPacientePorId(int id)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientePorId(id);
        }

        public Paciente BuscarUltimoPacienteAccess()
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarUltimoPacienteAccess();
        }

        public Paciente BuscarUltimoPacienteSql()
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarUltimoPacienteSql();
        }

        public List<Paciente> ListarPacientes()
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.ListarPacientes();
        }

        public List<Paciente> BuscarPacientesPorFecha(DateTime fecha)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientesPorFecha(fecha);
        }

        public List<Paciente> BuscarPacientesPorNombre(String nombre)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientesPorNombre(nombre);
        }

        public List<Paciente> BuscarPacientesPorApellido(String apellido)
        {
            ServicioRemoting.ServicioPaciente objServicioA = new ServicioRemoting.ServicioPaciente();
            return objServicioA.BuscarPacientesPorApellido(apellido);
        }
       

       


        

       
    }
}
