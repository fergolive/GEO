using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaNemo
    {
        NemoDocViewer BuscarNemo(String factura);
        void AgregarNemo(NemoDocViewer nemo);
        void ModificarNemo(NemoDocViewer nemo);
        void EliminarNemo(NemoDocViewer nemo);
        List<NemoDocViewer> ListarNemosPendientes();
    }
}
