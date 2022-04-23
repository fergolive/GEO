using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaModelo
    {
        Modelo BuscarModelo(string factura);
        void AgregarModelo(Modelo modelo);
        void ModificarModelo(Modelo modelo);
        void EliminarModelo(Modelo modelo);
        List<Modelo> ListarModelosPendientes();
        List<Foto> BuscarFotografiasModPorId(int id);
    }
}
