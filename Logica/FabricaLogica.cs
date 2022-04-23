using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public class FabricaLogica
    {
        public static ILogicaOxi getLogicaOxi()
        {
            return (LogicaOxi.getLogica());
        }

        public static ILogicaEmpleado getLogicaEmpleado()
        {
            return (LogicaEmpleado.getLogica());
        }

        public static ILogicaOdontologo getLogicaOdontologo()
        {
            return (LogicaOdontologo.getLogica());
        }

        public static ILogicaPaciente getLogicaPaciente()
        {
            return (LogicaPaciente.getLogica());
        }

        public static ILogicaCarpeta getLogicaCarpeta()
        {
            return (LogicaCarpeta.getLogica());
        }

        public static ILogicaTomografia getLogicaTomografia()
        {
            return (LogicaTomografia.getLogica());
        }

        public static ILogicaNemo getLogicaNemo()
        {
            return (LogicaNemo.getLogica());
        }

        public static ILogicaSpan getLogicaSpam()
        {
            return (LogicaSpan.getLogica());
        }

        public static ILogicaModelo getLogicaModelo()
        {
            return (LogicaModelo.getLogica());
        }

        public static ILogicaFotografia getLogicaFotografia()
        {
            return (LogicaFotografia.getLogica());
        }


    }
}
