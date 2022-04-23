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
    internal class PersistenciaOptParaImplante: MarshalByRefObject,IPersistenciaOxi
    {
        private static PersistenciaOptParaImplante _miPersistencia=null;
        private PersistenciaOptParaImplante() { }
        public static PersistenciaOptParaImplante GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaOptParaImplante();
            return _miPersistencia;
        }

        public OptParaImplante BuscarOptParaImplante(String factura)
        {

            FabricaPersistencia fp =new FabricaPersistencia();
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOxi " + factura, oConexion);
            SqlDataReader oReader;

            bool impresion;
            bool informe;
            bool cd;
            bool opt;
            int id;
            DateTime fechaRealizado;
            DateTime fechaPrometida;
            
            OptParaImplante oxi = null;
            bool cerrada;
            int _cerradaPor;
            String _carpeta;
           
            Empleado cerradaPor;
            Carpeta carpeta;
            

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    _carpeta = (String)oReader["Factura"];
                    
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["FechaPrometido"]);
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    opt = Convert.ToBoolean(oReader["opt123"]);
                    informe = Convert.ToBoolean(oReader["Informe"]);
                    impresion = Convert.ToBoolean(oReader["Impresion"]);
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]); 
                   

                    carpeta = fp.getPCarpeta().BuscarCarpeta(_carpeta);
                    cerradaPor = fp.getPEMpleado().BuscarEmpleadoPorId(_cerradaPor);


                    oxi = new OptParaImplante(impresion,informe,cd,opt,id,fechaRealizado,fechaPrometida,cerrada,cerradaPor,carpeta);
                    

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
            return oxi;
        }

        public OptParaImplante BuscarOptParaImplantePorId(int id)
        {


            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec buscarOxi " + id, oConexion);
            SqlDataReader oReader;

            bool impresion;
            bool informe;
            bool cd;
            bool opt;
            DateTime fechaRealizado;
            int tiempo;
            String estado;
            OptParaImplante oxi = null;



            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    impresion = Convert.ToBoolean(oReader["impresion"]);
                    informe = Convert.ToBoolean(oReader["informe"]);
                    cd = Convert.ToBoolean(oReader["cd"]);
                    opt = Convert.ToBoolean(oReader["opt"]);
                    fechaRealizado = Convert.ToDateTime(oReader["fechaRealizado"]);
                    tiempo = Convert.ToInt32(oReader["tiempo"]);
                    estado = (String)oReader["estado"];



                    //oxi = new OptParaImplante(impresion, informe, cd, opt, 0, fechaRealizado, tiempo, estado);


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
            return oxi;
        }

        public void AgregarOptParaImplante(OptParaImplante oxi)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarOxi", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

                SqlParameter fac = new SqlParameter("@fac", oxi.Carpeta.NumDeFactura);
                SqlParameter fr = new SqlParameter("@fechaRealizado", oxi.FechaRealizado);
                SqlParameter fp = new SqlParameter("@fechaPrometido",oxi.FechaPrometida);
                SqlParameter cd = new SqlParameter("@cd", oxi.Cd);

                SqlParameter opt = new SqlParameter("@opt123", oxi.Opt);
                SqlParameter inf = new SqlParameter("@informe", oxi.Informe);
                SqlParameter imp = new SqlParameter("@impresion", oxi.Impresion);
                SqlParameter cer = new SqlParameter("@cerrada", oxi.Cerrada);
                SqlParameter cerp = new SqlParameter("@cerradaPor", oxi.CerradaPor.Id);


                SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                retorno.Direction = ParameterDirection.ReturnValue;

                int resultado = -1;

                oComando.Parameters.Add(fac);
                oComando.Parameters.Add(fr);
                oComando.Parameters.Add(fp);
                oComando.Parameters.Add(cd);

                oComando.Parameters.Add(opt);
                oComando.Parameters.Add(inf);
                oComando.Parameters.Add(imp);
                oComando.Parameters.Add(cer);
                oComando.Parameters.Add(cerp);

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

        public void EliminarOptParaImplante(OptParaImplante oxi)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarOxi", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", oxi.Id);
           

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

                if (resultado == 1)
                    throw new Exception("No existe la oxi");
              

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

        public void ModificarOptParaImplante(OptParaImplante oxi)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarOxi", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@Factura", oxi.Carpeta.NumDeFactura);
            SqlParameter fr = new SqlParameter("@FechaRealizado", oxi.FechaRealizado);
            SqlParameter fp = new SqlParameter("FechaPrometido", oxi.FechaPrometida);
            SqlParameter cd = new SqlParameter("@Cd", oxi.Cd);

            SqlParameter opt = new SqlParameter("@Opt123", oxi.Opt);
            SqlParameter inf = new SqlParameter("@Informe", oxi.Informe);
            SqlParameter imp = new SqlParameter("@Impresion", oxi.Impresion);
            SqlParameter cer = new SqlParameter("@Cerrada", oxi.Cerrada);
            SqlParameter cerp = new SqlParameter("@CerradaPor", oxi.CerradaPor.Id);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(fr);
            oComando.Parameters.Add(fp);
            oComando.Parameters.Add(cd);

            oComando.Parameters.Add(opt);
            oComando.Parameters.Add(inf);
            oComando.Parameters.Add(imp);
            oComando.Parameters.Add(cer);
            oComando.Parameters.Add(cerp);

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

        public List<OptParaImplante> ListarOxisPendientes()
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarOxisPendientes", oConexion);
            SqlDataReader oReader;

            bool impresion;
            bool informe;
            bool cd;
            bool opt;
            DateTime fechaRealizado;
            DateTime fechaPrometida;

            bool cerrada;
            int _cerradaPor;
            String _carpeta;
            int _id;
            Empleado cerradaPor;
            Carpeta carpeta;
            List<OptParaImplante> listaDeOxis = new List<OptParaImplante>();

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    _carpeta = (String)oReader["Factura"];

                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["FechaPrometido"]);
                    cd = Convert.ToBoolean(oReader["Cd"]);
                    opt = Convert.ToBoolean(oReader["Opt123"]);
                    informe = Convert.ToBoolean(oReader["Informe"]);
                    impresion = Convert.ToBoolean(oReader["Impresion"]);
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);



                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(_carpeta);
                    carpeta =PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(_carpeta);
                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_cerradaPor);


                    OptParaImplante oxi = new OptParaImplante(impresion, informe, cd, opt, 0, fechaRealizado, fechaPrometida, cerrada, cerradaPor, carpeta);

                    listaDeOxis.Add(oxi);

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
            return listaDeOxis;
        }
    }
}
