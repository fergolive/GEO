using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace Persistencia
{
    internal class PersistenciaNemoDoc:MarshalByRefObject,IPersistenciaNemo
    {
        private static PersistenciaNemoDoc _miPersistencia=null;
        private PersistenciaNemoDoc() { }
        public static PersistenciaNemoDoc GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaNemoDoc();
            return _miPersistencia;
        }

        

        public NemoDocViewer BuscarNemo(String factura)
        {
            
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarNemo " + factura, oConexion);
            SqlDataReader oReader;

            int id;
            
            bool nemo;
            bool docV;
            bool roth;
            bool ayala;
            bool pcontrat;
            bool psintrat;
            bool visest;
            bool rb;
            bool mc;
            bool oli;
            bool bj;
            bool pow;
            bool quir;
            bool trevisi;
            bool hold;
            bool harv;
            bool sch;
            bool rick;
            bool fotoDig;
            String tipodefoto;
            String ident;
            bool cd;
            bool rickfront;
            bool modelo;
            bool sinopt;
            String software;
            String observaciones;
            DateTime fechaRealizado;
            DateTime fechaPrometido;
            bool cerrada;
            Empleado cerradaPor;
            int empleado;
            Carpeta carpeta;
            
            NemoDocViewer nemodoc = null;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id=Convert.ToInt32(oReader["id"]);
                    
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometido = Convert.ToDateTime(oReader["FechaPrometido"]);
                    nemo = Convert.ToBoolean(oReader["Nemo"]);
                    docV = Convert.ToBoolean(oReader["DocViewer"]);
                    roth = Convert.ToBoolean(oReader["Roth"]);
                    ayala = Convert.ToBoolean(oReader["Ayala"]);
                    pcontrat = Convert.ToBoolean(oReader["PConTrat"]);
                    psintrat = Convert.ToBoolean(oReader["PSinTrat"]);
                    visest = Convert.ToBoolean(oReader["VisEst"]);
                    rb = Convert.ToBoolean(oReader["Rb"]);
                    mc = Convert.ToBoolean(oReader["Mc"]);
                    oli = Convert.ToBoolean(oReader["Oli"]);
                    bj = Convert.ToBoolean(oReader["Bj"]);
                    pow = Convert.ToBoolean(oReader["Pow"]);
                    quir = Convert.ToBoolean(oReader["Quir"]);
                    trevisi = Convert.ToBoolean(oReader["Trevisi"]);
                    hold = Convert.ToBoolean(oReader["Hold"]);
                    harv = Convert.ToBoolean(oReader["Harv"]);
                    sch = Convert.ToBoolean(oReader["Sch"]);
                    rick = Convert.ToBoolean(oReader["Rick"]);
                    fotoDig = Convert.ToBoolean(oReader["FotoDigital"]);
                    tipodefoto = (String)oReader["TipoDeFotoDig"];
                    ident = (String)oReader["IdentikitComentarios"];
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    rickfront = Convert.ToBoolean(oReader["RickFront"]);
                    modelo = Convert.ToBoolean(oReader["Modelo"]);

                    sinopt = Convert.ToBoolean(oReader["SinOpt"]);
                    software = (String)oReader["Software"];
                    observaciones = (String)oReader["Observaciones"];
                    cerrada = Convert.ToBoolean(oReader["Cerrado"]);
                    empleado=Convert.ToInt32(oReader["CerradoPor"]);

                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(empleado);
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    nemodoc = new NemoDocViewer(nemo, docV, roth, ayala, pcontrat, psintrat, visest, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotoDig, tipodefoto, ident, cd,rickfront,modelo,sinopt,software,observaciones, id, fechaRealizado,fechaPrometido,cerrada,cerradaPor,carpeta);

                }
                oReader.Close();
            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return nemodoc;
        }

        public void AgregarNemo(NemoDocViewer nemoDoc)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarNemo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@factura", nemoDoc.Carpeta.NumDeFactura);
            SqlParameter fr = new SqlParameter("@fechaRealizado", nemoDoc.FechaRealizado);
            SqlParameter fp = new SqlParameter("@fechaPrometido", nemoDoc.FechaPrometida);
            SqlParameter nemo = new SqlParameter("@nemo", nemoDoc.Nemo);
            
            SqlParameter doc = new SqlParameter("@docViewer", nemoDoc.DocViewer);
            SqlParameter roth = new SqlParameter("@roth", nemoDoc.Roth);
            SqlParameter ayala = new SqlParameter("@ayala", nemoDoc.Ayala);
            SqlParameter pcon = new SqlParameter("@pconTrat", nemoDoc.PConTrat);
            SqlParameter psin = new SqlParameter("@psinTrat", nemoDoc.PSinTrat);
            SqlParameter vis = new SqlParameter("@visEst", nemoDoc.VisEst);
            SqlParameter rb = new SqlParameter("@rb", nemoDoc.Rb);
            SqlParameter mc = new SqlParameter("@mc", nemoDoc.Mc);
            SqlParameter oli = new SqlParameter("@oli", nemoDoc.Oli);
            SqlParameter bj = new SqlParameter("@bj", nemoDoc.Bj);
            SqlParameter pow = new SqlParameter("@pow", nemoDoc.Pow);
            SqlParameter quir = new SqlParameter("@quir", nemoDoc.Quir);
            SqlParameter trev = new SqlParameter("@trevisi", nemoDoc.Trevisi);
            SqlParameter hold = new SqlParameter("@hold", nemoDoc.Hold);
            SqlParameter harv= new SqlParameter("@harv", nemoDoc.Harv);
            SqlParameter sch = new SqlParameter("@sch", nemoDoc.Sch);
            SqlParameter rick = new SqlParameter("@rick", nemoDoc.Rick);
            SqlParameter fd = new SqlParameter("@fotoDig", nemoDoc.FotoDigital);
            SqlParameter sinopt = new SqlParameter("@sinopt", nemoDoc.SinOpt);
            SqlParameter software = new SqlParameter("@software", nemoDoc.Software);
            SqlParameter observaciones = new SqlParameter("@observaciones", nemoDoc.Observaciones);
            SqlParameter tipoFoto = new SqlParameter("@tipodeFoto", nemoDoc.TipoDeFotoDigital);
            SqlParameter ident = new SqlParameter("@identikitComentarios", nemoDoc.IdentikitComentarios);
            SqlParameter cd = new SqlParameter("@cd", nemoDoc.Cd);
            SqlParameter rickFront = new SqlParameter("@RickFront", nemoDoc.RickFront);
            SqlParameter modelo = new SqlParameter("@Modelo", nemoDoc.Modelo);
            SqlParameter cerrado = new SqlParameter("@cerrado", nemoDoc.Cerrada);
            SqlParameter cerradoP = new SqlParameter("@cerradoPor", nemoDoc.CerradaPor.Id);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(fr);
            oComando.Parameters.Add(fp);
            oComando.Parameters.Add(nemo);
            oComando.Parameters.Add(doc);
            oComando.Parameters.Add(roth);
            oComando.Parameters.Add(ayala);
            oComando.Parameters.Add(pcon);
            oComando.Parameters.Add(psin);
            oComando.Parameters.Add(vis);
            oComando.Parameters.Add(rb);
            oComando.Parameters.Add(mc);
            oComando.Parameters.Add(oli);
            oComando.Parameters.Add(bj);
            oComando.Parameters.Add(pow);
            oComando.Parameters.Add(quir);
            oComando.Parameters.Add(trev);
            oComando.Parameters.Add(hold);
            oComando.Parameters.Add(harv);
            oComando.Parameters.Add(sch);
            oComando.Parameters.Add(rick);
            oComando.Parameters.Add(fd);
            oComando.Parameters.Add(sinopt);
            oComando.Parameters.Add(software);
            oComando.Parameters.Add(observaciones);
            oComando.Parameters.Add(tipoFoto);
            oComando.Parameters.Add(ident);
            oComando.Parameters.Add(cd);
            oComando.Parameters.Add(rickFront);
            oComando.Parameters.Add(modelo);
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoP);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("No existe una carpeta con el numero \n de factura especificado");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public void EliminarNemo(NemoDocViewer nemoDoc)
        {


            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarNemo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", nemoDoc.Id);




            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;


            oComando.Parameters.Add(id);



            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 5)
                    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                if (resultado == 4)
                    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                if (resultado == 3)
                    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                if (resultado == 2)
                    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }

        }

        public void ModificarNemo(NemoDocViewer nemoDoc)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarNemo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@factura", nemoDoc.Carpeta.NumDeFactura);
            SqlParameter fr = new SqlParameter("@fechaRealizado", nemoDoc.FechaRealizado);
            SqlParameter fp = new SqlParameter("@fechaPrometido", nemoDoc.FechaPrometida);
            SqlParameter nemo = new SqlParameter("@nemo", nemoDoc.Nemo);

            SqlParameter doc = new SqlParameter("@docViewer", nemoDoc.DocViewer);
            SqlParameter roth = new SqlParameter("@roth", nemoDoc.Roth);
            SqlParameter ayala = new SqlParameter("@ayala", nemoDoc.Ayala);
            SqlParameter pcon = new SqlParameter("@pconTrat", nemoDoc.PConTrat);
            SqlParameter psin = new SqlParameter("@psinTrat", nemoDoc.PSinTrat);
            SqlParameter vis = new SqlParameter("@visEst", nemoDoc.VisEst);
            SqlParameter rb = new SqlParameter("@rb", nemoDoc.Rb);
            SqlParameter mc = new SqlParameter("@mc", nemoDoc.Mc);
            SqlParameter oli = new SqlParameter("@oli", nemoDoc.Oli);
            SqlParameter bj = new SqlParameter("@bj", nemoDoc.Bj);
            SqlParameter pow = new SqlParameter("@pow", nemoDoc.Pow);
            SqlParameter quir = new SqlParameter("@quir", nemoDoc.Quir);
            SqlParameter trev = new SqlParameter("@trevisi", nemoDoc.Trevisi);
            SqlParameter hold = new SqlParameter("@hold", nemoDoc.Hold);
            SqlParameter harv = new SqlParameter("@harv", nemoDoc.Harv);
            SqlParameter sch = new SqlParameter("@sch", nemoDoc.Sch);
            SqlParameter rick = new SqlParameter("@rick", nemoDoc.Rick);
            SqlParameter fd = new SqlParameter("@fotoDig", nemoDoc.FotoDigital);
            SqlParameter sinopt = new SqlParameter("@sinopt", nemoDoc.SinOpt);
            SqlParameter software = new SqlParameter("@software", nemoDoc.Software);
            SqlParameter observaciones = new SqlParameter("@observaciones", nemoDoc.Observaciones);
            SqlParameter tipoFoto = new SqlParameter("@tipodeFoto", nemoDoc.TipoDeFotoDigital);
            SqlParameter ident = new SqlParameter("@identikitComentarios", nemoDoc.IdentikitComentarios);
            SqlParameter cd = new SqlParameter("@cd", nemoDoc.Cd);
            SqlParameter rickFront = new SqlParameter("@RickFront", nemoDoc.RickFront);
            SqlParameter modelo = new SqlParameter("@Modelo", nemoDoc.Modelo);
            SqlParameter cerrado = new SqlParameter("@cerrado", nemoDoc.Cerrada);
            SqlParameter cerradoP = new SqlParameter("@cerradoPor", nemoDoc.CerradaPor.Id);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(fr);
            oComando.Parameters.Add(fp);
            oComando.Parameters.Add(nemo);
            oComando.Parameters.Add(doc);
            oComando.Parameters.Add(roth);
            oComando.Parameters.Add(ayala);
            oComando.Parameters.Add(pcon);
            oComando.Parameters.Add(psin);
            oComando.Parameters.Add(vis);
            oComando.Parameters.Add(rb);
            oComando.Parameters.Add(mc);
            oComando.Parameters.Add(oli);
            oComando.Parameters.Add(bj);
            oComando.Parameters.Add(pow);
            oComando.Parameters.Add(quir);
            oComando.Parameters.Add(trev);
            oComando.Parameters.Add(hold);
            oComando.Parameters.Add(harv);
            oComando.Parameters.Add(sch);
            oComando.Parameters.Add(rick);
            oComando.Parameters.Add(fd);
            oComando.Parameters.Add(sinopt);
            oComando.Parameters.Add(software);
            oComando.Parameters.Add(observaciones);
            oComando.Parameters.Add(tipoFoto);
            oComando.Parameters.Add(ident);
            oComando.Parameters.Add(cd);
            oComando.Parameters.Add(rickFront);
            oComando.Parameters.Add(modelo);
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoP);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("No existe una carpeta con el numero \n de factura especificado");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
           

        }

        public List<NemoDocViewer> ListarNemosPendientes()
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarNemosPendientes", oConexion);
            SqlDataReader oReader;

            int id;
            bool nemo;
            bool docV;
            bool roth;
            bool ayala;
            bool pcontrat;
            bool psintrat;
            bool visest;
            bool rb;
            bool mc;
            bool oli;
            bool bj;
            bool pow;
            bool quir;
            bool trevisi;
            bool hold;
            bool harv;
            bool sch;
            bool rick;
            bool fotoDig;
            bool sinOpt;
            String software;
            String observaciones;
            String tipodefoto;
            String ident;
            bool cd;
            bool rickFront;
            bool modelo;
            DateTime fechaRealizado;
            DateTime fechaPrometido;
            bool cerrada;
            Empleado cerradaPor;
            int empleado;
            Carpeta carpeta;
            String factura = "";
 
            List<NemoDocViewer> listaDeNemos = new List<NemoDocViewer>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["id"]);
                    factura = (String)oReader["Factura"];
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometido = Convert.ToDateTime(oReader["FechaPrometido"]);
                    nemo = Convert.ToBoolean(oReader["Nemo"]);
                    docV = Convert.ToBoolean(oReader["DocViewer"]);
                    roth = Convert.ToBoolean(oReader["Roth"]);
                    ayala = Convert.ToBoolean(oReader["Ayala"]);
                    pcontrat = Convert.ToBoolean(oReader["PConTrat"]);
                    psintrat = Convert.ToBoolean(oReader["PSinTrat"]);
                    visest = Convert.ToBoolean(oReader["VisEst"]);
                    rb = Convert.ToBoolean(oReader["Rb"]);
                    mc = Convert.ToBoolean(oReader["Mc"]);
                    oli = Convert.ToBoolean(oReader["Oli"]);
                    bj = Convert.ToBoolean(oReader["Bj"]);
                    pow = Convert.ToBoolean(oReader["Pow"]);
                    quir = Convert.ToBoolean(oReader["Quir"]);
                    trevisi = Convert.ToBoolean(oReader["Trevisi"]);
                    hold = Convert.ToBoolean(oReader["Hold"]);
                    harv = Convert.ToBoolean(oReader["Harv"]);
                    sch = Convert.ToBoolean(oReader["Sch"]);
                    rick = Convert.ToBoolean(oReader["Rick"]);
                    fotoDig = Convert.ToBoolean(oReader["FotoDigital"]);
                    sinOpt = Convert.ToBoolean(oReader["SinOpt"]);
                    software = (String)oReader["Software"];
                    observaciones = (String)oReader["Observaciones"];
                    tipodefoto = (String)oReader["TipoDeFotoDig"];
                    ident = (String)oReader["IdentikitComentarios"];
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    rickFront = Convert.ToBoolean(oReader["RickFront"]);
                    modelo = Convert.ToBoolean(oReader["Modelo"]);
                    cerrada = Convert.ToBoolean(oReader["Cerrado"]);
                    empleado = Convert.ToInt32(oReader["CerradoPor"]);

                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(empleado);
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    NemoDocViewer nemodoc = new NemoDocViewer(nemo, docV, roth, ayala, pcontrat, psintrat, visest, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotoDig, tipodefoto, ident, cd,rickFront,modelo,sinOpt,software,observaciones, id, fechaRealizado, fechaPrometido, cerrada, cerradaPor, carpeta);

                    listaDeNemos.Add(nemodoc);
                }
                oReader.Close();
            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return listaDeNemos;
        }
    }
}
