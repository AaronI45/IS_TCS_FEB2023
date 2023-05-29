using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosLinqEscolar.Modelo
{
    public static class UsuarioDAO
    {
        public static List<Usuario> obtenerUsuarios()
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();

            IQueryable<Usuario> usuariosBD = from usuarioQuery in conexionBD.Usuario
                                          select usuarioQuery;
            return usuariosBD.ToList();
        }

        //TODO
        public static Mensaje iniciarSesion(string username, string password)
        {
            DataClassesEscolarUVDataContext conexionBD = getConnection();
            Mensaje respuesta = new Mensaje();
            respuesta.Error = true;
            try
            {
                var resultadoLogin = conexionBD.Usuario.FirstOrDefault(u => u.username.Equals(username)
                                        && u.password.Equals(password));
                respuesta.UsuarioEncontrado = resultadoLogin;
                if (resultadoLogin != null) 
                {
                    respuesta.Respuesta = "Credenciales correctas, bienvenido al sistema";
                    respuesta.UsuarioEncontrado = resultadoLogin;
                    respuesta.Error = false;
                }
                else
                {
                    respuesta.Respuesta = "No se encontraron usuarios con las credenciales proporcionadas";
                }
            }
            catch(Exception e)
            {
                respuesta.Respuesta = "Error de conexión";
                throw new Exception("Error al obtener usuario");
            }
            return respuesta;
        }

        public static Boolean guardarUsuario(Usuario usuarioNuevo)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();

                var usuario = new Usuario()
                {
                    nombre = usuarioNuevo.nombre,
                    apellidoPaterno = usuarioNuevo.apellidoPaterno,
                    apellidoMaterno = usuarioNuevo.apellidoMaterno,
                    username = usuarioNuevo.username,
                    password = usuarioNuevo.password
                };
                conexionBD.Usuario.InsertOnSubmit(usuario);
                conexionBD.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean EditarUsuario(Usuario UsuarioEdicion)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();

                var usuario = (from usuarioEdicion in conexionBD.Usuario
                               where usuarioEdicion.idUsuario == UsuarioEdicion.idUsuario
                               select usuarioEdicion).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.nombre = UsuarioEdicion.nombre;
                    usuario.apellidoPaterno = UsuarioEdicion.apellidoPaterno;
                    usuario.apellidoMaterno = UsuarioEdicion.apellidoMaterno;
                    usuario.password = UsuarioEdicion.password;
                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public static Boolean EliminarUsuario(int idUsuario)
        {
            try
            {
                DataClassesEscolarUVDataContext conexionBD = getConnection();
                Usuario usuarioEliminar = conexionBD.Usuario.FirstOrDefault
                    (u => u.idUsuario == idUsuario);
                if (usuarioEliminar != null)
                {
                    conexionBD.Usuario.DeleteOnSubmit(usuarioEliminar);
                    conexionBD.SubmitChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static DataClassesEscolarUVDataContext getConnection()
        {
            return new DataClassesEscolarUVDataContext(global::System.Configuration.
                ConfigurationManager.ConnectionStrings["ConexionBDEscolarUV"].ConnectionString);

            ;

        }
    }
}