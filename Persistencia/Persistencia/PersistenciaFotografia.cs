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
    internal class PersistenciaFotografia:MarshalByRefObject,IPersistenciaFotografia
    {
        private static PersistenciaFotografia _miPersistencia=null;
        private PersistenciaFotografia() { }
        public static PersistenciaFotografia GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaFotografia();
            return _miPersistencia;
        }

        public Fotografia BuscarFotografia(String factura)
        {
            FabricaPersistencia fp=new FabricaPersistencia();
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarFotografiaEst " + factura, oConexion);
            SqlDataReader oReader;

            int id=0;
           
            DateTime fechaRealizado=DateTime.Now;
            DateTime fechaPrometido = DateTime.Now;

           
            
            bool frentePerfilSonrisa=false;
            bool intrabucal=false;
            bool overJet_y_OverBite=false;
            bool submenton=false;
           
            Fotografia fotografiaEstudio=null;
            bool cerrado = false;
            int cerradoPor=0;
            Empleado empCerradoPor = null;

            Empleado limpioPor = null;
            Empleado emplantiladoPor=null;
            Empleado impresoPor = null;

            int limpio=0;
            int emplantilla=0;
            int impreso=0;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["id"]);
                    factura=(String)oReader["factura"];
                    
                    fechaRealizado = Convert.ToDateTime(oReader["FechaRealizado"]);
                    fechaPrometido = Convert.ToDateTime(oReader["FechaPrometido"]);

                    frentePerfilSonrisa = Convert.ToBoolean(oReader["FrentePerfilSonrisa"]);
                    intrabucal = Convert.ToBoolean(oReader["Intrabucal"]);
                    overJet_y_OverBite = Convert.ToBoolean(oReader["OerJetYOverBite"]);
                    submenton = Convert.ToBoolean(oReader["Submenton"]);
                 
                    
                    limpio = Convert.ToInt32(oReader["LimpioPor"]);
                    emplantilla = Convert.ToInt32(oReader["EmplantilladoPor"]);
                    impreso = Convert.ToInt32(oReader["ImpresoPor"]);
                  

                    cerrado = Convert.ToBoolean(oReader["Cerrado"]);
                    cerradoPor = Convert.ToInt32(oReader["CerradoPor"]);

                    limpioPor = fp.getPEMpleado().BuscarEmpleadoPorId(limpio);
                    emplantiladoPor = fp.getPEMpleado().BuscarEmpleadoPorId(emplantilla);
                    impresoPor = fp.getPEMpleado().BuscarEmpleadoPorId(impreso);

                    empCerradoPor=fp.getPEMpleado().BuscarEmpleadoPorId(cerradoPor);
                    Carpeta carpeta = fp.getPCarpeta().BuscarCarpeta(factura);
                 

                    fotografiaEstudio = new Fotografia(frentePerfilSonrisa,intrabucal,overJet_y_OverBite,submenton,limpioPor,emplantiladoPor,impresoPor,id,fechaRealizado,fechaPrometido,cerrado,empCerradoPor,carpeta);

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
            return fotografiaEstudio;
        }

        public List<Foto> BuscarFotografiasPorId(int id)
        {
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarFotografiasPorId " + id, oConexion);
            SqlDataReader oReader;

            List<Foto> listaDeFotos = new List<Foto>();
            
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

        public void ModificarFotografia(Fotografia foto)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarFotografia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter factura = new SqlParameter("@factura", foto.Carpeta.NumDeFactura);
            SqlParameter fechaReal = new SqlParameter("@fechaReal", foto.FechaRealizado);
            SqlParameter fechaProm = new SqlParameter("@fechaProm", foto.FechaPrometida);

            SqlParameter frentePerfilSonrisa = new SqlParameter("@frentePerfilSonrisa", foto.FrentePerfilSonrisa);
            SqlParameter intrabucal = new SqlParameter("@intrabucal", foto.Intrabucal);
            SqlParameter OverJyOverB = new SqlParameter("@overs", foto.OverJet_y_OverBite);
            SqlParameter submenton = new SqlParameter("@submenton", foto.Submenton);
 

            SqlParameter limpiado = new SqlParameter("@limpiadoPor", foto.LimpiadoPor.Id);
            SqlParameter emplant = new SqlParameter("@emplantilladoPor", foto.EmplantilladoPor.Id);
            SqlParameter impreso = new SqlParameter("@impresoPor", foto.ImpresoPor.Id);
           

            SqlParameter cerrado = new SqlParameter("@cerrado", foto.Cerrada);
            SqlParameter cerradoPor = new SqlParameter("@cerradoPor", foto.CerradaPor.Id);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(fechaReal);
            oComando.Parameters.Add(fechaProm);

            oComando.Parameters.Add(frentePerfilSonrisa);
            oComando.Parameters.Add(intrabucal);
            oComando.Parameters.Add(OverJyOverB);
            oComando.Parameters.Add(submenton);
           
            oComando.Parameters.Add(limpiado);
            oComando.Parameters.Add(emplant);
            oComando.Parameters.Add(impreso);
           
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoPor);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                {
                    throw new Exception("Se modifico correctamente el estudio"); 
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

        public void AgregarFotografia(Fotografia foto)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarFotografiaEst", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter factura = new SqlParameter("@factura", foto.Carpeta.NumDeFactura);
            SqlParameter fechaReal = new SqlParameter("@fechaReal", foto.FechaRealizado);
            SqlParameter fechaProm = new SqlParameter("@fechaProm", foto.FechaPrometida);
            
            SqlParameter frentePerfilSonrisa = new SqlParameter("@frentePerfilSonrisa",foto.FrentePerfilSonrisa );
            SqlParameter intrabucal = new SqlParameter("@intrabucal", foto.Intrabucal);
            SqlParameter OverJyOverB= new SqlParameter("@overs", foto.OverJet_y_OverBite);
            SqlParameter submenton = new SqlParameter("@submenton", foto.Submenton);
      

            SqlParameter limpiado = new SqlParameter("@limpiadoPor", foto.LimpiadoPor.Id);
            SqlParameter emplant = new SqlParameter("@emplantilladoPor", foto.EmplantilladoPor.Id);
            SqlParameter impreso = new SqlParameter("@impresoPor", foto.ImpresoPor.Id);
      
        

            SqlParameter cerrado = new SqlParameter("@cerrado", foto.Cerrada);
            SqlParameter cerradoPor = new SqlParameter("@cerradoPor", foto.CerradaPor.Id);
           
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(fechaReal);
            oComando.Parameters.Add(fechaProm);
            
            oComando.Parameters.Add(frentePerfilSonrisa);
            oComando.Parameters.Add(intrabucal);
            oComando.Parameters.Add(OverJyOverB);
            oComando.Parameters.Add(submenton);
           
            oComando.Parameters.Add(limpiado);
            oComando.Parameters.Add(emplant);
            oComando.Parameters.Add(impreso);
          
            oComando.Parameters.Add(cerrado);
            oComando.Parameters.Add(cerradoPor);
            
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                
                if(resultado==2)
                {

                    throw new Exception("Ya existe un estudio con esa factura");
                    
                }

                //if (resultado == 5)
                //    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                //if (resultado == 4)
                //    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                //if (resultado == 3)
                //    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");
                //if (resultado == 2)
                //    throw new Exception("No se ha podido ingresar el cliente, intentelo mas tarde");


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

        public void AgregarImagen(Foto imagen)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarImagen", oConexion);
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

        public void EliminarFotografia(Fotografia foto)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("eliminarFotografia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter idEst = new SqlParameter("@idEst", foto.Id);


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

        public void EliminarFotos(int id)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarFotosF", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id_ = new SqlParameter("@id", id);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;


            oComando.Parameters.Add(id_);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("No se puede eliminar el estudio, contiene fotos");

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

        public void AgregarImagenConId(int id, Foto foto)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarImagenConId", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter estudioId = new SqlParameter("@idEstudio", id);
            SqlParameter fotoGrande = new SqlParameter("@fotogrande", foto.FotoGrande);
            SqlParameter fotoChica = new SqlParameter("@fotochica", foto.FotoMiniatura);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;


            oComando.Parameters.Add(estudioId);
            oComando.Parameters.Add(fotoChica);
            oComando.Parameters.Add(fotoGrande);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

        
                
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
