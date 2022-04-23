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
    internal class PersistenciaTomografia:MarshalByRefObject,IPersistenciaTomografia
    {
        private static PersistenciaTomografia _miPersistencia=null;
        private PersistenciaTomografia() { }
        public static PersistenciaTomografia GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaTomografia();
            return _miPersistencia;
        }

       

        public Tomografia BuscarTomografia(String factura)
        {
           
            int _id;
            
            DateTime fechaPrometida;
            String orden;
            int impresiones;
            bool informe;
            bool sinInforme;
            
            int cds;
            String patologia;
            DateTime fechaRealizado;

            int informadaPor;
            int tomadaPor;
            int _cerradaPor;
            int _chequeadaPor;
            bool cerrada;
            
            Carpeta carpeta;
            Empleado cerradaPor;
            Empleado _TomadaPor;
            Empleado _InformadaPor;
            Empleado chequeadaPor;
            bool cs3dImgSoft=false;
            bool implantViewer=false;
            bool inVivo=false;
            String otroSoft="";

            Tomografia tomo = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarTomografia " + factura, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["id"]);
                    orden = (String)oReader["orden"];
                    impresiones = Convert.ToInt32(oReader["impresiones"]);
                    informe = Convert.ToBoolean(oReader["informe"]);
                    sinInforme = Convert.ToBoolean(oReader["sinInforme"]);
                    cds = Convert.ToInt32(oReader["cds"]);
                    patologia = (String)oReader["patologia"];
                    tomadaPor = Convert.ToInt32(oReader["tomadaPor"]);
                    informadaPor = Convert.ToInt32(oReader["informadaPor"]);
                    _chequeadaPor = Convert.ToInt32(oReader["chequeadaPor"]);
                    fechaRealizado=Convert.ToDateTime(oReader["fechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["fechaPrometida"]);
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);
                    
                    cs3dImgSoft=Convert.ToBoolean(oReader["cs3dImagingSoft"]);
                    implantViewer=Convert.ToBoolean(oReader["implantViewer"]);
                    inVivo=Convert.ToBoolean(oReader["cs3dImagingSoft"]);
                    otroSoft=(oReader["otroSoftware"]).ToString();

                   
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_cerradaPor);
                    chequeadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_chequeadaPor);
                    _TomadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(tomadaPor);
                    _InformadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(informadaPor);

                    tomo = new Tomografia(orden,impresiones,informe,sinInforme,cds,patologia,_TomadaPor,_InformadaPor,chequeadaPor,_id,fechaRealizado,fechaPrometida,cerrada,cerradaPor,carpeta,cs3dImgSoft,implantViewer,inVivo,otroSoft);

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
            return tomo;
        }

        public void AgregarTomografia(Tomografia tomo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarTomografia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            
                 
            SqlParameter orden = new SqlParameter("@orden", tomo.Orden);
            SqlParameter impresiones = new SqlParameter("@impresiones", tomo.Impresiones);
            SqlParameter informe= new SqlParameter("@informe", tomo.Informe);
            SqlParameter sinforme= new SqlParameter("@sinInforme", tomo.SinInforme);
            SqlParameter cds = new SqlParameter("@cds", tomo.Cds);
            SqlParameter patologia = new SqlParameter("@patologia", tomo.Patologia);
            SqlParameter tomadaPor=new SqlParameter("@tomadaPor",tomo.TomadaPor.Id);
            SqlParameter informadaPor=new SqlParameter("@informadaPor",tomo.InformadaPor.Id);
            SqlParameter chequeadaPor = new SqlParameter("@chequeadaPor", tomo.ChequeadaPor.Id);
            SqlParameter fechaR = new SqlParameter("@fechaRealizado", tomo.FechaRealizado);
            SqlParameter fechaP = new SqlParameter("@fechaPrometido", tomo.FechaPrometida);
            SqlParameter cerrada=new SqlParameter("@cerrada",tomo.Cerrada);
            SqlParameter cerradaPor=new SqlParameter("@cerradaPor",tomo.CerradaPor.Id);
            SqlParameter factura=new SqlParameter("@factura",tomo.Carpeta.NumDeFactura.ToString());
            SqlParameter cs3d=new SqlParameter("@cs3d",tomo.Cs3dImagingSoft);
            SqlParameter implant=new SqlParameter("@implant",tomo.ImplantViewerSoft);
            SqlParameter invivo=new SqlParameter("@inVivo",tomo.InVivoSoft);
            SqlParameter otrosoft=new SqlParameter("@otroSoft",tomo.OtroSoft);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            
           
            oComando.Parameters.Add(orden);
            oComando.Parameters.Add(impresiones);
            oComando.Parameters.Add(informe);
            oComando.Parameters.Add(sinforme);
            oComando.Parameters.Add(cds);
            oComando.Parameters.Add(patologia);
            oComando.Parameters.Add(tomadaPor);
            oComando.Parameters.Add(informadaPor);
            oComando.Parameters.Add(chequeadaPor);
            oComando.Parameters.Add(fechaR);
            oComando.Parameters.Add(fechaP);
            oComando.Parameters.Add(cerrada);
            oComando.Parameters.Add(cerradaPor);
            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(cs3d);
            oComando.Parameters.Add(implant);
            oComando.Parameters.Add(invivo);
            oComando.Parameters.Add(otrosoft);


            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado != 0)
                {
                   
                        throw new Exception("No se ha podido agregar la tomo, intentelo mas tarde");
                  
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

        public void EliminarTomografia(Tomografia tomo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarTomografia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter idEst = new SqlParameter("@idEstudio", tomo.Id);




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

        public void ModificarTomografia(Tomografia tomo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarTomografia", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;



            SqlParameter orden = new SqlParameter("@orden", tomo.Orden);
            SqlParameter impresiones = new SqlParameter("@impresiones", tomo.Impresiones);
            SqlParameter informe = new SqlParameter("@informe", tomo.Informe);
            SqlParameter sinforme = new SqlParameter("@sinInforme", tomo.SinInforme);
            SqlParameter cds = new SqlParameter("@cds", tomo.Cds);
            SqlParameter patologia = new SqlParameter("@patologia", tomo.Patologia);
            SqlParameter tomadaPor = new SqlParameter("@tomadaPor", tomo.TomadaPor.Id);
            SqlParameter informadaPor = new SqlParameter("@informadaPor", tomo.InformadaPor.Id);
            SqlParameter chequeadaPor = new SqlParameter("@chequeadaPor", tomo.ChequeadaPor.Id);
            SqlParameter fechaR = new SqlParameter("@fechaRealizado", tomo.FechaRealizado);
            SqlParameter fechaP = new SqlParameter("@fechaPrometida", tomo.FechaPrometida);
            SqlParameter cerrada = new SqlParameter("@cerrada", tomo.Cerrada);
            SqlParameter cerradaPor = new SqlParameter("@cerradaPor", tomo.CerradaPor.Id);
            SqlParameter factura = new SqlParameter("@factura", tomo.Carpeta.NumDeFactura.ToString());
            SqlParameter cs3d = new SqlParameter("@cs3d", tomo.Cs3dImagingSoft);
            SqlParameter implant = new SqlParameter("@implant", tomo.ImplantViewerSoft);
            SqlParameter invivo = new SqlParameter("@inVivo", tomo.InVivoSoft);
            SqlParameter otrosoft = new SqlParameter("@otroSoft", tomo.OtroSoft);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;



            oComando.Parameters.Add(orden);
            oComando.Parameters.Add(impresiones);
            oComando.Parameters.Add(informe);
            oComando.Parameters.Add(sinforme);
            oComando.Parameters.Add(cds);
            oComando.Parameters.Add(patologia);
            oComando.Parameters.Add(tomadaPor);
            oComando.Parameters.Add(informadaPor);
            oComando.Parameters.Add(chequeadaPor);
            oComando.Parameters.Add(fechaR);
            oComando.Parameters.Add(fechaP);
            oComando.Parameters.Add(cerrada);
            oComando.Parameters.Add(cerradaPor);
            oComando.Parameters.Add(factura);
            oComando.Parameters.Add(cs3d);
            oComando.Parameters.Add(implant);
            oComando.Parameters.Add(invivo);
            oComando.Parameters.Add(otrosoft);


            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado != 0)
                {
                    if (resultado == 1)
                    {
                        throw new Exception("No existe la tomografia");
                    }
                    else
                    {
                        throw new Exception("No se ha podido modificar la tomo, intentelo mas tarde");
                    }
                    
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

        public List<Tomografia> ListarTomografiasPendientes()
        {
            
            int _id;

            DateTime fechaPrometida;
            String orden;
            int impresiones;
            bool informe;
            bool sinInforme;

            int cds;
            String patologia;
            DateTime fechaRealizado;

            int informadaPor;
            int tomadaPor;
            int chequeadaPor;
            int _cerradaPor;
            bool cerrada;

            Carpeta carpeta;
            Empleado cerradaPor;
            Empleado _TomadaPor;
            Empleado _InformadaPor;
            Empleado _ChequeadaPor;

            bool cs3dImgSoft = false;
            bool implantViewer = false;
            bool inVivo = false;
            String otroSoft = "";
            String factura = "";
            List<Tomografia> listaDeTomos=new List<Tomografia>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarTomografiasPendientes", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["id"]);
                    factura = (String)oReader["Factura"];
                    orden = (String)oReader["orden"];
                    impresiones = Convert.ToInt32(oReader["impresiones"]);
                    informe = Convert.ToBoolean(oReader["informe"]);
                    sinInforme = Convert.ToBoolean(oReader["sinInforme"]);
                    cds = Convert.ToInt32(oReader["cds"]);
                    patologia = (String)oReader["patologia"];
                    tomadaPor = Convert.ToInt32(oReader["tomadaPor"]);
                    informadaPor = Convert.ToInt32(oReader["informadaPor"]);
                    chequeadaPor = Convert.ToInt32(oReader["chequeadaPor"]);
                    fechaRealizado = Convert.ToDateTime(oReader["fechaRealizado"]);
                    fechaPrometida = Convert.ToDateTime(oReader["fechaPrometida"]);
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    _cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);

                    cs3dImgSoft = Convert.ToBoolean(oReader["cs3dImagingSoft"]);
                    implantViewer = Convert.ToBoolean(oReader["implantViewer"]);
                    inVivo = Convert.ToBoolean(oReader["cs3dImagingSoft"]);
                    otroSoft = (oReader["otroSoftware"]).ToString();

                    
                    carpeta = PersistenciaCarpeta.GetPersistencia().BuscarCarpeta(factura);
                    cerradaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(_cerradaPor);
                    _TomadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(tomadaPor);
                    _InformadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(informadaPor);
                    _ChequeadaPor = PersistenciaEmpleado.GetPersistencia().BuscarEmpleadoPorId(chequeadaPor);
                    Tomografia tomo = new Tomografia(orden, impresiones, informe, sinInforme, cds, patologia, _TomadaPor, _InformadaPor,_ChequeadaPor, _id, fechaRealizado, fechaPrometida, cerrada, cerradaPor, carpeta, cs3dImgSoft, implantViewer, inVivo, otroSoft);
                    listaDeTomos.Add(tomo);
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
            return listaDeTomos;
        }

        }
    }

