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
    internal class PersistenciaSpam:MarshalByRefObject,IPersistenciaSpan
    {
        private static PersistenciaSpam _miPersistencia=null;
        private PersistenciaSpam() { }
        public static PersistenciaSpam GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaSpam();
            return _miPersistencia;
        }

       

        public Span BuscarSpan(String factura)
        {

            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarSpan " + factura, oConexion);
            SqlDataReader oReader;

            int id;
            
            bool sinOpt;
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
            DateTime fechaRealizado;
            DateTime fechaPrometido;
            bool cerrado;
            int cerradoPor;
            EntidadesCompartidas.Span spanEncontrado = null;
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometido = Convert.ToDateTime(oReader["FechaPrometido"]);
                    sinOpt = Convert.ToBoolean(oReader["sinOpt"]);
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
                    fotoDig = Convert.ToBoolean(oReader["FotoDig"]);
                    tipodefoto = (String)oReader["TipoFotoDig"];
                    ident = (String)oReader["IdentikitComentarios"];
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    cerrado = Convert.ToBoolean(oReader["Cerrado"]);
                    cerradoPor = Convert.ToInt32(oReader["CerradaPor"]);
                    
                    Carpeta carpeta=PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    Empleado _cerradoPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(cerradoPor);
                    spanEncontrado=new EntidadesCompartidas.Span(sinOpt,rb,mc,oli,bj,pow,quir,trevisi,hold,harv,sch,rick,fotoDig,tipodefoto,ident,cd,id,fechaRealizado,fechaPrometido,cerrado,_cerradoPor,carpeta);
                    
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
            return spanEncontrado;
        }

        public void AgregarSpan(Span span)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarSpan", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@Factura", span.Carpeta.NumDeFactura);
            SqlParameter fr=new SqlParameter("@FechaRealizado", span.FechaRealizado);
            SqlParameter fp=new SqlParameter("@FechaPrometida", span.FechaPrometida);
            SqlParameter sopt = new SqlParameter("@SinOpt", span.SinOpt);
            SqlParameter rb = new SqlParameter("@Rb", span.Rb);
            SqlParameter mc = new SqlParameter("@Mc", span.Mc);
            SqlParameter oli = new SqlParameter("@Oli", span.Oli);
            SqlParameter bj = new SqlParameter("@Bj", span.Bj);
            SqlParameter pow = new SqlParameter("@Pow", span.Pow);
            SqlParameter quir = new SqlParameter("@Quir", span.Quir);
            SqlParameter trv = new SqlParameter("@Trevisi", span.Trevisi);
            SqlParameter hold = new SqlParameter("@Hold", span.Hold);
            SqlParameter harv = new SqlParameter("@Harv", span.Harv);
            SqlParameter sch = new SqlParameter("@Sch", span.Sch);
            SqlParameter rick = new SqlParameter("@Rick", span.Rick);
            SqlParameter fd = new SqlParameter("@FotoDig", span.FotoDigital);
            SqlParameter tipoFoto = new SqlParameter("@TipoFotoDig", span.TipoDeFotoDigital);
            SqlParameter ident = new SqlParameter("@IdentikitComentarios", span.IdentikitComentarios);
            SqlParameter cd = new SqlParameter("@Cd", span.Cd);
            SqlParameter cerrado = new SqlParameter("@Cerrado", span.Cerrada);
            SqlParameter cerradoP = new SqlParameter("@CerradoPor", span.CerradaPor.Id);
            

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(fr);
            oComando.Parameters.Add(fp);
            oComando.Parameters.Add(sopt);
            oComando.Parameters.Add(rb);
            oComando.Parameters.Add(mc);
            oComando.Parameters.Add(oli);
            oComando.Parameters.Add(bj);
            oComando.Parameters.Add(pow);
            oComando.Parameters.Add(quir);
            oComando.Parameters.Add(trv);
            oComando.Parameters.Add(hold);
            oComando.Parameters.Add(harv);
            oComando.Parameters.Add(sch);
            oComando.Parameters.Add(rick);
            oComando.Parameters.Add(fd);
            oComando.Parameters.Add(tipoFoto);
            oComando.Parameters.Add(ident);
            oComando.Parameters.Add(cd);
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoP);


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

        public void EliminarSpan(Span span)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarSpan", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter idEst = new SqlParameter("@id", span.Id);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;


            oComando.Parameters.Add(idEst);

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

        public void ModificarSpan(Span span)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarSpan", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@Factura", span.Carpeta.NumDeFactura);
            SqlParameter fr = new SqlParameter("@FechaRealizado", span.FechaRealizado);
            SqlParameter fp = new SqlParameter("@FechaPrometido", span.FechaPrometida);
            SqlParameter sopt = new SqlParameter("@SinOpt", span.SinOpt);
            SqlParameter rb = new SqlParameter("@Rb", span.Rb);
            SqlParameter mc = new SqlParameter("@Mc", span.Mc);
            SqlParameter oli = new SqlParameter("@Oli", span.Oli);
            SqlParameter bj = new SqlParameter("@Bj", span.Bj);
            SqlParameter pow = new SqlParameter("@Pow", span.Pow);
            SqlParameter quir = new SqlParameter("@Quir", span.Quir);
            SqlParameter trv = new SqlParameter("@Trevisi", span.Trevisi);
            SqlParameter hold = new SqlParameter("@Hold", span.Hold);
            SqlParameter harv = new SqlParameter("@Harv", span.Harv);
            SqlParameter sch = new SqlParameter("@Sch", span.Sch);
            SqlParameter rick = new SqlParameter("@Rick", span.Rick);
            SqlParameter fd = new SqlParameter("@FotoDig", span.FotoDigital);
            SqlParameter tipoFoto = new SqlParameter("@TipoFotoDig", span.TipoDeFotoDigital);
            SqlParameter ident = new SqlParameter("@IdentikitComentarios", span.IdentikitComentarios);
            SqlParameter cd = new SqlParameter("@Cd", span.Cd);
            SqlParameter cerrado = new SqlParameter("@Cerrado", span.Cerrada);
            SqlParameter cerradoP = new SqlParameter("@CerradaPor", span.CerradaPor.Id);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(fr);
            oComando.Parameters.Add(fp);
            oComando.Parameters.Add(sopt);
            oComando.Parameters.Add(rb);
            oComando.Parameters.Add(mc);
            oComando.Parameters.Add(oli);
            oComando.Parameters.Add(bj);
            oComando.Parameters.Add(pow);
            oComando.Parameters.Add(quir);
            oComando.Parameters.Add(trv);
            oComando.Parameters.Add(hold);
            oComando.Parameters.Add(harv);
            oComando.Parameters.Add(sch);
            oComando.Parameters.Add(rick);
            oComando.Parameters.Add(fd);
            oComando.Parameters.Add(tipoFoto);
            oComando.Parameters.Add(ident);
            oComando.Parameters.Add(cd);
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoP);


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

        public List<Span> ListarSpamPendientes()
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarSpanPendientes", oConexion);
            SqlDataReader oReader;

            int id;

            bool sinOpt;
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
            DateTime fechaRealizado;
            DateTime fechaPrometido;
            bool cerrado;
            String factura = "";
            int cerradoPor;
            
            List<Span> listaDeSpams = new List<Span>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while(oReader.Read())
                {
                    id = Convert.ToInt32(oReader["id"]);
                    factura=(String)oReader["Factura"];
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometido = Convert.ToDateTime(oReader["FechaPrometido"]);
                    sinOpt = Convert.ToBoolean(oReader["sinOpt"]);
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
                    fotoDig = Convert.ToBoolean(oReader["FotoDig"]);
                    tipodefoto = (String)oReader["TipoFotoDig"];
                    ident = (String)oReader["IdentikitComentarios"];
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    cerrado = Convert.ToBoolean(oReader["Cerrado"]);
                    cerradoPor = Convert.ToInt32(oReader["CerradaPor"]);
                   
                    Carpeta carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    Empleado _cerradoPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(cerradoPor);
                    EntidadesCompartidas.Span spanEncontrado = new EntidadesCompartidas.Span(sinOpt, rb, mc, oli, bj, pow, quir, trevisi, hold, harv, sch, rick, fotoDig, tipodefoto, ident, cd, id, fechaRealizado, fechaPrometido, cerrado, _cerradoPor, carpeta);

                    listaDeSpams.Add(spanEncontrado);
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
            return listaDeSpams;
        }
    }
}
