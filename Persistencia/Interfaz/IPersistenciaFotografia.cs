using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaFotografia
    {
        Fotografia BuscarFotografia(String factura);
        void AgregarFotografia(Fotografia fotografia);
        void ModificarFotografia(Fotografia fotografia);
        List<Foto> BuscarFotografiasPorId(int id);
        void EliminarFotografia(Fotografia fototografia);
        void AgregarImagen(Foto foto);
        void EliminarFotos(int id);
        void AgregarImagenConId(int id,Foto foto);
    }
}
