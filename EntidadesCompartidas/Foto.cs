using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.IO;





namespace EntidadesCompartidas
{
    [Serializable]
    public class Foto
    {
        private int id;
        private byte[] fotoGrande;
        private byte[] fotoMiniatura;

        public Foto()
        {
            id = 0;
            fotoGrande = null;
            fotoMiniatura = null;
        }

        public Foto(int _id,byte[] fGrande,byte[] fChica)
        {
            id = _id;
            fotoGrande = fGrande;
            fotoMiniatura = fChica;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        
        public byte[] FotoGrande
        {
            get { return fotoGrande; }
            set { fotoGrande = value; }
        }

        public byte[] FotoMiniatura
        {
            get { return fotoMiniatura; }
            set { fotoMiniatura=value; }
        }
    }
}
