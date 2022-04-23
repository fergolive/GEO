using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Data.OleDb;

using System.Data.Common;

namespace Persistencia
{
    internal class PersistenciaCarpeta : MarshalByRefObject, IPersistenciaCarpeta
    {
        private static PersistenciaCarpeta _miPersistencia = null;
        private PersistenciaCarpeta() { }
        public static PersistenciaCarpeta GetPersistencia()
        {
            if (_miPersistencia == null)
                _miPersistencia = new PersistenciaCarpeta();
            return _miPersistencia;
        }

        public Carpeta BuscarCarpeta(String factura)
        {
            String fac = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            String clinica = "";
            String obs = "";
            bool cerrada = false;
            int cerradaPor;
            String entregada;
            Paciente pac = null;
            Odontologo odo = null;
            String dir = "";
            bool enviada = false;
            bool retirada = false;
            String direccionOPersona = "";

            int idPac;
            int idOdo;

            Carpeta carpeta = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarCarpeta " + factura, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    fac = (String)oReader["Factura"];
                    tipo = (String)oReader["Tipo"];
                    fechaProm = Convert.ToDateTime(oReader["FechaPrometida"]);
                    fechaReal = Convert.ToDateTime(oReader["FechaRealizada"]);
                    clinica = (String)oReader["Clinica"];
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);
                    entregada = (String)oReader["EntregadoA"];
                    obs = (String)oReader["Observaciones"];
                    idPac = Convert.ToInt32(oReader["IdPaciente"]);
                    idOdo = Convert.ToInt32(oReader["IdOdontologo"]);
                    dir = (String)oReader["DireccionDeEnvio"];
                    enviada = Convert.ToBoolean(oReader["Enviada"]);
                    retirada = Convert.ToBoolean(oReader["Retirada"]);
                    direccionOPersona = (String)oReader["DireccionOPersona"];
                    //FabricaPersistencia fp = new FabricaPersistencia() ;
                    pac = (new FabricaPersistencia()).getPPaciente().BuscarPacientePorId(idPac);

                    odo = (new FabricaPersistencia()).getPOdontologo().BuscarOdontologoPorId(idOdo);

                    Empleado fueCerradaPor = null;

                    if (cerradaPor != 0)
                    {
                        fueCerradaPor = (new FabricaPersistencia()).getPEMpleado().BuscarEmpleadoPorId(cerradaPor);
                    }

                    carpeta = new Carpeta(fac, tipo, fechaProm, fechaReal, clinica, obs, cerrada, fueCerradaPor , entregada, pac, odo, dir, enviada, retirada, direccionOPersona);

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
            return carpeta;
        }

        public List<Carpeta> BuscarCarpetas(String consulta)
        {
            String fac = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            String clinica = "";
            String obs = "";
            bool cerrada = false;
            int cerradaPor;
            String entregada;
            Paciente pac = null;
            Odontologo odo = null;
            String dir = "";
            bool enviada = false;
            bool retirada = false;
            String direccionOPersona = "";
            List<Carpeta> listaDeCarpetas = new List<Carpeta>();

            int idPac;
            int idOdo;

            Carpeta carpeta = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand(consulta, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    fac = (String)oReader["Factura"];
                    tipo = (String)oReader["Tipo"];
                    fechaProm = Convert.ToDateTime(oReader["FechaPrometida"]);
                    fechaReal = Convert.ToDateTime(oReader["FechaRealizada"]);
                    clinica = (String)oReader["Clinica"];
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);
                    entregada = (String)oReader["EntregadoA"];
                    obs = (String)oReader["Observaciones"];
                    idPac = Convert.ToInt32(oReader["IdPaciente"]);
                    idOdo = Convert.ToInt32(oReader["IdOdontologo"]);
                    dir = (String)oReader["DireccionDeEnvio"];
                    enviada = Convert.ToBoolean(oReader["Enviada"]);
                    retirada = Convert.ToBoolean(oReader["Retirada"]);
                    direccionOPersona = (String)oReader["DireccionOPersona"];
                    //FabricaPersistencia fp = new FabricaPersistencia() ;
                    pac = (new FabricaPersistencia()).getPPaciente().BuscarPacientePorId(idPac);

                    odo = (new FabricaPersistencia()).getPOdontologo().BuscarOdontologoPorId(idOdo);

                    Empleado fueCerradaPor = null;

                    if (cerradaPor != 0)
                    {
                        fueCerradaPor = (new FabricaPersistencia()).getPEMpleado().BuscarEmpleadoPorId(cerradaPor);
                    }

                    carpeta = new Carpeta(fac, tipo, fechaProm, fechaReal, clinica, obs, cerrada, fueCerradaPor, entregada, pac, odo, dir, enviada, retirada, direccionOPersona);

                    listaDeCarpetas.Add(carpeta);
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
            return listaDeCarpetas;
        }


