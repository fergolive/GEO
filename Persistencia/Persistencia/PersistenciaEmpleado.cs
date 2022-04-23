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
    internal class PersistenciaEmpleado:MarshalByRefObject,IPersistenciaEmpleado
    {
        private static PersistenciaEmpleado _miPersistencia=null;
        private PersistenciaEmpleado() { }
        public static PersistenciaEmpleado GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaEmpleado();
            return _miPersistencia;
        }

        public Empleado BuscarEmpleado(String usuario,String contraseña)
        {

            String user;
            String pass;
            String nom;
            String ape;
            String tel;
            int cel;
            int id;
            String tipo = "";
            Empleado empleado=null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarEmpleado " + usuario + "," + contraseña, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    nom = (string)oReader["Nombre"];
                    ape = (string)oReader["Apellido"];
                    tel = (string)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    user = (string)oReader["usename"];
                    pass = (string)oReader["pass"];
                    tipo = (String)oReader["tipo"];
                    
                    

                    empleado = new Empleado(id,user,pass,nom,ape,tel,cel,tipo,true);

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
            return empleado;
        }

        public Empleado BuscarEmpleadoPorId(int id)
        {
            String user;
            String pass;
            String nom;
            String ape;
            String tel;
            int cel;
            int _id;
            String tipo = "";

            Empleado empleado=null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarEmpleadoPorId " + id, oConexion);
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
                    user = (string)oReader["usename"];
                    pass = (string)oReader["pass"];
                    tipo = (String)oReader["tipo"];

                    empleado = new Empleado(_id,user,pass,nom,ape,tel,cel,tipo,true);

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
            return empleado;
        }

        public List<Empleado> BuscarEmpleados(String tipoBuscado)
        {

            String user;
            String pass;
            String nom;
            String ape;
            String tel;
            int cel;
            int id;
            String tipo = "";

            List<Empleado> listaDeEmpleados = new List<Empleado>();
            Empleado empleado = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarEmpleados "+tipoBuscado, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["Apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    user = (String)oReader["usename"];
                    pass = (String)oReader["pass"];
                    tipo = (String)oReader["tipo"];

                    empleado = new Empleado(id, user, pass, nom, ape, tel, cel,tipo, true);

                    listaDeEmpleados.Add(empleado);
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
            return listaDeEmpleados;
        }

        public void AgregarEmpleado(Empleado empleado)
        {
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("agregarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            
            SqlParameter cedula = new SqlParameter("@user", empleado.Username);
            SqlParameter user = new SqlParameter("@pass", empleado.Password);
            SqlParameter pass = new SqlParameter("@nom", empleado.Nombre);
            SqlParameter nombre = new SqlParameter("@ape", empleado.Apellido);
            SqlParameter apellido = new SqlParameter("@tel", empleado.Telefono);
            SqlParameter direccion = new SqlParameter("@cel", empleado.Celular);
            SqlParameter tipo = new SqlParameter("@tipo", empleado.Tipo);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(cedula);
            oComando.Parameters.Add(user);
            oComando.Parameters.Add(pass);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(apellido);
            oComando.Parameters.Add(direccion);
            oComando.Parameters.Add(tipo);

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

        public void EliminarEmpleado(Empleado empleado)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("EliminarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", empleado.Id);

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

        public void ModificarEmpleado(Empleado empleado)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("ModificarEmpleado", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter id = new SqlParameter("@id", empleado.Id);
           
            SqlParameter cedula = new SqlParameter("@user", empleado.Username);
            SqlParameter user = new SqlParameter("@pass", empleado.Password);
            SqlParameter pass = new SqlParameter("@nom", empleado.Nombre);
            SqlParameter nombre = new SqlParameter("@ape", empleado.Apellido);
            SqlParameter apellido = new SqlParameter("@tel", empleado.Telefono);
            SqlParameter direccion = new SqlParameter("@cel", empleado.Celular);
            SqlParameter tipo = new SqlParameter("@tipo", empleado.Tipo);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(id);
            oComando.Parameters.Add(cedula);
            oComando.Parameters.Add(user);
            oComando.Parameters.Add(pass);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(apellido);
            oComando.Parameters.Add(direccion);
            oComando.Parameters.Add(tipo);

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

        public List<Empleado> BuscarEmpleadosPorNombre(String nombre)
        {

            String user;
            String pass;
            String nom;
            String ape;
            String tel;
            int cel;
            int id;
            String tipo = "";

            List<Empleado> listaDeEmpleados = new List<Empleado>();
            Empleado empleado = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarEmpleadosPorNombre " + nombre, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["Apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    user = (String)oReader["usename"];
                    pass = (String)oReader["pass"];
                    tipo = (String)oReader["tipo"];

                    empleado = new Empleado(id, user, pass, nom, ape, tel, cel, tipo, true);

                    listaDeEmpleados.Add(empleado);
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
            return listaDeEmpleados;
        }

        public List<Empleado> BuscarEmpleadosPorApellido(String apellido)
        {

            String user;
            String pass;
            String nom;
            String ape;
            String tel;
            int cel;
            int id;
            String tipo = "";

            List<Empleado> listaDeEmpleados = new List<Empleado>();
            Empleado empleado = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarEmpleadosPorApellido " + apellido, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["Apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                    user = (String)oReader["usename"];
                    pass = (String)oReader["pass"];
                    tipo = (String)oReader["tipo"];

                    empleado = new Empleado(id, user, pass, nom, ape, tel, cel, tipo, true);

                    listaDeEmpleados.Add(empleado);
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
            return listaDeEmpleados;
        }
    }
}
