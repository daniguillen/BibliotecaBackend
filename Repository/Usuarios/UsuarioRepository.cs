using ApiLibro.Conexiones;
using ApiLibro.Interfaces;
using ApiLibro.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace ApiLibro.Repository.Usuarios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConexionBD _conexionBD;
        public UsuarioRepository(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;
           
        }
        public bool addUser(Usuario usuario)
        {
            bool estado;
           

            try
            {

                _conexionBD.setearQuery("insert	into Users (Name,LastName,Email,UserPassword,IDRol) values(@name, @lastName, @email, @password, @rol)");
                _conexionBD.setearParametro("@name", usuario.name);
                _conexionBD.setearParametro("@lastName", usuario.lastName);
                _conexionBD.setearParametro("@password", usuario.password);
                _conexionBD.setearParametro("@email", usuario.email);
                _conexionBD.setearParametro("@rol", usuario.Rol.Id);
                _conexionBD.ejecutarLectura();
                estado = true;

            }
            catch (Exception ex)
            {
                estado = false;
                throw new Exception("Error al intentar eliminar.", ex);
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return estado;
        }
        public Usuario GetUser(string email, string password)
        {

                Usuario usuario = null;
            try
            {


                _conexionBD.setearQuery("SELECT p.ID, p.Name,p.LastName,p.Email , p.UserPassword,r.id, r.Rol, p.estate FROM Users p inner join  Rol R on r.ID=p.IDRol WHERE Email = @email AND userPassword = @password");
                _conexionBD.setearParametro("@email", email);
                _conexionBD.setearParametro("@password", password);
                _conexionBD.ejecutarLectura();

                if (_conexionBD.Lector.Read())
                {
                    usuario = new Usuario
                    {

                        Id = _conexionBD.Lector.GetInt32(0),
                        name = _conexionBD.Lector.GetString(1),
                        lastName = _conexionBD.Lector.GetString(2),
                        email = _conexionBD.Lector.GetString(3),
                        password = _conexionBD.Lector.GetString(4),
                        
                        Rol = new Rol()
                    };
                    usuario.Rol.Id = _conexionBD.Lector.GetInt32(5);
                    usuario.Rol.Nombre = _conexionBD.Lector.GetString(6);

                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el usuario de la base de datos.", ex);
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return usuario;
        }
        public Usuario GetUserById(int id)
        {

            Usuario usuario = null;
            try
            {


                _conexionBD.setearQuery("SELECT p.ID, p.Name,p.LastName,p.Email , p.UserPassword, r.Id,r.Rol, p.Estate estado FROM Users p inner join  Rol R on r.ID=p.IDRol WHERE p.id=@id");
                _conexionBD.setearParametro("@id", id);
                _conexionBD.ejecutarLectura();

                if (_conexionBD.Lector.Read())
                {
                    usuario = new Usuario()
                    {

                        Id = _conexionBD.Lector.GetInt32(0),
                        name = _conexionBD.Lector.GetString(1),
                        lastName = _conexionBD.Lector.GetString(2),
                        email = _conexionBD.Lector.GetString(3),
                        password = _conexionBD.Lector.GetString(4),
                        estado = _conexionBD.Lector.GetBoolean(7),
                        Rol = new Rol()
                    };
                    usuario.Rol.Id = _conexionBD.Lector.GetInt32(5);
                    usuario.Rol.Nombre  = _conexionBD.Lector.GetString(6);


                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el usuario de la base de datos.", ex);
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return usuario;
        }
        public List<Usuario> GetAllUser() {
            List<Usuario>  allUsuario = new List<Usuario>();
            Usuario usuario = null;
            try
            {


                _conexionBD.setearQuery("SELECT p.ID, p.Name,p.LastName,p.Email , p.UserPassword, r.Id,r.Rol, p.Estate estado FROM Users p inner join  Rol R on r.ID=p.IDRol ");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    usuario = new Usuario()
                    {

                        Id = _conexionBD.Lector.GetInt32(0),
                        name = _conexionBD.Lector.GetString(1),
                        lastName = _conexionBD.Lector.GetString(2),
                        email = _conexionBD.Lector.GetString(3),
                        password = _conexionBD.Lector.GetString(4),
                        estado = _conexionBD.Lector.GetBoolean(7),
                        Rol = new Rol()
                    };
                    usuario.Rol.Id = _conexionBD.Lector.GetInt32(5);
                    usuario.Rol.Nombre = _conexionBD.Lector.GetString(6);


                    allUsuario.Add(usuario);

                }


            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el usuario de la base de datos.", ex);
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return allUsuario;
        }
        public string Eliminar(int id)
        {

            try
            {
              
            _conexionBD.setearQuery("update users set Estate=0 where id= @id");
            _conexionBD.setearParametro("@id", id);
            _conexionBD.ejecutarLectura();
            

            }
            catch (Exception ex)
            {

                throw new Exception("Error al intentar eliminar.", ex);
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return "Eliminado";




        }
        public bool Activar(int id)
        {
            bool estado;
            try
            {

                _conexionBD.setearQuery("update users set Estate=1 where id= @id");
                _conexionBD.setearParametro("@id", id);
                _conexionBD.ejecutarLectura();
                estado = true;

            }
            catch (Exception ex)
            {
                estado = false;

                throw new Exception("Error al intentar eliminar.", ex);
            }
            finally {

                _conexionBD.cerrarConexion();
            }

            return estado;
        }

    }
    }