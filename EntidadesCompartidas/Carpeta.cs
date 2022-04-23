using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    [Serializable]
    public class Carpeta
    {
        

        String numDeFactura;
        String tipo;
        DateTime fechaPrometida;
        DateTime fechaRealizada;
        String clinica;
        String observaciones;
        bool cerrada;
        Empleado cerradaPor;
        String entregadaA;
        Paciente paciente;
        Odontologo odontologo;
        String direccionDeEnvio; //un string?? porque asi tendra una direccion d envio
        bool enviada;
        bool retirada;
        String direccion_Persona_EnvRet;


        public Carpeta() 
        {
            numDeFactura="";
            tipo = "";
            fechaPrometida=DateTime.Now;
            fechaRealizada = DateTime.Now;
            clinica="";
            observaciones="";
            cerrada = false;
            cerradaPor = new Empleado();
            entregadaA="";
            paciente = null;
            odontologo = null;
            direccionDeEnvio = "";
            enviada = false;
            retirada = false;
            direccion_Persona_EnvRet = "";
        }

        public Carpeta(String numFac,String _tipo,DateTime fecProm,DateTime fecReal,String clinic,String obs,bool cerrad,Empleado _cerradaPor,String entregada,Paciente pac,Odontologo doctor,String direccionEnvio,bool env,bool ret,String dper)
        {
            numDeFactura = numFac;
            tipo = _tipo;
            fechaPrometida = fecProm;
            fechaRealizada = fecReal;
            clinica = clinic;
            observaciones = obs;
            cerrada = cerrad;
            cerradaPor = _cerradaPor;
            entregadaA =entregada;
            paciente = pac;
            odontologo = doctor;
            direccionDeEnvio = direccionEnvio;
            enviada = env;
            retirada = ret;
            direccion_Persona_EnvRet = dper;
        }


        public String NumDeFactura
        {
            get { return numDeFactura; }
            set { numDeFactura = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public DateTime FechaPrometida
        {
            get { return fechaPrometida;}
            set { fechaPrometida=value; }
        }

        public DateTime FechaRealizada
        {
            get { return fechaRealizada; }
            set { fechaRealizada= value; }
        }

        public String Clinica
        {
            get { return clinica; }
            set { clinica=value; }
        }

        public String Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        public bool Cerrada
        {
            get { return cerrada; }
            set { cerrada = value; }
        }

        public Empleado CerradaPor
        {
            get { return cerradaPor; }
            set { cerradaPor = value; }
        }
        public String EntregadaA
        {
            get { return entregadaA; }
            set { entregadaA = value; }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        }

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public Odontologo Odontologo
        {
            get { return odontologo; }
            set { odontologo= value; }
        }

        public String DireccionDeEnvio
        {
            get { return direccionDeEnvio; }
            set { direccionDeEnvio = value; }
        }

        public bool Enviada
        {
            get { return enviada; }
            set { enviada = value; }
        }

        public bool Retirada
        {
            get { return retirada; }
            set { retirada = value; }
        }

        public String Direccion_Persona_EnvRet
        {
            get { return direccion_Persona_EnvRet; }
            set { direccion_Persona_EnvRet = value; }
        }
    }
}
