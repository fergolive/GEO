using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaNemo
    {
        NemoDocViewer BuscarNemo(String factura);
        void AgregarNemo(NemoDocViewer nemo);
        void ModificarNemo(NemoDocViewer nemo);
        void EliminarNemo(NemoDocViewer nemo);
        List<NemoDocViewer> ListarNemosPendientes();
    }
}
