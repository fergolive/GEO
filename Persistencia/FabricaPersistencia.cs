using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Persistencia
{
    public class FabricaPersistencia: MarshalByRefObject
    {
        
        public FabricaPersistencia() { }


        public IPersistenciaCarpeta getPCarpeta()
        {
           return (PersistenciaCarpeta.GetPersistencia());
        }

        public IPersistenciaEmpleado getPEMpleado()
        {
            return (PersistenciaEmpleado.GetPersistencia());
        }

        public IPersistenciaPaciente getPPaciente()
        {
            return (PersistenciaPaciente.GetPersistencia());
        }

        public IPersistenciaOdontologo getPOdontologo()
        {
            return (PersistenciaOdontologo.GetPersistencia());
        }

        public IPersistenciaNemo getPNemoDoc()
        {
            return (PersistenciaNemoDoc.GetPersistencia());
        }

        public IPersistenciaSpan getPSpan()
        {
            return (PersistenciaSpam.GetPersistencia());
        }

        public IPersistenciaTomografia getPTomografia()
        {
            return (PersistenciaTomografia.GetPersistencia());
        }

        public IPersistenciaFotografia getPFotografia()
        {
            return (PersistenciaFotografia.GetPersistencia());
        }

        public IPersistenciaModelo getPModelo()
        {
            return (PersistenciaModelo.GetPersistencia());
        }

        public IPersistenciaOxi getPOxi()
        {
            return (PersistenciaOptParaImplante.GetPersistencia());
        }
    }
}
