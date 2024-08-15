using ApiLibro.Interfaces;
using ApiLibro.Models;
using Microsoft.AspNetCore.Components.Web;


namespace ApiLibro.Services
{
    public class UsuarioServices
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario AuthenticateUser(string email, string password)
        {
            return _usuarioRepository.GetUser(email, password);
        }
        public Usuario UserById(int id)
        {
            return _usuarioRepository.GetUserById(id);
        }
        public string Eliminar(int id)
        {
            return _usuarioRepository.Eliminar(id);
        }
        public bool addUser(Usuario usuario)
        {
            return _usuarioRepository.addUser(usuario);
        }
        public List<Usuario> GetAllUser()
        {
            return _usuarioRepository.GetAllUser();
        }

        public bool ActiveUser(int id) {
           return _usuarioRepository.Activar(id);
        }




    }
}