        public List<Estudio> BuscarEstudios(String consulta)
        {
            String fac = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            Empleado fueCerradaPor = null;
            bool cerrada = false;
            int cerradaPor;
           

            int idPac;
            int idOdo;

            List<Estudio> listaDeEstudios = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand(consulta, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    fac = (String)oReader["Factura"];
                    tipo = (String)oReader["Tipo"];
                    fechaProm = Convert.ToDateTime(oReader["FechaPrometida"]);
                    fechaReal = Convert.ToDateTime(oReader["FechaRealizada"]);
                   
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);


                    if (cerradaPor != 0)
                    {
                        fueCerradaPor = (new FabricaPersistencia()).getPEMpleado().BuscarEmpleadoPorId(cerradaPor);
                    }

                    Estudio est=new Estudio(,)

                    listaDeEstudios.Add(Estudio);
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
            return listaDeCarpetas;
        }
        public void AgregarCarpeta(Carpeta carpeta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarCarpeta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;



            SqlParameter fac = new SqlParameter("@fac", carpeta.NumDeFactura);
            SqlParameter tipo = new SqlParameter("@tipo", carpeta.Tipo);
            SqlParameter fecProm = new SqlParameter("@fecProm", carpeta.FechaPrometida);
            SqlParameter fecReal = new SqlParameter("@fecReal", carpeta.FechaRealizada);
            SqlParameter cli = new SqlParameter("@cli", carpeta.Clinica);
            SqlParameter cerr = new SqlParameter("@cerr", carpeta.Cerrada);
            SqlParameter cerrP = new SqlParameter("@cerrpor", carpeta.CerradaPor.Id);
            SqlParameter entreg = new SqlParameter("@entreg", carpeta.EntregadaA);
            SqlParameter obs = new SqlParameter("@obs", carpeta.Observaciones);
            SqlParameter pac = new SqlParameter("@pac", carpeta.Paciente.Id);
            SqlParameter odo = new SqlParameter("@odo", carpeta.Odontologo.Id);
            SqlParameter dir = new SqlParameter("@dir", carpeta.DireccionDeEnvio);



            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(tipo);
            oComando.Parameters.Add(fecProm);
            oComando.Parameters.Add(fecReal);
            oComando.Parameters.Add(cli);
            oComando.Parameters.Add(cerr);
            oComando.Parameters.Add(cerrP);
            oComando.Parameters.Add(entreg);
            oComando.Parameters.Add(obs);
            oComando.Parameters.Add(pac);
            oComando.Parameters.Add(odo);
            oComando.Parameters.Add(dir);


            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("ya existe la carpeta");
                if (resultado == 2)
                    throw new Exception("No existe el paciente seleccionado");
                if (resultado == 3)
                    throw new Exception("no existe el odontologo seleccionado");
                if (resultado == 4)
                    throw new Exception("No existe la direccion ingresada");
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

        public void AgregarCarpeta2(Carpeta carpeta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarCarpeta2", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter fac = new SqlParameter("@fac", carpeta.NumDeFactura);
            SqlParameter tipo = new SqlParameter("@tipo", carpeta.Tipo);
            SqlParameter fecProm = new SqlParameter("@fecProm", carpeta.FechaPrometida);
            SqlParameter fecReal = new SqlParameter("@fecReal", carpeta.FechaRealizada);
            SqlParameter cli = new SqlParameter("@cli", carpeta.Clinica);
            SqlParameter cerr = new SqlParameter("@cerr", carpeta.Cerrada);
            SqlParameter cerrP = new SqlParameter("@cerrpor", carpeta.CerradaPor.Id);
            SqlParameter entreg = new SqlParameter("@entreg", carpeta.EntregadaA);
            SqlParameter obs = new SqlParameter("@obs", carpeta.Observaciones);
            SqlParameter pacnom = new SqlParameter("@pacnom", carpeta.Paciente.Nombre);
            SqlParameter pacape = new SqlParameter("@pacape", carpeta.Paciente.Apellido);

            SqlParameter odoape = new SqlParameter("@odoape", carpeta.Odontologo.Apellido);
            SqlParameter odonom = new SqlParameter("@odonom", carpeta.Odontologo.Nombre);
            SqlParameter odociu = new SqlParameter("@odociu", carpeta.Odontologo.Ciudad);
            SqlParameter ododir = new SqlParameter("@ododir", carpeta.Odontologo.Direcciones[0].ToString());
            SqlParameter odomail = new SqlParameter("@odomail", carpeta.Odontologo.Email);
            SqlParameter odotel = new SqlParameter("@odotel", carpeta.Odontologo.Telefono);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(tipo);
            oComando.Parameters.Add(fecProm);
            oComando.Parameters.Add(fecReal);
            oComando.Parameters.Add(cli);
            oComando.Parameters.Add(cerr);
            oComando.Parameters.Add(cerrP);
            oComando.Parameters.Add(entreg);
            oComando.Parameters.Add(obs);
            oComando.Parameters.Add(pacape);
            oComando.Parameters.Add(pacnom);
            oComando.Parameters.Add(odonom);
            oComando.Parameters.Add(odoape);
            oComando.Parameters.Add(ododir);
            oComando.Parameters.Add(odomail);
            oComando.Parameters.Add(odotel);
            oComando.Parameters.Add(odociu);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("ya existe la carpeta");
                if (resultado == 2)
                    throw new Exception("No existe el paciente seleccionado");
                if (resultado == 3)
                    throw new Exception("no existe el odontologo seleccionado");
                if (resultado == 4)
                    throw new Exception("No existe la direccion ingresada");
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

        public void EliminarCarpeta(Carpeta carpeta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarCarpeta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@fac", carpeta.NumDeFactura);

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

                if (resultado == 2)
                    throw new Exception("No existe la carpeta");
                if (resultado == 1)
                    throw new Exception("No se puede eliminar ya que tiene estudios realizados");


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

        public void ModificarCarpeta(Carpeta carpeta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarCarpeta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;



            SqlParameter fac = new SqlParameter("@fac", carpeta.NumDeFactura);
            SqlParameter tipo = new SqlParameter("@tipo", carpeta.Tipo);
            SqlParameter fecProm = new SqlParameter("@fecProm", carpeta.FechaPrometida);
            SqlParameter fecReal = new SqlParameter("@fecReal", carpeta.FechaRealizada);
            SqlParameter cli = new SqlParameter("@cli", carpeta.Clinica);
            SqlParameter cerr = new SqlParameter("@cerr", carpeta.Cerrada);
            SqlParameter cerrP = new SqlParameter("@cerrpor", carpeta.CerradaPor.Id);
            SqlParameter entreg = new SqlParameter("@entreg", carpeta.EntregadaA);
            SqlParameter obs = new SqlParameter("@obs", carpeta.Observaciones);
            SqlParameter pac = new SqlParameter("@pac", carpeta.Paciente.Id);
            SqlParameter odo = new SqlParameter("@odo", carpeta.Odontologo.Id);
            SqlParameter dir = new SqlParameter("@dir", carpeta.DireccionDeEnvio);



            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(tipo);
            oComando.Parameters.Add(fecProm);
            oComando.Parameters.Add(fecReal);
            oComando.Parameters.Add(cli);
            oComando.Parameters.Add(cerr);
            oComando.Parameters.Add(cerrP);
            oComando.Parameters.Add(entreg);
            oComando.Parameters.Add(obs);
            oComando.Parameters.Add(pac);
            oComando.Parameters.Add(odo);
            oComando.Parameters.Add(dir);


            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("ya existe la carpeta");
                if (resultado == 2)
                    throw new Exception("No existe el paciente seleccionado");
                if (resultado == 3)
                    throw new Exception("no existe el odontologo seleccionado");
                if (resultado == 4)
                    throw new Exception("No existe la direccion ingresada");
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

        public int ModificarEnviasRetiras(Carpeta carpeta)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarEnviasRetiras", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fac = new SqlParameter("@fac", carpeta.NumDeFactura);
            SqlParameter pac = new SqlParameter("@paciente", carpeta.Paciente.Nombre);
            SqlParameter env = new SqlParameter("@env", carpeta.Enviada);
            SqlParameter ret = new SqlParameter("@ret", carpeta.Retirada);
            SqlParameter diropers = new SqlParameter("@diropers", carpeta.Direccion_Persona_EnvRet);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fac);
            oComando.Parameters.Add(pac);
            oComando.Parameters.Add(env);
            oComando.Parameters.Add(ret);
            oComando.Parameters.Add(diropers);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                return resultado;


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

        public List<Carpeta> ListarEnviosPendientes(String tip, String entreg)
        {

            String fac = "";
            String tipo = "";
            DateTime fechaProm = DateTime.Now;
            DateTime fechaReal = DateTime.Now;
            String clinica = "";
            String obs = "";
            bool cerrada = false;
            int cerradaPor;
            String entregada;
            Paciente pac = null;
            Odontologo odo = null;
            String dir = "";
            bool enviada = false;
            bool retirada = false;
            String direccionOPersona = "";
            List<Carpeta> listaDeCarpetas = new List<Carpeta>();
            int idPac;
            int idOdo;

            string consulta = "exec ListarEnviosPendientes " + "'" + tip + "'" + "," + "'" + entreg + "'";
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand(consulta, oConexion);
            SqlDataReader oReader;


            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    fac = (String)oReader["Factura"];
                    tipo = (String)oReader["Tipo"];
                    fechaProm = Convert.ToDateTime(oReader["FechaPrometida"]);
                    fechaReal = Convert.ToDateTime(oReader["FechaRealizada"]);
                    clinica = (String)oReader["Clinica"];
                    cerrada = Convert.ToBoolean(oReader["Cerrada"]);
                    cerradaPor = Convert.ToInt32(oReader["CerradaPor"]);
                    entregada = (String)oReader["EntregadoA"];
                    obs = (String)oReader["Observaciones"];
                    idPac = Convert.ToInt32(oReader["IdPaciente"]);
                    idOdo = Convert.ToInt32(oReader["IdOdontologo"]);
                    dir = (String)oReader["DireccionDeEnvio"];
                    enviada = Convert.ToBoolean(oReader["Enviada"]);
                    retirada = Convert.ToBoolean(oReader["Retirada"]);
                    direccionOPersona = (String)oReader["DireccionOPersona"];
                    //FabricaPersistencia fp = new FabricaPersistencia() ;

                    pac = (new FabricaPersistencia()).getPPaciente().BuscarPacientePorId(idPac);
                    odo = (new FabricaPersistencia()).getPOdontologo().BuscarOdontologoPorId(idOdo);

                    Empleado fueCerradaPor = null;

                    if (cerradaPor != 0)
                    {
                        fueCerradaPor = (new FabricaPersistencia()).getPEMpleado().BuscarEmpleadoPorId(cerradaPor);
                    }


                    Carpeta carpeta = new Carpeta(fac, tipo, fechaProm, fechaReal, clinica, obs, cerrada, fueCerradaPor, entregada, pac, odo, dir, enviada, retirada, direccionOPersona);

                    listaDeCarpetas.Add(carpeta);
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
            return listaDeCarpetas;


        }

        public List<String> ListarUltimos5FacturasPacientesAccess(String ruta)
        {
            String conexionRuta = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ruta+";";
            OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = D:\\RecepcionDB.mdb;";
            conn.ConnectionString = conexionRuta;
            List<String> listaDeNumeros = new List<String>();
            try
            {

                String sql = "select top 10 Numero from Facturas order by Numero desc";
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();


                String numero = "";


                while (reader.Read())
                {
                    numero = reader["Numero"].ToString();
                    listaDeNumeros.Add(numero);

                }

                reader.Close();


            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return listaDeNumeros;
        }

        public Carpeta BuscarCarpetaPorFacturaAccess(String factura, String ruta)
        {
            OleDbConnection conn = new OleDbConnection();
            String ConexionRuta = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";";
            // conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RecepcionDB.mdb;";
            conn.ConnectionString = ConexionRuta;

            List<String> listaDeNumeros = new List<String>();
            Carpeta carpeta = null;
            try
            {

                String sql = "select Numero,Nombre,Apellido,ID_Profesional,FechaNacimiento from Facturas where Numero=" + "'" + factura.ToString() + "'";
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();

                String apellido = "";
                String nombre = "";
                String numero = "";
                String idOdontologo = "";
                String fechaNac = "";
                if (reader.Read())
                {
                    numero = reader["Numero"].ToString();
                    nombre = reader["Nombre"].ToString();
                    apellido = reader["Apellido"].ToString();
                    idOdontologo = reader["ID_Profesional"].ToString();
                    fechaNac = reader["FechaNacimiento"].ToString();
                }
                Odontologo nuevoOdontologo = null;

                if (idOdontologo != "")
                {
                    nuevoOdontologo = BuscarOdotologoPorIdAccess(Convert.ToInt32(idOdontologo));
                }
                else
                {
                    nuevoOdontologo = new Odontologo();
                    nuevoOdontologo.Id = 1;
                }



                Paciente nuevoPac = new Paciente();

                if (apellido == "")
                {
                    nuevoPac.Id = 1;
                }
                else if (nombre == "")
                {
                    nuevoPac.Id = 1;
                }
                else
                {

                    if (fechaNac != "")
                    {
                        nuevoPac.FechaDeNac = Convert.ToDateTime(fechaNac);
                    }

                    nuevoPac.Nombre = nombre;
                    nuevoPac.Apellido = apellido;
                }
                carpeta = new Carpeta();
                carpeta.NumDeFactura = numero;
                carpeta.Paciente = nuevoPac;
                carpeta.Odontologo = nuevoOdontologo;

                reader.Close();


            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return carpeta;
        }

        public Odontologo BuscarOdotologoPorIdAccess(int idOdontologo)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RecepcionDB.mdb;";
            Odontologo nuevoOdontologo = new Odontologo();
            List<String> listaDeNumeros = new List<String>();

            try
            {

                String sql = "select Nombre_Doc,Direccion_Doc,Telefono_Doc,EMail_Doc,Ciudad,Departamento from Docs where ID_Profesional=" + idOdontologo;
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();


                String nombre = "";
                String direccion = "";
                String email = "";
                String ciudad = "";
                String departamento = "";
                String telefono = "";



                if (reader.Read())
                {
                    nombre = reader["Nombre_Doc"].ToString();
                    direccion = reader["Direccion_Doc"].ToString();
                    telefono = reader["Telefono_Doc"].ToString();
                    email = reader["EMail_Doc"].ToString();
                    ciudad = reader["Ciudad"].ToString();
                    departamento = reader["Departamento"].ToString();

                }


                nuevoOdontologo.Nombre = nombre;
                if (nombre == "")
                {
                    nuevoOdontologo = new Odontologo();
                    nuevoOdontologo.Id = 1;
                }
                else
                {
                    String apellido = nombre;
                    Boolean banderaNom = false;
                    Boolean banderaApe = true;
                    String nomNuevo = "";
                    String apeNuevo = "";
                    for (int i = 0; i < nombre.Length; i++)
                    {
                        String caract = nombre[i].ToString();



                        if (caract.Equals(",") || caract.Equals(";"))
                        {
                            banderaNom = true;
                            banderaApe = false;
                            i += 1;
                            caract = nombre[i].ToString();
                        }

                        if (banderaApe)
                        {
                            apeNuevo += caract;
                        }
                        if (banderaNom)
                        {
                            nomNuevo += caract;
                        }
                    }

                    nomNuevo = nomNuevo.Trim();
                    apeNuevo = apeNuevo.Trim();

                    nuevoOdontologo.Nombre = nomNuevo;
                    nuevoOdontologo.Apellido = apeNuevo;
                    nuevoOdontologo.Ciudad = ciudad + ", " + departamento;
                    nuevoOdontologo.Email = email;
                    nuevoOdontologo.Direcciones.Add(direccion);
                }


                reader.Close();


            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return nuevoOdontologo;
        }

       


        public void GuardarRuta(String ruta, int tipo)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("GuardarRuta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;


            SqlParameter rut = new SqlParameter("@ruta", ruta);
            SqlParameter tip = new SqlParameter("@tipo", tipo);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(rut);
            oComando.Parameters.Add(tip);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("ya existe la carpeta");
                if (resultado == 2)
                    throw new Exception("No existe el paciente seleccionado");
                if (resultado == 3)
                    throw new Exception("no existe el odontologo seleccionado");
                if (resultado == 4)
                    throw new Exception("No existe la direccion ingresada");
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

        public String ObtenerRuta(int i)
        {

            String ruta="";

            string consulta = "exec ObtenerRuta " + i;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand(consulta, oConexion);
            SqlDataReader oReader;


            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    
                    ruta = (String)oReader["ruta"];
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
            return ruta;
        }

        public List<Carpeta> BuscarCarpetasAccess(String ruta)
        {
            OleDbConnection conn = new OleDbConnection();
            String ConexionRuta = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta;
            // conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\BaseDeDatosPocitos\RecepcionDB.mdb;"
            // conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RecepcionDB.mdb;";
            conn.ConnectionString = ConexionRuta;

            List<Carpeta> carpetas = new List<Carpeta>();
            
            try
            {

                String sql = "select Numero,Nombre,Apellido,ID_Profesional,FechaNacimiento from Facturas";
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();
                
                String apellido = "";
                String nombre = "";
                String numero = "";
                String idOdontologo = "";
                String fechaNac = "";


               

                
                   while(reader.Read())
                    {
                        numero = reader["Numero"].ToString();
                        nombre = reader["Nombre"].ToString();
                        apellido = reader["Apellido"].ToString();
                        idOdontologo = reader["ID_Profesional"].ToString();
                        fechaNac = reader["FechaNacimiento"].ToString();

                        Odontologo nuevoOdontologo = null;

                        if (idOdontologo != "")
                        {
                            nuevoOdontologo = BuscarOdotologoPorIdAccess(Convert.ToInt32(idOdontologo));
                        }
                        else
                        {
                            nuevoOdontologo = new Odontologo();
                            nuevoOdontologo.Id = 1;
                        }



                        Paciente nuevoPac = new Paciente();

                        if (apellido == "")
                        {
                            nuevoPac.Id = 1;
                        }
                        else if (nombre == "")
                        {
                            nuevoPac.Id = 1;
                        }
                        else
                        {

                            if (fechaNac != "")
                            {
                                nuevoPac.FechaDeNac = Convert.ToDateTime(fechaNac);
                            }

                            nuevoPac.Nombre = nombre;
                            nuevoPac.Apellido = apellido;
                        }
                        Carpeta carpeta = new Carpeta();
                        carpeta.NumDeFactura = numero;
                        carpeta.Paciente = nuevoPac;
                        carpeta.Odontologo = nuevoOdontologo;

                        carpetas.Add(carpeta);
                    }
                
                    reader.Close();


            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                conn.Close();
            }
            return carpetas;
        }

        public int ContarCarpetasXAnioMes(int anio,int mes)
        {

            int cantidad=0;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ContarCarpetasXAnioMes " + anio + "," + mes, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                   
                    cantidad = Convert.ToInt32(oReader["cuenta"]);
                  
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
            return cantidad;
        }
    }
}
