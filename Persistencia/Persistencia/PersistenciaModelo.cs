using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Drawing;
using System.IO;

namespace Persistencia
{
    internal class PersistenciaModelo:MarshalByRefObject,IPersistenciaModelo
    {
        private static PersistenciaModelo _miPersistencia=null;
        private PersistenciaModelo() { }
        public static PersistenciaModelo GetPersistencia()
        {
            if (_miPersistencia == null)
                _miPersistencia = new PersistenciaModelo();
            return _miPersistencia;
        }

       

        public Modelo BuscarModelo(String factura)
        {
            
           
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarModelo " + factura, oConexion);
            SqlDataReader oReader;

            int id;
            DateTime fechaPrometida;
            DateTime fechaRealizado;
            
            bool modeloYMedio;
            bool estudioDeModelo;
            String clinica;
            bool placaBase;
            bool paraArticulador;
            String laboratorio;
            bool cerrada;
            Empleado cerradaPor;
            Carpeta carpeta;
            int _cerradaPor;
            String _fac;

            bool tieneFotos;
            String observaciones;

            Modelo modelo = null;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    _fac = (String)oReader["Factura"];
                    clinica = (String)oReader["Clinica"];
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["FechaPrometido"]);
                    modeloYMedio = Convert.ToBoolean(oReader["ModeloYMedio"]);
                    estudioDeModelo = Convert.ToBoolean(oReader["EstudioDeModelo"]);
                    placaBase = Convert.ToBoolean(oReader["PlacaBase"]);
                    paraArticulador = Convert.ToBoolean(oReader["ParaArticulador"]);
                    laboratorio = (String)oReader["Laboratorio"];
                    tieneFotos = (Convert.ToBoolean(oReader["TieneFotos"]));
                    observaciones=(String)oReader["Observaciones"];
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);
                    PersistenciaCarpeta.GetPersistencia();
                    PersistenciaEmpleado.GetPersistencia();
                    List<Foto> listaDeFotos = BuscarFotografiasModPorId(id);
                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_cerradaPor);
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(_fac);

                    modelo = new Modelo(modeloYMedio,estudioDeModelo,clinica,placaBase,paraArticulador,laboratorio,id,fechaRealizado,fechaPrometida,cerrada,cerradaPor,carpeta,tieneFotos,observaciones);

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
            return modelo;
        }

        public void AgregarModelo(Modelo modelo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarModelo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter factura = new SqlParameter("@factura", modelo.Carpeta.NumDeFactura);
            SqlParameter clinica = new SqlParameter("@clinica", modelo.Clinica);
            SqlParameter estModelo = new SqlParameter("@estudioDeModelo", modelo.EstudioDeModelo);
            SqlParameter fechaRealiz = new SqlParameter("@fechaRealizado", modelo.FechaRealizado);
            SqlParameter fechaProm = new SqlParameter("@fechaPrometido", modelo.FechaPrometida);
            SqlParameter lab = new SqlParameter("@laboratorio", modelo.Laboratorio);
            SqlParameter modeloYMedio = new SqlParameter("@modeloyMedio", modelo.ModeloYMedio);
            SqlParameter paraArticulador = new SqlParameter("@paraArticulador", modelo.ParaArticulador);
            SqlParameter placaBase = new SqlParameter("@placaBase", modelo.PlacaBase);
            SqlParameter observaciones=new SqlParameter("@observaciones",modelo.Observaciones);
            SqlParameter tieneFotos = new SqlParameter("@tieneFotos", modelo.TieneFotos);

            SqlParameter cerrada = new SqlParameter("@cerrada", modelo.Cerrada);
            SqlParameter cerradaPor = new SqlParameter("@cerradaPor", modelo.CerradaPor.Id);
            

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int count = 0;
            int resultado = -1;
            int resultado2 = 0;

            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(clinica);
            oComando.Parameters.Add(fechaRealiz);
            oComando.Parameters.Add(fechaProm);
            oComando.Parameters.Add(modeloYMedio);
            oComando.Parameters.Add(estModelo);
            oComando.Parameters.Add(placaBase);
            oComando.Parameters.Add(paraArticulador);
            oComando.Parameters.Add(lab);
            oComando.Parameters.Add(observaciones);
            oComando.Parameters.Add(tieneFotos);
            oComando.Parameters.Add(cerrada);
            oComando.Parameters.Add(cerradaPor);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;


                    if (resultado == 1)
                    {
                        throw new Exception("Ya existe un modelo ingresado");
                    }
                   
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

        public void EliminarModelo(Modelo modelo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("eliminarModelo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@idEst", modelo.Id);




            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;


            oComando.Parameters.Add(fac);



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

        public void ModificarModelo(Modelo modelo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("modificarModelo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter factura = new SqlParameter("@factura", modelo.Carpeta.NumDeFactura);
            SqlParameter clinica = new SqlParameter("@clinica", modelo.Clinica);
            SqlParameter estModelo = new SqlParameter("@estudioDeModelo", modelo.EstudioDeModelo);
            SqlParameter fechaRealiz = new SqlParameter("@fechaRealizado", modelo.FechaRealizado);
            SqlParameter fechaProm = new SqlParameter("@fechaPrometido", modelo.FechaPrometida);
            SqlParameter lab = new SqlParameter("@laboratorio", modelo.Laboratorio);
            SqlParameter modeloYMedio = new SqlParameter("@modeloyMedio", modelo.ModeloYMedio);
            SqlParameter paraArticulador = new SqlParameter("@paraArticulador", modelo.ParaArticulador);
            SqlParameter placaBase = new SqlParameter("@placaBase", modelo.PlacaBase);
            SqlParameter observaciones = new SqlParameter("@observaciones", modelo.Observaciones);
            SqlParameter tieneFotos = new SqlParameter("@tieneFotos", modelo.TieneFotos);

            SqlParameter cerrada = new SqlParameter("@cerrada", modelo.Cerrada);
            SqlParameter cerradaPor = new SqlParameter("@cerradaPor", modelo.CerradaPor.Id);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            
            int resultado = -1;
            

            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(clinica);
            oComando.Parameters.Add(fechaRealiz);
            oComando.Parameters.Add(fechaProm);
            oComando.Parameters.Add(modeloYMedio);
            oComando.Parameters.Add(estModelo);
            oComando.Parameters.Add(placaBase);
            oComando.Parameters.Add(paraArticulador);
            oComando.Parameters.Add(lab);
            oComando.Parameters.Add(observaciones);
            oComando.Parameters.Add(tieneFotos);
            oComando.Parameters.Add(cerrada);
            oComando.Parameters.Add(cerradaPor);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;


                if (resultado == 1)
                {
                    throw new Exception("Ya existe un modelo ingresado");
                }

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

        public List<Modelo> ListarModelosPendientes()
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ListarModelosPendientes", oConexion);
            SqlDataReader oReader;

            int id;
            DateTime fechaPrometida;
            DateTime fechaRealizado;

            bool modeloYMedio;
            bool estudioDeModelo;
            String clinica;
            bool placaBase;
            bool paraArticulador;
            String laboratorio;
            bool cerrada;
            Empleado cerradaPor;
            Carpeta carpeta;
            int _cerradaPor;
            String _fac;
            String observaciones;
            bool tieneFotos;
            List<Modelo> listaDeModelos = new List<Modelo>();

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    _fac = (String)oReader["Factura"];
                    clinica = (String)oReader["Clinica"];
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["FechaPrometido"]);
                    modeloYMedio = Convert.ToBoolean(oReader["ModeloYMedio"]);
                    estudioDeModelo = Convert.ToBoolean(oReader["EstudioDeModelo"]);
                    placaBase = Convert.ToBoolean(oReader["PlacaBase"]);
                    paraArticulador = Convert.ToBoolean(oReader["ParaArticulador"]);
                    laboratorio = (String)oReader["Laboratorio"];
                    tieneFotos = (Convert.ToBoolean(oReader["TieneFotos"]));
                    observaciones = (String)oReader["Observaciones"];
                  
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);


                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_cerradaPor);
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(_fac);
                    List<Foto> listaDeFotos = BuscarFotografiasModPorId(id);

                     Modelo modelo = new Modelo(modeloYMedio, estudioDeModelo, clinica, placaBase, paraArticulador, laboratorio, id, fechaRealizado, fechaPrometida, cerrada, cerradaPor, carpeta,tieneFotos,observaciones);
                    listaDeModelos.Add(modelo);
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
            return listaDeModelos;
        }

        public List<Foto> BuscarFotografiasModPorId(int id)
        {
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarFotografiasModPorId " + id, oConexion);
            SqlDataReader oReader;

            List<Foto> listaDeFotos = new List<Foto>();
            String ruta = "";
            byte[] fotoChica = null;
            byte[] fotoGrande = null;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    
                    fotoChica = (Byte[])oReader["FotoChica"];
                    fotoGrande = (Byte[])oReader["FotoGrande"];

                   
                    Foto nuevaFoto = new Foto(id,fotoGrande,fotoChica);
                    listaDeFotos.Add(nuevaFoto);
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
            return listaDeFotos;
        }

        public static void AgregarImagen(Foto imagen)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarImagenDeModelo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            
            SqlParameter fotoGrande = new SqlParameter("@fotoGrande", imagen.FotoGrande);
            

            SqlParameter fotoChica = new SqlParameter("@fotoChica", imagen.FotoMiniatura);
            

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fotoChica);
            oComando.Parameters.Add(fotoGrande);

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

        public static byte[] convertiraBytes(Image img)
        {
            string sTemp = Path.GetTempFileName();
            FileStream fs = new FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            img.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
            fs.Position = 0;

            int imgLength = Convert.ToInt32(fs.Length);
            byte[] bytes = new byte[imgLength];
            fs.Read(bytes, 0, imgLength);
            fs.Close();
            return bytes;
        }

        public static Image convertiraImage(byte[] bytes)
        {
            if (bytes == null) return null;
            //
            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bm = null;
            try
            {
                bm = new Bitmap(ms);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return bm;
        }
    }
}
