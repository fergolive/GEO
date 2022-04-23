using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaTomografia
    {
        Tomografia BuscarTomografia(String factura);
        void AgregarTomografia(Tomografia tomo);
        void ModificarTomografia(Tomografia tomo);
        void EliminarTomografia(Tomografia tomo);
        List<Tomografia> ListarTomografiasPendientes();
    }
}
