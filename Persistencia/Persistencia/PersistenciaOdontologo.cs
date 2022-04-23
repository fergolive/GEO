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
    internal class PersistenciaOdontologo:MarshalByRefObject,IPersistenciaOdontologo
    {
        private static PersistenciaOdontologo _miPersistencia=null;
        private PersistenciaOdontologo() { }
        public static PersistenciaOdontologo GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaOdontologo();
            return _miPersistencia;
        }

       

        public List<String> BuscarDirecciones(int id)
        {
            List<String> ListaDeDirecciones=new List<String>();
            String dir;
            
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarDirecciones "+ id, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                   
                    dir = (string)oReader["Direccion"];
                    ListaDeDirecciones.Add(dir);
 
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
            return ListaDeDirecciones;
        }

        public List<Odontologo> BuscarOdontologos()
        {
            
            String nom;
            String ape;
            String tel;
            int cel;
            
            String hi;
            List<Odontologo> ListaDeOdontologos = new List<Odontologo>();
            String email;
            String ciudad;
            int id;
            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologos" , oConexion);
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
                    ciudad = (String)oReader["Ciudad"];
                    email = (String)oReader["Email"];
                    hi = (String)oReader["Horario"];

                    
                    

                    List<String> direcciones = (List<String>)PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    Odontologo odontologo = new Odontologo(id, direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
                   ListaDeOdontologos.Add(odontologo);
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
            return ListaDeOdontologos;
        }

        public Odontologo BuscarOdontologo(String apellido, String nombre)

        {
            
            String nom;
            String ape;
            String tel;
            int cel;
            
            String hi;
            
            String email;
            String ciudad;
            int id;
            Odontologo odontologo=null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec buscarOdontologo " + apellido + "," + nombre , oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                   
                    id=Convert.ToInt32(oReader["id"]);
                    nom = (String)oReader["nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["tel"];
                    cel = Convert.ToInt32(oReader["nombre"]);

                    
                    hi = (String)oReader["horario"];
                    
                    email = (String)oReader["email"];
                    ciudad=(String)oReader["ciudad"];



                    List<String> direcciones = PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    odontologo = new Odontologo(id,direcciones,hi,email,ciudad,nom,ape,tel,cel,true);

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
            return odontologo;
        }

        public Odontologo BuscarOdontologoPorId(int id)
        {

            String nom;
            String ape;
            String tel;
            int cel;
            
            String hi;
            
            String email;
            String ciudad;
            int _id;
            Odontologo odontologo=null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologoPorId " + id, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    _id=Convert.ToInt32(oReader["Id"]);
                    nom = (String)oReader["Nombre"];
                    ape = (String)oReader["Apellido"];
                    tel = (String)oReader["Telefono"];
                    cel = Convert.ToInt32(oReader["Celular"]);
                   
                    hi = (String)oReader["horario"];
                    
                    email = (String)oReader["Email"];
                    ciudad=(String)oReader["Ciudad"];



                    List<String> direcciones = PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    odontologo = new Odontologo(_id,direcciones,hi,email,ciudad,nom,ape,tel,cel,true);
                    odontologo.Datos = ape + " " + nom;
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
            return odontologo;
        }

        public Odontologo BuscarOdontologoPorFactura(String factura)
        {
            
            String nom;
            String ape;
            String tel;
            int cel;
            
            String hi;
           
            String email;
            String ciudad;
            int id;
            Odontologo odontologo = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec buscarOdontologoPorFactura " + factura, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {
                    id = Convert.ToInt32(oReader["id"]);
                    nom = (String)oReader["nombre"];
                    ape = (String)oReader["apellido"];
                    tel = (String)oReader["tel"];
                    cel = Convert.ToInt32(oReader["nombre"]);

                    
                    hi = (String)oReader["horario"];
                   
                    email = (String)oReader["email"];
                    ciudad = (String)oReader["ciudad"];



                    List<String> direcciones = PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    odontologo = new Odontologo(id,direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
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
            return odontologo;
        }

        public void AgregarOdontologo(Odontologo odontologo)
            {

                SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
                SqlCommand oComando = new SqlCommand("AgregarOdontologo", oConexion);
                oComando.CommandType = CommandType.StoredProcedure;

                
                SqlParameter nom = new SqlParameter("@nom", odontologo.Nombre);
                SqlParameter ape = new SqlParameter("@ape", odontologo.Apellido);
                SqlParameter tel = new SqlParameter("@tel", odontologo.Telefono);
                SqlParameter cel = new SqlParameter("@cel", odontologo.Celular);
                
                SqlParameter hor = new SqlParameter("@hor", odontologo.Horario);
                SqlParameter email = new SqlParameter("@email", odontologo.Email);
                SqlParameter ciudad = new SqlParameter("@ciudad", odontologo.Ciudad);


                SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                retorno.Direction = ParameterDirection.ReturnValue;

                int resultado = -1;

                oComando.Parameters.Add(nom);
                oComando.Parameters.Add(ape);
                oComando.Parameters.Add(tel);
                oComando.Parameters.Add(cel);
                
                oComando.Parameters.Add(hor);
                oComando.Parameters.Add(email);
                oComando.Parameters.Add(ciudad);

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

        public void AgregarDireccion(Odontologo odontologo,String direccion)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarDireccion", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter nom = new SqlParameter("@nom", odontologo.Nombre);
            SqlParameter ape = new SqlParameter("@ape", odontologo.Apellido);
            SqlParameter ciu = new SqlParameter("@ciu", odontologo.Ciudad);
            SqlParameter dir = new SqlParameter("@dir", direccion);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(nom);
            oComando.Parameters.Add(ape);
            oComando.Parameters.Add(ciu);
            oComando.Parameters.Add(dir);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 1)
                    throw new Exception("Ya existe la direccion");
               

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

        public void AgregarDireccionAccess(Odontologo odontologo, String direccion)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("AgregarDireccionAccess", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter nom = new SqlParameter("@nom", odontologo.Nombre);
            SqlParameter ape = new SqlParameter("@ape", odontologo.Apellido);
            SqlParameter ciu = new SqlParameter("@ciu", odontologo.Ciudad);
            SqlParameter dir = new SqlParameter("@dir", direccion);


            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(nom);
            oComando.Parameters.Add(ape);
            oComando.Parameters.Add(ciu);
            oComando.Parameters.Add(dir);
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

            public void EliminarOdontologo(Odontologo odontologo)
            {

                SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
                SqlCommand oComando = new SqlCommand("eliminarOdontologo", oConexion);
                oComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = new SqlParameter("@id", odontologo.Id);

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

                    if (resultado == 2)
                        throw new Exception("No se puede eliminar el odontologo ya que esta asociado a una carpeta");
                    if (resultado == 3)
                        throw new Exception("No existe el odontologo");
                   
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

            public void ModificarOdontologo(Odontologo odontologo)
            {

                SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
                SqlCommand oComando = new SqlCommand("modificarOdontologo", oConexion);
                oComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = new SqlParameter("@id", odontologo.Id);
                SqlParameter nom = new SqlParameter("@nom", odontologo.Nombre);
                SqlParameter ape = new SqlParameter("@ape", odontologo.Apellido);
                SqlParameter tel = new SqlParameter("@tel", odontologo.Telefono);
                SqlParameter cel = new SqlParameter("@cel", odontologo.Celular);
                
                SqlParameter hor= new SqlParameter("@hor", odontologo.Horario);
               
                SqlParameter email = new SqlParameter("@email", odontologo.Email);
                SqlParameter ciudad = new SqlParameter("@ciudad", odontologo.Ciudad);


                SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
                retorno.Direction = ParameterDirection.ReturnValue;

                int resultado = -1;
                oComando.Parameters.Add(id);
                oComando.Parameters.Add(nom);
                oComando.Parameters.Add(ape);
                oComando.Parameters.Add(tel);
                oComando.Parameters.Add(cel);
                oComando.Parameters.Add(hor);
                oComando.Parameters.Add(email);
                oComando.Parameters.Add(ciudad);
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

        public List<Odontologo> BuscarOdontologosAccess(String ruta)
        {
            //D:\\RecepcionDB.mdb;
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+ruta;
            
            List<Odontologo> listaDeOdontologosAccess = new List<Odontologo>();
            List<String> listaDeNumeros = new List<String>();

            try
            {

                String sql = "select * from Docs";
                OleDbCommand command = new OleDbCommand(sql, conn);
                conn.Open();
                OleDbDataReader reader = command.ExecuteReader();


                String nombre = "";
                String direccion = "";
                String email = "";
                String ciudad = "";
                String departamento = "";
                String telefono = "";



                while (reader.Read())
                {
                    nombre = reader["Nombre_Doc"].ToString();
                    direccion = reader["Direccion_Doc"].ToString();
                    telefono = reader["Telefono_Doc"].ToString();
                    email = reader["EMail_Doc"].ToString();
                    ciudad = reader["Ciudad"].ToString();
                    departamento = reader["Departamento"].ToString();

                    Odontologo nuevoOdontologo = new Odontologo();

                    if (nombre == "")
                    {

                        nuevoOdontologo.Id = 1;
                    }
                    else
                    {
                        String nombre2 = "";
                        String apellido2 = "";
                        String apellido = nombre;
                        String coma = ",";
                        for (int i = 0; i < nombre.Length; i++)
                        {
                            if (coma.Equals(nombre[i].ToString()))
                            {

                                nombre2 = nombre.Remove(0, i + 1); //borro (apellido, nombr)
                                nombre2.Trim();

                                apellido2 = apellido.Remove(i);
                                apellido2.Trim();

                                i = nombre.Length;
                            }
                        }
                        nuevoOdontologo.Nombre = nombre2;
                        nuevoOdontologo.Apellido = apellido2;
                        nuevoOdontologo.Ciudad = ciudad + ", " + departamento;
                        nuevoOdontologo.Email = email;
                        nuevoOdontologo.Direcciones.Add(direccion);

                        if (nuevoOdontologo.Id != 1)
                        {
                            listaDeOdontologosAccess.Add(nuevoOdontologo);
                        }
                    }
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
            return listaDeOdontologosAccess;
        }

        public List<Odontologo> BuscarOdontologosPorNombre(String nombre)
        {

            String nom;
            String ape;
            String tel;
            int cel;

            String hi;
            List<Odontologo> ListaDeOdontologos = new List<Odontologo>();
            String email;
            String ciudad;
            int id;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologosPorNombre "+ nombre , oConexion);
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
                    ciudad = (String)oReader["Ciudad"];
                    email = (String)oReader["Email"];
                    hi = (String)oReader["Horario"];




                    List<String> direcciones = (List<String>)PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    Odontologo odontologo = new Odontologo(id, direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
                    ListaDeOdontologos.Add(odontologo);
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
            return ListaDeOdontologos;
        }

        public List<Odontologo> BuscarOdontologosPorApellido(String apellido)
        {

            String nom;
            String ape;
            String tel;
            int cel;

            String hi;
            List<Odontologo> ListaDeOdontologos = new List<Odontologo>();
            String email;
            String ciudad;
            int id;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologosPorApellido " + apellido, oConexion);
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
                    ciudad = (String)oReader["Ciudad"];
                    email = (String)oReader["Email"];
                    hi = (String)oReader["Horario"];




                    List<String> direcciones = (List<String>)PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    Odontologo odontologo = new Odontologo(id, direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
                    ListaDeOdontologos.Add(odontologo);
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
            return ListaDeOdontologos;
        }

        public List<Odontologo> BuscarOdontologosPorTelefono(int telefono)
        {

            String nom;
            String ape;
            String tel;
            int cel;

            String hi;
            List<Odontologo> ListaDeOdontologos = new List<Odontologo>();
            String email;
            String ciudad;
            int id;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologosPorTelefono " + Convert.ToString(telefono), oConexion);
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
                    ciudad = (String)oReader["Ciudad"];
                    email = (String)oReader["Email"];
                    hi = (String)oReader["Horario"];




                    List<String> direcciones = (List<String>)PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    Odontologo odontologo = new Odontologo(id, direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
                    ListaDeOdontologos.Add(odontologo);
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
            return ListaDeOdontologos;
        }

        public List<Odontologo> BuscarOdontologosPorCelular(int celular)
        {

            String nom;
            String ape;
            String tel;
            int cel;

            String hi;
            List<Odontologo> ListaDeOdontologos = new List<Odontologo>();
            String email;
            String ciudad;
            int id;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec BuscarOdontologosPorCelular " + celular, oConexion);
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
                    ciudad = (String)oReader["Ciudad"];
                    email = (String)oReader["Email"];
                    hi = (String)oReader["Horario"];




                    List<String> direcciones = (List<String>)PersistenciaOdontologo.GetPersistencia().BuscarDirecciones(id);
                    Odontologo odontologo = new Odontologo(id, direcciones, hi, email, ciudad, nom, ape, tel, cel, true);
                    odontologo.Datos = ape + " " + nom;
                    ListaDeOdontologos.Add(odontologo);
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
            return ListaDeOdontologos;
        }
    }
}
