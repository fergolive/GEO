using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Logica;


namespace Logica
{
    internal class LogicaFotografia :ILogicaFotografia
    {
        private static LogicaFotografia instance = null;
        private LogicaFotografia() { }
        public static LogicaFotografia getLogica()
        {
            if (instance == null)
                instance = new LogicaFotografia();
            return instance;
        }

        public void AgregarFotografia(Fotografia fotografia)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.AgregarFotografia(fotografia);
        }

        public void ModificarFotografia(Fotografia fotografia)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.ModificarFotografia(fotografia);
        }

        public void EliminarFotografia(Fotografia fotografia)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.EliminarFotografia(fotografia);
        }

        public Fotografia BuscarFotografia(String factura)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            return objServicioF.BuscarFotografia(factura);
        }

        public List<Foto> BuscarFotografiasPorId(int id)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            return objServicioF.BuscarFotografiasPorId(id);
        }

        public void AgregarImagen(Foto foto)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.AgregarImagen(foto);
        }

        public void EliminarFotos(int id)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.EliminarFotos(id);
        }

        public void AgregarImagenConId(int id, Foto foto)
        {
            ServicioRemoting.ServicioFotografia objServicioF = new ServicioRemoting.ServicioFotografia();
            objServicioF.AgregarImagenConId(id,foto);
        }


       
    }
}
