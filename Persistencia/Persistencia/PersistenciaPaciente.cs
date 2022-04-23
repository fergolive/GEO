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
    internal class PersistenciaPaciente:MarshalByRefObject,IPersistenciaPaciente
    {
        private static PersistenciaPaciente _miPersistencia=null;
        private PersistenciaPaciente() { }
        public static PersistenciaPaciente GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaPaciente();
            return _miPersistencia;
        }

        public List<Paciente> ListarPacientes()
        {

            
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarPacientes", oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }

        public List<Paciente> Buscar20Pacientes()
        {
            
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar20Pacientes", oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }

        public List<Paciente> Buscar60Pacientes()
        {

            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar60Pacientes", oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }

        public Paciente BuscarPacientePorNombre(String nombre1, String apellido1, DateTime fechaDeNac1)
        {
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarPacientePorNombre"+" "+nombre1+","+apellido1+","+fechaDeNac1, oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    
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
            return paciente;
        }

        public Paciente BuscarUltimoPacienteAccess()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\\RecepcionDB.mdb;";
            Paciente nuevoPaciente = null;

            try
            {

                String sql = "select * from Pacientes order by Pacientes.Id_Paciente desc";
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();

                String nombre = "";
                String apellido = "";
                String tel = "";
                int cel = 0;



                if (reader.Read())
                {
                    nombre = reader["Nombre"].ToString();
                    apellido = reader["Apellido"].ToString();
                    tel = (String)reader["Telefono"];
                    cel = Convert.ToInt32(reader["Celular"]);

                    nuevoPaciente = new Paciente(0, DateTime.Now, nombre, apellido, tel, cel, true);
                    nuevoPaciente.Datos = apellido + " " + nombre;
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
            return nuevoPaciente;
        }

        public Paciente BuscarUltimoPacienteSql()
        {
            String user;
            String pass;
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec buscarUltimoPaciente", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["id"]);
                    user = (String)oReader["user"];
                    pass = (String)oReader["pass"];
                    nom = (String)oReader["nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["tel"];
                    cel = Convert.ToInt32(oReader["nombre"]);
                    fn = Convert.ToDateTime(oReader["fechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;

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
            return paciente;
        }

        public Paciente BuscarPacientePorId(int id)
        {
            
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarPacientePorId " + id, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["Apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id,fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;

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
            return paciente;
        }

        public Paciente BuscarPacientePorFactura(String factura)
        {
            String user;
            String pass;
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec buscarPacientePorFactura " + factura, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id=Convert.ToInt32(oReader["id"]);
                    user = (String)oReader["user"];
                    pass = (String)oReader["pass"];
                    nom = (String)oReader["nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["tel"];
                    cel = Convert.ToInt32(oReader["nombre"]);
                    fn = Convert.ToDateTime(oReader["fechaDeNac"]);

                    paciente = new Paciente(id,fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;

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
            return paciente;
        }

        public void AgregarPaciente (Paciente paciente)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

           
            SqlParameter nombre = new SqlParameter("@nom", paciente.Nombre);
            SqlParameter apellido = new SqlParameter("@ape", paciente.Apellido);
            SqlParameter telefono = new SqlParameter("@tel", paciente.Telefono);
            SqlParameter celular = new SqlParameter("@cel", paciente.Celular);
            SqlParameter fechaDeNac = new SqlParameter("@fechaDeNac", paciente.FechaDeNac);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(apellido);
            oComando.Parameters.Add(telefono);
            oComando.Parameters.Add(celular);
            oComando.Parameters.Add(fechaDeNac);
          

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

        public void EliminarPaciente(Paciente paciente)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("eliminarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", paciente.Id);

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
                    throw new Exception("No existe el paciente");
                if (resultado == 2)
                    throw new Exception("No se puede eliminar ya que el Pac. pertenece a una carpeta");
    

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

        public void ModificarPaciente(Paciente paciente)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("modificarPaciente", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", paciente.Id);
            SqlParameter nombre = new SqlParameter("@nom", paciente.Nombre);
            SqlParameter apellido = new SqlParameter("@ape", paciente.Apellido);
            SqlParameter telefono = new SqlParameter("@tel", paciente.Telefono);
            SqlParameter celular = new SqlParameter("@cel", paciente.Celular);
            SqlParameter fechaDeNac = new SqlParameter("@fechaDeNac", paciente.FechaDeNac);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(id);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(apellido);
            oComando.Parameters.Add(telefono);
            oComando.Parameters.Add(celular);
            oComando.Parameters.Add(fechaDeNac);


            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("No existe el paciente");
              

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

        public List<Paciente> BuscarPacientesPorNombre(String nombre)
        {
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarPacientesPorNombre "+nombre, oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }

        public List<Paciente> BuscarPacientesPorApellido(String apellido)
        {
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarPacientesPorApellido "+apellido, oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }

        public List<Paciente> BuscarPacientesPorFecha(DateTime fecha)
        {
            String nom;
            String ape;
            DateTime fn;
            String tel;
            int cel;
            int _id;
            Paciente paciente = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarPacientesPorFecha "+Convert.ToString(fecha), oConexion);
            SqlDataReader oReader;

            List<Paciente> lista = new List<Paciente>();
            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    _id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    fn = Convert.ToDateTime(oReader["FechaDeNac"]);

                    paciente = new Paciente(_id, fn, nom, ape, tel, cel, true);
                    paciente.Datos = ape + " " + nom;
                    lista.Add(paciente);
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
            return lista;
        }


        
    }
}
